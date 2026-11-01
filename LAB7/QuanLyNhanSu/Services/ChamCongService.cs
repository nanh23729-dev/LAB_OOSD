using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class ChamCongService
    {
        // ===================== KẾ HOẠCH PHÂN CÔNG TUẦN =====================
        public DataTable LayKeHoach(string maPB)
        {
            return Db.Query(@"SELECT MaKH, MaPB, TuNgay, DenNgay, MaNVLap, NgayLap FROM KeHoachPhanCong
                              WHERE MaPB=@PB ORDER BY TuNgay DESC", new SqlParameter("@PB", maPB ?? ""));
        }

        public KetQuaXuLy LapKeHoach(string maPB, DateTime tuNgay, string maNVLap)
        {
            if (string.IsNullOrWhiteSpace(maPB) || string.IsNullOrWhiteSpace(maNVLap))
                return KetQuaXuLy.Loi("Vui lòng chọn phòng ban và người lập.");
            if (tuNgay.DayOfWeek != DayOfWeek.Monday)
                return KetQuaXuLy.Loi("Kế hoạch tuần phải bắt đầu từ Thứ Hai.");
            string maKH = "KH-" + maPB + "-" + tuNgay.ToString("yyyyMMdd");
            try
            {
                Db.Execute(@"INSERT INTO KeHoachPhanCong(MaKH, MaPB, TuNgay, DenNgay, MaNVLap, NgayLap)
                             VALUES(@MaKH, @PB, @Tu, @Den, @NV, @NgayLap)",
                    new SqlParameter("@MaKH", maKH),
                    new SqlParameter("@PB", maPB),
                    new SqlParameter("@Tu", tuNgay.Date),
                    new SqlParameter("@Den", tuNgay.Date.AddDays(6)),
                    new SqlParameter("@NV", maNVLap),
                    new SqlParameter("@NgayLap", DateTime.Today));
                return KetQuaXuLy.Ok("Lập kế hoạch " + maKH + " thành công. Hãy thêm phân công cho từng nhân viên.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Phòng ban đã có kế hoạch cho tuần này.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public DataTable LayChiTietPhanCong(string maKH)
        {
            return Db.Query(@"SELECT ct.MaNV, nv.HoTen, ct.NgayLam, ct.MaCa, ca.TenCa, ct.GioPhuTroiDuKien
                              FROM ChiTietPhanCong ct JOIN NhanVien nv ON nv.MaNV = ct.MaNV
                              JOIN CaLamViec ca ON ca.MaCa = ct.MaCa
                              WHERE ct.MaKH=@KH ORDER BY ct.NgayLam, ct.MaNV", new SqlParameter("@KH", maKH ?? ""));
        }

        public KetQuaXuLy ThemPhanCong(string maKH, string maNV, DateTime ngayLam, string maCa, decimal gioPhuTroi)
        {
            if (string.IsNullOrWhiteSpace(maKH)) return KetQuaXuLy.Loi("Vui lòng chọn kế hoạch tuần.");
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(maCa)) return KetQuaXuLy.Loi("Vui lòng chọn nhân viên và ca.");
            if (gioPhuTroi < 0 || gioPhuTroi > 4) return KetQuaXuLy.Loi("Giờ phụ trội dự kiến trong ngày từ 0 đến 4 giờ.");

            DataTable kh = Db.Query("SELECT MaPB, TuNgay, DenNgay FROM KeHoachPhanCong WHERE MaKH=@KH", new SqlParameter("@KH", maKH));
            if (kh.Rows.Count == 0) return KetQuaXuLy.Loi("Không tìm thấy kế hoạch.");
            DateTime tu = Convert.ToDateTime(kh.Rows[0]["TuNgay"]);
            DateTime den = Convert.ToDateTime(kh.Rows[0]["DenNgay"]);
            if (ngayLam.Date < tu || ngayLam.Date > den) return KetQuaXuLy.Loi("Ngày làm phải nằm trong tuần của kế hoạch.");

            DataTable nv = Db.Query("SELECT MaPB, TrangThai FROM NhanVien WHERE MaNV=@NV", new SqlParameter("@NV", maNV));
            if (nv.Rows.Count == 0) return KetQuaXuLy.Loi("Không tìm thấy nhân viên.");
            if (Convert.ToString(nv.Rows[0]["MaPB"]) != Convert.ToString(kh.Rows[0]["MaPB"]))
                return KetQuaXuLy.Loi("Nhân viên không thuộc phòng ban của kế hoạch.");
            string tt = Convert.ToString(nv.Rows[0]["TrangThai"]);
            if (tt != "Thử việc" && tt != "Chính thức") return KetQuaXuLy.Loi("Nhân viên không còn làm việc.");
            try
            {
                Db.Execute(@"INSERT INTO ChiTietPhanCong(MaKH, MaNV, NgayLam, MaCa, GioPhuTroiDuKien)
                             VALUES(@KH, @NV, @Ngay, @Ca, @PT)",
                    new SqlParameter("@KH", maKH), new SqlParameter("@NV", maNV), new SqlParameter("@Ngay", ngayLam.Date),
                    new SqlParameter("@Ca", maCa), new SqlParameter("@PT", gioPhuTroi));
                return KetQuaXuLy.Ok("Đã thêm phân công.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Nhân viên đã được phân công trong ngày này.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public KetQuaXuLy XoaPhanCong(string maKH, string maNV, DateTime ngayLam)
        {
            int n = Db.Execute("DELETE FROM ChiTietPhanCong WHERE MaKH=@KH AND MaNV=@NV AND NgayLam=@Ngay",
                new SqlParameter("@KH", maKH ?? ""), new SqlParameter("@NV", maNV ?? ""), new SqlParameter("@Ngay", ngayLam.Date));
            return n > 0 ? KetQuaXuLy.Ok("Đã xóa phân công.") : KetQuaXuLy.Loi("Không tìm thấy dòng phân công.");
        }

        // ===================== BẢNG CHẤM CÔNG THÁNG =====================
        // Trả về mã bảng chấm công (tạo mới nếu chưa có)
        public KetQuaXuLy MoBangChamCong(string maPB, int thang, int nam, string maNVLap, out string maBCC)
        {
            maBCC = "";
            if (string.IsNullOrWhiteSpace(maPB) || string.IsNullOrWhiteSpace(maNVLap))
                return KetQuaXuLy.Loi("Vui lòng chọn phòng ban và nhân viên ban chấm công.");
            object pbLap = Db.Scalar("SELECT MaPB FROM NhanVien WHERE MaNV=@NV", new SqlParameter("@NV", maNVLap));
            if (Convert.ToString(pbLap) != "BCC") return KetQuaXuLy.Loi("Bảng chấm công phải do nhân viên Ban chấm công lập.");

            object ma = Db.Scalar("SELECT MaBCC FROM BangChamCong WHERE MaPB=@PB AND Thang=@T AND Nam=@N",
                new SqlParameter("@PB", maPB), new SqlParameter("@T", thang), new SqlParameter("@N", nam));
            if (ma != null) { maBCC = Convert.ToString(ma); return KetQuaXuLy.Ok("Đã mở bảng chấm công " + maBCC + "."); }

            maBCC = "BCC-" + maPB + "-" + nam.ToString("0000") + thang.ToString("00");
            Db.Execute(@"INSERT INTO BangChamCong(MaBCC, MaPB, Thang, Nam, NgayLap, MaNVLap) VALUES(@Ma, @PB, @T, @N, @Ngay, @NV)",
                new SqlParameter("@Ma", maBCC), new SqlParameter("@PB", maPB), new SqlParameter("@T", thang),
                new SqlParameter("@N", nam), new SqlParameter("@Ngay", DateTime.Today), new SqlParameter("@NV", maNVLap));
            return KetQuaXuLy.Ok("Đã tạo bảng chấm công " + maBCC + ".");
        }

        public DataTable LayChiTietChamCong(string maBCC)
        {
            return Db.Query(@"SELECT ct.MaNV, nv.HoTen, ct.SoNgayCong, ct.SoNgayNghiPhep, ct.SoNgayNghiKhongPhep
                              FROM ChiTietChamCong ct JOIN NhanVien nv ON nv.MaNV = ct.MaNV
                              WHERE ct.MaBCC=@Ma ORDER BY ct.MaNV", new SqlParameter("@Ma", maBCC ?? ""));
        }

        public KetQuaXuLy LuuChamCong(string maBCC, string maNV, decimal ngayCong, decimal nghiPhep, decimal nghiKhongPhep)
        {
            if (string.IsNullOrWhiteSpace(maBCC)) return KetQuaXuLy.Loi("Vui lòng tạo/mở bảng chấm công trước.");
            if (string.IsNullOrWhiteSpace(maNV)) return KetQuaXuLy.Loi("Vui lòng chọn nhân viên.");
            if (ngayCong < 0 || nghiPhep < 0 || nghiKhongPhep < 0) return KetQuaXuLy.Loi("Số ngày không được âm.");

            DataTable b = Db.Query("SELECT MaPB, Thang, Nam FROM BangChamCong WHERE MaBCC=@Ma", new SqlParameter("@Ma", maBCC));
            if (b.Rows.Count == 0) return KetQuaXuLy.Loi("Không tìm thấy bảng chấm công.");
            int soNgayThang = DateTime.DaysInMonth(Convert.ToInt32(b.Rows[0]["Nam"]), Convert.ToInt32(b.Rows[0]["Thang"]));
            if (ngayCong + nghiPhep + nghiKhongPhep > soNgayThang)
                return KetQuaXuLy.Loi("Tổng ngày công và ngày nghỉ vượt quá " + soNgayThang + " ngày của tháng.");
            object pb = Db.Scalar("SELECT MaPB FROM NhanVien WHERE MaNV=@NV", new SqlParameter("@NV", maNV));
            if (Convert.ToString(pb) != Convert.ToString(b.Rows[0]["MaPB"]))
                return KetQuaXuLy.Loi("Nhân viên không thuộc phòng ban của bảng chấm công.");

            // Có rồi thì cập nhật, chưa có thì thêm mới
            int n = Db.Execute(@"UPDATE ChiTietChamCong SET SoNgayCong=@C, SoNgayNghiPhep=@P, SoNgayNghiKhongPhep=@K
                                 WHERE MaBCC=@Ma AND MaNV=@NV",
                new SqlParameter("@C", ngayCong), new SqlParameter("@P", nghiPhep), new SqlParameter("@K", nghiKhongPhep),
                new SqlParameter("@Ma", maBCC), new SqlParameter("@NV", maNV));
            if (n == 0)
                Db.Execute(@"INSERT INTO ChiTietChamCong(MaBCC, MaNV, SoNgayCong, SoNgayNghiPhep, SoNgayNghiKhongPhep)
                             VALUES(@Ma, @NV, @C, @P, @K)",
                    new SqlParameter("@Ma", maBCC), new SqlParameter("@NV", maNV), new SqlParameter("@C", ngayCong),
                    new SqlParameter("@P", nghiPhep), new SqlParameter("@K", nghiKhongPhep));
            return KetQuaXuLy.Ok("Đã lưu chấm công cho " + maNV + ".");
        }

        // ===================== PHIẾU GHI NHẬN PHỤ TRỘI =====================
        public DataTable LayPhieuPhuTroi()
        {
            return Db.Query(@"SELECT p.SoPhieu, p.NgayPhuTroi, p.HinhThuc, p.SoGioPhuTroi, p.MaPB, p.MaNVLap,
                                     (SELECT COUNT(*) FROM ChiTietPhuTroi c WHERE c.SoPhieu = p.SoPhieu) AS SoNguoi
                              FROM PhieuPhuTroi p ORDER BY p.NgayPhuTroi DESC");
        }

        // dsNhanVien: danh sách (MaNV, SoGio) tham gia phụ trội
        public KetQuaXuLy LapPhieuPhuTroi(PhieuPhuTroi p, IList<KeyValuePair<string, decimal>> dsNhanVien)
        {
            if (p == null || string.IsNullOrWhiteSpace(p.SoPhieu) || string.IsNullOrWhiteSpace(p.HinhThuc) ||
                string.IsNullOrWhiteSpace(p.MaPB) || string.IsNullOrWhiteSpace(p.MaNVLap))
                return KetQuaXuLy.Loi("Vui lòng nhập Số phiếu, hình thức, phòng ban và người lập.");
            if (p.SoGioPhuTroi <= 0 || p.SoGioPhuTroi > 12) return KetQuaXuLy.Loi("Số giờ phụ trội của phiếu từ 0.5 đến 12 giờ.");
            if (dsNhanVien == null || dsNhanVien.Count == 0) return KetQuaXuLy.Loi("Phiếu phụ trội phải có ít nhất một nhân viên.");
            HashSet<string> trung = new HashSet<string>();
            foreach (KeyValuePair<string, decimal> x in dsNhanVien)
            {
                if (!trung.Add(x.Key)) return KetQuaXuLy.Loi("Nhân viên " + x.Key + " bị trùng trong phiếu.");
                if (x.Value <= 0 || x.Value > p.SoGioPhuTroi)
                    return KetQuaXuLy.Loi("Giờ phụ trội của " + x.Key + " phải lớn hơn 0 và không vượt số giờ của phiếu.");
            }

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    object pbLap = Db.ScalarTx(cn, tx, "SELECT MaPB FROM NhanVien WHERE MaNV=@NV", new SqlParameter("@NV", p.MaNVLap));
                    if (Convert.ToString(pbLap) != "BCC")
                    { tx.Rollback(); return KetQuaXuLy.Loi("Phiếu phụ trội phải do nhân viên Ban chấm công lập."); }

                    Db.ExecuteTx(cn, tx, @"INSERT INTO PhieuPhuTroi(SoPhieu, NgayPhuTroi, SoGioPhuTroi, HinhThuc, MaPB, MaNVLap)
                                           VALUES(@So, @Ngay, @Gio, @HT, @PB, @NV)",
                        new SqlParameter("@So", p.SoPhieu.Trim()), new SqlParameter("@Ngay", p.NgayPhuTroi.Date),
                        new SqlParameter("@Gio", p.SoGioPhuTroi), new SqlParameter("@HT", p.HinhThuc),
                        new SqlParameter("@PB", p.MaPB), new SqlParameter("@NV", p.MaNVLap));
                    foreach (KeyValuePair<string, decimal> x in dsNhanVien)
                    {
                        object pb = Db.ScalarTx(cn, tx, "SELECT MaPB FROM NhanVien WHERE MaNV=@NV", new SqlParameter("@NV", x.Key));
                        if (Convert.ToString(pb) != p.MaPB)
                            throw new InvalidOperationException("Nhân viên " + x.Key + " không thuộc phòng ban " + p.MaPB + ".");
                        Db.ExecuteTx(cn, tx, "INSERT INTO ChiTietPhuTroi(SoPhieu, MaNV, SoGio) VALUES(@So, @NV, @Gio)",
                            new SqlParameter("@So", p.SoPhieu.Trim()), new SqlParameter("@NV", x.Key), new SqlParameter("@Gio", x.Value));
                    }
                    tx.Commit();
                    return KetQuaXuLy.Ok("Lập phiếu phụ trội " + p.SoPhieu.Trim() + " cho " + dsNhanVien.Count + " nhân viên thành công.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    SqlException sqlEx = ex as SqlException;
                    if (sqlEx != null && (sqlEx.Number == 2627 || sqlEx.Number == 2601)) return KetQuaXuLy.Loi("Số phiếu đã tồn tại.");
                    return KetQuaXuLy.Loi("Không thể lập phiếu phụ trội: " + ex.Message);
                }
            }
        }
    }
}
