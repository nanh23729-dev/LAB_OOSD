using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class QuyetDinhService
    {
        private KetQuaXuLy KiemTraNhanVienChinhThuc(string maNV)
        {
            object tt = Db.Scalar("SELECT TrangThai FROM NhanVien WHERE MaNV=@Ma", new SqlParameter("@Ma", maNV));
            if (tt == null) return KetQuaXuLy.Loi("Không tìm thấy nhân viên.");
            if (Convert.ToString(tt) != "Chính thức")
                return KetQuaXuLy.Loi("Chỉ lập quyết định lương/chức vụ cho nhân viên đã ký hợp đồng chính thức.");
            return KetQuaXuLy.Ok("");
        }

        // ===================== QUYẾT ĐỊNH LƯƠNG =====================
        public DataTable LayQuyetDinhLuong(string maNV)
        {
            return Db.Query(@"SELECT SoQD, MaNV, NgayKy, NgayHieuLuc, LuongCoBan, PhuCapLuong, PhuCapDocHai, NguoiKy
                              FROM QuyetDinhLuong WHERE MaNV=@Ma ORDER BY NgayHieuLuc DESC",
                new SqlParameter("@Ma", maNV ?? ""));
        }

        public KetQuaXuLy LapQuyetDinhLuong(QuyetDinhLuong qd)
        {
            if (qd == null || string.IsNullOrWhiteSpace(qd.SoQD) || string.IsNullOrWhiteSpace(qd.MaNV) ||
                string.IsNullOrWhiteSpace(qd.NguoiKy))
                return KetQuaXuLy.Loi("Vui lòng nhập Số QĐ, nhân viên và người ký.");
            if (qd.LuongCoBan <= 0) return KetQuaXuLy.Loi("Lương cơ bản phải lớn hơn 0.");
            if (qd.PhuCapLuong < 0 || qd.PhuCapDocHai < 0) return KetQuaXuLy.Loi("Phụ cấp không được âm.");
            if (qd.NgayHieuLuc.Date < qd.NgayKy.Date) return KetQuaXuLy.Loi("Ngày hiệu lực không được trước ngày ký.");
            KetQuaXuLy kt = KiemTraNhanVienChinhThuc(qd.MaNV);
            if (!kt.ThanhCong) return kt;
            try
            {
                Db.Execute(@"INSERT INTO QuyetDinhLuong(SoQD, MaNV, NgayKy, NgayHieuLuc, LuongCoBan, PhuCapLuong, PhuCapDocHai, NguoiKy)
                             VALUES(@SoQD, @MaNV, @NgayKy, @HieuLuc, @LCB, @PCL, @PCDH, @NguoiKy)",
                    new SqlParameter("@SoQD", qd.SoQD.Trim()),
                    new SqlParameter("@MaNV", qd.MaNV),
                    new SqlParameter("@NgayKy", qd.NgayKy.Date),
                    new SqlParameter("@HieuLuc", qd.NgayHieuLuc.Date),
                    new SqlParameter("@LCB", qd.LuongCoBan),
                    new SqlParameter("@PCL", qd.PhuCapLuong),
                    new SqlParameter("@PCDH", qd.PhuCapDocHai),
                    new SqlParameter("@NguoiKy", qd.NguoiKy.Trim()));
                return KetQuaXuLy.Ok("Lập quyết định lương " + qd.SoQD.Trim() + " thành công.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return KetQuaXuLy.Loi("Số QĐ đã tồn tại hoặc nhân viên đã có QĐ lương cùng ngày hiệu lực.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== QUYẾT ĐỊNH CHỨC VỤ =====================
        public DataTable LayQuyetDinhChucVu(string maNV)
        {
            return Db.Query(@"SELECT qd.SoQD, qd.MaNV, cv.TenCV, pb.TenPB, qd.NgayKy, qd.NgayHieuLuc, qd.PhuCapChucVu, qd.NguoiKy
                              FROM QuyetDinhChucVu qd
                              JOIN ChucVu cv ON cv.MaCV = qd.MaCV
                              JOIN PhongBan pb ON pb.MaPB = qd.MaPB
                              WHERE qd.MaNV=@Ma ORDER BY qd.NgayHieuLuc DESC",
                new SqlParameter("@Ma", maNV ?? ""));
        }

        public KetQuaXuLy LapQuyetDinhChucVu(QuyetDinhChucVu qd)
        {
            if (qd == null || string.IsNullOrWhiteSpace(qd.SoQD) || string.IsNullOrWhiteSpace(qd.MaNV) ||
                string.IsNullOrWhiteSpace(qd.MaCV) || string.IsNullOrWhiteSpace(qd.MaPB) || string.IsNullOrWhiteSpace(qd.NguoiKy))
                return KetQuaXuLy.Loi("Vui lòng nhập Số QĐ, nhân viên, chức vụ, phòng ban và người ký.");
            if (qd.PhuCapChucVu < 0) return KetQuaXuLy.Loi("Phụ cấp chức vụ không được âm.");
            if (qd.NgayHieuLuc.Date < qd.NgayKy.Date) return KetQuaXuLy.Loi("Ngày hiệu lực không được trước ngày ký.");
            KetQuaXuLy kt = KiemTraNhanVienChinhThuc(qd.MaNV);
            if (!kt.ThanhCong) return kt;

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    Db.ExecuteTx(cn, tx, @"INSERT INTO QuyetDinhChucVu(SoQD, MaNV, MaCV, MaPB, NgayKy, NgayHieuLuc, PhuCapChucVu, NguoiKy)
                                           VALUES(@SoQD, @MaNV, @MaCV, @MaPB, @NgayKy, @HieuLuc, @PC, @NguoiKy)",
                        new SqlParameter("@SoQD", qd.SoQD.Trim()),
                        new SqlParameter("@MaNV", qd.MaNV),
                        new SqlParameter("@MaCV", qd.MaCV),
                        new SqlParameter("@MaPB", qd.MaPB),
                        new SqlParameter("@NgayKy", qd.NgayKy.Date),
                        new SqlParameter("@HieuLuc", qd.NgayHieuLuc.Date),
                        new SqlParameter("@PC", qd.PhuCapChucVu),
                        new SqlParameter("@NguoiKy", qd.NguoiKy.Trim()));
                    // Bổ nhiệm/điều chuyển: cập nhật phòng ban hiện tại của nhân viên
                    Db.ExecuteTx(cn, tx, "UPDATE NhanVien SET MaPB=@MaPB WHERE MaNV=@MaNV",
                        new SqlParameter("@MaPB", qd.MaPB), new SqlParameter("@MaNV", qd.MaNV));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Lập quyết định chức vụ " + qd.SoQD.Trim() + " thành công.");
                }
                catch (SqlException ex)
                {
                    try { tx.Rollback(); } catch { }
                    if (ex.Number == 2627 || ex.Number == 2601)
                        return KetQuaXuLy.Loi("Số QĐ đã tồn tại hoặc nhân viên đã có QĐ chức vụ cùng ngày hiệu lực.");
                    return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        // Mô tả lương - chức vụ đang hiệu lực tại một ngày (hiển thị trên Form)
        public string MoTaHienHanh(string maNV, DateTime ngay)
        {
            DataTable l = Db.Query(@"SELECT TOP 1 LuongCoBan, PhuCapLuong, PhuCapDocHai FROM QuyetDinhLuong
                                     WHERE MaNV=@Ma AND NgayHieuLuc<=@Ngay ORDER BY NgayHieuLuc DESC",
                new SqlParameter("@Ma", maNV ?? ""), new SqlParameter("@Ngay", ngay.Date));
            DataTable c = Db.Query(@"SELECT TOP 1 cv.TenCV, qd.PhuCapChucVu FROM QuyetDinhChucVu qd JOIN ChucVu cv ON cv.MaCV=qd.MaCV
                                     WHERE qd.MaNV=@Ma AND qd.NgayHieuLuc<=@Ngay ORDER BY qd.NgayHieuLuc DESC",
                new SqlParameter("@Ma", maNV ?? ""), new SqlParameter("@Ngay", ngay.Date));
            string s = l.Rows.Count == 0 ? "Chưa có QĐ lương" :
                "LCB " + Convert.ToDecimal(l.Rows[0]["LuongCoBan"]).ToString("N0") +
                " | PC lương " + Convert.ToDecimal(l.Rows[0]["PhuCapLuong"]).ToString("N0") +
                " | PC độc hại " + Convert.ToDecimal(l.Rows[0]["PhuCapDocHai"]).ToString("N0");
            s += c.Rows.Count == 0 ? "  ||  Chưa có QĐ chức vụ" :
                "  ||  " + Convert.ToString(c.Rows[0]["TenCV"]) + " - PC chức vụ " +
                Convert.ToDecimal(c.Rows[0]["PhuCapChucVu"]).ToString("N0");
            return "Hiện hành: " + s;
        }
    }
}
