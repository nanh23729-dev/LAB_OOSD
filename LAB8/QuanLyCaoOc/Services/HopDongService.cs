using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaoOc.Data;

namespace QuanLyCaoOc.Services
{
    // Hợp đồng thuê: lập hợp đồng, lịch thanh toán, công nợ, thanh lý, phiếu gia hạn
    public class HopDongService
    {
        public const int SoThangToiThieu = 6;     // thời gian thuê ít nhất 6 tháng
        public const int SoThangTraTruoc = 6;     // trả trước 6 tháng đầu

        // ===================== TRUY VẤN =====================
        public DataTable LayKhachHang()
        {
            return Db.Query("SELECT MaKH, MaKH + N' - ' + TenKH AS HienThi FROM KhachHang ORDER BY MaKH");
        }

        public DataTable LayPhongTrong()
        {
            return Db.Query(@"SELECT p.MaPhong, t.SoTang, p.DienTich, p.Huong, p.GiaThue
                              FROM Phong p JOIN Tang t ON t.MaTang = p.MaTang
                              WHERE p.TrangThai = N'Trống' ORDER BY t.SoTang, p.MaPhong");
        }

        public DataTable LayHopDongHieuLuc()
        {
            return Db.Query(@"SELECT h.SoHD, h.SoHD + N' - ' + k.TenKH AS HienThi
                              FROM HopDongThue h JOIN KhachHang k ON k.MaKH = h.MaKH
                              WHERE h.TrangThai = N'Hiệu lực' ORDER BY h.SoHD");
        }

        public DataTable LayDanhSachHopDong()
        {
            return Db.Query(@"SELECT h.SoHD, k.TenKH, h.NgayKy, h.NgayBatDau, h.SoThang, h.NgayKetThuc, h.TrangThai,
                                     (SELECT ISNULL(SUM(c.GiaThue), 0) FROM ChiTietHopDong c WHERE c.SoHD = h.SoHD) AS TienThueThang
                              FROM HopDongThue h JOIN KhachHang k ON k.MaKH = h.MaKH
                              ORDER BY h.NgayKy DESC, h.SoHD");
        }

        public DataTable LayChiTiet(string soHD)
        {
            return Db.Query(@"SELECT c.MaPhong, t.SoTang, p.DienTich, p.Huong, c.GiaThue, c.NgayKetThuc
                              FROM ChiTietHopDong c JOIN Phong p ON p.MaPhong = c.MaPhong JOIN Tang t ON t.MaTang = p.MaTang
                              WHERE c.SoHD = @H ORDER BY c.MaPhong", new SqlParameter("@H", soHD ?? ""));
        }

        public DataTable LayLichThanhToan(string soHD)
        {
            return Db.Query(@"SELECT MaKy, TuThang, DenThang, NgayDenHan, SoTien, TrangThai, NgayThu, NguoiThu, GhiChu
                              FROM KyThanhToan WHERE SoHD = @H ORDER BY TuThang, MaKy", new SqlParameter("@H", soHD ?? ""));
        }

        public DataTable LayPhieuGiaHan(string soHD)
        {
            return Db.Query(@"SELECT p.SoPhieu, p.NgayLap, c.MaPhong, c.SoThangGiaHan, c.NgayKetThucCu, c.NgayKetThucMoi, p.NguoiLap
                              FROM PhieuGiaHan p JOIN ChiTietGiaHan c ON c.SoPhieu = p.SoPhieu
                              WHERE p.SoHD = @H ORDER BY p.NgayLap DESC, p.SoPhieu, c.MaPhong", new SqlParameter("@H", soHD ?? ""));
        }

        // Công nợ: kỳ thu tiền thuê đã đến hạn mà chưa thu + hóa đơn dịch vụ chưa thanh toán
        public CongNoHopDong TinhCongNo(string soHD)
        {
            using (SqlConnection cn = Db.OpenConnection())
                return TinhCongNo(cn, null, soHD);
        }

        public CongNoHopDong TinhCongNo(SqlConnection cn, SqlTransaction tx, string soHD)
        {
            CongNoHopDong kq = new CongNoHopDong();
            DataTable ky = Db.QueryTx(cn, tx, @"SELECT COUNT(*) AS SoKy, ISNULL(SUM(SoTien), 0) AS Tien FROM KyThanhToan
                                                WHERE SoHD=@H AND TrangThai=N'Chưa thu' AND NgayDenHan<=@Nay",
                new SqlParameter("@H", soHD), new SqlParameter("@Nay", DateTime.Today));
            kq.SoKyNo = Convert.ToInt32(ky.Rows[0]["SoKy"]);
            kq.TienThueNo = Convert.ToDecimal(ky.Rows[0]["Tien"]);
            DataTable dv = Db.QueryTx(cn, tx, @"SELECT COUNT(*) AS SoHD, ISNULL(SUM(TongTien), 0) AS Tien FROM HoaDonDichVu
                                                WHERE SoHD=@H AND TrangThai=N'Chưa thanh toán'",
                new SqlParameter("@H", soHD));
            kq.SoHoaDonNo = Convert.ToInt32(dv.Rows[0]["SoHD"]);
            kq.DichVuNo = Convert.ToDecimal(dv.Rows[0]["Tien"]);
            return kq;
        }

        // ===================== LẬP HỢP ĐỒNG =====================
        public KetQuaXuLy LapHopDong(HopDongThue hd, List<string> dsPhong)
        {
            if (hd == null || string.IsNullOrWhiteSpace(hd.SoHD) || string.IsNullOrWhiteSpace(hd.MaKH))
                return KetQuaXuLy.Loi("Số hợp đồng và khách hàng không được để trống.");
            if (string.IsNullOrWhiteSpace(hd.NguoiLap)) return KetQuaXuLy.Loi("Hãy nhập người lập hợp đồng.");
            if (hd.SoThang < SoThangToiThieu)
                return KetQuaXuLy.Loi("Thời gian thuê tối thiểu là " + SoThangToiThieu + " tháng.");
            if (hd.NgayBatDau.Date < hd.NgayKy.Date)
                return KetQuaXuLy.Loi("Ngày bắt đầu thuê không được trước ngày ký hợp đồng.");
            if (dsPhong == null || dsPhong.Count == 0) return KetQuaXuLy.Loi("Hãy chọn ít nhất một phòng để thuê.");
            if (new HashSet<string>(dsPhong).Count != dsPhong.Count) return KetQuaXuLy.Loi("Danh sách phòng bị trùng.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    if (Convert.ToInt32(Db.ScalarTx(cn, tx, "SELECT COUNT(*) FROM KhachHang WHERE MaKH=@K", new SqlParameter("@K", hd.MaKH))) == 0)
                    { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy khách hàng " + hd.MaKH + "."); }

                    // Khóa và kiểm tra từng phòng phải đang trống
                    Dictionary<string, decimal> gia = new Dictionary<string, decimal>();
                    foreach (string ma in dsPhong)
                    {
                        DataTable p = Db.QueryTx(cn, tx, "SELECT GiaThue, TrangThai FROM Phong WITH (UPDLOCK) WHERE MaPhong=@P", new SqlParameter("@P", ma));
                        if (p.Rows.Count == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy phòng " + ma + "."); }
                        if (Convert.ToString(p.Rows[0]["TrangThai"]) != "Trống")
                        { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + ma + " không còn trống (" + p.Rows[0]["TrangThai"] + ")."); }
                        gia[ma] = Convert.ToDecimal(p.Rows[0]["GiaThue"]);
                    }

                    DateTime ketThuc = ThoiGian.NgayKetThuc(hd.NgayBatDau, hd.SoThang);
                    Db.ExecuteTx(cn, tx, @"INSERT INTO HopDongThue(SoHD, MaKH, NgayKy, NgayBatDau, SoThang, NgayKetThuc, TrangThai, DieuKhoan, NguoiLap)
                                           VALUES(@SoHD, @KH, @Ky, @BD, @ST, @KT, N'Hiệu lực', @DK, @NL)",
                        new SqlParameter("@SoHD", hd.SoHD.Trim()), new SqlParameter("@KH", hd.MaKH),
                        new SqlParameter("@Ky", hd.NgayKy.Date), new SqlParameter("@BD", hd.NgayBatDau.Date),
                        new SqlParameter("@ST", hd.SoThang), new SqlParameter("@KT", ketThuc),
                        new SqlParameter("@DK", Db.NullIfEmpty(hd.DieuKhoan)), new SqlParameter("@NL", hd.NguoiLap.Trim()));

                    decimal tienThang = 0;
                    foreach (string ma in dsPhong)
                    {
                        Db.ExecuteTx(cn, tx, "INSERT INTO ChiTietHopDong(SoHD, MaPhong, GiaThue, NgayKetThuc) VALUES(@H, @P, @G, @KT)",
                            new SqlParameter("@H", hd.SoHD.Trim()), new SqlParameter("@P", ma), new SqlParameter("@G", gia[ma]), new SqlParameter("@KT", ketThuc));
                        Db.ExecuteTx(cn, tx, "UPDATE Phong SET TrangThai=N'Đang thuê' WHERE MaPhong=@P", new SqlParameter("@P", ma));
                        tienThang += gia[ma];
                    }

                    // Lịch thanh toán: kỳ 1 = 6 tháng đầu trả trước (đến hạn ngày ký), từ tháng 7 mỗi tháng một kỳ, trả đầu tháng
                    TaoKy(cn, tx, hd.SoHD.Trim(), "01", 1, SoThangTraTruoc, hd.NgayKy.Date, tienThang * SoThangTraTruoc, "Trả trước 6 tháng đầu");
                    for (int m = SoThangTraTruoc + 1; m <= hd.SoThang; m++)
                        TaoKy(cn, tx, hd.SoHD.Trim(), m.ToString("00"), m, m, hd.NgayBatDau.Date.AddMonths(m - 1), tienThang, null);

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập hợp đồng " + hd.SoHD.Trim() + " cho " + dsPhong.Count + " phòng, hết hạn " + ketThuc.ToString("dd/MM/yyyy")
                        + ".\nTiền thuê mỗi tháng: " + tienThang.ToString("N0") + " đ. Phải trả trước 6 tháng đầu: " + (tienThang * SoThangTraTruoc).ToString("N0") + " đ.");
                }
                catch (SqlException ex)
                {
                    try { tx.Rollback(); } catch { }
                    if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Số hợp đồng đã tồn tại.");
                    return KetQuaXuLy.Loi("Không thể lập hợp đồng: " + ex.Message);
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể lập hợp đồng: " + ex.Message);
                }
            }
        }

        private void TaoKy(SqlConnection cn, SqlTransaction tx, string soHD, string hau, int tu, int den, DateTime denHan, decimal soTien, string ghiChu)
        {
            Db.ExecuteTx(cn, tx, @"INSERT INTO KyThanhToan(MaKy, SoHD, TuThang, DenThang, NgayDenHan, SoTien, TrangThai, GhiChu)
                                   VALUES(@Ma, @H, @Tu, @Den, @Han, @Tien, N'Chưa thu', @GC)",
                new SqlParameter("@Ma", "KY-" + soHD + "-" + hau), new SqlParameter("@H", soHD), new SqlParameter("@Tu", tu),
                new SqlParameter("@Den", den), new SqlParameter("@Han", denHan), new SqlParameter("@Tien", soTien),
                new SqlParameter("@GC", Db.NullIfEmpty(ghiChu)));
        }

        // ===================== THANH LÝ =====================
        public KetQuaXuLy ThanhLy(string soHD)
        {
            if (string.IsNullOrWhiteSpace(soHD)) return KetQuaXuLy.Loi("Chưa chọn hợp đồng.");
            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    object tt = Db.ScalarTx(cn, tx, "SELECT TrangThai FROM HopDongThue WITH (UPDLOCK) WHERE SoHD=@H", new SqlParameter("@H", soHD));
                    if (tt == null) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy hợp đồng."); }
                    if (Convert.ToString(tt) != "Hiệu lực") { tx.Rollback(); return KetQuaXuLy.Loi("Hợp đồng đã thanh lý."); }
                    CongNoHopDong no = TinhCongNo(cn, tx, soHD);
                    if (no.CoNo) { tx.Rollback(); return KetQuaXuLy.Loi("Chưa thể thanh lý. " + no.MoTa()); }

                    Db.ExecuteTx(cn, tx, "UPDATE HopDongThue SET TrangThai=N'Thanh lý' WHERE SoHD=@H", new SqlParameter("@H", soHD));
                    Db.ExecuteTx(cn, tx, @"UPDATE Phong SET TrangThai=N'Trống' WHERE MaPhong IN (SELECT MaPhong FROM ChiTietHopDong WHERE SoHD=@H)",
                        new SqlParameter("@H", soHD));
                    // bỏ các kỳ chưa đến hạn
                    Db.ExecuteTx(cn, tx, "DELETE FROM KyThanhToan WHERE SoHD=@H AND TrangThai=N'Chưa thu' AND NgayDenHan>@Nay",
                        new SqlParameter("@H", soHD), new SqlParameter("@Nay", DateTime.Today));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã thanh lý hợp đồng " + soHD + ", các phòng trở về trạng thái Trống.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể thanh lý: " + ex.Message);
                }
            }
        }

        // ===================== GIA HẠN =====================
        // Mỗi lần gia hạn một phòng không quá 1/2 thời gian thuê của hợp đồng
        public int SoThangToiDaGiaHan(string soHD)
        {
            object st = Db.Scalar("SELECT SoThang FROM HopDongThue WHERE SoHD=@H", new SqlParameter("@H", soHD ?? ""));
            if (st == null) return 0;
            return Convert.ToInt32(st) / 2;
        }

        public KetQuaXuLy LapPhieuGiaHan(string soHD, List<DongGiaHan> dsDong, string nguoiLap, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(soHD)) return KetQuaXuLy.Loi("Chưa chọn hợp đồng.");
            if (string.IsNullOrWhiteSpace(nguoiLap)) return KetQuaXuLy.Loi("Hãy nhập người lập phiếu.");
            if (dsDong == null || dsDong.Count == 0) return KetQuaXuLy.Loi("Hãy chọn ít nhất một phòng cần gia hạn.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    DataTable hd = Db.QueryTx(cn, tx, "SELECT SoThang, NgayBatDau, TrangThai FROM HopDongThue WITH (UPDLOCK) WHERE SoHD=@H", new SqlParameter("@H", soHD));
                    if (hd.Rows.Count == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy hợp đồng."); }
                    if (Convert.ToString(hd.Rows[0]["TrangThai"]) != "Hiệu lực") { tx.Rollback(); return KetQuaXuLy.Loi("Hợp đồng đã thanh lý, không thể gia hạn."); }
                    int soThangHD = Convert.ToInt32(hd.Rows[0]["SoThang"]);
                    DateTime batDau = Convert.ToDateTime(hd.Rows[0]["NgayBatDau"]);
                    int toiDa = soThangHD / 2;

                    // 1. Điều kiện công nợ: không còn nợ tiền thuê và đã thanh toán đầy đủ dịch vụ
                    CongNoHopDong no = TinhCongNo(cn, tx, soHD);
                    if (no.CoNo) { tx.Rollback(); return KetQuaXuLy.Loi("Không thể gia hạn. " + no.MoTa()); }

                    // 2. Kiểm tra từng phòng
                    HashSet<string> daCo = new HashSet<string>();
                    List<DataRow> phong = new List<DataRow>();
                    DataTable tmp = new DataTable();
                    Dictionary<string, DateTime> ketThucCu = new Dictionary<string, DateTime>();
                    Dictionary<string, decimal> giaPhong = new Dictionary<string, decimal>();
                    foreach (DongGiaHan d in dsDong)
                    {
                        if (!daCo.Add(d.MaPhong)) { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + " bị chọn hai lần."); }
                        if (d.SoThang <= 0) { tx.Rollback(); return KetQuaXuLy.Loi("Số tháng gia hạn của phòng " + d.MaPhong + " phải lớn hơn 0."); }
                        if (d.SoThang > toiDa)
                        { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + ": gia hạn tối đa " + toiDa + " tháng (bằng 1/2 thời gian thuê " + soThangHD + " tháng)."); }
                        DataTable ct = Db.QueryTx(cn, tx, "SELECT GiaThue, NgayKetThuc FROM ChiTietHopDong WITH (UPDLOCK) WHERE SoHD=@H AND MaPhong=@P",
                            new SqlParameter("@H", soHD), new SqlParameter("@P", d.MaPhong));
                        if (ct.Rows.Count == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + " không thuộc hợp đồng " + soHD + "."); }
                        DateTime kt = Convert.ToDateTime(ct.Rows[0]["NgayKetThuc"]);
                        if (kt.Date < DateTime.Today) { tx.Rollback(); return KetQuaXuLy.Loi("Phòng " + d.MaPhong + " đã hết hạn thuê ngày " + kt.ToString("dd/MM/yyyy") + ", cần ký hợp đồng mới."); }
                        ketThucCu[d.MaPhong] = kt;
                        giaPhong[d.MaPhong] = Convert.ToDecimal(ct.Rows[0]["GiaThue"]);
                    }

                    // 3. Lập phiếu
                    string tienTo = "GH" + DateTime.Today.Year + "-";
                    int stt = Convert.ToInt32(Db.ScalarTx(cn, tx, "SELECT COUNT(*) FROM PhieuGiaHan WHERE SoPhieu LIKE @P", new SqlParameter("@P", tienTo + "%"))) + 1;
                    string soPhieu = tienTo + stt.ToString("000");
                    Db.ExecuteTx(cn, tx, "INSERT INTO PhieuGiaHan(SoPhieu, SoHD, NgayLap, NguoiLap, GhiChu) VALUES(@P, @H, @Nay, @NL, @GC)",
                        new SqlParameter("@P", soPhieu), new SqlParameter("@H", soHD), new SqlParameter("@Nay", DateTime.Today),
                        new SqlParameter("@NL", nguoiLap.Trim()), new SqlParameter("@GC", Db.NullIfEmpty(ghiChu)));

                    // 4. Cập nhật từng phòng và gom tiền thuê của các tháng gia hạn
                    SortedDictionary<int, decimal> tienTheoThang = new SortedDictionary<int, decimal>();
                    foreach (DongGiaHan d in dsDong)
                    {
                        DateTime cu = ketThucCu[d.MaPhong];
                        DateTime moi = cu.AddDays(1).AddMonths(d.SoThang).AddDays(-1);
                        Db.ExecuteTx(cn, tx, @"INSERT INTO ChiTietGiaHan(SoPhieu, MaPhong, SoThangGiaHan, NgayKetThucCu, NgayKetThucMoi) VALUES(@P, @M, @ST, @Cu, @Moi)",
                            new SqlParameter("@P", soPhieu), new SqlParameter("@M", d.MaPhong), new SqlParameter("@ST", d.SoThang),
                            new SqlParameter("@Cu", cu), new SqlParameter("@Moi", moi));
                        Db.ExecuteTx(cn, tx, "UPDATE ChiTietHopDong SET NgayKetThuc=@Moi WHERE SoHD=@H AND MaPhong=@M",
                            new SqlParameter("@Moi", moi), new SqlParameter("@H", soHD), new SqlParameter("@M", d.MaPhong));
                        int thangCu = ThoiGian.SoThangDen(batDau, cu);
                        for (int m = thangCu + 1; m <= thangCu + d.SoThang; m++)
                        {
                            if (!tienTheoThang.ContainsKey(m)) tienTheoThang[m] = 0;
                            tienTheoThang[m] += giaPhong[d.MaPhong];
                        }
                    }
                    Db.ExecuteTx(cn, tx, "UPDATE HopDongThue SET NgayKetThuc=(SELECT MAX(NgayKetThuc) FROM ChiTietHopDong WHERE SoHD=@H) WHERE SoHD=@H",
                        new SqlParameter("@H", soHD));

                    // 5. Thêm kỳ thu tiền thuê cho các tháng gia hạn (từ tháng 7 trở đi: trả đầu mỗi tháng)
                    foreach (KeyValuePair<int, decimal> kv in tienTheoThang)
                    {
                        object chuaThu = Db.ScalarTx(cn, tx, @"SELECT TOP 1 MaKy FROM KyThanhToan WHERE SoHD=@H AND TuThang=@M AND DenThang=@M AND TrangThai=N'Chưa thu'",
                            new SqlParameter("@H", soHD), new SqlParameter("@M", kv.Key));
                        if (chuaThu != null)
                            Db.ExecuteTx(cn, tx, "UPDATE KyThanhToan SET SoTien = SoTien + @T WHERE MaKy=@K", new SqlParameter("@T", kv.Value), new SqlParameter("@K", Convert.ToString(chuaThu)));
                        else
                        {
                            string goc = "KY-" + soHD + "-" + kv.Key.ToString("00");
                            int daTon = Convert.ToInt32(Db.ScalarTx(cn, tx, "SELECT COUNT(*) FROM KyThanhToan WHERE MaKy LIKE @K", new SqlParameter("@K", goc + "%")));
                            string maKy = daTon == 0 ? goc : goc + "-GH" + daTon;
                            TaoKy(cn, tx, soHD, maKy.Substring(("KY-" + soHD + "-").Length), kv.Key, kv.Key, batDau.AddMonths(kv.Key - 1), kv.Value, "Gia hạn theo " + soPhieu);
                        }
                    }
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập phiếu gia hạn " + soPhieu + " cho " + dsDong.Count + " phòng. Đã bổ sung " + tienTheoThang.Count + " kỳ thu tiền thuê.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể lập phiếu gia hạn: " + ex.Message);
                }
            }
        }
    }
}
