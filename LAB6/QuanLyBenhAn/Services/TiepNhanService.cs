using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Đăng ký khám lần đầu, đóng lệ phí năm, cấp hồ sơ bệnh án, tra cứu hồ sơ.</summary>
    public class TiepNhanService
    {
        public DataTable TraCuuHoSo(string kw)
        {
            kw = (kw ?? "").Trim();
            return Db.Query(@"SELECT h.MaHoSo,b.MaBN,b.HoTen,b.NgaySinh,b.SoDienThoai,b.DiaChi,h.NgayCap,
                (SELECT MAX(Nam) FROM LePhiNam l WHERE l.MaHoSo=h.MaHoSo) AS LePhiDenNam
                FROM HoSoBenhAn h JOIN BenhNhan b ON h.MaBN=b.MaBN
                WHERE h.MaHoSo=@k OR b.MaBN=@k OR b.SoDienThoai=@k OR b.HoTen LIKE @l
                ORDER BY b.HoTen", "@k", kw, "@l", "%" + kw + "%");
        }

        public DataTable LayLePhi(string maHoSo)
        {
            return Db.Query("SELECT MaLePhi,Nam,SoTien,NgayDong,MaNV FROM LePhiNam WHERE MaHoSo=@h ORDER BY Nam DESC", "@h", maHoSo);
        }

        public KetQuaXuLy DangKyMoi(string hoTen, string diaChi, DateTime ngaySinh, string sdt, byte[] anh, string maNV, decimal lePhi)
        {
            if (Kt.Rong(hoTen) || Kt.Rong(diaChi) || Kt.Rong(sdt) || Kt.Rong(maNV))
                return KetQuaXuLy.Fail("Thông tin phiếu đăng ký chưa đầy đủ.");
            if (ngaySinh.Date > DateTime.Today) return KetQuaXuLy.Fail("Ngày sinh không hợp lệ.");
            if (lePhi <= 0) return KetQuaXuLy.Fail("Phải đóng lệ phí năm mới được cấp hồ sơ bệnh án.");

            return Db.InTx((cn, tx) =>
            {
                int trung = Convert.ToInt32(Db.Cmd(cn, tx,
                    "SELECT COUNT(*) FROM BenhNhan WHERE HoTen=@t AND NgaySinh=@n AND SoDienThoai=@s",
                    "@t", hoTen, "@n", ngaySinh.Date, "@s", sdt).ExecuteScalar());
                if (trung > 0) return KetQuaXuLy.Fail("Bệnh nhân đã có hồ sơ (không phải khám lần đầu). Hãy tra cứu và gia hạn lệ phí.");

                string bn = Db.NextCode(cn, tx, "BenhNhan", "MaBN", "BN", 5);
                var ins = Db.Cmd(cn, tx,
                    "INSERT INTO BenhNhan(MaBN,HoTen,DiaChi,NgaySinh,SoDienThoai,Anh) VALUES(@b,@t,@d,@n,@s,@a)",
                    "@b", bn, "@t", hoTen, "@d", diaChi, "@n", ngaySinh.Date, "@s", sdt);
                ins.Parameters.Add(new SqlParameter("@a", SqlDbType.VarBinary, -1) { Value = (object)anh ?? DBNull.Value });
                ins.ExecuteNonQuery();

                string dk = Db.NextCode(cn, tx, "PhieuDangKy", "SoPhieuDK", "DK", 6);
                Db.Cmd(cn, tx, "INSERT INTO PhieuDangKy(SoPhieuDK,MaBN,NgayLap,MaNV) VALUES(@p,@b,@n,@nv)",
                    "@p", dk, "@b", bn, "@n", DateTime.Now, "@nv", maNV).ExecuteNonQuery();

                string hs = Db.NextCode(cn, tx, "HoSoBenhAn", "MaHoSo", "HS", 5);
                Db.Cmd(cn, tx, "INSERT INTO HoSoBenhAn(MaHoSo,MaBN,SoPhieuDK,NgayCap) VALUES(@h,@b,@p,@n)",
                    "@h", hs, "@b", bn, "@p", dk, "@n", DateTime.Today).ExecuteNonQuery();

                string lp = Db.NextCode(cn, tx, "LePhiNam", "MaLePhi", "LP", 6);
                Db.Cmd(cn, tx, "INSERT INTO LePhiNam(MaLePhi,MaHoSo,Nam,SoTien,NgayDong,MaNV) VALUES(@l,@h,@y,@t,@n,@nv)",
                    "@l", lp, "@h", hs, "@y", DateTime.Now.Year, "@t", lePhi, "@n", DateTime.Now, "@nv", maNV).ExecuteNonQuery();

                return KetQuaXuLy.Ok("Đã đăng ký, thu lệ phí năm " + DateTime.Now.Year + " và cấp hồ sơ. Mã hồ sơ: " + hs, hs);
            });
        }

        public KetQuaXuLy GiaHanLePhi(string maHoSo, int nam, decimal soTien, string maNV)
        {
            if (Kt.Rong(maHoSo) || Kt.Rong(maNV)) return KetQuaXuLy.Fail("Chưa chọn hồ sơ hoặc nhân viên.");
            if (soTien <= 0) return KetQuaXuLy.Fail("Lệ phí phải lớn hơn 0.");
            if (nam < DateTime.Now.Year || nam > DateTime.Now.Year + 1) return KetQuaXuLy.Fail("Chỉ thu lệ phí cho năm hiện tại hoặc năm kế tiếp.");
            return Db.InTx((cn, tx) =>
            {
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM HoSoBenhAn WHERE MaHoSo=@h", "@h", maHoSo).ExecuteScalar()) == 0)
                    return KetQuaXuLy.Fail("Không tìm thấy hồ sơ.");
                if (Db.CoLePhiNam(cn, tx, maHoSo, nam)) return KetQuaXuLy.Fail("Hồ sơ đã đóng lệ phí năm " + nam + ".");
                string lp = Db.NextCode(cn, tx, "LePhiNam", "MaLePhi", "LP", 6);
                Db.Cmd(cn, tx, "INSERT INTO LePhiNam(MaLePhi,MaHoSo,Nam,SoTien,NgayDong,MaNV) VALUES(@l,@h,@y,@t,@n,@nv)",
                    "@l", lp, "@h", maHoSo, "@y", nam, "@t", soTien, "@n", DateTime.Now, "@nv", maNV).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã gia hạn lệ phí năm " + nam + ".", lp);
            });
        }
    }
}
