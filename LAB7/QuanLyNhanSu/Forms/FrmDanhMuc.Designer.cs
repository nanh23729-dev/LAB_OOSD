namespace QuanLyNhanSu.Forms
{
    partial class FrmDanhMuc
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
            this.tabPB = new System.Windows.Forms.TabPage();
            this.tabCV = new System.Windows.Forms.TabPage();
            this.tabCa = new System.Windows.Forms.TabPage();
            this.lblPBMa = new System.Windows.Forms.Label();
            this.txtPBMa = new System.Windows.Forms.TextBox();
            this.lblPBTen = new System.Windows.Forms.Label();
            this.txtPBTen = new System.Windows.Forms.TextBox();
            this.lblPBLoai = new System.Windows.Forms.Label();
            this.cboPBLoai = new System.Windows.Forms.ComboBox();
            this.lblPBDienThoai = new System.Windows.Forms.Label();
            this.txtPBDienThoai = new System.Windows.Forms.TextBox();
            this.btnPBThem = new System.Windows.Forms.Button();
            this.btnPBCapNhat = new System.Windows.Forms.Button();
            this.btnPBXoa = new System.Windows.Forms.Button();
            this.btnPBMoi = new System.Windows.Forms.Button();
            this.dgvPB = new System.Windows.Forms.DataGridView();
            this.lblCVMa = new System.Windows.Forms.Label();
            this.txtCVMa = new System.Windows.Forms.TextBox();
            this.lblCVTen = new System.Windows.Forms.Label();
            this.txtCVTen = new System.Windows.Forms.TextBox();
            this.btnCVThem = new System.Windows.Forms.Button();
            this.btnCVCapNhat = new System.Windows.Forms.Button();
            this.btnCVXoa = new System.Windows.Forms.Button();
            this.btnCVMoi = new System.Windows.Forms.Button();
            this.dgvCV = new System.Windows.Forms.DataGridView();
            this.lblCaMa = new System.Windows.Forms.Label();
            this.txtCaMa = new System.Windows.Forms.TextBox();
            this.lblCaTen = new System.Windows.Forms.Label();
            this.txtCaTen = new System.Windows.Forms.TextBox();
            this.lblCaBatDau = new System.Windows.Forms.Label();
            this.dtCaBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblCaKetThuc = new System.Windows.Forms.Label();
            this.dtCaKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btnCaThem = new System.Windows.Forms.Button();
            this.btnCaCapNhat = new System.Windows.Forms.Button();
            this.btnCaXoa = new System.Windows.Forms.Button();
            this.btnCaMoi = new System.Windows.Forms.Button();
            this.dgvCa = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabPB.SuspendLayout();
            this.tabCV.SuspendLayout();
            this.tabCa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCa)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPB);
            this.tabs.Controls.Add(this.tabCV);
            this.tabs.Controls.Add(this.tabCa);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(876, 550);
            this.tabs.TabIndex = 0;
            // 
            // tabPB
            // 
            this.tabPB.Controls.Add(this.lblPBMa);
            this.tabPB.Controls.Add(this.txtPBMa);
            this.tabPB.Controls.Add(this.lblPBTen);
            this.tabPB.Controls.Add(this.txtPBTen);
            this.tabPB.Controls.Add(this.lblPBLoai);
            this.tabPB.Controls.Add(this.cboPBLoai);
            this.tabPB.Controls.Add(this.lblPBDienThoai);
            this.tabPB.Controls.Add(this.txtPBDienThoai);
            this.tabPB.Controls.Add(this.btnPBThem);
            this.tabPB.Controls.Add(this.btnPBCapNhat);
            this.tabPB.Controls.Add(this.btnPBXoa);
            this.tabPB.Controls.Add(this.btnPBMoi);
            this.tabPB.Controls.Add(this.dgvPB);
            this.tabPB.Location = new System.Drawing.Point(4, 29);
            this.tabPB.Name = "tabPB";
            this.tabPB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPB.Size = new System.Drawing.Size(868, 517);
            this.tabPB.TabIndex = 0;
            this.tabPB.Text = "Phòng ban";
            this.tabPB.UseVisualStyleBackColor = true;
            // 
            // lblPBMa
            // 
            this.lblPBMa.AutoSize = true;
            this.lblPBMa.Location = new System.Drawing.Point(20, 23);
            this.lblPBMa.Name = "lblPBMa";
            this.lblPBMa.Size = new System.Drawing.Size(93, 20);
            this.lblPBMa.TabIndex = 0;
            this.lblPBMa.Text = "Mã phòng ban:";
            // 
            // txtPBMa
            // 
            this.txtPBMa.Location = new System.Drawing.Point(140, 20);
            this.txtPBMa.Name = "txtPBMa";
            this.txtPBMa.Size = new System.Drawing.Size(180, 25);
            this.txtPBMa.TabIndex = 1;
            // 
            // lblPBTen
            // 
            this.lblPBTen.AutoSize = true;
            this.lblPBTen.Location = new System.Drawing.Point(20, 58);
            this.lblPBTen.Name = "lblPBTen";
            this.lblPBTen.Size = new System.Drawing.Size(100, 20);
            this.lblPBTen.TabIndex = 2;
            this.lblPBTen.Text = "Tên phòng ban:";
            // 
            // txtPBTen
            // 
            this.txtPBTen.Location = new System.Drawing.Point(140, 55);
            this.txtPBTen.Name = "txtPBTen";
            this.txtPBTen.Size = new System.Drawing.Size(320, 25);
            this.txtPBTen.TabIndex = 3;
            // 
            // lblPBLoai
            // 
            this.lblPBLoai.AutoSize = true;
            this.lblPBLoai.Location = new System.Drawing.Point(20, 93);
            this.lblPBLoai.Name = "lblPBLoai";
            this.lblPBLoai.Size = new System.Drawing.Size(86, 20);
            this.lblPBLoai.TabIndex = 4;
            this.lblPBLoai.Text = "Loại đơn vị:";
            // 
            // cboPBLoai
            // 
            this.cboPBLoai.Location = new System.Drawing.Point(140, 90);
            this.cboPBLoai.Name = "cboPBLoai";
            this.cboPBLoai.Size = new System.Drawing.Size(180, 25);
            this.cboPBLoai.TabIndex = 5;
            this.cboPBLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPBLoai.FormattingEnabled = true;
            // 
            // lblPBDienThoai
            // 
            this.lblPBDienThoai.AutoSize = true;
            this.lblPBDienThoai.Location = new System.Drawing.Point(20, 128);
            this.lblPBDienThoai.Name = "lblPBDienThoai";
            this.lblPBDienThoai.Size = new System.Drawing.Size(79, 20);
            this.lblPBDienThoai.TabIndex = 6;
            this.lblPBDienThoai.Text = "Điện thoại:";
            // 
            // txtPBDienThoai
            // 
            this.txtPBDienThoai.Location = new System.Drawing.Point(140, 125);
            this.txtPBDienThoai.Name = "txtPBDienThoai";
            this.txtPBDienThoai.Size = new System.Drawing.Size(180, 25);
            this.txtPBDienThoai.TabIndex = 7;
            // 
            // btnPBThem
            // 
            this.btnPBThem.Location = new System.Drawing.Point(520, 17);
            this.btnPBThem.Name = "btnPBThem";
            this.btnPBThem.Size = new System.Drawing.Size(100, 32);
            this.btnPBThem.TabIndex = 8;
            this.btnPBThem.Text = "Thêm";
            this.btnPBThem.UseVisualStyleBackColor = true;
            this.btnPBThem.Click += new System.EventHandler(this.btnPBThem_Click);
            // 
            // btnPBCapNhat
            // 
            this.btnPBCapNhat.Location = new System.Drawing.Point(630, 17);
            this.btnPBCapNhat.Name = "btnPBCapNhat";
            this.btnPBCapNhat.Size = new System.Drawing.Size(100, 32);
            this.btnPBCapNhat.TabIndex = 9;
            this.btnPBCapNhat.Text = "Cập nhật";
            this.btnPBCapNhat.UseVisualStyleBackColor = true;
            this.btnPBCapNhat.Click += new System.EventHandler(this.btnPBCapNhat_Click);
            // 
            // btnPBXoa
            // 
            this.btnPBXoa.Location = new System.Drawing.Point(520, 57);
            this.btnPBXoa.Name = "btnPBXoa";
            this.btnPBXoa.Size = new System.Drawing.Size(100, 32);
            this.btnPBXoa.TabIndex = 10;
            this.btnPBXoa.Text = "Xóa";
            this.btnPBXoa.UseVisualStyleBackColor = true;
            this.btnPBXoa.Click += new System.EventHandler(this.btnPBXoa_Click);
            // 
            // btnPBMoi
            // 
            this.btnPBMoi.Location = new System.Drawing.Point(630, 57);
            this.btnPBMoi.Name = "btnPBMoi";
            this.btnPBMoi.Size = new System.Drawing.Size(100, 32);
            this.btnPBMoi.TabIndex = 11;
            this.btnPBMoi.Text = "Làm mới";
            this.btnPBMoi.UseVisualStyleBackColor = true;
            this.btnPBMoi.Click += new System.EventHandler(this.btnPBMoi_Click);
            // 
            // dgvPB
            // 
            this.dgvPB.Location = new System.Drawing.Point(20, 165);
            this.dgvPB.Name = "dgvPB";
            this.dgvPB.AllowUserToAddRows = false;
            this.dgvPB.AllowUserToDeleteRows = false;
            this.dgvPB.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPB.MultiSelect = false;
            this.dgvPB.ReadOnly = true;
            this.dgvPB.RowHeadersWidth = 30;
            this.dgvPB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPB.Size = new System.Drawing.Size(826, 330);
            this.dgvPB.TabIndex = 12;
            this.dgvPB.SelectionChanged += new System.EventHandler(this.dgvPB_SelectionChanged);
            // 
            // tabCV
            // 
            this.tabCV.Controls.Add(this.lblCVMa);
            this.tabCV.Controls.Add(this.txtCVMa);
            this.tabCV.Controls.Add(this.lblCVTen);
            this.tabCV.Controls.Add(this.txtCVTen);
            this.tabCV.Controls.Add(this.btnCVThem);
            this.tabCV.Controls.Add(this.btnCVCapNhat);
            this.tabCV.Controls.Add(this.btnCVXoa);
            this.tabCV.Controls.Add(this.btnCVMoi);
            this.tabCV.Controls.Add(this.dgvCV);
            this.tabCV.Location = new System.Drawing.Point(4, 29);
            this.tabCV.Name = "tabCV";
            this.tabCV.Padding = new System.Windows.Forms.Padding(3);
            this.tabCV.Size = new System.Drawing.Size(868, 517);
            this.tabCV.TabIndex = 1;
            this.tabCV.Text = "Chức vụ";
            this.tabCV.UseVisualStyleBackColor = true;
            // 
            // lblCVMa
            // 
            this.lblCVMa.AutoSize = true;
            this.lblCVMa.Location = new System.Drawing.Point(20, 23);
            this.lblCVMa.Name = "lblCVMa";
            this.lblCVMa.Size = new System.Drawing.Size(79, 20);
            this.lblCVMa.TabIndex = 0;
            this.lblCVMa.Text = "Mã chức vụ:";
            // 
            // txtCVMa
            // 
            this.txtCVMa.Location = new System.Drawing.Point(140, 20);
            this.txtCVMa.Name = "txtCVMa";
            this.txtCVMa.Size = new System.Drawing.Size(180, 25);
            this.txtCVMa.TabIndex = 1;
            // 
            // lblCVTen
            // 
            this.lblCVTen.AutoSize = true;
            this.lblCVTen.Location = new System.Drawing.Point(20, 58);
            this.lblCVTen.Name = "lblCVTen";
            this.lblCVTen.Size = new System.Drawing.Size(86, 20);
            this.lblCVTen.TabIndex = 2;
            this.lblCVTen.Text = "Tên chức vụ:";
            // 
            // txtCVTen
            // 
            this.txtCVTen.Location = new System.Drawing.Point(140, 55);
            this.txtCVTen.Name = "txtCVTen";
            this.txtCVTen.Size = new System.Drawing.Size(320, 25);
            this.txtCVTen.TabIndex = 3;
            // 
            // btnCVThem
            // 
            this.btnCVThem.Location = new System.Drawing.Point(520, 17);
            this.btnCVThem.Name = "btnCVThem";
            this.btnCVThem.Size = new System.Drawing.Size(100, 32);
            this.btnCVThem.TabIndex = 4;
            this.btnCVThem.Text = "Thêm";
            this.btnCVThem.UseVisualStyleBackColor = true;
            this.btnCVThem.Click += new System.EventHandler(this.btnCVThem_Click);
            // 
            // btnCVCapNhat
            // 
            this.btnCVCapNhat.Location = new System.Drawing.Point(630, 17);
            this.btnCVCapNhat.Name = "btnCVCapNhat";
            this.btnCVCapNhat.Size = new System.Drawing.Size(100, 32);
            this.btnCVCapNhat.TabIndex = 5;
            this.btnCVCapNhat.Text = "Cập nhật";
            this.btnCVCapNhat.UseVisualStyleBackColor = true;
            this.btnCVCapNhat.Click += new System.EventHandler(this.btnCVCapNhat_Click);
            // 
            // btnCVXoa
            // 
            this.btnCVXoa.Location = new System.Drawing.Point(520, 57);
            this.btnCVXoa.Name = "btnCVXoa";
            this.btnCVXoa.Size = new System.Drawing.Size(100, 32);
            this.btnCVXoa.TabIndex = 6;
            this.btnCVXoa.Text = "Xóa";
            this.btnCVXoa.UseVisualStyleBackColor = true;
            this.btnCVXoa.Click += new System.EventHandler(this.btnCVXoa_Click);
            // 
            // btnCVMoi
            // 
            this.btnCVMoi.Location = new System.Drawing.Point(630, 57);
            this.btnCVMoi.Name = "btnCVMoi";
            this.btnCVMoi.Size = new System.Drawing.Size(100, 32);
            this.btnCVMoi.TabIndex = 7;
            this.btnCVMoi.Text = "Làm mới";
            this.btnCVMoi.UseVisualStyleBackColor = true;
            this.btnCVMoi.Click += new System.EventHandler(this.btnCVMoi_Click);
            // 
            // dgvCV
            // 
            this.dgvCV.Location = new System.Drawing.Point(20, 105);
            this.dgvCV.Name = "dgvCV";
            this.dgvCV.AllowUserToAddRows = false;
            this.dgvCV.AllowUserToDeleteRows = false;
            this.dgvCV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCV.MultiSelect = false;
            this.dgvCV.ReadOnly = true;
            this.dgvCV.RowHeadersWidth = 30;
            this.dgvCV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCV.Size = new System.Drawing.Size(826, 390);
            this.dgvCV.TabIndex = 8;
            this.dgvCV.SelectionChanged += new System.EventHandler(this.dgvCV_SelectionChanged);
            // 
            // tabCa
            // 
            this.tabCa.Controls.Add(this.lblCaMa);
            this.tabCa.Controls.Add(this.txtCaMa);
            this.tabCa.Controls.Add(this.lblCaTen);
            this.tabCa.Controls.Add(this.txtCaTen);
            this.tabCa.Controls.Add(this.lblCaBatDau);
            this.tabCa.Controls.Add(this.dtCaBatDau);
            this.tabCa.Controls.Add(this.lblCaKetThuc);
            this.tabCa.Controls.Add(this.dtCaKetThuc);
            this.tabCa.Controls.Add(this.btnCaThem);
            this.tabCa.Controls.Add(this.btnCaCapNhat);
            this.tabCa.Controls.Add(this.btnCaXoa);
            this.tabCa.Controls.Add(this.btnCaMoi);
            this.tabCa.Controls.Add(this.dgvCa);
            this.tabCa.Location = new System.Drawing.Point(4, 29);
            this.tabCa.Name = "tabCa";
            this.tabCa.Padding = new System.Windows.Forms.Padding(3);
            this.tabCa.Size = new System.Drawing.Size(868, 517);
            this.tabCa.TabIndex = 2;
            this.tabCa.Text = "Ca làm việc";
            this.tabCa.UseVisualStyleBackColor = true;
            // 
            // lblCaMa
            // 
            this.lblCaMa.AutoSize = true;
            this.lblCaMa.Location = new System.Drawing.Point(20, 23);
            this.lblCaMa.Name = "lblCaMa";
            this.lblCaMa.Size = new System.Drawing.Size(43, 20);
            this.lblCaMa.TabIndex = 0;
            this.lblCaMa.Text = "Mã ca:";
            // 
            // txtCaMa
            // 
            this.txtCaMa.Location = new System.Drawing.Point(140, 20);
            this.txtCaMa.Name = "txtCaMa";
            this.txtCaMa.Size = new System.Drawing.Size(180, 25);
            this.txtCaMa.TabIndex = 1;
            // 
            // lblCaTen
            // 
            this.lblCaTen.AutoSize = true;
            this.lblCaTen.Location = new System.Drawing.Point(20, 58);
            this.lblCaTen.Name = "lblCaTen";
            this.lblCaTen.Size = new System.Drawing.Size(50, 20);
            this.lblCaTen.TabIndex = 2;
            this.lblCaTen.Text = "Tên ca:";
            // 
            // txtCaTen
            // 
            this.txtCaTen.Location = new System.Drawing.Point(140, 55);
            this.txtCaTen.Name = "txtCaTen";
            this.txtCaTen.Size = new System.Drawing.Size(320, 25);
            this.txtCaTen.TabIndex = 3;
            // 
            // lblCaBatDau
            // 
            this.lblCaBatDau.AutoSize = true;
            this.lblCaBatDau.Location = new System.Drawing.Point(20, 93);
            this.lblCaBatDau.Name = "lblCaBatDau";
            this.lblCaBatDau.Size = new System.Drawing.Size(86, 20);
            this.lblCaBatDau.TabIndex = 4;
            this.lblCaBatDau.Text = "Giờ bắt đầu:";
            // 
            // dtCaBatDau
            // 
            this.dtCaBatDau.Location = new System.Drawing.Point(140, 90);
            this.dtCaBatDau.Name = "dtCaBatDau";
            this.dtCaBatDau.Size = new System.Drawing.Size(120, 25);
            this.dtCaBatDau.TabIndex = 5;
            this.dtCaBatDau.CustomFormat = "HH:mm";
            this.dtCaBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCaBatDau.ShowUpDown = true;
            // 
            // lblCaKetThuc
            // 
            this.lblCaKetThuc.AutoSize = true;
            this.lblCaKetThuc.Location = new System.Drawing.Point(20, 128);
            this.lblCaKetThuc.Name = "lblCaKetThuc";
            this.lblCaKetThuc.Size = new System.Drawing.Size(93, 20);
            this.lblCaKetThuc.TabIndex = 6;
            this.lblCaKetThuc.Text = "Giờ kết thúc:";
            // 
            // dtCaKetThuc
            // 
            this.dtCaKetThuc.Location = new System.Drawing.Point(140, 125);
            this.dtCaKetThuc.Name = "dtCaKetThuc";
            this.dtCaKetThuc.Size = new System.Drawing.Size(120, 25);
            this.dtCaKetThuc.TabIndex = 7;
            this.dtCaKetThuc.CustomFormat = "HH:mm";
            this.dtCaKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCaKetThuc.ShowUpDown = true;
            // 
            // btnCaThem
            // 
            this.btnCaThem.Location = new System.Drawing.Point(520, 17);
            this.btnCaThem.Name = "btnCaThem";
            this.btnCaThem.Size = new System.Drawing.Size(100, 32);
            this.btnCaThem.TabIndex = 8;
            this.btnCaThem.Text = "Thêm";
            this.btnCaThem.UseVisualStyleBackColor = true;
            this.btnCaThem.Click += new System.EventHandler(this.btnCaThem_Click);
            // 
            // btnCaCapNhat
            // 
            this.btnCaCapNhat.Location = new System.Drawing.Point(630, 17);
            this.btnCaCapNhat.Name = "btnCaCapNhat";
            this.btnCaCapNhat.Size = new System.Drawing.Size(100, 32);
            this.btnCaCapNhat.TabIndex = 9;
            this.btnCaCapNhat.Text = "Cập nhật";
            this.btnCaCapNhat.UseVisualStyleBackColor = true;
            this.btnCaCapNhat.Click += new System.EventHandler(this.btnCaCapNhat_Click);
            // 
            // btnCaXoa
            // 
            this.btnCaXoa.Location = new System.Drawing.Point(520, 57);
            this.btnCaXoa.Name = "btnCaXoa";
            this.btnCaXoa.Size = new System.Drawing.Size(100, 32);
            this.btnCaXoa.TabIndex = 10;
            this.btnCaXoa.Text = "Xóa";
            this.btnCaXoa.UseVisualStyleBackColor = true;
            this.btnCaXoa.Click += new System.EventHandler(this.btnCaXoa_Click);
            // 
            // btnCaMoi
            // 
            this.btnCaMoi.Location = new System.Drawing.Point(630, 57);
            this.btnCaMoi.Name = "btnCaMoi";
            this.btnCaMoi.Size = new System.Drawing.Size(100, 32);
            this.btnCaMoi.TabIndex = 11;
            this.btnCaMoi.Text = "Làm mới";
            this.btnCaMoi.UseVisualStyleBackColor = true;
            this.btnCaMoi.Click += new System.EventHandler(this.btnCaMoi_Click);
            // 
            // dgvCa
            // 
            this.dgvCa.Location = new System.Drawing.Point(20, 165);
            this.dgvCa.Name = "dgvCa";
            this.dgvCa.AllowUserToAddRows = false;
            this.dgvCa.AllowUserToDeleteRows = false;
            this.dgvCa.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCa.MultiSelect = false;
            this.dgvCa.ReadOnly = true;
            this.dgvCa.RowHeadersWidth = 30;
            this.dgvCa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCa.Size = new System.Drawing.Size(826, 330);
            this.dgvCa.TabIndex = 12;
            this.dgvCa.SelectionChanged += new System.EventHandler(this.dgvCa_SelectionChanged);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(788, 574);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 34);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục: phòng ban - chức vụ - ca làm việc";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCa)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabPB.ResumeLayout(false);
            this.tabPB.PerformLayout();
            this.tabCV.ResumeLayout(false);
            this.tabCV.PerformLayout();
            this.tabCa.ResumeLayout(false);
            this.tabCa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPB;
        private System.Windows.Forms.TabPage tabCV;
        private System.Windows.Forms.TabPage tabCa;
        private System.Windows.Forms.Label lblPBMa;
        private System.Windows.Forms.TextBox txtPBMa;
        private System.Windows.Forms.Label lblPBTen;
        private System.Windows.Forms.TextBox txtPBTen;
        private System.Windows.Forms.Label lblPBLoai;
        private System.Windows.Forms.ComboBox cboPBLoai;
        private System.Windows.Forms.Label lblPBDienThoai;
        private System.Windows.Forms.TextBox txtPBDienThoai;
        private System.Windows.Forms.Button btnPBThem;
        private System.Windows.Forms.Button btnPBCapNhat;
        private System.Windows.Forms.Button btnPBXoa;
        private System.Windows.Forms.Button btnPBMoi;
        private System.Windows.Forms.DataGridView dgvPB;
        private System.Windows.Forms.Label lblCVMa;
        private System.Windows.Forms.TextBox txtCVMa;
        private System.Windows.Forms.Label lblCVTen;
        private System.Windows.Forms.TextBox txtCVTen;
        private System.Windows.Forms.Button btnCVThem;
        private System.Windows.Forms.Button btnCVCapNhat;
        private System.Windows.Forms.Button btnCVXoa;
        private System.Windows.Forms.Button btnCVMoi;
        private System.Windows.Forms.DataGridView dgvCV;
        private System.Windows.Forms.Label lblCaMa;
        private System.Windows.Forms.TextBox txtCaMa;
        private System.Windows.Forms.Label lblCaTen;
        private System.Windows.Forms.TextBox txtCaTen;
        private System.Windows.Forms.Label lblCaBatDau;
        private System.Windows.Forms.DateTimePicker dtCaBatDau;
        private System.Windows.Forms.Label lblCaKetThuc;
        private System.Windows.Forms.DateTimePicker dtCaKetThuc;
        private System.Windows.Forms.Button btnCaThem;
        private System.Windows.Forms.Button btnCaCapNhat;
        private System.Windows.Forms.Button btnCaXoa;
        private System.Windows.Forms.Button btnCaMoi;
        private System.Windows.Forms.DataGridView dgvCa;
        private System.Windows.Forms.Button btnDong;
    }
}
