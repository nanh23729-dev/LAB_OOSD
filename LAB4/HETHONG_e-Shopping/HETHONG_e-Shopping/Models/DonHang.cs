using System.Collections.Generic;

namespace EShopping.Models
{
    public class CartItem
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public decimal ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
    }

    public class TheTinDung
    {
        public LoaiThe Loai { get; set; }
        public string SoThe { get; set; }
        public string HetHan { get; set; }     // dạng MM/yyyy
        public string TenChuThe { get; set; }
        public string Csv { get; set; }
    }

    public class ChiPhi
    {
        public decimal TienHang { get; set; }
        public decimal PhiGiao { get; set; }
        public decimal LePhiThe { get; set; }

        public decimal Tong
        {
            get { return TienHang + PhiGiao + LePhiThe; }
        }
    }

    public class DonHangRequest
    {
        public int MaKH { get; set; }
        public List<CartItem> Gio { get; set; }
        public LoaiGiao LoaiGiao { get; set; }
        public KhuVuc KhuVuc { get; set; }
        public string TenNguoiNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string DienThoaiNhan { get; set; }
        public TheTinDung The { get; set; }

        public DonHangRequest()
        {
            Gio = new List<CartItem>();
        }
    }
}