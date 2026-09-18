using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public class FrmMain : Form
    {
        private Button btnDanhMuc, btnSach, btnDocGia, btnMuonTra, btnThongKe, btnThoat;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Quản lý thư viện";
            this.ClientSize = new Size(780, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);

            Label lblTitle = new Label
            {
                Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 20),
                Size = new Size(740, 60)
            };

            btnDanhMuc = new Button { Text = "Danh mục / Nhân viên", Location = new Point(60, 110), Size = new Size(240, 60) };
            btnSach = new Button { Text = "Quản lý đầu sách", Location = new Point(480, 110), Size = new Size(240, 60) };
            btnDocGia = new Button { Text = "Độc giả và thẻ", Location = new Point(60, 190), Size = new Size(240, 60) };
            btnMuonTra = new Button { Text = "Mượn - Trả sách", Location = new Point(480, 190), Size = new Size(240, 60) };
            btnThongKe = new Button { Text = "Thống kê", Location = new Point(60, 270), Size = new Size(240, 60) };
            btnThoat = new Button { Text = "Thoát", Location = new Point(480, 270), Size = new Size(240, 60) };

            btnDanhMuc.Click += (s, e) => { using (FrmDanhMuc f = new FrmDanhMuc()) f.ShowDialog(this); };
            btnSach.Click += (s, e) => { using (FrmSach f = new FrmSach()) f.ShowDialog(this); };
            btnDocGia.Click += (s, e) => { using (FrmDocGia f = new FrmDocGia()) f.ShowDialog(this); };
            btnMuonTra.Click += (s, e) => { using (FrmMuonTra f = new FrmMuonTra()) f.ShowDialog(this); };
            btnThongKe.Click += (s, e) => { using (FrmThongKe f = new FrmThongKe()) f.ShowDialog(this); };
            btnThoat.Click += (s, e) =>
            {
                if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
            };

            this.Controls.AddRange(new Control[] { lblTitle, btnDanhMuc, btnSach, btnDocGia, btnMuonTra, btnThongKe, btnThoat });
        }
    }
}