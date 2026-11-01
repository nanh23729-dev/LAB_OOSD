using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaoOc.Data;

namespace QuanLyCaoOc.Services
{
    // Danh mục: tầng, phòng, loại dịch vụ
    public class DanhMucService
    {
        // ===================== TẦNG =====================
        public DataTable LayTang()
        {
            return Db.Query("SELECT MaTang, SoTang, TenTang, DoCao, DonGiaM2 FROM Tang ORDER BY SoTang");
        }

        public KetQuaXuLy LuuTang(string ma, int soTang, string ten, decimal doCao, decimal donGiaM2, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                return KetQuaXuLy.Loi("Mã tầng và tên tầng không được để trống.");
            if (soTang <= 0 || doCao <= 0 || donGiaM2 <= 0)
                return KetQuaXuLy.Loi("Số tầng, độ cao và đơn giá phải lớn hơn 0.");
            try
            {
                string sql = capNhat
                    ? "UPDATE Tang SET SoTang=@So, TenTang=@Ten, DoCao=@Cao, DonGiaM2=@Gia WHERE MaTang=@Ma"
                    : "INSERT INTO Tang(MaTang, SoTang, TenTang, DoCao, DonGiaM2) VALUES(@Ma, @So, @Ten, @Cao, @Gia)";
                int n = Db.Execute(sql, new SqlParameter("@Ma", ma.Trim()), new SqlParameter("@So", soTang),
                    new SqlParameter("@Ten", ten.Trim()), new SqlParameter("@Cao", doCao), new SqlParameter("@Gia", donGiaM2));
                return n > 0 ? KetQuaXuLy.Ok("Lưu tầng thành công.") : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã tầng hoặc số tầng đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== PHÒNG =====================
        public DataTable LayPhong(string maTang, string trangThai)
        {
            return Db.Query(@"SELECT p.MaPhong, p.MaTang, t.SoTang, p.DienTich, p.Huong, p.GiaThue, p.TrangThai, p.NgayKiemTraCuoi
                              FROM Phong p JOIN Tang t ON t.MaTang = p.MaTang
                              WHERE (@Tang = '' OR p.MaTang = @Tang) AND (@TT = '' OR p.TrangThai = @TT)
                              ORDER BY t.SoTang, p.MaPhong",
                new SqlParameter("@Tang", maTang ?? ""), new SqlParameter("@TT", trangThai ?? ""));
        }

        // Phòng còn trống để khách tham khảo vị trí, diện tích, giá
        public DataTable LayPhongTrong()
        {
            return Db.Query(@"SELECT p.MaPhong, t.SoTang, t.DoCao, p.DienTich, p.Huong, p.GiaThue
                              FROM Phong p JOIN Tang t ON t.MaTang = p.MaTang
                              WHERE p.TrangThai = N'Trống' ORDER BY t.SoTang, p.MaPhong");
        }

        // Giá thuê ấn định theo độ cao (đơn giá m2 của tầng) và diện tích sử dụng
        public decimal TinhGiaThue(string maTang, decimal dienTich)
        {
            object gia = Db.Scalar("SELECT DonGiaM2 FROM Tang WHERE MaTang=@T", new SqlParameter("@T", maTang));
            if (gia == null || gia == DBNull.Value) return 0;
            return Math.Round(Convert.ToDecimal(gia) * dienTich, 0);
        }

        public KetQuaXuLy LuuPhong(string ma, string maTang, decimal dienTich, string huong, decimal giaThue, string trangThai, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(maTang) || string.IsNullOrWhiteSpace(huong))
                return KetQuaXuLy.Loi("Mã phòng, tầng và hướng không được để trống.");
            if (dienTich <= 0) return KetQuaXuLy.Loi("Diện tích sử dụng phải lớn hơn 0.");
            if (giaThue <= 0) giaThue = TinhGiaThue(maTang, dienTich);      // chưa nhập giá thì tự tính theo tầng
            if (giaThue <= 0) return KetQuaXuLy.Loi("Không tính được giá thuê, hãy kiểm tra đơn giá của tầng.");
            try
            {
                if (capNhat)
                {
                    object cu = Db.Scalar("SELECT TrangThai FROM Phong WHERE MaPhong=@P", new SqlParameter("@P", ma.Trim()));
                    if (cu == null) return KetQuaXuLy.Loi("Không tìm thấy phòng " + ma + ".");
                    // Trạng thái "Đang thuê" chỉ thay đổi thông qua hợp đồng
                    if ((Convert.ToString(cu) == "Đang thuê") != (trangThai == "Đang thuê"))
                        return KetQuaXuLy.Loi("Trạng thái Đang thuê chỉ thay đổi khi lập hoặc thanh lý hợp đồng.");
                }
                else if (trangThai == "Đang thuê")
                    return KetQuaXuLy.Loi("Phòng mới chỉ có thể ở trạng thái Trống hoặc Bảo trì.");

                string sql = capNhat
                    ? "UPDATE Phong SET MaTang=@Tang, DienTich=@DT, Huong=@Huong, GiaThue=@Gia, TrangThai=@TT WHERE MaPhong=@Ma"
                    : "INSERT INTO Phong(MaPhong, MaTang, DienTich, Huong, GiaThue, TrangThai) VALUES(@Ma, @Tang, @DT, @Huong, @Gia, @TT)";
                int n = Db.Execute(sql, new SqlParameter("@Ma", ma.Trim()), new SqlParameter("@Tang", maTang),
                    new SqlParameter("@DT", dienTich), new SqlParameter("@Huong", huong), new SqlParameter("@Gia", giaThue),
                    new SqlParameter("@TT", trangThai));
                return n > 0 ? KetQuaXuLy.Ok("Lưu phòng thành công. Giá thuê: " + giaThue.ToString("N0") + " đ/tháng.")
                             : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã phòng đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== LOẠI DỊCH VỤ =====================
        public DataTable LayDichVu()
        {
            return Db.Query("SELECT MaDV, TenDV, DonViTinh, DonGia FROM LoaiDichVu ORDER BY MaDV");
        }

        public KetQuaXuLy LuuDichVu(string ma, string ten, string donVi, decimal donGia, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(donVi))
                return KetQuaXuLy.Loi("Mã, tên và đơn vị tính không được để trống.");
            if (donGia < 0) return KetQuaXuLy.Loi("Đơn giá không được âm.");
            try
            {
                string sql = capNhat
                    ? "UPDATE LoaiDichVu SET TenDV=@Ten, DonViTinh=@DV, DonGia=@Gia WHERE MaDV=@Ma"
                    : "INSERT INTO LoaiDichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES(@Ma, @Ten, @DV, @Gia)";
                int n = Db.Execute(sql, new SqlParameter("@Ma", ma.Trim()), new SqlParameter("@Ten", ten.Trim()),
                    new SqlParameter("@DV", donVi.Trim()), new SqlParameter("@Gia", donGia));
                return n > 0 ? KetQuaXuLy.Ok("Lưu dịch vụ thành công.") : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã hoặc tên dịch vụ đã tồn tại.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ===================== XÓA DÙNG CHUNG =====================
        public KetQuaXuLy Xoa(string bang, string cot, string ma)
        {
            // chỉ cho xóa các bảng danh mục, tránh ghép chuỗi SQL từ dữ liệu bên ngoài
            if (bang != "Tang" && bang != "Phong" && bang != "LoaiDichVu" && bang != "KhachHang")
                return KetQuaXuLy.Loi("Bảng không được phép xóa.");
            if (string.IsNullOrWhiteSpace(ma)) return KetQuaXuLy.Loi("Chưa chọn dòng cần xóa.");
            try
            {
                int n = Db.Execute("DELETE FROM " + bang + " WHERE " + cot + "=@Ma", new SqlParameter("@Ma", ma));
                return n > 0 ? KetQuaXuLy.Ok("Đã xóa.") : KetQuaXuLy.Loi("Không tìm thấy dữ liệu cần xóa.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) return KetQuaXuLy.Loi("Không thể xóa vì dữ liệu đang được sử dụng ở nơi khác.");
                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
