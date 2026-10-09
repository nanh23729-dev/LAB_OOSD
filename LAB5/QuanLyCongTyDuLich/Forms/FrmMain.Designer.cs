namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTour = new System.Windows.Forms.Button();
            this.btnChuyenLe = new System.Windows.Forms.Button();
            this.btnDangKyLe = new System.Windows.Forms.Button();
            this.btnDangKyDoan = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(0, 28);
            this.lblTieuDe.Size = new System.Drawing.Size(720, 40);
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTieuDe.Text = "CÔNG TY DU LỊCH VĂN HÓA VIỆT";
            this.lblTieuDe.TabIndex = 0;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Location = new System.Drawing.Point(45, 100);
            this.btnDanhMuc.Size = new System.Drawing.Size(300, 60);
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.TabIndex = 1;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnTour
            // 
            this.btnTour.Name = "btnTour";
            this.btnTour.Location = new System.Drawing.Point(375, 100);
            this.btnTour.Size = new System.Drawing.Size(300, 60);
            this.btnTour.UseVisualStyleBackColor = true;
            this.btnTour.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTour.Text = "Tour - hành trình";
            this.btnTour.TabIndex = 2;
            this.btnTour.Click += new System.EventHandler(this.btnTour_Click);
            // 
            // btnChuyenLe
            // 
            this.btnChuyenLe.Name = "btnChuyenLe";
            this.btnChuyenLe.Location = new System.Drawing.Point(45, 180);
            this.btnChuyenLe.Size = new System.Drawing.Size(300, 60);
            this.btnChuyenLe.UseVisualStyleBackColor = true;
            this.btnChuyenLe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnChuyenLe.Text = "Lịch chuyến khách lẻ";
            this.btnChuyenLe.TabIndex = 3;
            this.btnChuyenLe.Click += new System.EventHandler(this.btnChuyenLe_Click);
            // 
            // btnDangKyLe
            // 
            this.btnDangKyLe.Name = "btnDangKyLe";
            this.btnDangKyLe.Location = new System.Drawing.Point(375, 180);
            this.btnDangKyLe.Size = new System.Drawing.Size(300, 60);
            this.btnDangKyLe.UseVisualStyleBackColor = true;
            this.btnDangKyLe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDangKyLe.Text = "Đăng ký khách lẻ";
            this.btnDangKyLe.TabIndex = 4;
            this.btnDangKyLe.Click += new System.EventHandler(this.btnDangKyLe_Click);
            // 
            // btnDangKyDoan
            // 
            this.btnDangKyDoan.Name = "btnDangKyDoan";
            this.btnDangKyDoan.Location = new System.Drawing.Point(45, 260);
            this.btnDangKyDoan.Size = new System.Drawing.Size(300, 60);
            this.btnDangKyDoan.UseVisualStyleBackColor = true;
            this.btnDangKyDoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDangKyDoan.Text = "Đăng ký theo đoàn";
            this.btnDangKyDoan.TabIndex = 5;
            this.btnDangKyDoan.Click += new System.EventHandler(this.btnDangKyDoan_Click);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Location = new System.Drawing.Point(375, 260);
            this.btnPhanCong.Size = new System.Drawing.Size(300, 60);
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPhanCong.Text = "Phân công hướng dẫn viên";
            this.btnPhanCong.TabIndex = 6;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Location = new System.Drawing.Point(45, 340);
            this.btnKetThuc.Size = new System.Drawing.Size(300, 60);
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKetThuc.Text = "Kết thúc tour - khảo sát";
            this.btnKetThuc.TabIndex = 7;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Location = new System.Drawing.Point(375, 340);
            this.btnThongKe.Size = new System.Drawing.Size(300, 60);
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnThongKe.Text = "Lương - thống kê";
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Location = new System.Drawing.Point(210, 430);
            this.btnThoat.Size = new System.Drawing.Size(300, 60);
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.btnTour);
            this.Controls.Add(this.btnChuyenLe);
            this.Controls.Add(this.btnDangKyLe);
            this.Controls.Add(this.btnDangKyDoan);
            this.Controls.Add(this.btnPhanCong);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnThoat);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(720, 520);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý công ty du lịch Văn Hóa Việt";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnTour;
        private System.Windows.Forms.Button btnChuyenLe;
        private System.Windows.Forms.Button btnDangKyLe;
        private System.Windows.Forms.Button btnDangKyDoan;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
    }
}
