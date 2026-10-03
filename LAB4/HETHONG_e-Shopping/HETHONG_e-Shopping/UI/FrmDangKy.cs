using System;
using System.Drawing;
using System.Windows.Forms;
using EShopping.Models;
using EShopping.Services;

namespace EShopping.UI
{
    public partial class FrmDangKy : Form
    {
        private KhachHangService service = new KhachHangService();

        private TextBox txtHoTen, txtCmnd, txtDiaChi, txtDienThoai;
        private TextBox txtUser, txtPass, txtPass2, txtEmail;
        private DateTimePicker dtpNgaySinh;
        private Button btnDangKy;

        public FrmDangKy()
        {
            Text = "Đăng ký khách hàng";
            ClientSize = new Size(440, 420);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            txtHoTen = TaoO("Họ tên", 20);

            Label lblNs = new Label();
            lblNs.Text = "Ngày sinh";
            lblNs.Location = new Point(20, 62);
            lblNs.AutoSize = true;
            dtpNgaySinh = new DateTimePicker();
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(170, 58);
            dtpNgaySinh.Width = 240;
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
            Controls.Add(lblNs);
            Controls.Add(dtpNgaySinh);

            txtCmnd = TaoO("CMND / Passport", 100);
            txtDiaChi = TaoO("Địa chỉ", 140);
            txtDienThoai = TaoO("Điện thoại", 180);
            txtUser = TaoO("Tên đăng nhập", 220);
            txtPass = TaoO("Mật khẩu", 260);
            txtPass.UseSystemPasswordChar = true;
            txtPass2 = TaoO("Nhập lại mật khẩu", 300);
            txtPass2.UseSystemPasswordChar = true;
            txtEmail = TaoO("Email (không bắt buộc)", 340);

            btnDangKy = new Button();
            btnDangKy.Text = "Đăng ký";
            btnDangKy.Location = new Point(170, 378);
            btnDangKy.Size = new Size(120, 30);
            btnDangKy.Click += BtnDangKy_Click;
            Controls.Add(btnDangKy);
        }

        // Tạo 1 cặp Label + TextBox
        private TextBox TaoO(string nhan, int y)
        {
            Label lbl = new Label();
            lbl.Text = nhan;
            lbl.Location = new Point(20, y + 4);
            lbl.AutoSize = true;

            TextBox txt = new TextBox();
            txt.Location = new Point(170, y);
            txt.Width = 240;

            Controls.Add(lbl);
            Controls.Add(txt);
            return txt;
        }

        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            // UI chỉ kiểm tra việc nhập lại mật khẩu
            if (txtPass.Text != txtPass2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang kh = new KhachHang();
            kh.HoTen = txtHoTen.Text;
            kh.NgaySinh = dtpNgaySinh.Value;
            kh.CmndPassport = txtCmnd.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.DienThoai = txtDienThoai.Text;
            kh.TenDangNhap = txtUser.Text;
            kh.MatKhau = txtPass.Text;
            kh.Email = txtEmail.Text;

            try
            {
                ServiceResult kq = service.DangKy(kh);
                if (kq.Success)
                {
                    MessageBox.Show(kq.Message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
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
    }
}