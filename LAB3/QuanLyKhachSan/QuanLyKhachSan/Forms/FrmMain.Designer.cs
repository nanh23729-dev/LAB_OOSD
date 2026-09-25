using QuanLyKhachSan.Helpers;

namespace QuanLyKhachSan.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(860, 40);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(20, 55, 130);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN";

            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnDanhMuc.Location = new System.Drawing.Point(80, 100);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(220, 70);
            this.btnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDanhMuc.Text = "  Danh mục";
            this.btnDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDanhMuc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDanhMuc.Image = IconHelper.Clipboard(28, System.Drawing.Color.White);
            this.btnDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnDanhMuc.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);

            this.btnPhong = new System.Windows.Forms.Button();
            this.btnPhong.Location = new System.Drawing.Point(340, 100);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.Size = new System.Drawing.Size(220, 70);
            this.btnPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhong.Text = "  Phòng - Tiện nghi";
            this.btnPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhong.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPhong.Image = IconHelper.Bed(28, System.Drawing.Color.White);
            this.btnPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong.FlatAppearance.BorderSize = 0;
            this.btnPhong.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
            this.btnPhong.ForeColor = System.Drawing.Color.White;
            this.btnPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);

            this.btnDatPhong = new System.Windows.Forms.Button();
            this.btnDatPhong.Location = new System.Drawing.Point(600, 100);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(220, 70);
            this.btnDatPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDatPhong.Text = "  Đặt / Nhận phòng";
            this.btnDatPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatPhong.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDatPhong.Image = IconHelper.Key(28, System.Drawing.Color.White);
            this.btnDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatPhong.FlatAppearance.BorderSize = 0;
            this.btnDatPhong.BackColor = System.Drawing.Color.FromArgb(103, 58, 183);
            this.btnDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnDatPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);

            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnDichVu.Location = new System.Drawing.Point(80, 200);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(220, 70);
            this.btnDichVu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDichVu.Text = "  Sử dụng dịch vụ";
            this.btnDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDichVu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDichVu.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDichVu.Image = IconHelper.Gear(28, System.Drawing.Color.White);
            this.btnDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDichVu.FlatAppearance.BorderSize = 0;
            this.btnDichVu.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnDichVu.ForeColor = System.Drawing.Color.White;
            this.btnDichVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);

            this.btnTraPhong = new System.Windows.Forms.Button();
            this.btnTraPhong.Location = new System.Drawing.Point(340, 200);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(220, 70);
            this.btnTraPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTraPhong.Text = "  Trả phòng - Thanh toán";
            this.btnTraPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTraPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTraPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraPhong.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTraPhong.Image = IconHelper.Cash(28, System.Drawing.Color.White);
            this.btnTraPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraPhong.FlatAppearance.BorderSize = 0;
            this.btnTraPhong.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnTraPhong.ForeColor = System.Drawing.Color.White;
            this.btnTraPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);

            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThongKe.Location = new System.Drawing.Point(600, 200);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(220, 70);
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.Text = "  Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnThongKe.Image = IconHelper.BarChart(28, System.Drawing.Color.White);
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);

            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThoat.Location = new System.Drawing.Point(340, 300);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(220, 70);
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Text = "  Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnThoat.Image = IconHelper.Door(28, System.Drawing.Color.White);
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.btnPhong);
            this.Controls.Add(this.btnDatPhong);
            this.Controls.Add(this.btnDichVu);
            this.Controls.Add(this.btnTraPhong);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnThoat);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 400);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách sạn";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnTraPhong;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
    }
}