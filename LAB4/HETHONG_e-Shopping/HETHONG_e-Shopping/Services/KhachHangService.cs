using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using EShopping.Data;
using EShopping.Models;

namespace EShopping.Services
{
    public class KhachHangService
    {
        public ServiceResult DangKy(KhachHang kh)
        {
            // 1. Kiểm tra hợp lệ
            ServiceResult kt = KiemTraKhachHang(kh);
            if (kt.Success == false)
                return kt;

            // 2. Kiểm tra trùng
            if (DaTonTai("TenDangNhap", kh.TenDangNhap.Trim()))
                return ServiceResult.Fail("Tên đăng nhập đã tồn tại.");

            if (DaTonTai("CmndPassport", kh.CmndPassport.Trim()))
                return ServiceResult.Fail("CMND/Passport đã được đăng ký.");

            // 3. Băm mật khẩu với salt ngẫu nhiên
            byte[] salt = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);
            string hash = BamMatKhau(kh.MatKhau, salt);

            // 4. Lưu vào CSDL
            object email = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(kh.Email))
                email = kh.Email.Trim();

            string sql = "INSERT INTO KhachHang(HoTen, NgaySinh, CmndPassport, DiaChi, DienThoai, " +
                         "TenDangNhap, MatKhauHash, Salt, Email) " +
                         "VALUES(@ten, @ns, @cmnd, @dc, @dt, @user, @hash, @salt, @mail); " +
                         "SELECT SCOPE_IDENTITY();";

            object kq = Db.ExecuteScalar(sql,
                new SqlParameter("@ten", kh.HoTen.Trim()),
                new SqlParameter("@ns", kh.NgaySinh.Date),
                new SqlParameter("@cmnd", kh.CmndPassport.Trim()),
                new SqlParameter("@dc", kh.DiaChi.Trim()),
                new SqlParameter("@dt", kh.DienThoai.Trim()),
                new SqlParameter("@user", kh.TenDangNhap.Trim()),
                new SqlParameter("@hash", hash),
                new SqlParameter("@salt", Convert.ToBase64String(salt)),
                new SqlParameter("@mail", email));

            return ServiceResult.Ok("Đăng ký thành công!", Convert.ToInt32(kq));
        }

        public ServiceResult DangNhap(string user, string pass)
        {
            DataTable dt = Db.ExecuteQuery(
                "SELECT MaKH, MatKhauHash, Salt FROM KhachHang WHERE TenDangNhap = @u",
                new SqlParameter("@u", user));

            if (dt.Rows.Count == 0)
                return ServiceResult.Fail("Sai tên đăng nhập hoặc mật khẩu.");

            DataRow row = dt.Rows[0];
            byte[] salt = Convert.FromBase64String(row["Salt"].ToString());
            string hash = BamMatKhau(pass, salt);

            if (hash != row["MatKhauHash"].ToString())
                return ServiceResult.Fail("Sai tên đăng nhập hoặc mật khẩu.");

            return ServiceResult.Ok("Đăng nhập thành công.", Convert.ToInt32(row["MaKH"]));
        }

        // ---------- Các hàm phụ ----------

        private ServiceResult KiemTraKhachHang(KhachHang kh)
        {
            if (string.IsNullOrWhiteSpace(kh.HoTen) || kh.HoTen.Trim().Length < 2)
                return ServiceResult.Fail("Họ tên không hợp lệ.");

            // Tính tuổi
            int tuoi = DateTime.Today.Year - kh.NgaySinh.Year;
            if (kh.NgaySinh.Date > DateTime.Today.AddYears(-tuoi))
                tuoi = tuoi - 1;
            if (tuoi < 18 || tuoi > 120)
                return ServiceResult.Fail("Khách hàng phải từ 18 tuổi trở lên.");

            // CMND 9 hoặc 12 số, Passport 1 chữ + 7-8 số
            if (string.IsNullOrWhiteSpace(kh.CmndPassport) ||
                !Regex.IsMatch(kh.CmndPassport.Trim(), @"^(\d{9}|\d{12}|[A-Za-z]\d{7,8})$"))
                return ServiceResult.Fail("CMND (9 hoặc 12 số) / Passport (1 chữ + 7-8 số) không hợp lệ.");

            if (string.IsNullOrWhiteSpace(kh.DiaChi))
                return ServiceResult.Fail("Địa chỉ không được để trống.");

            if (string.IsNullOrWhiteSpace(kh.DienThoai) ||
                !Regex.IsMatch(kh.DienThoai.Trim(), @"^0\d{9}$"))
                return ServiceResult.Fail("Số điện thoại gồm 10 số, bắt đầu bằng 0.");

            if (string.IsNullOrWhiteSpace(kh.TenDangNhap) ||
                !Regex.IsMatch(kh.TenDangNhap.Trim(), @"^[A-Za-z0-9_]{4,20}$"))
                return ServiceResult.Fail("Tên đăng nhập 4-20 ký tự (chữ, số, gạch dưới).");

            if (string.IsNullOrEmpty(kh.MatKhau) || kh.MatKhau.Length < 8 ||
                !Regex.IsMatch(kh.MatKhau, "[A-Za-z]") || !Regex.IsMatch(kh.MatKhau, "[0-9]"))
                return ServiceResult.Fail("Mật khẩu tối thiểu 8 ký tự, gồm cả chữ và số.");

            // Email không bắt buộc, nhưng nếu nhập thì phải đúng dạng
            if (!string.IsNullOrWhiteSpace(kh.Email) &&
                !Regex.IsMatch(kh.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return ServiceResult.Fail("Email không hợp lệ.");

            return ServiceResult.Ok("Hợp lệ.");
        }

        // Kiểm tra 1 giá trị đã có trong bảng KhachHang chưa (cột chỉ là tên cố định, không phải dữ liệu người dùng)
        private bool DaTonTai(string cot, string giaTri)
        {
            string sql = "SELECT COUNT(*) FROM KhachHang WHERE " + cot + " = @v";
            object kq = Db.ExecuteScalar(sql, new SqlParameter("@v", giaTri));
            return Convert.ToInt32(kq) > 0;
        }

        // PBKDF2 (Rfc2898DeriveBytes) + salt
        private string BamMatKhau(string matKhau, byte[] salt)
        {
            Rfc2898DeriveBytes kdf = new Rfc2898DeriveBytes(matKhau, salt, 100000, HashAlgorithmName.SHA256);
            return Convert.ToBase64String(kdf.GetBytes(32));
        }
    }
}