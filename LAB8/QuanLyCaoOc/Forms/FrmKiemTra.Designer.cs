namespace QuanLyCaoOc.Forms
{
    partial class FrmKiemTra
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabLap = new System.Windows.Forms.TabPage();
            this.tabPhieu = new System.Windows.Forms.TabPage();
            this.tabPhat = new System.Windows.Forms.TabPage();
            this.lblDenHan = new System.Windows.Forms.Label();
            this.dgvDenHan = new System.Windows.Forms.DataGridView();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.chkKetCau = new System.Windows.Forms.CheckBox();
            this.lblKeHoach = new System.Windows.Forms.Label();
            this.txtKeHoach = new System.Windows.Forms.TextBox();
            this.lblDongGhiChu = new System.Windows.Forms.Label();
            this.txtDongGhiChu = new System.Windows.Forms.TextBox();
            this.btnThemDong = new System.Windows.Forms.Button();
            this.btnBoDong = new System.Windows.Forms.Button();
            this.dgvDong = new System.Windows.Forms.DataGridView();
            this.lblNguoiKT = new System.Windows.Forms.Label();
            this.txtNguoiKT = new System.Windows.Forms.TextBox();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.dgvPhat = new System.Windows.Forms.DataGridView();
            this.btnThuPhat = new System.Windows.Forms.Button();
            this.btnPhatTaiLai = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabLap.SuspendLayout();
            this.tabPhieu.SuspendLayout();
            this.tabPhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabLap);
            this.tabs.Controls.Add(this.tabPhieu);
            this.tabs.Controls.Add(this.tabPhat);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1016, 640);
            this.tabs.TabIndex = 0;
            // 
            // tabLap
            // 
            this.tabLap.Controls.Add(this.lblDenHan);
            this.tabLap.Controls.Add(this.dgvDenHan);
            this.tabLap.Controls.Add(this.lblPhong);
            this.tabLap.Controls.Add(this.cboPhong);
            this.tabLap.Controls.Add(this.lblTinhTrang);
            this.tabLap.Controls.Add(this.cboTinhTrang);
            this.tabLap.Controls.Add(this.chkKetCau);
            this.tabLap.Controls.Add(this.lblKeHoach);
            this.tabLap.Controls.Add(this.txtKeHoach);
            this.tabLap.Controls.Add(this.lblDongGhiChu);
            this.tabLap.Controls.Add(this.txtDongGhiChu);
            this.tabLap.Controls.Add(this.btnThemDong);
            this.tabLap.Controls.Add(this.btnBoDong);
            this.tabLap.Controls.Add(this.dgvDong);
            this.tabLap.Controls.Add(this.lblNguoiKT);
            this.tabLap.Controls.Add(this.txtNguoiKT);
            this.tabLap.Controls.Add(this.btnLapPhieu);
            this.tabLap.Location = new System.Drawing.Point(4, 29);
            this.tabLap.Name = "tabLap";
            this.tabLap.Padding = new System.Windows.Forms.Padding(3);
            this.tabLap.Size = new System.Drawing.Size(1008, 607);
            this.tabLap.TabIndex = 0;
            this.tabLap.Text = "Lập phiếu kiểm tra";
            this.tabLap.UseVisualStyleBackColor = true;
            // 
            // lblDenHan
            // 
            this.lblDenHan.AutoSize = true;
            this.lblDenHan.Location = new System.Drawing.Point(20, 15);
            this.lblDenHan.Name = "lblDenHan";
            this.lblDenHan.Size = new System.Drawing.Size(500, 20);
            this.lblDenHan.TabIndex = 0;
            this.lblDenHan.Text = "Phòng đến hạn kiểm tra (chưa kiểm tra trong 1 năm):";
            // 
            // dgvDenHan
            // 
            this.dgvDenHan.Location = new System.Drawing.Point(20, 40);
            this.dgvDenHan.Name = "dgvDenHan";
            this.dgvDenHan.AllowUserToAddRows = false;
            this.dgvDenHan.AllowUserToDeleteRows = false;
            this.dgvDenHan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDenHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDenHan.MultiSelect = false;
            this.dgvDenHan.ReadOnly = true;
            this.dgvDenHan.RowHeadersWidth = 30;
            this.dgvDenHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDenHan.Size = new System.Drawing.Size(960, 150);
            this.dgvDenHan.TabIndex = 1;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(20, 208);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(43, 20);
            this.lblPhong.TabIndex = 2;
            this.lblPhong.Text = "Phòng:";
            // 
            // cboPhong
            // 
            this.cboPhong.Location = new System.Drawing.Point(120, 205);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(170, 25);
            this.cboPhong.TabIndex = 3;
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(20, 243);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(79, 20);
            this.lblTinhTrang.TabIndex = 4;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.Location = new System.Drawing.Point(120, 240);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(170, 25);
            this.cboTinhTrang.TabIndex = 5;
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.FormattingEnabled = true;
            // 
            // chkKetCau
            // 
            this.chkKetCau.AutoSize = true;
            this.chkKetCau.Location = new System.Drawing.Point(20, 275);
            this.chkKetCau.Name = "chkKetCau";
            this.chkKetCau.Size = new System.Drawing.Size(330, 24);
            this.chkKetCau.TabIndex = 6;
            this.chkKetCau.Text = "Khách tự ý thay đổi kết cấu phòng";
            this.chkKetCau.UseVisualStyleBackColor = true;
            // 
            // lblKeHoach
            // 
            this.lblKeHoach.AutoSize = true;
            this.lblKeHoach.Location = new System.Drawing.Point(20, 313);
            this.lblKeHoach.Name = "lblKeHoach";
            this.lblKeHoach.Size = new System.Drawing.Size(115, 20);
            this.lblKeHoach.TabIndex = 7;
            this.lblKeHoach.Text = "Kế hoạch tự sửa:";
            // 
            // txtKeHoach
            // 
            this.txtKeHoach.Location = new System.Drawing.Point(140, 310);
            this.txtKeHoach.Name = "txtKeHoach";
            this.txtKeHoach.Size = new System.Drawing.Size(420, 25);
            this.txtKeHoach.TabIndex = 8;
            // 
            // lblDongGhiChu
            // 
            this.lblDongGhiChu.AutoSize = true;
            this.lblDongGhiChu.Location = new System.Drawing.Point(20, 348);
            this.lblDongGhiChu.Name = "lblDongGhiChu";
            this.lblDongGhiChu.Size = new System.Drawing.Size(57, 20);
            this.lblDongGhiChu.TabIndex = 9;
            this.lblDongGhiChu.Text = "Ghi chú:";
            // 
            // txtDongGhiChu
            // 
            this.txtDongGhiChu.Location = new System.Drawing.Point(140, 345);
            this.txtDongGhiChu.Name = "txtDongGhiChu";
            this.txtDongGhiChu.Size = new System.Drawing.Size(420, 25);
            this.txtDongGhiChu.TabIndex = 10;
            // 
            // btnThemDong
            // 
            this.btnThemDong.Location = new System.Drawing.Point(600, 205);
            this.btnThemDong.Name = "btnThemDong";
            this.btnThemDong.Size = new System.Drawing.Size(150, 32);
            this.btnThemDong.TabIndex = 11;
            this.btnThemDong.Text = "Thêm vào phiếu";
            this.btnThemDong.UseVisualStyleBackColor = true;
            this.btnThemDong.Click += new System.EventHandler(this.btnThemDong_Click);
            // 
            // btnBoDong
            // 
            this.btnBoDong.Location = new System.Drawing.Point(765, 205);
            this.btnBoDong.Name = "btnBoDong";
            this.btnBoDong.Size = new System.Drawing.Size(140, 32);
            this.btnBoDong.TabIndex = 12;
            this.btnBoDong.Text = "Bỏ dòng chọn";
            this.btnBoDong.UseVisualStyleBackColor = true;
            this.btnBoDong.Click += new System.EventHandler(this.btnBoDong_Click);
            // 
            // dgvDong
            // 
            this.dgvDong.Location = new System.Drawing.Point(20, 385);
            this.dgvDong.Name = "dgvDong";
            this.dgvDong.AllowUserToAddRows = false;
            this.dgvDong.AllowUserToDeleteRows = false;
            this.dgvDong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDong.MultiSelect = false;
            this.dgvDong.ReadOnly = true;
            this.dgvDong.RowHeadersWidth = 30;
            this.dgvDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDong.Size = new System.Drawing.Size(960, 130);
            this.dgvDong.TabIndex = 13;
            // 
            // lblNguoiKT
            // 
            this.lblNguoiKT.AutoSize = true;
            this.lblNguoiKT.Location = new System.Drawing.Point(20, 533);
            this.lblNguoiKT.Name = "lblNguoiKT";
            this.lblNguoiKT.Size = new System.Drawing.Size(108, 20);
            this.lblNguoiKT.TabIndex = 14;
            this.lblNguoiKT.Text = "Người kiểm tra:";
            // 
            // txtNguoiKT
            // 
            this.txtNguoiKT.Location = new System.Drawing.Point(130, 530);
            this.txtNguoiKT.Name = "txtNguoiKT";
            this.txtNguoiKT.Size = new System.Drawing.Size(220, 25);
            this.txtNguoiKT.TabIndex = 15;
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(440, 525);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(180, 36);
            this.btnLapPhieu.TabIndex = 16;
            this.btnLapPhieu.Text = "Lập phiếu kiểm tra";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // tabPhieu
            // 
            this.tabPhieu.Controls.Add(this.dgvPhieu);
            this.tabPhieu.Controls.Add(this.dgvChiTiet);
            this.tabPhieu.Location = new System.Drawing.Point(4, 29);
            this.tabPhieu.Name = "tabPhieu";
            this.tabPhieu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhieu.Size = new System.Drawing.Size(1008, 607);
            this.tabPhieu.TabIndex = 1;
            this.tabPhieu.Text = "Phiếu đã lập";
            this.tabPhieu.UseVisualStyleBackColor = true;
            // 
            // dgvPhieu
            // 
            this.dgvPhieu.Location = new System.Drawing.Point(20, 20);
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.RowHeadersWidth = 30;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.Size = new System.Drawing.Size(960, 230);
            this.dgvPhieu.TabIndex = 0;
            this.dgvPhieu.SelectionChanged += new System.EventHandler(this.dgvPhieu_SelectionChanged);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Location = new System.Drawing.Point(20, 270);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 30;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(960, 290);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // tabPhat
            // 
            this.tabPhat.Controls.Add(this.dgvPhat);
            this.tabPhat.Controls.Add(this.btnThuPhat);
            this.tabPhat.Controls.Add(this.btnPhatTaiLai);
            this.tabPhat.Location = new System.Drawing.Point(4, 29);
            this.tabPhat.Name = "tabPhat";
            this.tabPhat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhat.Size = new System.Drawing.Size(1008, 607);
            this.tabPhat.TabIndex = 2;
            this.tabPhat.Text = "Phiếu phạt";
            this.tabPhat.UseVisualStyleBackColor = true;
            // 
            // dgvPhat
            // 
            this.dgvPhat.Location = new System.Drawing.Point(20, 20);
            this.dgvPhat.Name = "dgvPhat";
            this.dgvPhat.AllowUserToAddRows = false;
            this.dgvPhat.AllowUserToDeleteRows = false;
            this.dgvPhat.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhat.MultiSelect = false;
            this.dgvPhat.ReadOnly = true;
            this.dgvPhat.RowHeadersWidth = 30;
            this.dgvPhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhat.Size = new System.Drawing.Size(960, 440);
            this.dgvPhat.TabIndex = 0;
            // 
            // btnThuPhat
            // 
            this.btnThuPhat.Location = new System.Drawing.Point(20, 475);
            this.btnThuPhat.Name = "btnThuPhat";
            this.btnThuPhat.Size = new System.Drawing.Size(160, 36);
            this.btnThuPhat.TabIndex = 1;
            this.btnThuPhat.Text = "Thu tiền phạt";
            this.btnThuPhat.UseVisualStyleBackColor = true;
            this.btnThuPhat.Click += new System.EventHandler(this.btnThuPhat_Click);
            // 
            // btnPhatTaiLai
            // 
            this.btnPhatTaiLai.Location = new System.Drawing.Point(195, 475);
            this.btnPhatTaiLai.Name = "btnPhatTaiLai";
            this.btnPhatTaiLai.Size = new System.Drawing.Size(120, 36);
            this.btnPhatTaiLai.TabIndex = 2;
            this.btnPhatTaiLai.Text = "Tải lại";
            this.btnPhatTaiLai.UseVisualStyleBackColor = true;
            this.btnPhatTaiLai.Click += new System.EventHandler(this.btnPhatTaiLai_Click);
            // 
            // FrmKiemTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 700);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKiemTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kiểm tra tình trạng phòng - phiếu phạt";
            this.Load += new System.EventHandler(this.FrmKiemTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhat)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabLap.ResumeLayout(false);
            this.tabLap.PerformLayout();
            this.tabPhieu.ResumeLayout(false);
            this.tabPhieu.PerformLayout();
            this.tabPhat.ResumeLayout(false);
            this.tabPhat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabLap;
        private System.Windows.Forms.TabPage tabPhieu;
        private System.Windows.Forms.TabPage tabPhat;
        private System.Windows.Forms.Label lblDenHan;
        private System.Windows.Forms.DataGridView dgvDenHan;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.CheckBox chkKetCau;
        private System.Windows.Forms.Label lblKeHoach;
        private System.Windows.Forms.TextBox txtKeHoach;
        private System.Windows.Forms.Label lblDongGhiChu;
        private System.Windows.Forms.TextBox txtDongGhiChu;
        private System.Windows.Forms.Button btnThemDong;
        private System.Windows.Forms.Button btnBoDong;
        private System.Windows.Forms.DataGridView dgvDong;
        private System.Windows.Forms.Label lblNguoiKT;
        private System.Windows.Forms.TextBox txtNguoiKT;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridView dgvPhat;
        private System.Windows.Forms.Button btnThuPhat;
        private System.Windows.Forms.Button btnPhatTaiLai;
    }
}
