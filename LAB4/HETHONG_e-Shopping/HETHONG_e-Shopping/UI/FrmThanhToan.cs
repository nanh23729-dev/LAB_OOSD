using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EShopping.Models;
using EShopping.Services;

namespace EShopping.UI
{
    public partial class FrmThanhToan : Form
    {
        private DatHangService service;
        private int maKH;
        private List<CartItem> gio;

        private ComboBox cboGiao, cboKhuVuc, cboThe;
        private TextBox txtTenNhan, txtDcNhan, txtDtNhan;
        private TextBox txtSoThe, txtHetHan, txtChuThe, txtCsv;
        private Label lblTienHang, lblPhiGiao, lblLePhi, lblTong;
        private Button btnDatHang;

        public FrmThanhToan(int maKH, List<CartItem> gio, DatHangService service)
        {
            this.maKH = maKH;
            this.gio = gio;
            this.service = service;

            Text = "Thanh toán";
            ClientSize = new Size(460, 560);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // Thứ tự item trong combo phải giống thứ tự trong enum
            cboGiao = TaoCombo("Loại giao hàng", 15,
                new string[] { "Thường", "Chuyển phát nhanh", "Nhanh trong ngày" });
            cboKhuVuc = TaoCombo("Khu vực giao", 50,
                new string[] { "Nội thành", "Ngoại thành", "Tỉnh khác" });

            txtTenNhan = TaoO("Người nhận", 85);
            txtDcNhan = TaoO("Địa chỉ nhận", 120);
            txtDtNhan = TaoO("ĐT người nhận", 155);

            cboThe = TaoCombo("Loại thẻ", 195,
                new string[] { "Visa", "Master", "Discover", "American Express" });
            txtSoThe = TaoO("Số thẻ", 230);
            txtHetHan = TaoO("Hết hạn (MM/yyyy)", 265);
            txtChuThe = TaoO("Tên chủ thẻ", 300);
            txtCsv = TaoO("CSV", 335);
            txtCsv.UseSystemPasswordChar = true;

            lblTienHang = TaoNhan("Tiền hàng", 380);
            lblPhiGiao = TaoNhan("Phí giao hàng", 410);
            lblLePhi = TaoNhan("Lệ phí thẻ", 440);
            lblTong = TaoNhan("TỔNG THANH TOÁN", 470);
            lblTong.Font = new Font(Font, FontStyle.Bold);

            btnDatHang = new Button();
            btnDatHang.Text = "Đặt hàng";
            btnDatHang.Location = new Point(160, 508);
            btnDatHang.Size = new Size(130, 34);
            btnDatHang.Click += BtnDatHang_Click;
            Controls.Add(btnDatHang);

            // Gắn sự kiện sau khi các Label đã tạo xong
            cboGiao.SelectedIndexChanged += LuaChonThayDoi;
            cboKhuVuc.SelectedIndexChanged += LuaChonThayDoi;
            cboThe.SelectedIndexChanged += LuaChonThayDoi;

            TinhLai();
        }

        private void LuaChonThayDoi(object sender, EventArgs e)
        {
            TinhLai();
        }

        // Gọi Service tính lại tiền, form chỉ hiển thị kết quả
        private void TinhLai()
        {
            ChiPhi cp = service.TinhChiPhi(gio,
                (LoaiGiao)cboGiao.SelectedIndex,
                (KhuVuc)cboKhuVuc.SelectedIndex,
                (LoaiThe)cboThe.SelectedIndex);

            lblTienHang.Text = cp.TienHang.ToString("N0") + " đ";
            lblPhiGiao.Text = cp.PhiGiao.ToString("N0") + " đ";
            if (cp.PhiGiao == 0)
                lblPhiGiao.Text = lblPhiGiao.Text + " (miễn phí)";
            lblLePhi.Text = cp.LePhiThe.ToString("N0") + " đ";
            lblTong.Text = cp.Tong.ToString("N0") + " đ";
        }

        private void BtnDatHang_Click(object sender, EventArgs e)
        {
            // UI chỉ kiểm tra có bỏ trống không
            TextBox[] cacO = { txtTenNhan, txtDcNhan, txtDtNhan, txtSoThe, txtHetHan, txtChuThe, txtCsv };
            foreach (TextBox o in cacO)
            {
                if (o.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    o.Focus();
                    return;
                }
            }

            TheTinDung the = new TheTinDung();
            the.Loai = (LoaiThe)cboThe.SelectedIndex;
            the.SoThe = txtSoThe.Text;
            the.HetHan = txtHetHan.Text;
            the.TenChuThe = txtChuThe.Text;
            the.Csv = txtCsv.Text;

            DonHangRequest rq = new DonHangRequest();
            rq.MaKH = maKH;
            rq.Gio = gio;
            rq.LoaiGiao = (LoaiGiao)cboGiao.SelectedIndex;
            rq.KhuVuc = (KhuVuc)cboKhuVuc.SelectedIndex;
            rq.TenNguoiNhan = txtTenNhan.Text;
            rq.DiaChiNhan = txtDcNhan.Text;
            rq.DienThoaiNhan = txtDtNhan.Text;
            rq.The = the;

            try
            {
                ServiceResult kq = service.DatHang(rq);
                if (kq.Success)
                {
                    MessageBox.Show(kq.Message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show(kq.Message, "Không thể đặt hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        // ---------- Hàm tạo control ----------

        private TextBox TaoO(string nhan, int y)
        {
            Label lbl = new Label();
            lbl.Text = nhan;
            lbl.Location = new Point(20, y + 4);
            lbl.AutoSize = true;

            TextBox txt = new TextBox();
            txt.Location = new Point(170, y);
            txt.Width = 260;

            Controls.Add(lbl);
            Controls.Add(txt);
            return txt;
        }

        private ComboBox TaoCombo(string nhan, int y, string[] cacMuc)
        {
            Label lbl = new Label();
            lbl.Text = nhan;
            lbl.Location = new Point(20, y + 4);
            lbl.AutoSize = true;

            ComboBox cbo = new ComboBox();
            cbo.Location = new Point(170, y);
            cbo.Width = 260;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.Items.AddRange(cacMuc);
            cbo.SelectedIndex = 0;

            Controls.Add(lbl);
            Controls.Add(cbo);
            return cbo;
        }

        private Label TaoNhan(string tieuDe, int y)
        {
            Label lblTieuDe = new Label();
            lblTieuDe.Text = tieuDe;
            lblTieuDe.Location = new Point(20, y);
            lblTieuDe.AutoSize = true;

            Label lblGiaTri = new Label();
            lblGiaTri.Location = new Point(170, y);
            lblGiaTri.AutoSize = true;

            Controls.Add(lblTieuDe);
            Controls.Add(lblGiaTri);
            return lblGiaTri;
        }
    }
}