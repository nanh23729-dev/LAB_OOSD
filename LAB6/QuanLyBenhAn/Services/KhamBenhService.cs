using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Phiếu khám, chẩn đoán, xét nghiệm, toa thuốc, phản ứng phụ.</summary>
    public class KhamBenhService
    {
        public DataTable LayLichSu(string maHoSo)
        {
            return Db.Query(@"SELECT k.SoPhieuKham,k.NgayGioKham,k.LoaiKham,bs.HoTen AS BacSi,kh.TenKhoa,
                k.TrieuChung,k.ThanNhiet,k.HuyetAp,k.ChanDoan,k.TrangThai
                FROM PhieuKham k JOIN BacSi bs ON k.MaBS=bs.MaBS JOIN Khoa kh ON k.MaKhoa=kh.MaKhoa
                WHERE k.MaHoSo=@h ORDER BY k.NgayGioKham DESC", "@h", maHoSo);
        }

        public DataTable LayLichHenChoKham(string maHoSo)
        {
            return Db.Query(@"SELECT MaLichHen,CONCAT(N'Q',Quy,N'/',Nam,N' - ',CONVERT(varchar(16),NgayGioHen,120)) AS Hien
                FROM LichHen WHERE MaHoSo=@h AND TrangThai=N'Đã hẹn' ORDER BY NgayGioHen", "@h", maHoSo);
        }

        public DataTable LayXetNghiem(string soPhieu)
        {
            return Db.Query(@"SELECT c.MaXN,x.TenXN,c.DonGia,c.KetQua,c.NgayThucHien
                FROM ChiTietXetNghiem c JOIN XetNghiem x ON c.MaXN=x.MaXN WHERE c.SoPhieuKham=@s", "@s", soPhieu);
        }

        public DataTable LayToa(string soPhieu)
        {
            return Db.Query(@"SELECT t.SoToa,c.MaThuoc,th.TenThuoc,c.SoLuong,th.DonViTinh,c.LieuDung,c.DonGia,c.ThanhTien,c.PhanUngPhu,t.LoiDan
                FROM ToaThuoc t JOIN ChiTietToaThuoc c ON t.SoToa=c.SoToa JOIN Thuoc th ON c.MaThuoc=th.MaThuoc
                WHERE t.SoPhieuKham=@s", "@s", soPhieu);
        }

        /// <summary>Trả về lý do không sửa được, hoặc null nếu sửa được.</summary>
        static string KhongSuaDuoc(SqlConnection cn, SqlTransaction tx, string so, bool chanKhiCoHoaDon)
        {
            object o = Db.Cmd(cn, tx, "SELECT TrangThai FROM PhieuKham WHERE SoPhieuKham=@s", "@s", so).ExecuteScalar();
            if (o == null) return "Không tìm thấy phiếu khám.";
            if (Convert.ToString(o) != "Đang khám") return "Phiếu khám đã hoàn tất, không được sửa.";
            if (chanKhiCoHoaDon && Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM HoaDonVienPhi WHERE SoPhieuKham=@s", "@s", so).ExecuteScalar()) > 0)
                return "Phiếu khám đã lập hóa đơn viện phí, không được thay đổi chỉ định/toa thuốc.";
            return null;
        }

        public KetQuaXuLy TaoPhieuKham(string maHoSo, string maBS, string maKhoa, string loai, DateTime gio,
            string trieuChung, decimal? nhiet, string huyetAp, string maLich)
        {
            if (Kt.Rong(maHoSo) || Kt.Rong(maBS) || Kt.Rong(maKhoa)) return KetQuaXuLy.Fail("Chưa chọn hồ sơ, khoa hoặc bác sĩ.");
            if (loai != "Điều trị" && loai != "Định kỳ") return KetQuaXuLy.Fail("Loại khám không hợp lệ.");
            if (loai == "Điều trị" && Kt.Rong(trieuChung)) return KetQuaXuLy.Fail("Khám điều trị phải ghi triệu chứng.");
            if (nhiet.HasValue && (nhiet.Value < 30 || nhiet.Value > 45)) return KetQuaXuLy.Fail("Thân nhiệt không hợp lệ (30–45 °C).");
            if (loai == "Định kỳ" && Kt.Rong(maLich)) return KetQuaXuLy.Fail("Khám định kỳ phải theo lịch hẹn của quý.");

            return Db.InTx((cn, tx) =>
            {
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM HoSoBenhAn WHERE MaHoSo=@h", "@h", maHoSo).ExecuteScalar()) == 0)
                    return KetQuaXuLy.Fail("Không tìm thấy hồ sơ bệnh án.");
                if (!Db.CoLePhiNam(cn, tx, maHoSo, gio.Year))
                    return KetQuaXuLy.Fail("Hồ sơ chưa đóng lệ phí năm " + gio.Year + ". Hãy gia hạn lệ phí tại màn hình Tiếp nhận.");
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM BacSi WHERE MaBS=@b AND MaKhoa=@k", "@b", maBS, "@k", maKhoa).ExecuteScalar()) == 0)
                    return KetQuaXuLy.Fail("Bác sĩ không thuộc khoa đã chọn.");
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM PhieuKham WHERE MaHoSo=@h AND TrangThai=N'Đang khám'", "@h", maHoSo).ExecuteScalar()) > 0)
                    return KetQuaXuLy.Fail("Hồ sơ đang có phiếu khám chưa hoàn tất.");

                if (loai == "Định kỳ")
                {
                    string lhHS = null, lhTT = null;
                    using (var rd = Db.Cmd(cn, tx, "SELECT MaHoSo,TrangThai FROM LichHen WHERE MaLichHen=@l", "@l", maLich).ExecuteReader())
                        if (rd.Read()) { lhHS = rd.GetString(0); lhTT = rd.GetString(1); }
                    if (lhHS != maHoSo || lhTT != "Đã hẹn") return KetQuaXuLy.Fail("Lịch hẹn không hợp lệ hoặc đã được sử dụng.");
                    Db.Cmd(cn, tx, "UPDATE LichHen SET TrangThai=N'Đã khám' WHERE MaLichHen=@l", "@l", maLich).ExecuteNonQuery();
                }

                string so = Db.NextCode(cn, tx, "PhieuKham", "SoPhieuKham", "PK", 7);
                Db.Cmd(cn, tx, @"INSERT INTO PhieuKham(SoPhieuKham,MaHoSo,NgayGioKham,MaBS,MaKhoa,LoaiKham,TrieuChung,ThanNhiet,HuyetAp,MaLichHen,TrangThai)
                    VALUES(@s,@h,@g,@b,@k,@l,@tc,@nh,@ha,@ml,N'Đang khám')",
                    "@s", so, "@h", maHoSo, "@g", gio, "@b", maBS, "@k", maKhoa, "@l", loai,
                    "@tc", Kt.Rong(trieuChung) ? null : trieuChung, "@nh", nhiet,
                    "@ha", Kt.Rong(huyetAp) ? null : huyetAp, "@ml", loai == "Định kỳ" ? maLich : null).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã lập phiếu khám " + so + ".", so);
            });
        }

        public KetQuaXuLy CapNhatChanDoan(string so, string chanDoan)
        {
            if (Kt.Rong(so) || Kt.Rong(chanDoan)) return KetQuaXuLy.Fail("Chưa chọn phiếu khám hoặc chưa nhập chẩn đoán.");
            return Db.InTx((cn, tx) =>
            {
                string loi = KhongSuaDuoc(cn, tx, so, false);
                if (loi != null) return KetQuaXuLy.Fail(loi);
                Db.Cmd(cn, tx, "UPDATE PhieuKham SET ChanDoan=@c WHERE SoPhieuKham=@s", "@c", chanDoan, "@s", so).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã lưu chẩn đoán.");
            });
        }

        public KetQuaXuLy ThemXetNghiem(string so, string maXN)
        {
            if (Kt.Rong(so) || Kt.Rong(maXN)) return KetQuaXuLy.Fail("Chưa chọn phiếu khám hoặc xét nghiệm.");
            return Db.InTx((cn, tx) =>
            {
                string loi = KhongSuaDuoc(cn, tx, so, true);
                if (loi != null) return KetQuaXuLy.Fail(loi);
                object gia = Db.Cmd(cn, tx, "SELECT DonGia FROM XetNghiem WHERE MaXN=@m", "@m", maXN).ExecuteScalar();
                if (gia == null) return KetQuaXuLy.Fail("Không tìm thấy loại xét nghiệm.");
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM ChiTietXetNghiem WHERE SoPhieuKham=@s AND MaXN=@m", "@s", so, "@m", maXN).ExecuteScalar()) > 0)
                    return KetQuaXuLy.Fail("Xét nghiệm này đã được chỉ định cho phiếu khám.");
                Db.Cmd(cn, tx, "INSERT INTO ChiTietXetNghiem(SoPhieuKham,MaXN,DonGia) VALUES(@s,@m,@g)", "@s", so, "@m", maXN, "@g", Convert.ToDecimal(gia)).ExecuteNonQuery();
                return KetQuaXuLy.Ok("Đã chỉ định xét nghiệm.");
            });
        }

        public KetQuaXuLy CapNhatKetQuaXN(string so, string maXN, string ketQua)
        {
            if (Kt.Rong(so) || Kt.Rong(maXN) || Kt.Rong(ketQua)) return KetQuaXuLy.Fail("Chưa chọn xét nghiệm hoặc chưa nhập kết quả.");
            return Db.InTx((cn, tx) =>
            {
                string loi = KhongSuaDuoc(cn, tx, so, false);
                if (loi != null) return KetQuaXuLy.Fail(loi);
                int n = Db.Cmd(cn, tx, "UPDATE ChiTietXetNghiem SET KetQua=@k,NgayThucHien=@n WHERE SoPhieuKham=@s AND MaXN=@m",
                    "@k", ketQua, "@n", DateTime.Now, "@s", so, "@m", maXN).ExecuteNonQuery();
                return n == 0 ? KetQuaXuLy.Fail("Phiếu khám chưa chỉ định xét nghiệm này.") : KetQuaXuLy.Ok("Đã ghi kết quả xét nghiệm.");
            });
        }

        /// <summary>Lập toa thuốc: bác sĩ của toa là bác sĩ khám của phiếu; mỗi phiếu tối đa 1 toa.</summary>
        public KetQuaXuLy LapToaThuoc(string so, string loiDan, List<DongThuoc> ds)
        {
            if (Kt.Rong(so) || ds == null || ds.Count == 0) return KetQuaXuLy.Fail("Toa thuốc phải có ít nhất một loại thuốc.");
            foreach (var x in ds)
                if (x.SoLuong <= 0 || Kt.Rong(x.LieuDung)) return KetQuaXuLy.Fail("Thuốc " + x.TenThuoc + ": số lượng phải > 0 và phải ghi liều dùng.");
            if (ds.Select(x => x.MaThuoc).Distinct().Count() != ds.Count) return KetQuaXuLy.Fail("Toa có thuốc bị trùng.");

            return Db.InTx((cn, tx) =>
            {
                string loi = KhongSuaDuoc(cn, tx, so, true);
                if (loi != null) return KetQuaXuLy.Fail(loi);
                if (Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM ToaThuoc WHERE SoPhieuKham=@s", "@s", so).ExecuteScalar()) > 0)
                    return KetQuaXuLy.Fail("Phiếu khám đã có toa thuốc.");
                string bs = Convert.ToString(Db.Cmd(cn, tx, "SELECT MaBS FROM PhieuKham WHERE SoPhieuKham=@s", "@s", so).ExecuteScalar());
                string toa = Db.NextCode(cn, tx, "ToaThuoc", "SoToa", "TO", 6);
                Db.Cmd(cn, tx, "INSERT INTO ToaThuoc(SoToa,SoPhieuKham,NgayLap,MaBS,LoiDan) VALUES(@t,@s,@n,@b,@l)",
                    "@t", toa, "@s", so, "@n", DateTime.Now, "@b", bs, "@l", Kt.Rong(loiDan) ? null : loiDan).ExecuteNonQuery();
                foreach (var x in ds)
                {
                    object gia = Db.Cmd(cn, tx, "SELECT DonGia FROM Thuoc WHERE MaThuoc=@m", "@m", x.MaThuoc).ExecuteScalar();
                    if (gia == null) return KetQuaXuLy.Fail("Không tìm thấy thuốc " + x.MaThuoc + ".");
                    Db.Cmd(cn, tx, "INSERT INTO ChiTietToaThuoc(SoToa,MaThuoc,SoLuong,DonGia,LieuDung) VALUES(@t,@m,@sl,@g,@ld)",
                        "@t", toa, "@m", x.MaThuoc, "@sl", x.SoLuong, "@g", Convert.ToDecimal(gia), "@ld", x.LieuDung).ExecuteNonQuery();
                }
                return KetQuaXuLy.Ok("Đã lập toa thuốc " + toa + ".", toa);
            });
        }

        /// <summary>Ghi nhận phản ứng phụ của một thuốc trong toa (cho phép cả sau khi hoàn tất để theo dõi diễn biến).</summary>
        public KetQuaXuLy GhiNhanPhanUng(string so, string maThuoc, string noiDung)
        {
            if (Kt.Rong(so) || Kt.Rong(maThuoc) || Kt.Rong(noiDung)) return KetQuaXuLy.Fail("Chưa chọn thuốc trong toa hoặc chưa nhập nội dung.");
            return Db.InTx((cn, tx) =>
            {
                int n = Db.Cmd(cn, tx, @"UPDATE c SET PhanUngPhu=@p FROM ChiTietToaThuoc c JOIN ToaThuoc t ON c.SoToa=t.SoToa
                    WHERE t.SoPhieuKham=@s AND c.MaThuoc=@m", "@p", noiDung, "@s", so, "@m", maThuoc).ExecuteNonQuery();
                return n == 0 ? KetQuaXuLy.Fail("Không tìm thấy thuốc trong toa.") : KetQuaXuLy.Ok("Đã ghi nhận phản ứng phụ.");
            });
        }
    }
}
