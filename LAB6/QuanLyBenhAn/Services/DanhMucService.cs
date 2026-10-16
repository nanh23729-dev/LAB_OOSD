using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class DanhMucService
    {
        public DataTable LayKhoa() { return Db.Query("SELECT * FROM Khoa ORDER BY MaKhoa"); }
        public DataTable LayBacSi() { return Db.Query("SELECT b.MaBS,b.HoTen,b.ChuyenMon,k.TenKhoa FROM BacSi b JOIN Khoa k ON b.MaKhoa=k.MaKhoa ORDER BY b.MaBS"); }
        public DataTable LayBacSiTheoKhoa(string maKhoa) { return Db.Query("SELECT MaBS,HoTen FROM BacSi WHERE MaKhoa=@k ORDER BY HoTen", "@k", maKhoa); }
        public DataTable LayNhanVien() { return Db.Query("SELECT * FROM NhanVien ORDER BY MaNV"); }
        public DataTable LayThuoc() { return Db.Query("SELECT * FROM Thuoc ORDER BY MaThuoc"); }
        public DataTable LayXetNghiem() { return Db.Query("SELECT * FROM XetNghiem ORDER BY MaXN"); }

        public KetQuaXuLy ThemKhoa(string ma, string ten, decimal phi)
        {
            if (Kt.Rong(ma) || Kt.Rong(ten) || phi < 0) return KetQuaXuLy.Fail("Thông tin khoa không hợp lệ.");
            return Db.InTx((cn, tx) =>
            {
                Db.Cmd(cn, tx, "INSERT INTO Khoa(MaKhoa,TenKhoa,PhiKham) VALUES(@m,@t,@p)", "@m", ma, "@t", ten, "@p", phi).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã thêm khoa.");
            });
        }

        public KetQuaXuLy ThemBacSi(string ma, string ten, string maKhoa, string chuyenMon)
        {
            if (Kt.Rong(ma) || Kt.Rong(ten) || Kt.Rong(maKhoa)) return KetQuaXuLy.Fail("Thông tin bác sĩ chưa đầy đủ.");
            return Db.InTx((cn, tx) =>
            {
                Db.Cmd(cn, tx, "INSERT INTO BacSi(MaBS,HoTen,MaKhoa,ChuyenMon) VALUES(@m,@t,@k,@c)",
                    "@m", ma, "@t", ten, "@k", maKhoa, "@c", Kt.Rong(chuyenMon) ? null : chuyenMon).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã thêm bác sĩ.");
            });
        }

        public KetQuaXuLy ThemNhanVien(string ma, string ten, string sdt, string vaiTro)
        {
            if (Kt.Rong(ma) || Kt.Rong(ten) || Kt.Rong(vaiTro)) return KetQuaXuLy.Fail("Thông tin nhân viên chưa đầy đủ.");
            return Db.InTx((cn, tx) =>
            {
                Db.Cmd(cn, tx, "INSERT INTO NhanVien(MaNV,HoTen,VaiTro,SoDienThoai) VALUES(@m,@t,@v,@s)",
                    "@m", ma, "@t", ten, "@v", vaiTro, "@s", Kt.Rong(sdt) ? null : sdt).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã thêm nhân viên.");
            });
        }

        public KetQuaXuLy ThemThuoc(string ma, string ten, string dvt, decimal gia)
        {
            if (Kt.Rong(ma) || Kt.Rong(ten) || Kt.Rong(dvt) || gia < 0) return KetQuaXuLy.Fail("Thông tin thuốc không hợp lệ.");
            return Db.InTx((cn, tx) =>
            {
                Db.Cmd(cn, tx, "INSERT INTO Thuoc(MaThuoc,TenThuoc,DonViTinh,DonGia) VALUES(@m,@t,@d,@g)",
                    "@m", ma, "@t", ten, "@d", dvt, "@g", gia).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã thêm thuốc.");
            });
        }

        public KetQuaXuLy ThemXetNghiem(string ma, string ten, decimal gia)
        {
            if (Kt.Rong(ma) || Kt.Rong(ten) || gia < 0) return KetQuaXuLy.Fail("Thông tin xét nghiệm không hợp lệ.");
            return Db.InTx((cn, tx) =>
            {
                Db.Cmd(cn, tx, "INSERT INTO XetNghiem(MaXN,TenXN,DonGia) VALUES(@m,@t,@g)", "@m", ma, "@t", ten, "@g", gia).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã thêm loại xét nghiệm.");
            });
        }
    }
}
