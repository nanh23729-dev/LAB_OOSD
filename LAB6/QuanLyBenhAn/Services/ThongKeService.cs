using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class ThongKeService
    {
        public DataTable TongHop(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT
              (SELECT COUNT(*) FROM PhieuDangKy WHERE CAST(NgayLap AS date) BETWEEN @tu AND @den) AS BenhNhanMoi,
              (SELECT ISNULL(SUM(SoTien),0) FROM LePhiNam WHERE CAST(NgayDong AS date) BETWEEN @tu AND @den) AS LePhiNamThu,
              (SELECT COUNT(*) FROM PhieuKham WHERE CAST(NgayGioKham AS date) BETWEEN @tu AND @den) AS SoPhieuKham,
              (SELECT COUNT(*) FROM PhieuKham WHERE LoaiKham=N'Định kỳ' AND CAST(NgayGioKham AS date) BETWEEN @tu AND @den) AS KhamDinhKy,
              (SELECT COUNT(*) FROM PhieuKham WHERE TrangThai=N'Đang khám') AS DangKham,
              (SELECT ISNULL(SUM(SoTien),0) FROM ThanhToanVienPhi WHERE CAST(NgayThanhToan AS date) BETWEEN @tu AND @den) AS DoanhThuVienPhi",
                "@tu", tu.Date, "@den", den.Date);
        }

        public DataTable ThuocSuDung(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT th.MaThuoc,th.TenThuoc,SUM(c.SoLuong) AS TongSoLuong,SUM(c.ThanhTien) AS TongTien
                FROM ToaThuoc t JOIN ChiTietToaThuoc c ON t.SoToa=c.SoToa JOIN Thuoc th ON c.MaThuoc=th.MaThuoc
                WHERE CAST(t.NgayLap AS date) BETWEEN @tu AND @den
                GROUP BY th.MaThuoc,th.TenThuoc ORDER BY TongTien DESC", "@tu", tu.Date, "@den", den.Date);
        }
    }
}
