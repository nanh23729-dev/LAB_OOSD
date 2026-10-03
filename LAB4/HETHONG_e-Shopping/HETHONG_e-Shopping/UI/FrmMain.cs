using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EShopping.Models;
using EShopping.Services;

namespace EShopping.UI
{
    public partial class FrmMain : Form
    {
        private KhachHangService khService = new KhachHangService();
        private DatHangService dhService;
        private int maKH = 0;
        private List<CartItem> gio = new List<CartItem>();

        private TextBox txtUser, txtPass;
        private Button btnDangNhap, btnDangKy, btnThanhToan;
        private Label lblTrangThai;
        private DataGridView grid;

        public FrmMain()
        {
            // Truyền 2 dịch vụ ngoài (đang dùng bản giả lập)
            dhService = new DatHangService(new MockPaymentGateway(), new MockEmailService());

            Text = "e-SHOPPING";
            ClientSize = new Size(600, 400);
            StartPosition = FormStartPosition.CenterScreen;

            Label l1 = new Label();
            l1.Text = "User:";
            l1.Location = new Point(10, 15);
            l1.AutoSize = true;
            txtUser = new TextBox();
            txtUser.Location = new Point(55, 12);
            txtUser.Width = 110;

            Label l2 = new Label();
            l2.Text = "Pass:";
            l2.Location = new Point(175, 15);
            l2.AutoSize = true;
            txtPass = new TextBox();
            txtPass.Location = new Point(220, 12);
            txtPass.Width = 110;
            txtPass.UseSystemPasswordChar = true;

            btnDangNhap = new Button();
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Location = new Point(345, 10);
            btnDangNhap.Size = new Size(90, 26);
            btnDangNhap.Click += BtnDangNhap_Click;

            btnDangKy = new Button();
            btnDangKy.Text = "Đăng ký";
            btnDangKy.Location = new Point(445, 10);
            btnDangKy.Size = new Size(90, 26);
            btnDangKy.Click += BtnDangKy_Click;

            lblTrangThai = new Label();
            lblTrangThai.Text = "Chưa đăng nhập";
            lblTrangThai.Location = new Point(10, 48);
            lblTrangThai.AutoSize = true;

            // Giỏ hàng mẫu (thực tế dữ liệu lấy từ Hệ thống quản lý sản phẩm)
            TaoGioHangMau();
            grid = new DataGridView();
            grid.Location = new Point(10, 75);
            grid.Size = new Size(580, 260);
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.DataSource = gio;

            btnThanhToan = new Button();
            btnThanhToan.Text = "Tính tiền / Thanh toán";
            btnThanhToan.Location = new Point(10, 350);
            btnThanhToan.Size = new Size(580, 38);
            btnThanhToan.Click += BtnThanhToan_Click;

            Controls.Add(l1);
            Controls.Add(txtUser);
            Controls.Add(l2);
            Controls.Add(txtPass);
            Controls.Add(btnDangNhap);
            Controls.Add(btnDangKy);
            Controls.Add(lblTrangThai);
            Controls.Add(grid);
            Controls.Add(btnThanhToan);
        }

        private void TaoGioHangMau()
        {
            CartItem a = new CartItem();
            a.MaSP = "SP001"; a.TenSP = "Máy ảnh kỹ thuật số"; a.SoLuong = 1; a.DonGia = 4500000;
            CartItem b = new CartItem();
            b.MaSP = "SP002"; b.TenSP = "Đồ chơi lắp ráp"; b.SoLuong = 2; b.DonGia = 350000;
            CartItem c = new CartItem();
            c.MaSP = "SP003"; c.TenSP = "Nồi chiên không dầu"; c.SoLuong = 1; c.DonGia = 1800000;
            gio.Add(a);
            gio.Add(b);
            gio.Add(c);
        }

        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            FrmDangKy f = new FrmDangKy();
            f.ShowDialog(this);
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceResult kq = khService.DangNhap(txtUser.Text, txtPass.Text);
                if (kq.Success)
                {
                    maKH = kq.Id;
                    lblTrangThai.Text = "Đã đăng nhập: " + txtUser.Text;
                }
                else
                {
                    MessageBox.Show(kq.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (maKH == 0)
            {
                MessageBox.Show("Vui lòng đăng nhập trước khi tính tiền.");
                return;
            }
            FrmThanhToan f = new FrmThanhToan(maKH, gio, dhService);
            f.ShowDialog(this);
        }
    }
}