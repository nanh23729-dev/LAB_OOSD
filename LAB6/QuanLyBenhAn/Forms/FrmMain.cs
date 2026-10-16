using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBenhAn.Forms
{
    public class FrmMain : Form
    {
        public FrmMain()
        {
            Ui.Setup(this, "Quản lý hồ sơ bệnh án", 680, 380);
            StartPosition = FormStartPosition.CenterScreen;
            var title = new Label
            {
                Text = "HỆ THỐNG QUẢN LÝ HỒ SƠ BỆNH ÁN", Font = new Font("Segoe UI", 17, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 64, 128), Dock = DockStyle.Top, Height = 70, TextAlign = ContentAlignment.MiddleCenter
            };
            var grid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 3, Padding = new Padding(15) };
            for (int i = 0; i < 3; i++)
            {
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3f));
            }
            Add(grid, 0, "Danh mục", () => new FrmDanhMuc());
            Add(grid, 1, "Tiếp nhận - Hồ sơ", () => new FrmTiepNhan());
            Add(grid, 2, "Khám bệnh", () => new FrmKhamBenh());
            Add(grid, 3, "Lịch khám định kỳ", () => new FrmLichHen());
            Add(grid, 4, "Viện phí - Hoàn tất", () => new FrmVienPhi());
            Add(grid, 5, "Thống kê", () => new FrmThongKe());
            var thoat = new Button { Text = "Thoát", Dock = DockStyle.Fill, Margin = new Padding(8) };
            thoat.Click += (o, e) =>
            {
                if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
            };
            grid.Controls.Add(thoat, 1, 2);
            Controls.Add(grid);
            Controls.Add(title);
        }

        void Add(TableLayoutPanel g, int idx, string text, Func<Form> make)
        {
            var b = new Button { Text = text, Dock = DockStyle.Fill, Margin = new Padding(8), Font = new Font("Segoe UI", 10.5f) };
            b.Click += (o, e) => { using (var f = make()) f.ShowDialog(this); };
            g.Controls.Add(b, idx % 3, idx / 3);
        }
    }
}
