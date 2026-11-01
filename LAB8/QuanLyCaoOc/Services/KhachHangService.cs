using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaoOc.Data;

namespace QuanLyCaoOc.Services
{
    public class KhachHangService
    {
        public DataTable LayKhachHang(string tuKhoa)
        {
            return Db.Query(@"SELECT MaKH, TenKH, LoaiKH, NguoiDaiDien, DienThoai, Email, DiaChi, MaSoThue
                              FROM KhachHang
                              WHERE @K = '' OR MaKH LIKE @L OR TenKH LIKE @L OR NguoiDaiDien LIKE @L OR DienThoai LIKE @L
                              ORDER BY MaKH",
                new SqlParameter("@K", (tuKhoa ?? "").Trim()), new SqlParameter("@L", "%" + (tuKhoa ?? "").Trim() + "%"));
        }

        public KetQuaXuLy Luu(string ma, string ten, string loai, string nguoiDaiDien, string dienThoai,
                              string email, string diaChi, string maSoThue, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(nguoiDaiDien) || string.IsNullOrWhiteSpace(dienThoai))
                return KetQuaXuLy.Loi("Mã, tên, người đại diện và điện thoại không được để trống.");
            if (dienThoai.Trim().Length < 9 || dienThoai.Trim().Length > 11)
                return KetQuaXuLy.Loi("Số điện thoại không hợp lệ (9 - 11 chữ số).");
            foreach (char c in dienThoai.Trim())
                if (!char.IsDigit(c)) return KetQuaXuLy.Loi("Số điện thoại chỉ gồm chữ số.");
            try
            {
                string sql = capNhat
                    ? @"UPDATE KhachHang SET TenKH=@Ten, LoaiKH=@Loai, NguoiDaiDien=@DD, DienThoai=@DT, Email=@Email, DiaChi=@DC, MaSoThue=@MST WHERE MaKH=@Ma"
                    : @"INSERT INTO KhachHang(MaKH, TenKH, LoaiKH, NguoiDaiDien, DienThoai, Email, DiaChi, MaSoThue)
                        VALUES(@Ma, @Ten, @Loai, @DD, @DT, @Email, @DC, @MST)";
                int n = Db.Execute(sql, new SqlParameter("@Ma", ma.Trim()), new SqlParameter("@Ten", ten.Trim()),
                    new SqlParameter("@Loai", loai), new SqlParameter("@DD", nguoiDaiDien.Trim()),
                    new SqlParameter("@DT", dienThoai.Trim()), new SqlParameter("@Email", Db.NullIfEmpty(email)),
                    new SqlParameter("@DC", Db.NullIfEmpty(diaChi)), new SqlParameter("@MST", Db.NullIfEmpty(maSoThue)));
                return n > 0 ? KetQuaXuLy.Ok("Lưu khách hàng thành công.") : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã khách hàng đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
