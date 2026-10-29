using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class KhenThuongKyLuatService
    {
        // Kiểm tra đối tượng của quyết định; trả về tên người nhận/nộp để ghi lên phiếu
        private KetQuaXuLy KiemTraDoiTuong(string doiTuong, string maNV, string maPB, out string tenDoiTuong)
        {
            tenDoiTuong = "";
            if (doiTuong == "Cá nhân")
            {
                if (string.IsNullOrWhiteSpace(maNV)) return KetQuaXuLy.Loi("Quyết định cho cá nhân phải chọn nhân viên.");
                DataTable t = Db.Query("SELECT HoTen, TrangThai FROM NhanVien WHERE MaNV=@NV", new SqlParameter("@NV", maNV));
                if (t.Rows.Count == 0) return KetQuaXuLy.Loi("Không tìm thấy nhân viên.");
                string tt = Convert.ToString(t.Rows[0]["TrangThai"]);
                if (tt != "Thử việc" && tt != "Chính thức") return KetQuaXuLy.Loi("Nhân viên không còn làm việc tại công ty.");
                tenDoiTuong = Convert.ToString(t.Rows[0]["HoTen"]);
                return KetQuaXuLy.Ok("");
            }
            if (doiTuong == "Tập thể")
            {
                if (string.IsNullOrWhiteSpace(maPB)) return KetQuaXuLy.Loi("Quyết định cho tập thể phải chọn phòng ban/đơn vị.");
                object ten = Db.Scalar("SELECT TenPB FROM PhongBan WHERE MaPB=@PB", new SqlParameter("@PB", maPB));
                if (ten == null) return KetQuaXuLy.Loi("Không tìm thấy phòng ban.");
                tenDoiTuong = "Đại diện " + Convert.ToString(ten);
                return KetQuaXuLy.Ok("");
            }
            return KetQuaXuLy.Loi("Đối tượng phải là Cá nhân hoặc Tập thể.");
        }

        // ===================== KHEN THƯỞNG =====================
        public DataTable LayKhenThuong()
        {
            return Db.Query(@"SELECT qd.SoQD, qd.NgayKy, qd.LoaiKhenThuong, qd.DoiTuong,
                                     ISNULL(nv.HoTen, pb.TenPB) AS NguoiNhan, qd.SoTien, qd.HinhThucChi,
                                     pc.SoPhieuChi, qd.NguoiKy, qd.NoiDung
                              FROM QuyetDinhKhenThuong qd
                              LEFT JOIN NhanVien nv ON nv.MaNV = qd.MaNV
                              LEFT JOIN PhongBan pb ON pb.MaPB = qd.MaPB
                              LEFT JOIN PhieuChiKhenThuong pc ON pc.SoQD = qd.SoQD
                              ORDER BY qd.NgayKy DESC, qd.SoQD DESC");
        }

        public KetQuaXuLy LapQuyetDinhKhenThuong(QuyetDinhKhenThuong qd)
        {
            if (qd == null || string.IsNullOrWhiteSpace(qd.SoQD) || string.IsNullOrWhiteSpace(qd.LoaiKhenThuong) ||
                string.IsNullOrWhiteSpace(qd.NoiDung) || string.IsNullOrWhiteSpace(qd.NguoiKy) ||
                string.IsNullOrWhiteSpace(qd.HinhThucChi))
                return KetQuaXuLy.Loi("Vui lòng nhập Số QĐ, loại khen thưởng, nội dung, hình thức chi và người ký.");
            if (qd.SoTien <= 0) return KetQuaXuLy.Loi("Số tiền khen thưởng phải lớn hơn 0.");
            if (qd.DoiTuong == "Tập thể" && qd.HinhThucChi != "Phiếu chi")
                return KetQuaXuLy.Loi("Khen thưởng tập thể phải chi bằng phiếu chi, không cộng vào lương.");
            if (qd.HinhThucChi == "Phiếu chi" && string.IsNullOrWhiteSpace(qd.MaNVLapPhieu))
                return KetQuaXuLy.Loi("Vui lòng chọn nhân viên kế toán lập phiếu chi.");

            string nguoiNhan;
            KetQuaXuLy kt = KiemTraDoiTuong(qd.DoiTuong, qd.MaNV, qd.MaPB, out nguoiNhan);
            if (!kt.ThanhCong) return kt;
            if (qd.DoiTuong == "Cá nhân") qd.MaPB = null; else qd.MaNV = null;

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    Db.ExecuteTx(cn, tx, @"INSERT INTO QuyetDinhKhenThuong(SoQD, NgayKy, LoaiKhenThuong, DoiTuong, MaNV, MaPB,
                                                  NoiDung, SoTien, HinhThucChi, NguoiKy)
                                           VALUES(@SoQD, @NgayKy, @Loai, @DoiTuong, @MaNV, @MaPB, @NoiDung, @SoTien, @HinhThuc, @NguoiKy)",
                        new SqlParameter("@SoQD", qd.SoQD.Trim()),
                        new SqlParameter("@NgayKy", qd.NgayKy.Date),
                        new SqlParameter("@Loai", qd.LoaiKhenThuong),
                        new SqlParameter("@DoiTuong", qd.DoiTuong),
                        new SqlParameter("@MaNV", Db.NullIfEmpty(qd.MaNV)),
                        new SqlParameter("@MaPB", Db.NullIfEmpty(qd.MaPB)),
                        new SqlParameter("@NoiDung", qd.NoiDung.Trim()),
                        new SqlParameter("@SoTien", qd.SoTien),
                        new SqlParameter("@HinhThuc", qd.HinhThucChi),
                        new SqlParameter("@NguoiKy", qd.NguoiKy.Trim()));

                    string thongBao = "Lập quyết định khen thưởng " + qd.SoQD.Trim() + " thành công.";
                    if (qd.HinhThucChi == "Phiếu chi")
                    {
                        string soPhieu = "PC-" + DateTime.Now.ToString("yyMMddHHmmss");
                        Db.ExecuteTx(cn, tx, @"INSERT INTO PhieuChiKhenThuong(SoPhieuChi, SoQD, NgayChi, SoTien, NguoiNhan, MaNVLap)
                                               VALUES(@SoPC, @SoQD, @Ngay, @SoTien, @NguoiNhan, @NVLap)",
                            new SqlParameter("@SoPC", soPhieu),
                            new SqlParameter("@SoQD", qd.SoQD.Trim()),
                            new SqlParameter("@Ngay", qd.NgayKy.Date),
                            new SqlParameter("@SoTien", qd.SoTien),
                            new SqlParameter("@NguoiNhan", nguoiNhan),
                            new SqlParameter("@NVLap", qd.MaNVLapPhieu));
                        thongBao += "\nĐã lập phiếu chi " + soPhieu + " - " + qd.SoTien.ToString("N0") + " đ cho " + nguoiNhan + ".";
                    }
                    else
                    {
                        thongBao += "\nSố tiền sẽ được cộng vào bảng lương tháng " + qd.NgayKy.ToString("MM/yyyy") + ".";
                    }
                    tx.Commit();
                    return KetQuaXuLy.Ok(thongBao);
                }
                catch (SqlException ex)
                {
                    try { tx.Rollback(); } catch { }
                    if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Số quyết định đã tồn tại.");
                    return KetQuaXuLy.Loi("Không thể lập quyết định khen thưởng: " + ex.Message);
                }
            }
        }

        // ===================== KỶ LUẬT =====================
        public DataTable LayKyLuat()
        {
            return Db.Query(@"SELECT qd.SoQD, qd.NgayKy, qd.DoiTuong, ISNULL(nv.HoTen, pb.TenPB) AS NguoiNop,
                                     qd.SoTienPhat, qd.HinhThucThu, pt.SoPhieuThu, qd.NguoiKy, qd.LyDo
                              FROM QuyetDinhKyLuat qd
                              LEFT JOIN NhanVien nv ON nv.MaNV = qd.MaNV
                              LEFT JOIN PhongBan pb ON pb.MaPB = qd.MaPB
                              LEFT JOIN PhieuThuNopPhat pt ON pt.SoQD = qd.SoQD
                              ORDER BY qd.NgayKy DESC, qd.SoQD DESC");
        }

        public KetQuaXuLy LapQuyetDinhKyLuat(QuyetDinhKyLuat qd)
        {
            if (qd == null || string.IsNullOrWhiteSpace(qd.SoQD) || string.IsNullOrWhiteSpace(qd.LyDo) ||
                string.IsNullOrWhiteSpace(qd.NguoiKy) || string.IsNullOrWhiteSpace(qd.HinhThucThu))
                return KetQuaXuLy.Loi("Vui lòng nhập Số QĐ, lý do, hình thức thu và người ký.");
            if (qd.SoTienPhat <= 0) return KetQuaXuLy.Loi("Số tiền phạt phải lớn hơn 0.");
            if (qd.DoiTuong == "Tập thể" && qd.HinhThucThu != "Phiếu thu")
                return KetQuaXuLy.Loi("Phạt tập thể phải thu bằng phiếu thu, không trừ lương cá nhân.");
            if (qd.HinhThucThu == "Phiếu thu" && string.IsNullOrWhiteSpace(qd.MaNVLapPhieu))
                return KetQuaXuLy.Loi("Vui lòng chọn nhân viên kế toán lập phiếu thu.");

            string nguoiNop;
            KetQuaXuLy kt = KiemTraDoiTuong(qd.DoiTuong, qd.MaNV, qd.MaPB, out nguoiNop);
            if (!kt.ThanhCong) return kt;
            if (qd.DoiTuong == "Cá nhân") qd.MaPB = null; else qd.MaNV = null;

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    Db.ExecuteTx(cn, tx, @"INSERT INTO QuyetDinhKyLuat(SoQD, NgayKy, DoiTuong, MaNV, MaPB, LyDo, SoTienPhat, HinhThucThu, NguoiKy)
                                           VALUES(@SoQD, @NgayKy, @DoiTuong, @MaNV, @MaPB, @LyDo, @SoTien, @HinhThuc, @NguoiKy)",
                        new SqlParameter("@SoQD", qd.SoQD.Trim()),
                        new SqlParameter("@NgayKy", qd.NgayKy.Date),
                        new SqlParameter("@DoiTuong", qd.DoiTuong),
                        new SqlParameter("@MaNV", Db.NullIfEmpty(qd.MaNV)),
                        new SqlParameter("@MaPB", Db.NullIfEmpty(qd.MaPB)),
                        new SqlParameter("@LyDo", qd.LyDo.Trim()),
                        new SqlParameter("@SoTien", qd.SoTienPhat),
                        new SqlParameter("@HinhThuc", qd.HinhThucThu),
                        new SqlParameter("@NguoiKy", qd.NguoiKy.Trim()));

                    string thongBao = "Lập quyết định kỷ luật " + qd.SoQD.Trim() + " thành công.";
                    if (qd.HinhThucThu == "Phiếu thu")
                    {
                        string soPhieu = "PT-" + DateTime.Now.ToString("yyMMddHHmmss");
                        Db.ExecuteTx(cn, tx, @"INSERT INTO PhieuThuNopPhat(SoPhieuThu, SoQD, NgayThu, SoTien, NguoiNop, MaNVLap)
                                               VALUES(@SoPT, @SoQD, @Ngay, @SoTien, @NguoiNop, @NVLap)",
                            new SqlParameter("@SoPT", soPhieu),
                            new SqlParameter("@SoQD", qd.SoQD.Trim()),
                            new SqlParameter("@Ngay", qd.NgayKy.Date),
                            new SqlParameter("@SoTien", qd.SoTienPhat),
                            new SqlParameter("@NguoiNop", nguoiNop),
                            new SqlParameter("@NVLap", qd.MaNVLapPhieu));
                        thongBao += "\nĐã lập phiếu thu " + soPhieu + " - " + qd.SoTienPhat.ToString("N0") + " đ.";
                    }
                    else
                    {
                        thongBao += "\nSố tiền phạt sẽ trừ vào bảng lương tháng " + qd.NgayKy.ToString("MM/yyyy") + ".";
                    }
                    tx.Commit();
                    return KetQuaXuLy.Ok(thongBao);
                }
                catch (SqlException ex)
                {
                    try { tx.Rollback(); } catch { }
                    if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Số quyết định đã tồn tại.");
                    return KetQuaXuLy.Loi("Không thể lập quyết định kỷ luật: " + ex.Message);
                }
            }
        }
    }
}
