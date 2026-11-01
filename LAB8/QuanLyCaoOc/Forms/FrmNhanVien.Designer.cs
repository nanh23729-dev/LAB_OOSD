namespace QuanLyCaoOc.Forms
{
    partial class FrmNhanVien
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
            this.tabNV = new System.Windows.Forms.TabPage();
            this.tabThe = new System.Windows.Forms.TabPage();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblHinh = new System.Windows.Forms.Label();
            this.txtHinh = new System.Windows.Forms.TextBox();
            this.btnChonHinh = new System.Windows.Forms.Button();
            this.picHinh = new System.Windows.Forms.PictureBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnNghi = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.lblTheNV = new System.Windows.Forms.Label();
            this.cboTheNV = new System.Windows.Forms.ComboBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblHieuXe = new System.Windows.Forms.Label();
            this.txtHieuXe = new System.Windows.Forms.TextBox();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.btnCapThe = new System.Windows.Forms.Button();
            this.btnThuHoi = new System.Windows.Forms.Button();
            this.dgvThe = new System.Windows.Forms.DataGridView();
            this.tabs.SuspendLayout();
            this.tabNV.SuspendLayout();
            this.tabThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThe)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabNV);
            this.tabs.Controls.Add(this.tabThe);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1016, 640);
            this.tabs.TabIndex = 0;
            // 
            // tabNV
            // 
            this.tabNV.Controls.Add(this.lblMa);
            this.tabNV.Controls.Add(this.txtMa);
            this.tabNV.Controls.Add(this.lblTen);
            this.tabNV.Controls.Add(this.txtTen);
            this.tabNV.Controls.Add(this.lblGioiTinh);
            this.tabNV.Controls.Add(this.cboGioiTinh);
            this.tabNV.Controls.Add(this.lblNgaySinh);
            this.tabNV.Controls.Add(this.dtNgaySinh);
            this.tabNV.Controls.Add(this.lblChucVu);
            this.tabNV.Controls.Add(this.txtChucVu);
            this.tabNV.Controls.Add(this.lblPhong);
            this.tabNV.Controls.Add(this.cboPhong);
            this.tabNV.Controls.Add(this.lblHinh);
            this.tabNV.Controls.Add(this.txtHinh);
            this.tabNV.Controls.Add(this.btnChonHinh);
            this.tabNV.Controls.Add(this.picHinh);
            this.tabNV.Controls.Add(this.btnThem);
            this.tabNV.Controls.Add(this.btnCapNhat);
            this.tabNV.Controls.Add(this.btnNghi);
            this.tabNV.Controls.Add(this.btnMoi);
            this.tabNV.Controls.Add(this.lblTim);
            this.tabNV.Controls.Add(this.txtTim);
            this.tabNV.Controls.Add(this.btnTim);
            this.tabNV.Controls.Add(this.dgvNV);
            this.tabNV.Location = new System.Drawing.Point(4, 29);
            this.tabNV.Name = "tabNV";
            this.tabNV.Padding = new System.Windows.Forms.Padding(3);
            this.tabNV.Size = new System.Drawing.Size(1008, 607);
            this.tabNV.TabIndex = 0;
            this.tabNV.Text = "Nhân viên";
            this.tabNV.UseVisualStyleBackColor = true;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(20, 23);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(43, 20);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã NV:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(120, 20);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(150, 25);
            this.txtMa.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(20, 58);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(50, 20);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Họ tên:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(120, 55);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(280, 25);
            this.txtTen.TabIndex = 3;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(20, 93);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(72, 20);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Location = new System.Drawing.Point(120, 90);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(120, 25);
            this.cboGioiTinh.TabIndex = 5;
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 128);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(72, 20);
            this.lblNgaySinh.TabIndex = 6;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Location = new System.Drawing.Point(120, 125);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(150, 25);
            this.dtNgaySinh.TabIndex = 7;
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(20, 163);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(57, 20);
            this.lblChucVu.TabIndex = 8;
            this.lblChucVu.Text = "Chức vụ:";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(120, 160);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(250, 25);
            this.txtChucVu.TabIndex = 9;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(20, 198);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(93, 20);
            this.lblPhong.TabIndex = 10;
            this.lblPhong.Text = "Làm việc tại:";
            // 
            // cboPhong
            // 
            this.cboPhong.Location = new System.Drawing.Point(120, 195);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(320, 25);
            this.cboPhong.TabIndex = 11;
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            // 
            // lblHinh
            // 
            this.lblHinh.AutoSize = true;
            this.lblHinh.Location = new System.Drawing.Point(20, 233);
            this.lblHinh.Name = "lblHinh";
            this.lblHinh.Size = new System.Drawing.Size(64, 20);
            this.lblHinh.TabIndex = 12;
            this.lblHinh.Text = "Hình ảnh:";
            // 
            // txtHinh
            // 
            this.txtHinh.Location = new System.Drawing.Point(120, 230);
            this.txtHinh.Name = "txtHinh";
            this.txtHinh.ReadOnly = true;
            this.txtHinh.Size = new System.Drawing.Size(280, 25);
            this.txtHinh.TabIndex = 13;
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.Location = new System.Drawing.Point(410, 227);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(100, 30);
            this.btnChonHinh.TabIndex = 14;
            this.btnChonHinh.Text = "Chọn ảnh...";
            this.btnChonHinh.UseVisualStyleBackColor = true;
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click);
            // 
            // picHinh
            // 
            this.picHinh.Location = new System.Drawing.Point(640, 20);
            this.picHinh.Name = "picHinh";
            this.picHinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinh.TabStop = false;
            this.picHinh.Size = new System.Drawing.Size(130, 160);
            this.picHinh.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(800, 17);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 32);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(800, 57);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(110, 32);
            this.btnCapNhat.TabIndex = 17;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnNghi
            // 
            this.btnNghi.Location = new System.Drawing.Point(800, 97);
            this.btnNghi.Name = "btnNghi";
            this.btnNghi.Size = new System.Drawing.Size(110, 32);
            this.btnNghi.TabIndex = 18;
            this.btnNghi.Text = "Cho nghỉ việc";
            this.btnNghi.UseVisualStyleBackColor = true;
            this.btnNghi.Click += new System.EventHandler(this.btnNghi_Click);
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(800, 137);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(110, 32);
            this.btnMoi.TabIndex = 19;
            this.btnMoi.Text = "Làm mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(20, 283);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(64, 20);
            this.lblTim.TabIndex = 20;
            this.lblTim.Text = "Tìm kiếm:";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(120, 280);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(280, 25);
            this.txtTim.TabIndex = 21;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(410, 277);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 30);
            this.btnTim.TabIndex = 22;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvNV
            // 
            this.dgvNV.Location = new System.Drawing.Point(20, 320);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.AllowUserToAddRows = false;
            this.dgvNV.AllowUserToDeleteRows = false;
            this.dgvNV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.MultiSelect = false;
            this.dgvNV.ReadOnly = true;
            this.dgvNV.RowHeadersWidth = 30;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNV.Size = new System.Drawing.Size(960, 260);
            this.dgvNV.TabIndex = 23;
            this.dgvNV.SelectionChanged += new System.EventHandler(this.dgvNV_SelectionChanged);
            // 
            // tabThe
            // 
            this.tabThe.Controls.Add(this.lblTheNV);
            this.tabThe.Controls.Add(this.cboTheNV);
            this.tabThe.Controls.Add(this.lblMaThe);
            this.tabThe.Controls.Add(this.txtMaThe);
            this.tabThe.Controls.Add(this.lblBienSo);
            this.tabThe.Controls.Add(this.txtBienSo);
            this.tabThe.Controls.Add(this.lblLoaiXe);
            this.tabThe.Controls.Add(this.cboLoaiXe);
            this.tabThe.Controls.Add(this.lblHieuXe);
            this.tabThe.Controls.Add(this.txtHieuXe);
            this.tabThe.Controls.Add(this.lblMauSac);
            this.tabThe.Controls.Add(this.txtMauSac);
            this.tabThe.Controls.Add(this.btnCapThe);
            this.tabThe.Controls.Add(this.btnThuHoi);
            this.tabThe.Controls.Add(this.dgvThe);
            this.tabThe.Location = new System.Drawing.Point(4, 29);
            this.tabThe.Name = "tabThe";
            this.tabThe.Padding = new System.Windows.Forms.Padding(3);
            this.tabThe.Size = new System.Drawing.Size(1008, 607);
            this.tabThe.TabIndex = 1;
            this.tabThe.Text = "Thẻ giữ xe";
            this.tabThe.UseVisualStyleBackColor = true;
            // 
            // lblTheNV
            // 
            this.lblTheNV.AutoSize = true;
            this.lblTheNV.Location = new System.Drawing.Point(20, 23);
            this.lblTheNV.Name = "lblTheNV";
            this.lblTheNV.Size = new System.Drawing.Size(72, 20);
            this.lblTheNV.TabIndex = 0;
            this.lblTheNV.Text = "Nhân viên:";
            // 
            // cboTheNV
            // 
            this.cboTheNV.Location = new System.Drawing.Point(120, 20);
            this.cboTheNV.Name = "cboTheNV";
            this.cboTheNV.Size = new System.Drawing.Size(320, 25);
            this.cboTheNV.TabIndex = 1;
            this.cboTheNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheNV.FormattingEnabled = true;
            this.cboTheNV.SelectedIndexChanged += new System.EventHandler(this.cboTheNV_SelectedIndexChanged);
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(20, 63);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(50, 20);
            this.lblMaThe.TabIndex = 2;
            this.lblMaThe.Text = "Mã thẻ:";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(120, 60);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(150, 25);
            this.txtMaThe.TabIndex = 3;
            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location = new System.Drawing.Point(20, 98);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(57, 20);
            this.lblBienSo.TabIndex = 4;
            this.lblBienSo.Text = "Biển số:";
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(120, 95);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(170, 25);
            this.txtBienSo.TabIndex = 5;
            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location = new System.Drawing.Point(20, 133);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size = new System.Drawing.Size(57, 20);
            this.lblLoaiXe.TabIndex = 6;
            this.lblLoaiXe.Text = "Loại xe:";
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.Location = new System.Drawing.Point(120, 130);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size = new System.Drawing.Size(150, 25);
            this.cboLoaiXe.TabIndex = 7;
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            // 
            // lblHieuXe
            // 
            this.lblHieuXe.AutoSize = true;
            this.lblHieuXe.Location = new System.Drawing.Point(20, 168);
            this.lblHieuXe.Name = "lblHieuXe";
            this.lblHieuXe.Size = new System.Drawing.Size(57, 20);
            this.lblHieuXe.TabIndex = 8;
            this.lblHieuXe.Text = "Hiệu xe:";
            // 
            // txtHieuXe
            // 
            this.txtHieuXe.Location = new System.Drawing.Point(120, 165);
            this.txtHieuXe.Name = "txtHieuXe";
            this.txtHieuXe.Size = new System.Drawing.Size(200, 25);
            this.txtHieuXe.TabIndex = 9;
            // 
            // lblMauSac
            // 
            this.lblMauSac.AutoSize = true;
            this.lblMauSac.Location = new System.Drawing.Point(20, 203);
            this.lblMauSac.Name = "lblMauSac";
            this.lblMauSac.Size = new System.Drawing.Size(57, 20);
            this.lblMauSac.TabIndex = 10;
            this.lblMauSac.Text = "Màu sắc:";
            // 
            // txtMauSac
            // 
            this.txtMauSac.Location = new System.Drawing.Point(120, 200);
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(150, 25);
            this.txtMauSac.TabIndex = 11;
            // 
            // btnCapThe
            // 
            this.btnCapThe.Location = new System.Drawing.Point(20, 245);
            this.btnCapThe.Name = "btnCapThe";
            this.btnCapThe.Size = new System.Drawing.Size(130, 34);
            this.btnCapThe.TabIndex = 12;
            this.btnCapThe.Text = "Cấp thẻ";
            this.btnCapThe.UseVisualStyleBackColor = true;
            this.btnCapThe.Click += new System.EventHandler(this.btnCapThe_Click);
            // 
            // btnThuHoi
            // 
            this.btnThuHoi.Location = new System.Drawing.Point(165, 245);
            this.btnThuHoi.Name = "btnThuHoi";
            this.btnThuHoi.Size = new System.Drawing.Size(170, 34);
            this.btnThuHoi.TabIndex = 13;
            this.btnThuHoi.Text = "Thu hồi thẻ chọn";
            this.btnThuHoi.UseVisualStyleBackColor = true;
            this.btnThuHoi.Click += new System.EventHandler(this.btnThuHoi_Click);
            // 
            // dgvThe
            // 
            this.dgvThe.Location = new System.Drawing.Point(20, 300);
            this.dgvThe.Name = "dgvThe";
            this.dgvThe.AllowUserToAddRows = false;
            this.dgvThe.AllowUserToDeleteRows = false;
            this.dgvThe.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvThe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThe.MultiSelect = false;
            this.dgvThe.ReadOnly = true;
            this.dgvThe.RowHeadersWidth = 30;
            this.dgvThe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThe.Size = new System.Drawing.Size(960, 270);
            this.dgvThe.TabIndex = 14;
            // 
            // FrmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 700);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhân viên làm việc tại phòng thuê - thẻ giữ xe";
            this.Load += new System.EventHandler(this.FrmNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThe)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabNV.ResumeLayout(false);
            this.tabNV.PerformLayout();
            this.tabThe.ResumeLayout(false);
            this.tabThe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabNV;
        private System.Windows.Forms.TabPage tabThe;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblHinh;
        private System.Windows.Forms.TextBox txtHinh;
        private System.Windows.Forms.Button btnChonHinh;
        private System.Windows.Forms.PictureBox picHinh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnNghi;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Label lblTheNV;
        private System.Windows.Forms.ComboBox cboTheNV;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Label lblHieuXe;
        private System.Windows.Forms.TextBox txtHieuXe;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.Button btnCapThe;
        private System.Windows.Forms.Button btnThuHoi;
        private System.Windows.Forms.DataGridView dgvThe;
    }
}
