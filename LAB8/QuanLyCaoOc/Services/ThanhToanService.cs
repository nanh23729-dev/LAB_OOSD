using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaoOc.Data;

namespace QuanLyCaoOc.Services
{
    // Thu tiền thuê theo kỳ, lập hóa đơn dịch vụ cuối tháng, thu hóa đơn, công nợ
    public class ThanhToanService
    {
        public DataTable LayKyChuaThu(string soHD)
        {
            return Db.Query(@"SELECT MaKy, TuThang, DenThang, NgayDenHan, SoTien, TrangThai FROM KyThanhToan
                              WHERE SoHD=@H AND TrangThai=N'Chưa thu' ORDER BY TuThang, MaKy", new SqlParameter("@H", soHD ?? ""));
        }

        // Thu kỳ: phải thu đúng thứ tự (kỳ trước đã thu mới thu kỳ sau)
        public KetQuaXuLy ThuKy(string maKy, string nguoiThu)
        {
            if (string.IsNullOrWhiteSpace(maKy)) return KetQuaXuLy.Loi("Chưa chọn kỳ thanh toán.");
            if (string.IsNullOrWhiteSpace(nguoiThu)) return KetQuaXuLy.Loi("Hãy nhập người thu tiền.");
            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    DataTable ky = Db.QueryTx(cn, tx, "SELECT SoHD, TuThang, SoTien, TrangThai FROM KyThanhToan WITH (UPDLOCK) WHERE MaKy=@K", new SqlParameter("@K", maKy));
                    if (ky.Rows.Count == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy kỳ thanh toán."); }
                    if (Convert.ToString(ky.Rows[0]["TrangThai"]) == "Đã thu") { tx.Rollback(); return KetQuaXuLy.Loi("Kỳ này đã được thu."); }
                    string soHD = Convert.ToString(ky.Rows[0]["SoHD"]);
                    int tu = Convert.ToInt32(ky.Rows[0]["TuThang"]);
                    int truoc = Convert.ToInt32(Db.ScalarTx(cn, tx, "SELECT COUNT(*) FROM KyThanhToan WHERE SoHD=@H AND TuThang<@T AND TrangThai=N'Chưa thu'",
                        new SqlParameter("@H", soHD), new SqlParameter("@T", tu)));
                    if (truoc > 0) { tx.Rollback(); return KetQuaXuLy.Loi("Còn " + truoc + " kỳ trước chưa thu, hãy thu theo thứ tự tháng."); }

                    Db.ExecuteTx(cn, tx, "UPDATE KyThanhToan SET TrangThai=N'Đã thu', NgayThu=@N, NguoiThu=@NT WHERE MaKy=@K",
                        new SqlParameter("@N", DateTime.Today), new SqlParameter("@NT", nguoiThu.Trim()), new SqlParameter("@K", maKy));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã thu " + Convert.ToDecimal(ky.Rows[0]["SoTien"]).ToString("N0") + " đ (" + maKy + ").");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể thu tiền: " + ex.Message);
                }
            }
        }

        public DataTable LayHoaDonDichVu(string soHD)
        {
            return Db.Query(@"SELECT SoHDDV, Thang, Nam, NgayLap, NgayDenHan, TongTien, NgayThanhToan, TrangThai
                              FROM HoaDonDichVu WHERE SoHD=@H ORDER BY Nam DESC, Thang DESC", new SqlParameter("@H", soHD ?? ""));
        }

        public DataTable LayChiTietHoaDon(string soHDDV)
        {
            return Db.Query(@"SELECT c.MaDV, d.TenDV, d.DonViTinh, c.SoLuong, c.DonGia, c.ThanhTien
                              FROM ChiTietHoaDon c JOIN LoaiDichVu d ON d.MaDV = c.MaDV WHERE c.SoHDDV=@H ORDER BY c.MaDV",
                new SqlParameter("@H", soHDDV ?? ""));
        }

        // Hóa đơn dịch vụ lập vào cuối tháng, hạn thanh toán cuối tháng đó
        public KetQuaXuLy LapHoaDonDichVu(string soHD, int thang, int nam, List<DongDichVu> dsDong)
        {
            if (string.IsNullOrWhiteSpace(soHD)) return KetQuaXuLy.Loi("Chưa chọn hợp đồng.");
            if (thang < 1 || thang > 12) return KetQuaXuLy.Loi("Tháng phải từ 1 đến 12.");
            if (dsDong == null || dsDong.Count == 0) return KetQuaXuLy.Loi("Hãy nhập ít nhất một dịch vụ.");
            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    DataTable hd = Db.QueryTx(cn, tx, "SELECT NgayBatDau, NgayKetThuc, TrangThai FROM HopDongThue WHERE SoHD=@H", new SqlParameter("@H", soHD));
                    if (hd.Rows.Count == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy hợp đồng."); }
                    if (Convert.ToString(hd.Rows[0]["TrangThai"]) != "Hiệu lực") { tx.Rollback(); return KetQuaXuLy.Loi("Hợp đồng đã thanh lý."); }
                    DateTime cuoi = ThoiGian.CuoiThang(nam, thang);
                    DateTime bd = Convert.ToDateTime(hd.Rows[0]["NgayBatDau"]);
                    DateTime kt = Convert.ToDateTime(hd.Rows[0]["NgayKetThuc"]);
                    if (cuoi < bd.Date || new DateTime(nam, thang, 1) > kt.Date)
                    { tx.Rollback(); return KetQuaXuLy.Loi("Tháng " + thang + "/" + nam + " nằm ngoài thời gian thuê của hợp đồng."); }
                    if (Convert.ToInt32(Db.ScalarTx(cn, tx, "SELECT COUNT(*) FROM HoaDonDichVu WHERE SoHD=@H AND Thang=@T AND Nam=@N",
                        new SqlParameter("@H", soHD), new SqlParameter("@T", thang), new SqlParameter("@N", nam))) > 0)
                    { tx.Rollback(); return KetQuaXuLy.Loi("Hợp đồng đã có hóa đơn dịch vụ tháng " + thang + "/" + nam + "."); }

                    HashSet<string> da = new HashSet<string>();
                    decimal tong = 0;
                    List<object[]> dong = new List<object[]>();
                    foreach (DongDichVu d in dsDong)
                    {
                        if (!da.Add(d.MaDV)) { tx.Rollback(); return KetQuaXuLy.Loi("Dịch vụ " + d.MaDV + " bị nhập hai lần."); }
                        if (d.SoLuong <= 0) { tx.Rollback(); return KetQuaXuLy.Loi("Số lượng dịch vụ " + d.MaDV + " phải lớn hơn 0."); }
                        object g = Db.ScalarTx(cn, tx, "SELECT DonGia FROM LoaiDichVu WHERE MaDV=@D", new SqlParameter("@D", d.MaDV));
                        if (g == null) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy dịch vụ " + d.MaDV + "."); }
                        decimal gia = Convert.ToDecimal(g);
                        decimal tt = Math.Round(gia * d.SoLuong, 0);
                        tong += tt;
                        dong.Add(new object[] { d.MaDV, d.SoLuong, gia, tt });
                    }
                    string tienTo = "DV-" + nam + "-" + thang.ToString("00") + "-";
                    int stt = Convert.ToInt32(Db.ScalarTx(cn, tx, "SELECT COUNT(*) FROM HoaDonDichVu WHERE SoHDDV LIKE @P", new SqlParameter("@P", tienTo + "%"))) + 1;
                    string so = tienTo + stt.ToString("000");
                    Db.ExecuteTx(cn, tx, @"INSERT INTO HoaDonDichVu(SoHDDV, SoHD, Thang, Nam, NgayLap, NgayDenHan, TongTien, TrangThai)
                                           VALUES(@S, @H, @T, @N, @NL, @DH, @TT, N'Chưa thanh toán')",
                        new SqlParameter("@S", so), new SqlParameter("@H", soHD), new SqlParameter("@T", thang), new SqlParameter("@N", nam),
                        new SqlParameter("@NL", cuoi), new SqlParameter("@DH", cuoi), new SqlParameter("@TT", tong));
                    foreach (object[] r in dong)
                        Db.ExecuteTx(cn, tx, "INSERT INTO ChiTietHoaDon(SoHDDV, MaDV, SoLuong, DonGia, ThanhTien) VALUES(@S, @D, @SL, @G, @TT)",
                            new SqlParameter("@S", so), new SqlParameter("@D", r[0]), new SqlParameter("@SL", r[1]), new SqlParameter("@G", r[2]), new SqlParameter("@TT", r[3]));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập hóa đơn dịch vụ " + so + ", tổng " + tong.ToString("N0") + " đ, hạn thanh toán " + cuoi.ToString("dd/MM/yyyy") + ".");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể lập hóa đơn: " + ex.Message);
                }
            }
        }

        public KetQuaXuLy ThuHoaDon(string soHDDV)
        {
            if (string.IsNullOrWhiteSpace(soHDDV)) return KetQuaXuLy.Loi("Chưa chọn hóa đơn.");
            object tt = Db.Scalar("SELECT TrangThai FROM HoaDonDichVu WHERE SoHDDV=@S", new SqlParameter("@S", soHDDV));
            if (tt == null) return KetQuaXuLy.Loi("Không tìm thấy hóa đơn.");
            if (Convert.ToString(tt) == "Đã thanh toán") return KetQuaXuLy.Loi("Hóa đơn đã thanh toán.");
            Db.Execute("UPDATE HoaDonDichVu SET TrangThai=N'Đã thanh toán', NgayThanhToan=@N WHERE SoHDDV=@S",
                new SqlParameter("@N", DateTime.Today), new SqlParameter("@S", soHDDV));
            return KetQuaXuLy.Ok("Đã thu hóa đơn " + soHDDV + ".");
        }

        // Danh sách công nợ toàn bộ hợp đồng còn hiệu lực
        public DataTable LayCongNo()
        {
            return Db.Query(@"SELECT h.SoHD, k.TenKH,
                    (SELECT COUNT(*) FROM KyThanhToan y WHERE y.SoHD=h.SoHD AND y.TrangThai=N'Chưa thu' AND y.NgayDenHan<=@N) AS SoKyNo,
                    (SELECT ISNULL(SUM(y.SoTien),0) FROM KyThanhToan y WHERE y.SoHD=h.SoHD AND y.TrangThai=N'Chưa thu' AND y.NgayDenHan<=@N) AS TienThueNo,
                    (SELECT COUNT(*) FROM HoaDonDichVu v WHERE v.SoHD=h.SoHD AND v.TrangThai=N'Chưa thanh toán') AS SoHoaDonNo,
                    (SELECT ISNULL(SUM(v.TongTien),0) FROM HoaDonDichVu v WHERE v.SoHD=h.SoHD AND v.TrangThai=N'Chưa thanh toán') AS DichVuNo
                  FROM HopDongThue h JOIN KhachHang k ON k.MaKH=h.MaKH
                  WHERE h.TrangThai=N'Hiệu lực' ORDER BY h.SoHD", new SqlParameter("@N", DateTime.Today));
        }
    }
}
