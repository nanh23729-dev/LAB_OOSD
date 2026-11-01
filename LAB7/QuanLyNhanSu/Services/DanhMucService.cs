using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class DanhMucService
    {
        // ===================== PHÒNG BAN =====================
        public DataTable LayPhongBan()
        {
            return Db.Query("SELECT MaPB, TenPB, LoaiDonVi, DienThoai FROM PhongBan ORDER BY MaPB");
        }

        public KetQuaXuLy LuuPhongBan(string ma, string ten, string loai, string dienThoai, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(loai))
                return KetQuaXuLy.Loi("Mã, tên và loại đơn vị không được để trống.");
            try
            {
                string sql = capNhat
                    ? "UPDATE PhongBan SET TenPB=@Ten, LoaiDonVi=@Loai, DienThoai=@DT WHERE MaPB=@Ma"
                    : "INSERT INTO PhongBan(MaPB, TenPB, LoaiDonVi, DienThoai) VALUES(@Ma, @Ten, @Loai, @DT)";
                int n = Db.Execute(sql,
                    new SqlParameter("@Ma", ma.Trim()),
                    new SqlParameter("@Ten", ten.Trim()),
                    new SqlParameter("@Loai", loai),
                    new SqlParameter("@DT", Db.NullIfEmpty(dienThoai)));
                return n > 0 ? KetQuaXuLy.Ok("Lưu phòng ban thành công.") : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã hoặc tên phòng ban đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== CHỨC VỤ =====================
        public DataTable LayChucVu()
        {
            return Db.Query("SELECT MaCV, TenCV FROM ChucVu ORDER BY MaCV");
        }

        public KetQuaXuLy LuuChucVu(string ma, string ten, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                return KetQuaXuLy.Loi("Mã và tên chức vụ không được để trống.");
            try
            {
                string sql = capNhat
                    ? "UPDATE ChucVu SET TenCV=@Ten WHERE MaCV=@Ma"
                    : "INSERT INTO ChucVu(MaCV, TenCV) VALUES(@Ma, @Ten)";
                int n = Db.Execute(sql, new SqlParameter("@Ma", ma.Trim()), new SqlParameter("@Ten", ten.Trim()));
                return n > 0 ? KetQuaXuLy.Ok("Lưu chức vụ thành công.") : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã hoặc tên chức vụ đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== CA LÀM VIỆC =====================
        public DataTable LayCaLamViec()
        {
            return Db.Query(@"SELECT MaCa, TenCa, CONVERT(VARCHAR(5), GioBatDau, 108) AS GioBatDau,
                                     CONVERT(VARCHAR(5), GioKetThuc, 108) AS GioKetThuc, SoGio
                              FROM CaLamViec ORDER BY MaCa");
        }

        public KetQuaXuLy LuuCaLamViec(string ma, string ten, DateTime batDau, DateTime ketThuc, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                return KetQuaXuLy.Loi("Mã và tên ca không được để trống.");
            TimeSpan bd = new TimeSpan(batDau.Hour, batDau.Minute, 0);
            TimeSpan kt = new TimeSpan(ketThuc.Hour, ketThuc.Minute, 0);
            // Ca qua đêm (ví dụ 22:00 - 06:00) thì cộng thêm 24 giờ
            double soGio = (kt - bd).TotalHours;
            if (soGio <= 0) soGio += 24;
            if (soGio > 12) return KetQuaXuLy.Loi("Một ca làm việc không được dài quá 12 giờ.");
            try
            {
                string sql = capNhat
                    ? "UPDATE CaLamViec SET TenCa=@Ten, GioBatDau=@BD, GioKetThuc=@KT, SoGio=@SoGio WHERE MaCa=@Ma"
                    : "INSERT INTO CaLamViec(MaCa, TenCa, GioBatDau, GioKetThuc, SoGio) VALUES(@Ma, @Ten, @BD, @KT, @SoGio)";
                int n = Db.Execute(sql,
                    new SqlParameter("@Ma", ma.Trim()),
                    new SqlParameter("@Ten", ten.Trim()),
                    new SqlParameter("@BD", bd),
                    new SqlParameter("@KT", kt),
                    new SqlParameter("@SoGio", (decimal)soGio));
                return n > 0 ? KetQuaXuLy.Ok("Lưu ca làm việc thành công.") : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã ca đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== XÓA DÙNG CHUNG =====================
        public KetQuaXuLy Xoa(string bang, string cotMa, string ma)
        {
            string[] bangChoPhep = { "PhongBan", "ChucVu", "CaLamViec" };
            string[] cotChoPhep = { "MaPB", "MaCV", "MaCa" };
            int index = Array.IndexOf(bangChoPhep, bang);
            if (index < 0 || cotChoPhep[index] != cotMa) return KetQuaXuLy.Loi("Tham số xóa không hợp lệ.");
            if (string.IsNullOrWhiteSpace(ma)) return KetQuaXuLy.Loi("Vui lòng chọn dòng cần xóa.");
            try
            {
                int n = Db.Execute("DELETE FROM " + bang + " WHERE " + cotMa + "=@Ma", new SqlParameter("@Ma", ma.Trim()));
                return n > 0 ? KetQuaXuLy.Ok("Xóa dữ liệu thành công.") : KetQuaXuLy.Loi("Không tìm thấy dữ liệu để xóa.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) return KetQuaXuLy.Loi("Không thể xóa vì dữ liệu đang được sử dụng ở nghiệp vụ khác.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
