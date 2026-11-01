using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaoOc.Data;

namespace QuanLyCaoOc.Services
{
    // Kiểm tra tình trạng phòng mỗi năm một lần; tự ý thay đổi kết cấu thì lập phiếu phạt
    public class KiemTraService
    {
        public const decimal TienPhatKetCau = 10000000m;

        // Phòng đang thuê chưa được kiểm tra trong 365 ngày gần nhất
        public DataTable LayPhongDenHan()
        {
            return Db.Query(@"SELECT c.MaPhong, h.SoHD, k.TenKH,
                                     (SELECT MAX(pk.NgayKiemTra) FROM ChiTietKiemTra ct JOIN PhieuKiemTra pk ON pk.SoPhieu=ct.SoPhieu WHERE ct.MaPhong=c.MaPhong) AS LanKiemTraCuoi
                              FROM ChiTietHopDong c JOIN HopDongThue h ON h.SoHD=c.SoHD JOIN KhachHang k ON k.MaKH=h.MaKH
                              WHERE h.TrangThai=N'Hiệu lực'
                                AND NOT EXISTS (SELECT 1 FROM ChiTietKiemTra ct JOIN PhieuKiemTra pk ON pk.SoPhieu=ct.SoPhieu
                                                WHERE ct.MaPhong=c.MaPhong AND pk.NgayKiemTra > DATEADD(YEAR, -1, @N))
                              ORDER BY c.MaPhong", new SqlParameter("@N", DateTime.Today));
        }

        public DataTable LayPhieuKiemTra()
        {
            return Db.Query(@"SELECT p.SoPhieu, p.NgayKiemTra, p.NguoiKiemTra, COUNT(c.MaPhong) AS SoPhong, p.GhiChu
                              FROM PhieuKiemTra p LEFT JOIN ChiTietKiemTra c ON c.SoPhieu=p.SoPhieu
                              GROUP BY p.SoPhieu, p.NgayKiemTra, p.NguoiKiemTra, p.GhiChu ORDER BY p.NgayKiemTra DESC, p.SoPhieu");
        }

        public DataTable LayChiTiet(string soPhieu)
        {
            return Db.Query(@"SELECT MaPhong, TinhTrang, ThayDoiKetCau, GhiChu, KeHoachTuSua FROM ChiTietKiemTra WHERE SoPhieu=@S ORDER BY MaPhong",
                new SqlParameter("@S", soPhieu ?? ""));
        }

        public KetQuaXuLy LapPhieuKiemTra(string nguoiKiemTra, string ghiChu, List<DongKiemTra> dsDong)
        {
            if (string.IsNullOrWhiteSpace(nguoiKiemTra)) return KetQuaXuLy.Loi("Hãy nhập người kiểm tra.");
            if (dsDong == null || dsDong.Count == 0) return KetQuaXuLy.Loi("Hãy chọn ít nhất một phòng kiểm tra.");
            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    HashSet<string> da = new HashSet<string>();
                    Dictionary<string, string> hdCuaPhong = new Dictionary<string, string>();
                    foreach (DongKiemTra d in dsDong)
                    {
                        if (!da.Add(d.MaPhong)) { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + " bị chọn hai lần."); }
                        if (d.TinhTrang != "Tốt" && string.IsNullOrWhiteSpace(d.KeHoachTuSua))
                        { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + " " + d.TinhTrang.ToLower() + ": hãy nhập kế hoạch tự sửa chữa."); }
                        object h = Db.ScalarTx(cn, tx, @"SELECT TOP 1 h.SoHD FROM ChiTietHopDong c JOIN HopDongThue h ON h.SoHD=c.SoHD
                                                         WHERE c.MaPhong=@P AND h.TrangThai=N'Hiệu lực'", new SqlParameter("@P", d.MaPhong));
                        if (h == null) { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + " không có hợp đồng hiệu lực."); }
                        hdCuaPhong[d.MaPhong] = Convert.ToString(h);
                        if (Convert.ToInt32(Db.ScalarTx(cn, tx, @"SELECT COUNT(*) FROM ChiTietKiemTra ct JOIN PhieuKiemTra pk ON pk.SoPhieu=ct.SoPhieu
                                WHERE ct.MaPhong=@P AND pk.NgayKiemTra > DATEADD(YEAR, -1, @N)",
                                new SqlParameter("@P", d.MaPhong), new SqlParameter("@N", DateTime.Today))) > 0)
                        { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + " đã được kiểm tra trong vòng 1 năm."); }
                    }
                    string tienTo = "KT" + DateTime.Today.Year + "-";
                    int stt = Convert.ToInt32(Db.ScalarTx(cn, tx, "SELECT COUNT(*) FROM PhieuKiemTra WHERE SoPhieu LIKE @P", new SqlParameter("@P", tienTo + "%"))) + 1;
                    string so = tienTo + stt.ToString("000");
                    Db.ExecuteTx(cn, tx, "INSERT INTO PhieuKiemTra(SoPhieu, NgayKiemTra, NguoiKiemTra, GhiChu) VALUES(@S, @N, @NK, @G)",
                        new SqlParameter("@S", so), new SqlParameter("@N", DateTime.Today), new SqlParameter("@NK", nguoiKiemTra.Trim()), new SqlParameter("@G", Db.NullIfEmpty(ghiChu)));
                    int phat = 0;
                    foreach (DongKiemTra d in dsDong)
                    {
                        Db.ExecuteTx(cn, tx, @"INSERT INTO ChiTietKiemTra(SoPhieu, MaPhong, TinhTrang, ThayDoiKetCau, GhiChu, KeHoachTuSua)
                                               VALUES(@S, @P, @TT, @KC, @G, @KH)",
                            new SqlParameter("@S", so), new SqlParameter("@P", d.MaPhong), new SqlParameter("@TT", d.TinhTrang),
                            new SqlParameter("@KC", d.ThayDoiKetCau), new SqlParameter("@G", Db.NullIfEmpty(d.GhiChu)), new SqlParameter("@KH", Db.NullIfEmpty(d.KeHoachTuSua)));
                        if (d.ThayDoiKetCau)
                        {
                            phat++;
                            Db.ExecuteTx(cn, tx, @"INSERT INTO PhieuPhat(SoPhat, SoPhieuKT, MaPhong, SoHD, NgayLap, LyDo, SoTien, TrangThai)
                                                   VALUES(@SP, @S, @P, @H, @N, N'Tự ý thay đổi kết cấu phòng', @T, N'Chưa nộp')",
                                new SqlParameter("@SP", "PH" + so.Substring(2) + "-" + phat.ToString("00")), new SqlParameter("@S", so),
                                new SqlParameter("@P", d.MaPhong), new SqlParameter("@H", hdCuaPhong[d.MaPhong]),
                                new SqlParameter("@N", DateTime.Today), new SqlParameter("@T", TienPhatKetCau));
                        }
                    }
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập phiếu kiểm tra " + so + " cho " + dsDong.Count + " phòng" + (phat > 0 ? ", lập " + phat + " phiếu phạt " + TienPhatKetCau.ToString("N0") + " đ/phiếu." : "."));
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể lập phiếu kiểm tra: " + ex.Message);
                }
            }
        }

        public DataTable LayPhieuPhat()
        {
            return Db.Query(@"SELECT SoPhat, SoPhieuKT, MaPhong, SoHD, NgayLap, LyDo, SoTien, NgayNop, TrangThai FROM PhieuPhat ORDER BY NgayLap DESC, SoPhat");
        }

        public KetQuaXuLy ThuPhat(string soPhat)
        {
            if (string.IsNullOrWhiteSpace(soPhat)) return KetQuaXuLy.Loi("Chưa chọn phiếu phạt.");
            int n = Db.Execute("UPDATE PhieuPhat SET TrangThai=N'Đã nộp', NgayNop=@N WHERE SoPhat=@S AND TrangThai=N'Chưa nộp'",
                new SqlParameter("@N", DateTime.Today), new SqlParameter("@S", soPhat));
            return n == 0 ? KetQuaXuLy.Loi("Phiếu phạt không tồn tại hoặc đã nộp.") : KetQuaXuLy.Ok("Đã thu tiền phạt " + soPhat + ".");
        }
    }
}
