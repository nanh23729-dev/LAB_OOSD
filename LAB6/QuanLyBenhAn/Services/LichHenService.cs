using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Lịch khám sức khỏe định kỳ theo quý (miễn phí) do phòng CSKH đặt.</summary>
    public class LichHenService
    {
        public DataTable LayLichHen(string maHoSo)
        {
            return Db.Query("SELECT MaLichHen,Nam,Quy,NgayGioHen,TrangThai,MaNV FROM LichHen WHERE MaHoSo=@h ORDER BY Nam DESC,Quy DESC,NgayGioHen DESC", "@h", maHoSo);
        }

        public KetQuaXuLy DatLich(string maHoSo, int quy, int nam, DateTime gio, string maNV)
        {
            if (Kt.Rong(maHoSo) || Kt.Rong(maNV)) return KetQuaXuLy.Fail("Chưa chọn hồ sơ hoặc nhân viên CSKH.");
            if (quy < 1 || quy > 4) return KetQuaXuLy.Fail("Quý không hợp lệ.");
            if (gio.Year != nam || (gio.Month - 1) / 3 + 1 != quy) return KetQuaXuLy.Fail("Ngày giờ hẹn phải nằm trong quý " + quy + "/" + nam + ".");
            if (gio <= DateTime.Now) return KetQuaXuLy.Fail("Ngày giờ hẹn phải ở tương lai.");

            return Db.InTx((cn, tx) =>
            {
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM HoSoBenhAn WHERE MaHoSo=@h", "@h", maHoSo).ExecuteScalar()) == 0)
                    return KetQuaXuLy.Fail("Không tìm thấy hồ sơ.");
                if (!Db.CoLePhiNam(cn, tx, maHoSo, nam))
                    return KetQuaXuLy.Fail("Hồ sơ chưa đóng lệ phí năm " + nam + " nên chưa có quyền khám định kỳ.");
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM LichHen WHERE MaHoSo=@h AND Quy=@q AND Nam=@n AND TrangThai<>N'Hủy'",
                        "@h", maHoSo, "@q", quy, "@n", nam).ExecuteScalar()) > 0)
                    return KetQuaXuLy.Fail("Quý " + quy + "/" + nam + " đã có lịch khám định kỳ.");
                string ma = Db.NextCode(cn, tx, "LichHen", "MaLichHen", "LH", 6);
                Db.Cmd(cn, tx, "INSERT INTO LichHen(MaLichHen,MaHoSo,Quy,Nam,NgayGioHen,MaNV,TrangThai) VALUES(@m,@h,@q,@n,@g,@nv,N'Đã hẹn')",
                    "@m", ma, "@h", maHoSo, "@q", quy, "@n", nam, "@g", gio, "@nv", maNV).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã đặt lịch khám định kỳ " + ma + ".", ma);
            });
        }

        public KetQuaXuLy Huy(string maLich)
        {
            if (Kt.Rong(maLich)) return KetQuaXuLy.Fail("Chưa chọn lịch hẹn.");
            return Db.InTx((cn, tx) =>
            {
                int n = Db.Cmd(cn, tx, "UPDATE LichHen SET TrangThai=N'Hủy' WHERE MaLichHen=@m AND TrangThai=N'Đã hẹn'", "@m", maLich).ExecuteNonQuery();
                return n == 0 ? KetQuaXuLy.Fail("Chỉ hủy được lịch ở trạng thái Đã hẹn.") : KetQuaXuLy.Ok("Đã hủy lịch hẹn.");
            });
        }
    }
}
