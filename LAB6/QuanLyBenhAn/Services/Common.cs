namespace QuanLyBenhAn.Services
{
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public string Ma { get; set; }   // mã vừa được sinh (mã hồ sơ, số phiếu...)
        public static KetQuaXuLy Ok(string m, string ma = null) { return new KetQuaXuLy { ThanhCong = true, ThongBao = m, Ma = ma }; }
        public static KetQuaXuLy Fail(string m) { return new KetQuaXuLy { ThanhCong = false, ThongBao = m }; }
    }

    public class DongThuoc
    {
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuong { get; set; }
        public string LieuDung { get; set; }
    }

    public static class Kt
    {
        public static bool Rong(string s) { return string.IsNullOrWhiteSpace(s); }
    }
}
