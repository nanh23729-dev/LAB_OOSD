namespace QuanLyNhanSu.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnQuyetDinh = new System.Windows.Forms.Button();
            this.btnChamCong = new System.Windows.Forms.Button();
            this.btnKhenThuong = new System.Windows.Forms.Button();
            this.btnBangLuong = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(780, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSub
            // 
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSub.Location = new System.Drawing.Point(0, 72);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(780, 28);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Công ty sơn Đông Á";
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Location = new System.Drawing.Point(120, 125);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(250, 62);
            this.btnDanhMuc.TabIndex = 2;
            this.btnDanhMuc.Text = "Danh mục\r\n(Phòng ban - Chức vụ - Ca)";
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(410, 125);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(250, 62);
            this.btnNhanVien.TabIndex = 3;
            this.btnNhanVien.Text = "Nhân viên - Tuyển dụng\r\nHợp đồng - Bảo hiểm";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnQuyetDinh
            // 
            this.btnQuyetDinh.Location = new System.Drawing.Point(120, 205);
            this.btnQuyetDinh.Name = "btnQuyetDinh";
            this.btnQuyetDinh.Size = new System.Drawing.Size(250, 62);
            this.btnQuyetDinh.TabIndex = 4;
            this.btnQuyetDinh.Text = "Quyết định lương\r\nQuyết định chức vụ";
            this.btnQuyetDinh.UseVisualStyleBackColor = true;
            this.btnQuyetDinh.Click += new System.EventHandler(this.btnQuyetDinh_Click);
            // 
            // btnChamCong
            // 
            this.btnChamCong.Location = new System.Drawing.Point(410, 205);
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.Size = new System.Drawing.Size(250, 62);
            this.btnChamCong.TabIndex = 5;
            this.btnChamCong.Text = "Phân công - Chấm công\r\nPhụ trội";
            this.btnChamCong.UseVisualStyleBackColor = true;
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);
            // 
            // btnKhenThuong
            // 
            this.btnKhenThuong.Location = new System.Drawing.Point(120, 285);
            this.btnKhenThuong.Name = "btnKhenThuong";
            this.btnKhenThuong.Size = new System.Drawing.Size(250, 62);
            this.btnKhenThuong.TabIndex = 6;
            this.btnKhenThuong.Text = "Khen thưởng - Kỷ luật";
            this.btnKhenThuong.UseVisualStyleBackColor = true;
            this.btnKhenThuong.Click += new System.EventHandler(this.btnKhenThuong_Click);
            // 
            // btnBangLuong
            // 
            this.btnBangLuong.Location = new System.Drawing.Point(410, 285);
            this.btnBangLuong.Name = "btnBangLuong";
            this.btnBangLuong.Size = new System.Drawing.Size(250, 62);
            this.btnBangLuong.TabIndex = 7;
            this.btnBangLuong.Text = "Bảng lương hằng tháng";
            this.btnBangLuong.UseVisualStyleBackColor = true;
            this.btnBangLuong.Click += new System.EventHandler(this.btnBangLuong_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(580, 395);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(140, 40);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 470);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnBangLuong);
            this.Controls.Add(this.btnKhenThuong);
            this.Controls.Add(this.btnChamCong);
            this.Controls.Add(this.btnQuyetDinh);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân sự - Công ty sơn Đông Á";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnQuyetDinh;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.Button btnKhenThuong;
        private System.Windows.Forms.Button btnBangLuong;
        private System.Windows.Forms.Button btnThoat;
    }
}
