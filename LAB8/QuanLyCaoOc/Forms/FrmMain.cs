using System;
using System.Windows.Forms;

namespace QuanLyCaoOc.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain() { InitializeComponent(); }

        private void btnDanhMuc_Click(object sender, EventArgs e) { using (FrmDanhMuc f = new FrmDanhMuc()) f.ShowDialog(this); }
        private void btnKhachHang_Click(object sender, EventArgs e) { using (FrmKhachHang f = new FrmKhachHang()) f.ShowDialog(this); }
        private void btnHopDong_Click(object sender, EventArgs e) { using (FrmHopDong f = new FrmHopDong()) f.ShowDialog(this); }
        private void btnThanhToan_Click(object sender, EventArgs e) { using (FrmThanhToan f = new FrmThanhToan()) f.ShowDialog(this); }
        private void btnNhanVien_Click(object sender, EventArgs e) { using (FrmNhanVien f = new FrmNhanVien()) f.ShowDialog(this); }
        private void btnKiemTra_Click(object sender, EventArgs e) { using (FrmKiemTra f = new FrmKiemTra()) f.ShowDialog(this); }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Bạn có thực sự muốn thoát chương trình?")) Close();
        }
    }
}
