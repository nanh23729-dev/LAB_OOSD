using System;

namespace QuanLyNhanSu
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string MaPB { get; set; }
    }

    public class QuyetDinhTuyenDung
    {
        public string SoQD { get; set; }
        public string MaNV { get; set; }
        public string MaPB { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayBatDauThuViec { get; set; }
        public DateTime NgayKetThucThuViec { get; set; }
        public decimal LuongThuViec { get; set; }
        public string DieuKhoan { get; set; }
        public string NguoiKy { get; set; }
    }

    public class HopDongLaoDong
    {
        public string SoHD { get; set; }
        public string SoQDTuyenDung { get; set; }
        public string LoaiHD { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string NguoiKy { get; set; }
    }

    public class HoSoBaoHiem
    {
        public string SoHD { get; set; }
        public string SoSoBHXH { get; set; }
        public string SoTheBHYT { get; set; }
        public DateTime NgayThamGia { get; set; }
        public decimal TyLeBHXH { get; set; }
        public decimal TyLeBHYT { get; set; }
    }

    public class QuyetDinhLuong
    {
        public string SoQD { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal PhuCapLuong { get; set; }
        public decimal PhuCapDocHai { get; set; }
        public string NguoiKy { get; set; }
    }

    public class QuyetDinhChucVu
    {
        public string SoQD { get; set; }
        public string MaNV { get; set; }
        public string MaCV { get; set; }
        public string MaPB { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public decimal PhuCapChucVu { get; set; }
        public string NguoiKy { get; set; }
    }

    public class PhieuPhuTroi
    {
        public string SoPhieu { get; set; }
        public DateTime NgayPhuTroi { get; set; }
        public decimal SoGioPhuTroi { get; set; }
        public string HinhThuc { get; set; }
        public string MaPB { get; set; }
        public string MaNVLap { get; set; }
    }

    // Dùng chung cho quyết định khen thưởng và quyết định kỷ luật
    public class QuyetDinhKhenThuong
    {
        public string SoQD { get; set; }
        public DateTime NgayKy { get; set; }
        public string LoaiKhenThuong { get; set; }
        public string DoiTuong { get; set; }      // Cá nhân / Tập thể
        public string MaNV { get; set; }
        public string MaPB { get; set; }
        public string NoiDung { get; set; }
        public decimal SoTien { get; set; }
        public string HinhThucChi { get; set; }   // Phiếu chi / Cộng vào lương
        public string NguoiKy { get; set; }
        public string MaNVLapPhieu { get; set; }
    }

    public class QuyetDinhKyLuat
    {
        public string SoQD { get; set; }
        public DateTime NgayKy { get; set; }
        public string DoiTuong { get; set; }
        public string MaNV { get; set; }
        public string MaPB { get; set; }
        public string LyDo { get; set; }
        public decimal SoTienPhat { get; set; }
        public string HinhThucThu { get; set; }   // Phiếu thu / Trừ lương
        public string NguoiKy { get; set; }
        public string MaNVLapPhieu { get; set; }
    }

    public class KetQuaXuLy
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }

        private KetQuaXuLy(bool thanhCong, string thongBao)
        {
            ThanhCong = thanhCong;
            ThongBao = thongBao;
        }

        public static KetQuaXuLy Ok(string thongBao) { return new KetQuaXuLy(true, thongBao); }
        public static KetQuaXuLy Loi(string thongBao) { return new KetQuaXuLy(false, thongBao); }
    }
}
