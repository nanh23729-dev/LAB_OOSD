using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaoOc.Data;

namespace QuanLyCaoOc.Services
{
    // Nhân viên làm việc tại phòng thuê và thẻ giữ xe
    public class NhanVienService
    {
        public DataTable LayPhongDangThue()
        {
            return Db.Query(@"SELECT DISTINCT c.MaPhong, h.MaKH, k.TenKH, c.MaPhong + N' - ' + k.TenKH AS HienThi
                              FROM ChiTietHopDong c JOIN HopDongThue h ON h.SoHD=c.SoHD JOIN KhachHang k ON k.MaKH=h.MaKH
                              WHERE h.TrangThai=N'Hiệu lực' ORDER BY c.MaPhong");
        }

        public DataTable LayNhanVien(string tuKhoa)
        {
            return Db.Query(@"SELECT n.MaNV, n.HoTen, n.GioiTinh, n.NgaySinh, n.ChucVu, n.MaKH, n.MaPhong, n.NgayBaoCao, n.TrangThai, n.HinhAnh
                              FROM NhanVien n WHERE @K = N'' OR n.MaNV LIKE @L OR n.HoTen LIKE @L OR n.MaPhong LIKE @L ORDER BY n.MaNV",
                new SqlParameter("@K", tuKhoa ?? ""), new SqlParameter("@L", "%" + (tuKhoa ?? "") + "%"));
        }

        public KetQuaXuLy LuuNhanVien(string ma, string ten, string gioiTinh, DateTime ngaySinh, string chucVu, string hinh, string maPhong, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten)) return KetQuaXuLy.Loi("Mã và họ tên nhân viên không được để trống.");
            if (string.IsNullOrWhiteSpace(maPhong)) return KetQuaXuLy.Loi("Hãy chọn phòng làm việc.");
            if (string.IsNullOrWhiteSpace(chucVu)) return KetQuaXuLy.Loi("Hãy nhập chức vụ.");
            int tuoi = DateTime.Today.Year - ngaySinh.Year;
            if (tuoi < 18 || tuoi > 70) return KetQuaXuLy.Loi("Tuổi nhân viên phải từ 18 đến 70.");
            DataTable p = Db.Query(@"SELECT TOP 1 h.MaKH FROM ChiTietHopDong c JOIN HopDongThue h ON h.SoHD=c.SoHD
                                     WHERE c.MaPhong=@P AND h.TrangThai=N'Hiệu lực'", new SqlParameter("@P", maPhong));
            if (p.Rows.Count == 0) return KetQuaXuLy.Loi("Phòng " + maPhong + " hiện không có hợp đồng thuê hiệu lực.");
            string maKH = Convert.ToString(p.Rows[0]["MaKH"]);
            try
            {
                if (capNhat)
                {
                    int n = Db.Execute(@"UPDATE NhanVien SET HoTen=@T, GioiTinh=@G, NgaySinh=@NS, ChucVu=@CV, HinhAnh=@H, MaKH=@KH, MaPhong=@P WHERE MaNV=@M",
                        new SqlParameter("@T", ten.Trim()), new SqlParameter("@G", gioiTinh), new SqlParameter("@NS", ngaySinh.Date),
                        new SqlParameter("@CV", chucVu.Trim()), new SqlParameter("@H", Db.NullIfEmpty(hinh)), new SqlParameter("@KH", maKH),
                        new SqlParameter("@P", maPhong), new SqlParameter("@M", ma.Trim()));
                    return n == 0 ? KetQuaXuLy.Loi("Không tìm thấy nhân viên.") : KetQuaXuLy.Ok("Đã cập nhật nhân viên " + ma.Trim() + ".");
                }
                Db.Execute(@"INSERT INTO NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, ChucVu, HinhAnh, MaKH, MaPhong, NgayBaoCao, TrangThai)
                             VALUES(@M, @T, @G, @NS, @CV, @H, @KH, @P, @N, N'Đang làm')",
                    new SqlParameter("@M", ma.Trim()), new SqlParameter("@T", ten.Trim()), new SqlParameter("@G", gioiTinh),
                    new SqlParameter("@NS", ngaySinh.Date), new SqlParameter("@CV", chucVu.Trim()), new SqlParameter("@H", Db.NullIfEmpty(hinh)),
                    new SqlParameter("@KH", maKH), new SqlParameter("@P", maPhong), new SqlParameter("@N", DateTime.Today));
                return KetQuaXuLy.Ok("Đã báo cáo nhân viên " + ma.Trim() + " làm việc tại phòng " + maPhong + ".");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã nhân viên đã tồn tại.");
                return KetQuaXuLy.Loi("Không thể lưu nhân viên: " + ex.Message);
            }
        }

        // Nghỉ việc: thu hồi thẻ giữ xe đang dùng
        public KetQuaXuLy ChoNghi(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV)) return KetQuaXuLy.Loi("Chưa chọn nhân viên.");
            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    int n = Db.ExecuteTx(cn, tx, "UPDATE NhanVien SET TrangThai=N'Đã nghỉ' WHERE MaNV=@M AND TrangThai=N'Đang làm'", new SqlParameter("@M", maNV));
                    if (n == 0) { tx.Rollback(); return KetQuaXuLy.Loi("Nhân viên không tồn tại hoặc đã nghỉ."); }
                    int the = Db.ExecuteTx(cn, tx, "UPDATE TheGiuXe SET TrangThai=N'Đã thu hồi' WHERE MaNV=@M AND TrangThai=N'Đang dùng'", new SqlParameter("@M", maNV));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã cho nhân viên " + maNV + " nghỉ" + (the > 0 ? ", đã thu hồi thẻ giữ xe." : "."));
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Loi("Không thể xử lý: " + ex.Message);
                }
            }
        }

        public DataTable LayThe(string maNV)
        {
            return Db.Query(@"SELECT MaThe, BienSo, LoaiXe, HieuXe, MauSac, NgayCap, TrangThai FROM TheGiuXe
                              WHERE MaNV=@M ORDER BY NgayCap DESC", new SqlParameter("@M", maNV ?? ""));
        }

        public KetQuaXuLy CapThe(string maThe, string maNV, string bienSo, string loaiXe, string hieuXe, string mauSac)
        {
            if (string.IsNullOrWhiteSpace(maThe) || string.IsNullOrWhiteSpace(maNV)) return KetQuaXuLy.Loi("Mã thẻ và nhân viên không được để trống.");
            if (string.IsNullOrWhiteSpace(bienSo)) return KetQuaXuLy.Loi("Hãy nhập biển số xe.");
            object tt = Db.Scalar("SELECT TrangThai FROM NhanVien WHERE MaNV=@M", new SqlParameter("@M", maNV));
            if (tt == null) return KetQuaXuLy.Loi("Không tìm thấy nhân viên.");
            if (Convert.ToString(tt) != "Đang làm") return KetQuaXuLy.Loi("Nhân viên đã nghỉ, không thể cấp thẻ.");
            if (Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM TheGiuXe WHERE MaNV=@M AND TrangThai=N'Đang dùng'", new SqlParameter("@M", maNV))) > 0)
                return KetQuaXuLy.Loi("Nhân viên này đã có thẻ đang dùng, mỗi người chỉ có một thẻ.");
            if (Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM TheGiuXe WHERE BienSo=@B AND TrangThai=N'Đang dùng'", new SqlParameter("@B", bienSo.Trim().ToUpper()))) > 0)
                return KetQuaXuLy.Loi("Biển số " + bienSo.Trim().ToUpper() + " đã được cấp thẻ.");
            try
            {
                Db.Execute(@"INSERT INTO TheGiuXe(MaThe, MaNV, BienSo, LoaiXe, HieuXe, MauSac, NgayCap, TrangThai)
                             VALUES(@T, @M, @B, @L, @H, @C, @N, N'Đang dùng')",
                    new SqlParameter("@T", maThe.Trim()), new SqlParameter("@M", maNV), new SqlParameter("@B", bienSo.Trim().ToUpper()),
                    new SqlParameter("@L", loaiXe), new SqlParameter("@H", Db.NullIfEmpty(hieuXe)), new SqlParameter("@C", Db.NullIfEmpty(mauSac)),
                    new SqlParameter("@N", DateTime.Today));
                return KetQuaXuLy.Ok("Đã cấp thẻ " + maThe.Trim() + " cho nhân viên " + maNV + ".");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) return KetQuaXuLy.Loi("Mã thẻ hoặc biển số bị trùng.");
                return KetQuaXuLy.Loi("Không thể cấp thẻ: " + ex.Message);
            }
        }

        public KetQuaXuLy ThuHoiThe(string maThe)
        {
            if (string.IsNullOrWhiteSpace(maThe)) return KetQuaXuLy.Loi("Chưa chọn thẻ.");
            int n = Db.Execute("UPDATE TheGiuXe SET TrangThai=N'Đã thu hồi' WHERE MaThe=@T AND TrangThai=N'Đang dùng'", new SqlParameter("@T", maThe));
            return n == 0 ? KetQuaXuLy.Loi("Thẻ không tồn tại hoặc đã thu hồi.") : KetQuaXuLy.Ok("Đã thu hồi thẻ " + maThe + ".");
        }
    }
}
