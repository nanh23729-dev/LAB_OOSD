using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Hóa đơn viện phí, thanh toán, hoàn tất đợt điều trị (xuất viện) và ghi nhận hồ sơ.</summary>
    public class VienPhiService
    {
        public DataTable LayPhieuCanXuLy()
        {
            return Db.Query(@"SELECT k.SoPhieuKham,k.MaHoSo,b.HoTen,k.LoaiKham,k.NgayGioKham,
                ISNULL(h.TrangThai,N'Chưa lập') AS TrangThaiHD,ISNULL(h.TongTien,0) AS TongTien
                FROM PhieuKham k JOIN HoSoBenhAn hs ON k.MaHoSo=hs.MaHoSo JOIN BenhNhan b ON hs.MaBN=b.MaBN
                LEFT JOIN HoaDonVienPhi h ON h.SoPhieuKham=k.SoPhieuKham
                WHERE k.TrangThai=N'Đang khám' ORDER BY k.NgayGioKham");
        }

        public DataTable LayHoaDon(string soPhieu)
        {
            return Db.Query(@"SELECT h.SoHoaDon,h.TienKham,h.TienXetNghiem,h.TienThuoc,h.TongTien,
                ISNULL((SELECT SUM(SoTien) FROM ThanhToanVienPhi t WHERE t.SoHoaDon=h.SoHoaDon),0) AS DaThanhToan,
                h.TongTien-ISNULL((SELECT SUM(SoTien) FROM ThanhToanVienPhi t WHERE t.SoHoaDon=h.SoHoaDon),0) AS ConLai,
                h.TrangThai FROM HoaDonVienPhi h WHERE h.SoPhieuKham=@s", "@s", soPhieu);
        }

        public DataTable LayThanhToan(string soHD)
        {
            return Db.Query("SELECT MaThanhToan,NgayThanhToan,HinhThuc,SoTien FROM ThanhToanVienPhi WHERE SoHoaDon=@h ORDER BY NgayThanhToan", "@h", soHD);
        }

        public KetQuaXuLy LapHoaDon(string soPhieu, string maNV)
        {
            if (Kt.Rong(soPhieu) || Kt.Rong(maNV)) return KetQuaXuLy.Fail("Chưa chọn phiếu khám hoặc nhân viên lập hóa đơn.");
            return Db.InTx((cn, tx) =>
            {
                string loai = null, khoa = null, tt = null;
                using (var rd = Db.Cmd(cn, tx, "SELECT LoaiKham,MaKhoa,TrangThai FROM PhieuKham WHERE SoPhieuKham=@s", "@s", soPhieu).ExecuteReader())
                    if (rd.Read()) { loai = rd.GetString(0); khoa = rd.GetString(1); tt = rd.GetString(2); }
                if (loai == null) return KetQuaXuLy.Fail("Không tìm thấy phiếu khám.");
                if (tt != "Đang khám") return KetQuaXuLy.Fail("Phiếu khám không ở trạng thái có thể lập hóa đơn.");
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM HoaDonVienPhi WHERE SoPhieuKham=@s", "@s", soPhieu).ExecuteScalar()) > 0)
                    return KetQuaXuLy.Fail("Phiếu khám đã có hóa đơn.");

                decimal kham = 0, xn = 0, thuoc = 0;
                if (loai == "Điều trị")   // khám định kỳ được miễn toàn bộ chi phí
                {
                    kham = Convert.ToDecimal(Db.Cmd(cn, tx, "SELECT PhiKham FROM Khoa WHERE MaKhoa=@k", "@k", khoa).ExecuteScalar());
                    xn = Convert.ToDecimal(Db.Cmd(cn, tx, "SELECT ISNULL(SUM(DonGia),0) FROM ChiTietXetNghiem WHERE SoPhieuKham=@s", "@s", soPhieu).ExecuteScalar());
                    thuoc = Convert.ToDecimal(Db.Cmd(cn, tx, @"SELECT ISNULL(SUM(c.ThanhTien),0) FROM ToaThuoc t
                        JOIN ChiTietToaThuoc c ON t.SoToa=c.SoToa WHERE t.SoPhieuKham=@s", "@s", soPhieu).ExecuteScalar());
                }
                decimal tong = kham + xn + thuoc;
                string so = Db.NextCode(cn, tx, "HoaDonVienPhi", "SoHoaDon", "HD", 6);
                Db.Cmd(cn, tx, @"INSERT INTO HoaDonVienPhi(SoHoaDon,SoPhieuKham,NgayLap,MaNV,TienKham,TienXetNghiem,TienThuoc,TrangThai)
                    VALUES(@h,@s,@n,@nv,@k,@x,@t,@tt)",
                    "@h", so, "@s", soPhieu, "@n", DateTime.Now, "@nv", maNV, "@k", kham, "@x", xn, "@t", thuoc,
                    "@tt", tong == 0 ? "Đã thanh toán" : "Chưa thanh toán").ExecuteNonQuery();
                return KetQuaXuLy.Ok(tong == 0
                    ? "Khám sức khỏe định kỳ được miễn phí: hóa đơn " + so + " = 0đ, tự động Đã thanh toán."
                    : "Đã lập hóa đơn " + so + " (khám + xét nghiệm + thuốc).", so);
            });
        }

        public KetQuaXuLy ThanhToan(string soHD, string hinhThuc, decimal tien)
        {
            if (Kt.Rong(soHD) || Kt.Rong(hinhThuc) || tien <= 0) return KetQuaXuLy.Fail("Thông tin thanh toán không hợp lệ.");
            return Db.InTx((cn, tx) =>
            {
                object o = Db.Cmd(cn, tx, "SELECT TongTien FROM HoaDonVienPhi WITH (UPDLOCK) WHERE SoHoaDon=@h", "@h", soHD).ExecuteScalar();
                if (o == null) return KetQuaXuLy.Fail("Không tìm thấy hóa đơn.");
                decimal tong = Convert.ToDecimal(o);
                decimal da = Convert.ToDecimal(Db.Cmd(cn, tx, "SELECT ISNULL(SUM(SoTien),0) FROM ThanhToanVienPhi WHERE SoHoaDon=@h", "@h", soHD).ExecuteScalar());
                if (da + tien > tong) return KetQuaXuLy.Fail("Số tiền thanh toán vượt số còn phải trả.");
                string ma = Db.NextCode(cn, tx, "ThanhToanVienPhi", "MaThanhToan", "TT", 6);
                Db.Cmd(cn, tx, "INSERT INTO ThanhToanVienPhi(MaThanhToan,SoHoaDon,NgayThanhToan,HinhThuc,SoTien) VALUES(@m,@h,@n,@ht,@t)",
                    "@m", ma, "@h", soHD, "@n", DateTime.Now, "@ht", hinhThuc, "@t", tien).ExecuteNonQuery();
                if (da + tien == tong)
                    Db.Cmd(cn, tx, "UPDATE HoaDonVienPhi SET TrangThai=N'Đã thanh toán' WHERE SoHoaDon=@h", "@h", soHD).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã ghi nhận thanh toán bằng " + hinhThuc + ".", ma);
            });
        }

        /// <summary>Xuất viện: chỉ khi hóa đơn đã thanh toán đủ; phòng CSKH ghi nhận thông tin vào hồ sơ.</summary>
        public KetQuaXuLy HoanTat(string soPhieu, string maNVGhiNhan)
        {
            if (Kt.Rong(soPhieu) || Kt.Rong(maNVGhiNhan)) return KetQuaXuLy.Fail("Chưa chọn phiếu khám hoặc nhân viên ghi nhận.");
            return Db.InTx((cn, tx) =>
            {
                object tt = Db.Cmd(cn, tx, "SELECT TrangThai FROM HoaDonVienPhi WHERE SoPhieuKham=@s", "@s", soPhieu).ExecuteScalar();
                if (tt == null) return KetQuaXuLy.Fail("Chưa lập hóa đơn viện phí cho phiếu khám.");
                if (Convert.ToString(tt) != "Đã thanh toán") return KetQuaXuLy.Fail("Hóa đơn chưa thanh toán đủ.");
                int n = Db.Cmd(cn, tx, @"UPDATE PhieuKham SET TrangThai=N'Hoàn tất',MaNVGhiNhan=@nv,NgayGhiNhan=@n
                    WHERE SoPhieuKham=@s AND TrangThai=N'Đang khám'", "@nv", maNVGhiNhan, "@n", DateTime.Now, "@s", soPhieu).ExecuteNonQuery();
                return n == 0 ? KetQuaXuLy.Fail("Phiếu khám không ở trạng thái Đang khám.")
                              : KetQuaXuLy.Ok("Đã hoàn tất đợt điều trị và ghi nhận vào hồ sơ bệnh án.");
            });
        }
    }
}
