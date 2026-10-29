using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class NhanVienService
    {
        // ===================== HỒ SƠ NHÂN VIÊN =====================
        public DataTable LayDanhSach(string tuKhoa)
        {
            string key = (tuKhoa ?? string.Empty).Trim();
            return Db.Query(@"SELECT nv.MaNV, nv.HoTen, nv.GioiTinh, nv.NgaySinh, nv.CCCD, nv.DiaChi,
                                     nv.DienThoai, nv.MaPB, pb.TenPB, nv.TrangThai
                              FROM NhanVien nv LEFT JOIN PhongBan pb ON pb.MaPB = nv.MaPB
                              WHERE (@Key = '' OR nv.MaNV LIKE @Like OR nv.HoTen LIKE @Like OR nv.CCCD LIKE @Like)
                              ORDER BY nv.MaNV",
                new SqlParameter("@Key", key), new SqlParameter("@Like", "%" + key + "%"));
        }

        // Dùng cho ComboBox; trangThai = null thì lấy những người đang làm việc (Thử việc + Chính thức)
        public DataTable LayCombo(string trangThai)
        {
            if (string.IsNullOrEmpty(trangThai))
                return Db.Query(@"SELECT MaNV, MaNV + N' - ' + HoTen AS HienThi, MaPB, TrangThai FROM NhanVien
                                  WHERE TrangThai IN (N'Thử việc', N'Chính thức') ORDER BY MaNV");
            return Db.Query(@"SELECT MaNV, MaNV + N' - ' + HoTen AS HienThi, MaPB, TrangThai FROM NhanVien
                              WHERE TrangThai = @TT ORDER BY MaNV", new SqlParameter("@TT", trangThai));
        }

        public KetQuaXuLy Luu(NhanVien nv, bool capNhat)
        {
            if (nv == null || string.IsNullOrWhiteSpace(nv.MaNV) || string.IsNullOrWhiteSpace(nv.HoTen) ||
                string.IsNullOrWhiteSpace(nv.GioiTinh) || string.IsNullOrWhiteSpace(nv.CCCD))
                return KetQuaXuLy.Loi("Vui lòng nhập Mã NV, Họ tên, Giới tính và CCCD.");
            string cccd = nv.CCCD.Trim();
            if (cccd.Length != 12) return KetQuaXuLy.Loi("CCCD phải gồm đúng 12 chữ số.");
            foreach (char c in cccd) if (!char.IsDigit(c)) return KetQuaXuLy.Loi("CCCD chỉ được chứa chữ số.");
            if (nv.NgaySinh.Date > DateTime.Today.AddYears(-18))
                return KetQuaXuLy.Loi("Người lao động phải đủ 18 tuổi.");
            try
            {
                string sql = capNhat
                    ? @"UPDATE NhanVien SET HoTen=@HoTen, GioiTinh=@GT, NgaySinh=@NS, CCCD=@CCCD, DiaChi=@DC,
                               DienThoai=@DT, MaPB=@PB WHERE MaNV=@Ma"
                    : @"INSERT INTO NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, CCCD, DiaChi, DienThoai, MaPB, TrangThai)
                        VALUES(@Ma, @HoTen, @GT, @NS, @CCCD, @DC, @DT, @PB, N'Hồ sơ')";
                int n = Db.Execute(sql,
                    new SqlParameter("@Ma", nv.MaNV.Trim()),
                    new SqlParameter("@HoTen", nv.HoTen.Trim()),
                    new SqlParameter("@GT", nv.GioiTinh),
                    new SqlParameter("@NS", nv.NgaySinh.Date),
                    new SqlParameter("@CCCD", cccd),
                    new SqlParameter("@DC", Db.NullIfEmpty(nv.DiaChi)),
                    new SqlParameter("@DT", Db.NullIfEmpty(nv.DienThoai)),
                    new SqlParameter("@PB", Db.NullIfEmpty(nv.MaPB)));
                return n > 0 ? KetQuaXuLy.Ok(capNhat ? "Cập nhật nhân viên thành công." : "Thêm hồ sơ nhân viên thành công.")
                             : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã nhân viên hoặc CCCD đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== QUYẾT ĐỊNH TUYỂN DỤNG =====================
        public DataTable LayQuyetDinhTuyenDung()
        {
            return Db.Query(@"SELECT qd.SoQD, qd.MaNV, nv.HoTen, qd.MaPB, qd.NgayKy, qd.NgayBatDauThuViec,
                                     qd.NgayKetThucThuViec, qd.LuongThuViec, qd.NguoiKy, qd.KetQuaThuViec, qd.DieuKhoan
                              FROM QuyetDinhTuyenDung qd JOIN NhanVien nv ON nv.MaNV = qd.MaNV
                              ORDER BY qd.NgayKy DESC");
        }

        public KetQuaXuLy LapQuyetDinhTuyenDung(QuyetDinhTuyenDung qd)
        {
            if (qd == null || string.IsNullOrWhiteSpace(qd.SoQD) || string.IsNullOrWhiteSpace(qd.MaNV) ||
                string.IsNullOrWhiteSpace(qd.MaPB) || string.IsNullOrWhiteSpace(qd.NguoiKy) ||
                string.IsNullOrWhiteSpace(qd.DieuKhoan))
                return KetQuaXuLy.Loi("Vui lòng nhập Số QĐ, nhân viên, phòng ban, điều khoản và người ký.");
            if (qd.NgayBatDauThuViec.Date < qd.NgayKy.Date)
                return KetQuaXuLy.Loi("Ngày bắt đầu thử việc không được trước ngày ký quyết định.");
            if (qd.NgayKetThucThuViec.Date <= qd.NgayBatDauThuViec.Date)
                return KetQuaXuLy.Loi("Ngày kết thúc thử việc phải sau ngày bắt đầu.");
            if (qd.LuongThuViec <= 0) return KetQuaXuLy.Loi("Lương thử việc phải lớn hơn 0.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    object tt = Db.ScalarTx(cn, tx, "SELECT TrangThai FROM NhanVien WITH (UPDLOCK) WHERE MaNV=@Ma",
                        new SqlParameter("@Ma", qd.MaNV));
                    if (tt == null) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy nhân viên."); }
                    if (Convert.ToString(tt) != "Hồ sơ")
                    {
                        tx.Rollback();
                        return KetQuaXuLy.Loi("Chỉ lập quyết định tuyển dụng cho nhân viên đang ở trạng thái Hồ sơ.");
                    }

                    Db.ExecuteTx(cn, tx, @"INSERT INTO QuyetDinhTuyenDung(SoQD, MaNV, MaPB, NgayKy, NgayBatDauThuViec,
                                                  NgayKetThucThuViec, LuongThuViec, DieuKhoan, NguoiKy)
                                           VALUES(@SoQD, @MaNV, @MaPB, @NgayKy, @BD, @KT, @Luong, @DK, @NguoiKy)",
                        new SqlParameter("@SoQD", qd.SoQD.Trim()),
                        new SqlParameter("@MaNV", qd.MaNV),
                        new SqlParameter("@MaPB", qd.MaPB),
                        new SqlParameter("@NgayKy", qd.NgayKy.Date),
                        new SqlParameter("@BD", qd.NgayBatDauThuViec.Date),
                        new SqlParameter("@KT", qd.NgayKetThucThuViec.Date),
                        new SqlParameter("@Luong", qd.LuongThuViec),
                        new SqlParameter("@DK", qd.DieuKhoan.Trim()),
                        new SqlParameter("@NguoiKy", qd.NguoiKy.Trim()));

                    Db.ExecuteTx(cn, tx, "UPDATE NhanVien SET TrangThai=N'Thử việc', MaPB=@MaPB WHERE MaNV=@MaNV",
                        new SqlParameter("@MaPB", qd.MaPB), new SqlParameter("@MaNV", qd.MaNV));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Lập quyết định tuyển dụng " + qd.SoQD.Trim() + " thành công. Nhân viên chuyển sang Thử việc.");
                }
                catch (SqlException ex)
                {
                    try { tx.Rollback(); } catch { }
                    if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Số quyết định đã tồn tại.");
                    return KetQuaXuLy.Loi("Không thể lập quyết định: " + ex.Message);
                }
            }
        }

        public KetQuaXuLy CapNhatKetQuaThuViec(string soQD, string ketQua)
        {
            if (string.IsNullOrWhiteSpace(soQD)) return KetQuaXuLy.Loi("Vui lòng chọn quyết định tuyển dụng.");
            if (ketQua != "Đạt" && ketQua != "Không đạt") return KetQuaXuLy.Loi("Kết quả thử việc không hợp lệ.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    DataTable t = Db.QueryTx(cn, tx, @"SELECT qd.MaNV, qd.NgayKetThucThuViec, qd.KetQuaThuViec, nv.TrangThai
                                                      FROM QuyetDinhTuyenDung qd JOIN NhanVien nv ON nv.MaNV = qd.MaNV
                                                      WHERE qd.SoQD = @SoQD", new SqlParameter("@SoQD", soQD));
                    if (t.Rows.Count == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy quyết định."); }
                    DataRow r = t.Rows[0];
                    if (Convert.ToString(r["TrangThai"]) != "Thử việc")
                    { tx.Rollback(); return KetQuaXuLy.Loi("Nhân viên không còn ở trạng thái Thử việc."); }

                    Db.ExecuteTx(cn, tx, "UPDATE QuyetDinhTuyenDung SET KetQuaThuViec=@KQ WHERE SoQD=@SoQD",
                        new SqlParameter("@KQ", ketQua), new SqlParameter("@SoQD", soQD));
                    // Không đạt thì kết thúc quan hệ lao động
                    if (ketQua == "Không đạt")
                        Db.ExecuteTx(cn, tx, "UPDATE NhanVien SET TrangThai=N'Nghỉ việc' WHERE MaNV=@MaNV",
                            new SqlParameter("@MaNV", r["MaNV"]));
                    tx.Commit();
                    return KetQuaXuLy.Ok(ketQua == "Đạt" ? "Đã ghi nhận thử việc Đạt. Có thể ký hợp đồng."
                                                         : "Đã ghi nhận thử việc Không đạt. Nhân viên chuyển sang Nghỉ việc.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể cập nhật kết quả: " + ex.Message);
                }
            }
        }

        // QĐ đã thử việc Đạt và chưa có hợp đồng -> nguồn cho ComboBox ký hợp đồng
        public DataTable LayQuyetDinhChoKyHopDong()
        {
            return Db.Query(@"SELECT qd.SoQD, qd.SoQD + N' - ' + nv.HoTen AS HienThi, qd.NgayKetThucThuViec
                              FROM QuyetDinhTuyenDung qd JOIN NhanVien nv ON nv.MaNV = qd.MaNV
                              WHERE qd.KetQuaThuViec = N'Đạt' AND nv.TrangThai = N'Thử việc'
                                AND NOT EXISTS (SELECT 1 FROM HopDongLaoDong hd WHERE hd.SoQDTuyenDung = qd.SoQD)
                              ORDER BY qd.SoQD");
        }

        // ===================== HỢP ĐỒNG LAO ĐỘNG =====================
        public DataTable LayHopDong()
        {
            return Db.Query(@"SELECT hd.SoHD, hd.MaNV, nv.HoTen, hd.LoaiHD, hd.NgayKy, hd.NgayBatDau, hd.NgayKetThuc,
                                     hd.NguoiKy, bh.MaHSBH, bh.SoSoBHXH, bh.SoTheBHYT
                              FROM HopDongLaoDong hd JOIN NhanVien nv ON nv.MaNV = hd.MaNV
                              LEFT JOIN HoSoBaoHiem bh ON bh.SoHD = hd.SoHD
                              ORDER BY hd.NgayKy DESC");
        }

        public KetQuaXuLy KyHopDong(HopDongLaoDong hd)
        {
            if (hd == null || string.IsNullOrWhiteSpace(hd.SoHD) || string.IsNullOrWhiteSpace(hd.SoQDTuyenDung) ||
                string.IsNullOrWhiteSpace(hd.LoaiHD) || string.IsNullOrWhiteSpace(hd.NguoiKy))
                return KetQuaXuLy.Loi("Vui lòng nhập Số HĐ, quyết định tuyển dụng, loại hợp đồng và người ký.");
            if (hd.NgayKy.Date > hd.NgayBatDau.Date) return KetQuaXuLy.Loi("Ngày ký không được sau ngày bắt đầu hợp đồng.");
            if (hd.LoaiHD == "Ngắn hạn")
            {
                if (hd.NgayKetThuc == null || hd.NgayKetThuc.Value.Date <= hd.NgayBatDau.Date)
                    return KetQuaXuLy.Loi("Hợp đồng ngắn hạn phải có ngày kết thúc sau ngày bắt đầu.");
            }
            else hd.NgayKetThuc = null;

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    DataTable t = Db.QueryTx(cn, tx, @"SELECT qd.MaNV, qd.NgayKetThucThuViec, qd.KetQuaThuViec, nv.TrangThai
                                                      FROM QuyetDinhTuyenDung qd JOIN NhanVien nv ON nv.MaNV = qd.MaNV
                                                      WHERE qd.SoQD = @SoQD", new SqlParameter("@SoQD", hd.SoQDTuyenDung));
                    if (t.Rows.Count == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Không tìm thấy quyết định tuyển dụng."); }
                    DataRow r = t.Rows[0];
                    string maNV = Convert.ToString(r["MaNV"]);
                    DateTime ketThucTV = Convert.ToDateTime(r["NgayKetThucThuViec"]);

                    if (Convert.ToString(r["TrangThai"]) != "Thử việc")
                    { tx.Rollback(); return KetQuaXuLy.Loi("Nhân viên không ở trạng thái Thử việc."); }
                    if (Convert.ToString(r["KetQuaThuViec"]) != "Đạt")
                    { tx.Rollback(); return KetQuaXuLy.Loi("Chỉ ký hợp đồng khi kết quả thử việc là Đạt."); }
                    if (hd.NgayBatDau.Date <= ketThucTV.Date)
                    {
                        tx.Rollback();
                        return KetQuaXuLy.Loi("Hợp đồng chỉ bắt đầu sau khi hết thời gian thử việc (" + ketThucTV.ToString("dd/MM/yyyy") + ").");
                    }

                    Db.ExecuteTx(cn, tx, @"INSERT INTO HopDongLaoDong(SoHD, MaNV, SoQDTuyenDung, LoaiHD, NgayKy, NgayBatDau, NgayKetThuc, NguoiKy)
                                           VALUES(@SoHD, @MaNV, @SoQD, @Loai, @NgayKy, @BD, @KT, @NguoiKy)",
                        new SqlParameter("@SoHD", hd.SoHD.Trim()),
                        new SqlParameter("@MaNV", maNV),
                        new SqlParameter("@SoQD", hd.SoQDTuyenDung),
                        new SqlParameter("@Loai", hd.LoaiHD),
                        new SqlParameter("@NgayKy", hd.NgayKy.Date),
                        new SqlParameter("@BD", hd.NgayBatDau.Date),
                        new SqlParameter("@KT", hd.NgayKetThuc.HasValue ? (object)hd.NgayKetThuc.Value.Date : DBNull.Value),
                        new SqlParameter("@NguoiKy", hd.NguoiKy.Trim()));
                    Db.ExecuteTx(cn, tx, "UPDATE NhanVien SET TrangThai=N'Chính thức' WHERE MaNV=@MaNV", new SqlParameter("@MaNV", maNV));
                    tx.Commit();

                    string thongBao = "Ký hợp đồng " + hd.SoHD.Trim() + " thành công. Nhân viên chuyển sang Chính thức.";
                    if (hd.LoaiHD == "Dài hạn") thongBao += "\nHợp đồng dài hạn: hãy lập hồ sơ BHXH - BHYT.";
                    thongBao += "\nTiếp theo: lập Quyết định lương và Quyết định chức vụ.";
                    return KetQuaXuLy.Ok(thongBao);
                }
                catch (SqlException ex)
                {
                    try { tx.Rollback(); } catch { }
                    if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Số hợp đồng đã tồn tại hoặc quyết định này đã có hợp đồng.");
                    return KetQuaXuLy.Loi("Không thể ký hợp đồng: " + ex.Message);
                }
            }
        }

        // ===================== HỒ SƠ BẢO HIỂM =====================
        public KetQuaXuLy LapHoSoBaoHiem(HoSoBaoHiem bh)
        {
            if (bh == null || string.IsNullOrWhiteSpace(bh.SoHD) || string.IsNullOrWhiteSpace(bh.SoSoBHXH) ||
                string.IsNullOrWhiteSpace(bh.SoTheBHYT))
                return KetQuaXuLy.Loi("Vui lòng chọn hợp đồng và nhập số sổ BHXH, số thẻ BHYT.");
            if (bh.TyLeBHXH < 0 || bh.TyLeBHXH > 100 || bh.TyLeBHYT < 0 || bh.TyLeBHYT > 100)
                return KetQuaXuLy.Loi("Tỷ lệ trích bảo hiểm không hợp lệ.");

            DataTable t = Db.Query("SELECT MaNV, LoaiHD, NgayBatDau FROM HopDongLaoDong WHERE SoHD=@SoHD",
                new SqlParameter("@SoHD", bh.SoHD));
            if (t.Rows.Count == 0) return KetQuaXuLy.Loi("Không tìm thấy hợp đồng.");
            if (Convert.ToString(t.Rows[0]["LoaiHD"]) != "Dài hạn")
                return KetQuaXuLy.Loi("Chỉ hợp đồng dài hạn mới lập hồ sơ BHXH - BHYT.");
            if (bh.NgayThamGia.Date < Convert.ToDateTime(t.Rows[0]["NgayBatDau"]).Date)
                return KetQuaXuLy.Loi("Ngày tham gia bảo hiểm không được trước ngày bắt đầu hợp đồng.");
            string maNV = Convert.ToString(t.Rows[0]["MaNV"]);
            try
            {
                Db.Execute(@"INSERT INTO HoSoBaoHiem(MaHSBH, MaNV, SoHD, SoSoBHXH, SoTheBHYT, NgayThamGia, TyLeBHXH, TyLeBHYT)
                             VALUES(@Ma, @MaNV, @SoHD, @SoSo, @SoThe, @Ngay, @XH, @YT)",
                    new SqlParameter("@Ma", "BH-" + maNV),
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@SoHD", bh.SoHD),
                    new SqlParameter("@SoSo", bh.SoSoBHXH.Trim()),
                    new SqlParameter("@SoThe", bh.SoTheBHYT.Trim()),
                    new SqlParameter("@Ngay", bh.NgayThamGia.Date),
                    new SqlParameter("@XH", bh.TyLeBHXH),
                    new SqlParameter("@YT", bh.TyLeBHYT));
                return KetQuaXuLy.Ok("Lập hồ sơ bảo hiểm cho " + maNV + " thành công.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Nhân viên đã có hồ sơ bảo hiểm hoặc số sổ/số thẻ bị trùng.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
