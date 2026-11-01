using System;
using System.Collections.Generic;

namespace QuanLyCaoOc
{
    // Thông tin hợp đồng nhập từ form (các phòng thuê truyền riêng thành danh sách mã phòng)
    public class HopDongThue
    {
        public string SoHD { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public int SoThang { get; set; }
        public string DieuKhoan { get; set; }
        public string NguoiLap { get; set; }
    }

    // Một dòng dịch vụ khi lập hóa đơn
    public class DongDichVu
    {
        public string MaDV { get; set; }
        public decimal SoLuong { get; set; }
    }

    // Một dòng của phiếu gia hạn: phòng nào, gia hạn mấy tháng
    public class DongGiaHan
    {
        public string MaPhong { get; set; }
        public int SoThang { get; set; }
    }

    // Một dòng kết quả kiểm tra phòng
    public class DongKiemTra
    {
        public string MaPhong { get; set; }
        public string TinhTrang { get; set; }
        public bool ThayDoiKetCau { get; set; }
        public string GhiChu { get; set; }
        public string KeHoachTuSua { get; set; }
    }

    // Công nợ của một hợp đồng: tiền thuê đã đến hạn mà chưa thu + hóa đơn dịch vụ chưa thanh toán
    public class CongNoHopDong
    {
        public int SoKyNo { get; set; }
        public decimal TienThueNo { get; set; }
        public int SoHoaDonNo { get; set; }
        public decimal DichVuNo { get; set; }
        public bool CoNo { get { return SoKyNo > 0 || SoHoaDonNo > 0; } }

        public string MoTa()
        {
            if (!CoNo) return "Không còn nợ.";
            List<string> ds = new List<string>();
            if (SoKyNo > 0) ds.Add("tiền thuê " + TienThueNo.ToString("N0") + " đ (" + SoKyNo + " kỳ đã đến hạn)");
            if (SoHoaDonNo > 0) ds.Add("dịch vụ " + DichVuNo.ToString("N0") + " đ (" + SoHoaDonNo + " hóa đơn)");
            return "Còn nợ " + string.Join(" và ", ds.ToArray()) + ".";
        }
    }

    // Các hàm tính thời gian dùng chung (thuê theo tháng, tính từ ngày bắt đầu)
    public static class ThoiGian
    {
        public static DateTime NgayKetThuc(DateTime batDau, int soThang)
        {
            return batDau.Date.AddMonths(soThang).AddDays(-1);
        }

        // Số tháng tính từ ngày bắt đầu đến hết ngày kết thúc
        public static int SoThangDen(DateTime batDau, DateTime ketThuc)
        {
            DateTime k = ketThuc.Date.AddDays(1);
            return (k.Year - batDau.Year) * 12 + k.Month - batDau.Month;
        }

        public static DateTime CuoiThang(int nam, int thang)
        {
            return new DateTime(nam, thang, 1).AddMonths(1).AddDays(-1);
        }
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
