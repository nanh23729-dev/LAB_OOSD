using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class BangLuongService
    {
        // Quy định triển khai (đề gốc chỉ cho hệ số phụ trội 1.5)
        public const decimal NgayCongChuan = 26m;
        public const decimal GioMotNgay = 8m;
        public const decimal HeSoPhuTroi = 1.5m;

        public DataTable LayBangLuong(int thang, int nam)
        {
            return Db.Query(@"SELECT bl.MaNV, nv.HoTen, bl.LuongCoBan, bl.SoNgayCong, bl.TienNgayCong,
                                     bl.PhuCapChucVu, bl.PhuCapLuong, bl.PhuCapDocHai, bl.SoGioPhuTroi, bl.TienPhuTroi,
                                     bl.TienThuong, bl.TienPhat, bl.TruBHXH, bl.TruBHYT, bl.ThucLinh
                              FROM BangLuong bl JOIN NhanVien nv ON nv.MaNV = bl.MaNV
                              WHERE bl.Thang=@T AND bl.Nam=@N ORDER BY bl.MaNV",
                new SqlParameter("@T", thang), new SqlParameter("@N", nam));
        }

        public KetQuaXuLy TinhBangLuong(int thang, int nam)
        {
            if (thang < 1 || thang > 12 || nam < 2000) return KetQuaXuLy.Loi("Tháng/năm không hợp lệ.");
            DateTime dauThang = new DateTime(nam, thang, 1);
            DateTime cuoiThang = dauThang.AddMonths(1).AddDays(-1);

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    // 1. Nhân viên có dòng chấm công trong tháng
                    DataTable ds = Db.QueryTx(cn, tx, @"SELECT ct.MaNV, SUM(ct.SoNgayCong) AS SoNgayCong
                                                       FROM ChiTietChamCong ct
                                                       JOIN BangChamCong b ON b.MaBCC = ct.MaBCC
                                                       WHERE b.Thang=@T AND b.Nam=@N
                                                       GROUP BY ct.MaNV",
                        new SqlParameter("@T", thang), new SqlParameter("@N", nam));
                    if (ds.Rows.Count == 0)
                    { tx.Rollback(); return KetQuaXuLy.Loi("Chưa có bảng chấm công của tháng " + thang + "/" + nam + "."); }

                    // 2. Lập lại: xóa bảng lương cũ của tháng
                    Db.ExecuteTx(cn, tx, "DELETE FROM BangLuong WHERE Thang=@T AND Nam=@N",
                        new SqlParameter("@T", thang), new SqlParameter("@N", nam));

                    int soNV = 0;
                    string boQua = "";
                    foreach (DataRow r in ds.Rows)
                    {
                        string maNV = Convert.ToString(r["MaNV"]);
                        decimal ngayCong = Convert.ToDecimal(r["SoNgayCong"]);
                        decimal lcb = 0, pcLuong = 0, pcDocHai = 0, pcChucVu = 0;

                        // Có QĐ lương hiệu lực tính đến cuối tháng -> lương chính thức;
                        // chưa có -> nhân viên đang thử việc, lấy lương thử việc trong QĐ tuyển dụng
                        DataTable l = Db.QueryTx(cn, tx, @"SELECT TOP 1 LuongCoBan, PhuCapLuong, PhuCapDocHai FROM QuyetDinhLuong
                                                          WHERE MaNV=@NV AND NgayHieuLuc<=@Cuoi ORDER BY NgayHieuLuc DESC",
                            new SqlParameter("@NV", maNV), new SqlParameter("@Cuoi", cuoiThang));
                        if (l.Rows.Count > 0)
                        {
                            lcb = Convert.ToDecimal(l.Rows[0]["LuongCoBan"]);
                            pcLuong = Convert.ToDecimal(l.Rows[0]["PhuCapLuong"]);
                            pcDocHai = Convert.ToDecimal(l.Rows[0]["PhuCapDocHai"]);
                            object pc = Db.ScalarTx(cn, tx, @"SELECT TOP 1 PhuCapChucVu FROM QuyetDinhChucVu
                                                              WHERE MaNV=@NV AND NgayHieuLuc<=@Cuoi ORDER BY NgayHieuLuc DESC",
                                new SqlParameter("@NV", maNV), new SqlParameter("@Cuoi", cuoiThang));
                            pcChucVu = pc == null ? 0 : Convert.ToDecimal(pc);
                        }
                        else
                        {
                            // Thử việc: không phụ cấp, không bảo hiểm
                            object luongTV = Db.ScalarTx(cn, tx, @"SELECT TOP 1 LuongThuViec FROM QuyetDinhTuyenDung
                                                                   WHERE MaNV=@NV AND NgayBatDauThuViec<=@Cuoi ORDER BY NgayKy DESC",
                                new SqlParameter("@NV", maNV), new SqlParameter("@Cuoi", cuoiThang));
                            if (luongTV == null) { boQua += maNV + " (chưa có QĐ lương/QĐ tuyển dụng); "; continue; }
                            lcb = Convert.ToDecimal(luongTV);
                        }

                        // Giờ phụ trội trong tháng
                        decimal gioPT = Convert.ToDecimal(Db.ScalarTx(cn, tx, @"SELECT ISNULL(SUM(c.SoGio),0)
                                                        FROM ChiTietPhuTroi c JOIN PhieuPhuTroi p ON p.SoPhieu = c.SoPhieu
                                                        WHERE c.MaNV=@NV AND p.NgayPhuTroi BETWEEN @Dau AND @Cuoi",
                            new SqlParameter("@NV", maNV), new SqlParameter("@Dau", dauThang), new SqlParameter("@Cuoi", cuoiThang)));
                        // Thưởng cộng vào lương / phạt trừ lương trong tháng (cá nhân)
                        decimal thuong = Convert.ToDecimal(Db.ScalarTx(cn, tx, @"SELECT ISNULL(SUM(SoTien),0) FROM QuyetDinhKhenThuong
                                                        WHERE MaNV=@NV AND HinhThucChi=N'Cộng vào lương' AND NgayKy BETWEEN @Dau AND @Cuoi",
                            new SqlParameter("@NV", maNV), new SqlParameter("@Dau", dauThang), new SqlParameter("@Cuoi", cuoiThang)));
                        decimal phat = Convert.ToDecimal(Db.ScalarTx(cn, tx, @"SELECT ISNULL(SUM(SoTienPhat),0) FROM QuyetDinhKyLuat
                                                        WHERE MaNV=@NV AND HinhThucThu=N'Trừ lương' AND NgayKy BETWEEN @Dau AND @Cuoi",
                            new SqlParameter("@NV", maNV), new SqlParameter("@Dau", dauThang), new SqlParameter("@Cuoi", cuoiThang)));

                        // Bảo hiểm: chỉ nhân viên có hồ sơ BH (hợp đồng dài hạn), tham gia trước cuối tháng
                        decimal bhxh = 0, bhyt = 0;
                        if (l.Rows.Count > 0)
                        {
                            DataTable bh = Db.QueryTx(cn, tx, @"SELECT TyLeBHXH, TyLeBHYT FROM HoSoBaoHiem
                                                               WHERE MaNV=@NV AND NgayThamGia<=@Cuoi",
                                new SqlParameter("@NV", maNV), new SqlParameter("@Cuoi", cuoiThang));
                            if (bh.Rows.Count > 0)
                            {
                                bhxh = Math.Round(lcb * Convert.ToDecimal(bh.Rows[0]["TyLeBHXH"]) / 100m, 0);
                                bhyt = Math.Round(lcb * Convert.ToDecimal(bh.Rows[0]["TyLeBHYT"]) / 100m, 0);
                            }
                        }

                        decimal tienNgayCong = Math.Round(lcb / NgayCongChuan * ngayCong, 0);
                        decimal tienPhuTroi = Math.Round(lcb / NgayCongChuan / GioMotNgay * HeSoPhuTroi * gioPT, 0);
                        decimal thucLinh = tienNgayCong + pcChucVu + pcLuong + pcDocHai + tienPhuTroi + thuong - phat - bhxh - bhyt;

                        Db.ExecuteTx(cn, tx, @"INSERT INTO BangLuong(MaBL, MaNV, Thang, Nam, LuongCoBan, PhuCapChucVu, PhuCapLuong, PhuCapDocHai,
                                                      SoNgayCong, TienNgayCong, SoGioPhuTroi, TienPhuTroi, TienThuong, TienPhat,
                                                      TruBHXH, TruBHYT, ThucLinh, NgayLap)
                                               VALUES(@MaBL, @NV, @T, @N, @LCB, @PCCV, @PCL, @PCDH, @NC, @TNC, @GPT, @TPT, @Thuong, @Phat,
                                                      @BHXH, @BHYT, @TL, @NgayLap)",
                            new SqlParameter("@MaBL", "BL-" + nam.ToString("0000") + thang.ToString("00") + "-" + maNV),
                            new SqlParameter("@NV", maNV), new SqlParameter("@T", thang), new SqlParameter("@N", nam),
                            new SqlParameter("@LCB", lcb), new SqlParameter("@PCCV", pcChucVu),
                            new SqlParameter("@PCL", pcLuong), new SqlParameter("@PCDH", pcDocHai),
                            new SqlParameter("@NC", ngayCong), new SqlParameter("@TNC", tienNgayCong),
                            new SqlParameter("@GPT", gioPT), new SqlParameter("@TPT", tienPhuTroi),
                            new SqlParameter("@Thuong", thuong), new SqlParameter("@Phat", phat),
                            new SqlParameter("@BHXH", bhxh), new SqlParameter("@BHYT", bhyt),
                            new SqlParameter("@TL", thucLinh), new SqlParameter("@NgayLap", DateTime.Today));
                        soNV++;
                    }
                    tx.Commit();
                    string thongBao = "Đã lập bảng lương tháng " + thang + "/" + nam + " cho " + soNV + " nhân viên.";
                    if (boQua != "") thongBao += "\nBỏ qua: " + boQua;
                    return KetQuaXuLy.Ok(thongBao);
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể tính bảng lương: " + ex.Message);
                }
            }
        }
    }
}
