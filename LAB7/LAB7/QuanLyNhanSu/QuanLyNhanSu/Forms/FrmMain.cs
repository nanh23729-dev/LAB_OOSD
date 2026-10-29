using System;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain() { InitializeComponent(); }

        private void btnDanhMuc_Click(object sender, EventArgs e) { using (FrmDanhMuc f = new FrmDanhMuc()) f.ShowDialog(this); }
        private void btnNhanVien_Click(object sender, EventArgs e) { using (FrmNhanVien f = new FrmNhanVien()) f.ShowDialog(this); }
        private void btnQuyetDinh_Click(object sender, EventArgs e) { using (FrmQuyetDinh f = new FrmQuyetDinh()) f.ShowDialog(this); }
        private void btnChamCong_Click(object sender, EventArgs e) { using (FrmChamCong f = new FrmChamCong()) f.ShowDialog(this); }
        private void btnKhenThuong_Click(object sender, EventArgs e) { using (FrmKhenThuongKyLuat f = new FrmKhenThuongKyLuat()) f.ShowDialog(this); }
        private void btnBangLuong_Click(object sender, EventArgs e) { using (FrmBangLuong f = new FrmBangLuong()) f.ShowDialog(this); }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Bạn có thực sự muốn thoát chương trình?")) Close();
        }
    }
}
