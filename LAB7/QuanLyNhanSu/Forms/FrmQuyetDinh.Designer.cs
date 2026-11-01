namespace QuanLyNhanSu.Forms
{
    partial class FrmQuyetDinh
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
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblHienHanh = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabLuong = new System.Windows.Forms.TabPage();
            this.tabChucVu = new System.Windows.Forms.TabPage();
            this.lblLSoQD = new System.Windows.Forms.Label();
            this.txtLSoQD = new System.Windows.Forms.TextBox();
            this.lblLNgayKy = new System.Windows.Forms.Label();
            this.dtLNgayKy = new System.Windows.Forms.DateTimePicker();
            this.lblLHieuLuc = new System.Windows.Forms.Label();
            this.dtLHieuLuc = new System.Windows.Forms.DateTimePicker();
            this.lblLNguoiKy = new System.Windows.Forms.Label();
            this.txtLNguoiKy = new System.Windows.Forms.TextBox();
            this.lblLCB = new System.Windows.Forms.Label();
            this.numLCB = new System.Windows.Forms.NumericUpDown();
            this.lblLPCLuong = new System.Windows.Forms.Label();
            this.numLPCLuong = new System.Windows.Forms.NumericUpDown();
            this.lblLPCDocHai = new System.Windows.Forms.Label();
            this.numLPCDocHai = new System.Windows.Forms.NumericUpDown();
            this.btnLLap = new System.Windows.Forms.Button();
            this.btnLMoi = new System.Windows.Forms.Button();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.lblCSoQD = new System.Windows.Forms.Label();
            this.txtCSoQD = new System.Windows.Forms.TextBox();
            this.lblCNgayKy = new System.Windows.Forms.Label();
            this.dtCNgayKy = new System.Windows.Forms.DateTimePicker();
            this.lblCHieuLuc = new System.Windows.Forms.Label();
            this.dtCHieuLuc = new System.Windows.Forms.DateTimePicker();
            this.lblCNguoiKy = new System.Windows.Forms.Label();
            this.txtCNguoiKy = new System.Windows.Forms.TextBox();
            this.lblCChucVu = new System.Windows.Forms.Label();
            this.cboCChucVu = new System.Windows.Forms.ComboBox();
            this.lblCPhongBan = new System.Windows.Forms.Label();
            this.cboCPhongBan = new System.Windows.Forms.ComboBox();
            this.lblCPhuCap = new System.Windows.Forms.Label();
            this.numCPhuCap = new System.Windows.Forms.NumericUpDown();
            this.btnCLap = new System.Windows.Forms.Button();
            this.btnCMoi = new System.Windows.Forms.Button();
            this.dgvChucVu = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabLuong.SuspendLayout();
            this.tabChucVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLCB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLPCLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLPCDocHai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(14, 18);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(165, 20);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Nhân viên (chính thức):";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Location = new System.Drawing.Point(180, 15);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(330, 25);
            this.cboNhanVien.TabIndex = 1;
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            // 
            // lblHienHanh
            // 
            this.lblHienHanh.AutoSize = true;
            this.lblHienHanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblHienHanh.Location = new System.Drawing.Point(14, 50);
            this.lblHienHanh.Name = "lblHienHanh";
            this.lblHienHanh.Size = new System.Drawing.Size(900, 20);
            this.lblHienHanh.TabIndex = 2;
            this.lblHienHanh.Text = "Hiện hành: LCB 7,800,000 | PC lương 300,000 | PC độc hại 600,000  ||  Công nhân - PC chức vụ 0";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabLuong);
            this.tabs.Controls.Add(this.tabChucVu);
            this.tabs.Location = new System.Drawing.Point(12, 78);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(976, 520);
            this.tabs.TabIndex = 3;
            // 
            // tabLuong
            // 
            this.tabLuong.Controls.Add(this.lblLSoQD);
            this.tabLuong.Controls.Add(this.txtLSoQD);
            this.tabLuong.Controls.Add(this.lblLNgayKy);
            this.tabLuong.Controls.Add(this.dtLNgayKy);
            this.tabLuong.Controls.Add(this.lblLHieuLuc);
            this.tabLuong.Controls.Add(this.dtLHieuLuc);
            this.tabLuong.Controls.Add(this.lblLNguoiKy);
            this.tabLuong.Controls.Add(this.txtLNguoiKy);
            this.tabLuong.Controls.Add(this.lblLCB);
            this.tabLuong.Controls.Add(this.numLCB);
            this.tabLuong.Controls.Add(this.lblLPCLuong);
            this.tabLuong.Controls.Add(this.numLPCLuong);
            this.tabLuong.Controls.Add(this.lblLPCDocHai);
            this.tabLuong.Controls.Add(this.numLPCDocHai);
            this.tabLuong.Controls.Add(this.btnLLap);
            this.tabLuong.Controls.Add(this.btnLMoi);
            this.tabLuong.Controls.Add(this.dgvLuong);
            this.tabLuong.Location = new System.Drawing.Point(4, 29);
            this.tabLuong.Name = "tabLuong";
            this.tabLuong.Padding = new System.Windows.Forms.Padding(3);
            this.tabLuong.Size = new System.Drawing.Size(968, 487);
            this.tabLuong.TabIndex = 0;
            this.tabLuong.Text = "Quyết định lương";
            this.tabLuong.UseVisualStyleBackColor = true;
            // 
            // lblLSoQD
            // 
            this.lblLSoQD.AutoSize = true;
            this.lblLSoQD.Location = new System.Drawing.Point(20, 23);
            this.lblLSoQD.Name = "lblLSoQD";
            this.lblLSoQD.Size = new System.Drawing.Size(43, 20);
            this.lblLSoQD.TabIndex = 0;
            this.lblLSoQD.Text = "Số QĐ:";
            // 
            // txtLSoQD
            // 
            this.txtLSoQD.Location = new System.Drawing.Point(130, 20);
            this.txtLSoQD.Name = "txtLSoQD";
            this.txtLSoQD.Size = new System.Drawing.Size(200, 25);
            this.txtLSoQD.TabIndex = 1;
            // 
            // lblLNgayKy
            // 
            this.lblLNgayKy.AutoSize = true;
            this.lblLNgayKy.Location = new System.Drawing.Point(20, 58);
            this.lblLNgayKy.Name = "lblLNgayKy";
            this.lblLNgayKy.Size = new System.Drawing.Size(57, 20);
            this.lblLNgayKy.TabIndex = 2;
            this.lblLNgayKy.Text = "Ngày ký:";
            // 
            // dtLNgayKy
            // 
            this.dtLNgayKy.Location = new System.Drawing.Point(130, 55);
            this.dtLNgayKy.Name = "dtLNgayKy";
            this.dtLNgayKy.Size = new System.Drawing.Size(140, 25);
            this.dtLNgayKy.TabIndex = 3;
            this.dtLNgayKy.CustomFormat = "dd/MM/yyyy";
            this.dtLNgayKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            // 
            // lblLHieuLuc
            // 
            this.lblLHieuLuc.AutoSize = true;
            this.lblLHieuLuc.Location = new System.Drawing.Point(20, 93);
            this.lblLHieuLuc.Name = "lblLHieuLuc";
            this.lblLHieuLuc.Size = new System.Drawing.Size(100, 20);
            this.lblLHieuLuc.TabIndex = 4;
            this.lblLHieuLuc.Text = "Ngày hiệu lực:";
            // 
            // dtLHieuLuc
            // 
            this.dtLHieuLuc.Location = new System.Drawing.Point(130, 90);
            this.dtLHieuLuc.Name = "dtLHieuLuc";
            this.dtLHieuLuc.Size = new System.Drawing.Size(140, 25);
            this.dtLHieuLuc.TabIndex = 5;
            this.dtLHieuLuc.CustomFormat = "dd/MM/yyyy";
            this.dtLHieuLuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            // 
            // lblLNguoiKy
            // 
            this.lblLNguoiKy.AutoSize = true;
            this.lblLNguoiKy.Location = new System.Drawing.Point(20, 128);
            this.lblLNguoiKy.Name = "lblLNguoiKy";
            this.lblLNguoiKy.Size = new System.Drawing.Size(64, 20);
            this.lblLNguoiKy.TabIndex = 6;
            this.lblLNguoiKy.Text = "Người ký:";
            // 
            // txtLNguoiKy
            // 
            this.txtLNguoiKy.Location = new System.Drawing.Point(130, 125);
            this.txtLNguoiKy.Name = "txtLNguoiKy";
            this.txtLNguoiKy.Size = new System.Drawing.Size(200, 25);
            this.txtLNguoiKy.TabIndex = 7;
            // 
            // lblLCB
            // 
            this.lblLCB.AutoSize = true;
            this.lblLCB.Location = new System.Drawing.Point(380, 23);
            this.lblLCB.Name = "lblLCB";
            this.lblLCB.Size = new System.Drawing.Size(93, 20);
            this.lblLCB.TabIndex = 8;
            this.lblLCB.Text = "Lương cơ bản:";
            // 
            // numLCB
            // 
            this.numLCB.Location = new System.Drawing.Point(510, 20);
            this.numLCB.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numLCB.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numLCB.Name = "numLCB";
            this.numLCB.Size = new System.Drawing.Size(170, 25);
            this.numLCB.TabIndex = 9;
            this.numLCB.ThousandsSeparator = true;
            this.numLCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLPCLuong
            // 
            this.lblLPCLuong.AutoSize = true;
            this.lblLPCLuong.Location = new System.Drawing.Point(380, 58);
            this.lblLPCLuong.Name = "lblLPCLuong";
            this.lblLPCLuong.Size = new System.Drawing.Size(100, 20);
            this.lblLPCLuong.TabIndex = 10;
            this.lblLPCLuong.Text = "Phụ cấp lương:";
            // 
            // numLPCLuong
            // 
            this.numLPCLuong.Location = new System.Drawing.Point(510, 55);
            this.numLPCLuong.Increment = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numLPCLuong.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numLPCLuong.Name = "numLPCLuong";
            this.numLPCLuong.Size = new System.Drawing.Size(170, 25);
            this.numLPCLuong.TabIndex = 11;
            this.numLPCLuong.ThousandsSeparator = true;
            this.numLPCLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLPCDocHai
            // 
            this.lblLPCDocHai.AutoSize = true;
            this.lblLPCDocHai.Location = new System.Drawing.Point(380, 93);
            this.lblLPCDocHai.Name = "lblLPCDocHai";
            this.lblLPCDocHai.Size = new System.Drawing.Size(115, 20);
            this.lblLPCDocHai.TabIndex = 12;
            this.lblLPCDocHai.Text = "Phụ cấp độc hại:";
            // 
            // numLPCDocHai
            // 
            this.numLPCDocHai.Location = new System.Drawing.Point(510, 90);
            this.numLPCDocHai.Increment = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numLPCDocHai.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numLPCDocHai.Name = "numLPCDocHai";
            this.numLPCDocHai.Size = new System.Drawing.Size(170, 25);
            this.numLPCDocHai.TabIndex = 13;
            this.numLPCDocHai.ThousandsSeparator = true;
            this.numLPCDocHai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLLap
            // 
            this.btnLLap.Location = new System.Drawing.Point(760, 17);
            this.btnLLap.Name = "btnLLap";
            this.btnLLap.Size = new System.Drawing.Size(180, 32);
            this.btnLLap.TabIndex = 14;
            this.btnLLap.Text = "Lập QĐ lương";
            this.btnLLap.UseVisualStyleBackColor = true;
            this.btnLLap.Click += new System.EventHandler(this.btnLLap_Click);
            // 
            // btnLMoi
            // 
            this.btnLMoi.Location = new System.Drawing.Point(760, 57);
            this.btnLMoi.Name = "btnLMoi";
            this.btnLMoi.Size = new System.Drawing.Size(180, 32);
            this.btnLMoi.TabIndex = 15;
            this.btnLMoi.Text = "Làm mới";
            this.btnLMoi.UseVisualStyleBackColor = true;
            this.btnLMoi.Click += new System.EventHandler(this.btnLMoi_Click);
            // 
            // dgvLuong
            // 
            this.dgvLuong.Location = new System.Drawing.Point(20, 170);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.MultiSelect = false;
            this.dgvLuong.ReadOnly = true;
            this.dgvLuong.RowHeadersWidth = 30;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.Size = new System.Drawing.Size(925, 295);
            this.dgvLuong.TabIndex = 16;
            // 
            // tabChucVu
            // 
            this.tabChucVu.Controls.Add(this.lblCSoQD);
            this.tabChucVu.Controls.Add(this.txtCSoQD);
            this.tabChucVu.Controls.Add(this.lblCNgayKy);
            this.tabChucVu.Controls.Add(this.dtCNgayKy);
            this.tabChucVu.Controls.Add(this.lblCHieuLuc);
            this.tabChucVu.Controls.Add(this.dtCHieuLuc);
            this.tabChucVu.Controls.Add(this.lblCNguoiKy);
            this.tabChucVu.Controls.Add(this.txtCNguoiKy);
            this.tabChucVu.Controls.Add(this.lblCChucVu);
            this.tabChucVu.Controls.Add(this.cboCChucVu);
            this.tabChucVu.Controls.Add(this.lblCPhongBan);
            this.tabChucVu.Controls.Add(this.cboCPhongBan);
            this.tabChucVu.Controls.Add(this.lblCPhuCap);
            this.tabChucVu.Controls.Add(this.numCPhuCap);
            this.tabChucVu.Controls.Add(this.btnCLap);
            this.tabChucVu.Controls.Add(this.btnCMoi);
            this.tabChucVu.Controls.Add(this.dgvChucVu);
            this.tabChucVu.Location = new System.Drawing.Point(4, 29);
            this.tabChucVu.Name = "tabChucVu";
            this.tabChucVu.Padding = new System.Windows.Forms.Padding(3);
            this.tabChucVu.Size = new System.Drawing.Size(968, 487);
            this.tabChucVu.TabIndex = 1;
            this.tabChucVu.Text = "Quyết định chức vụ";
            this.tabChucVu.UseVisualStyleBackColor = true;
            // 
            // lblCSoQD
            // 
            this.lblCSoQD.AutoSize = true;
            this.lblCSoQD.Location = new System.Drawing.Point(20, 23);
            this.lblCSoQD.Name = "lblCSoQD";
            this.lblCSoQD.Size = new System.Drawing.Size(43, 20);
            this.lblCSoQD.TabIndex = 0;
            this.lblCSoQD.Text = "Số QĐ:";
            // 
            // txtCSoQD
            // 
            this.txtCSoQD.Location = new System.Drawing.Point(130, 20);
            this.txtCSoQD.Name = "txtCSoQD";
            this.txtCSoQD.Size = new System.Drawing.Size(200, 25);
            this.txtCSoQD.TabIndex = 1;
            // 
            // lblCNgayKy
            // 
            this.lblCNgayKy.AutoSize = true;
            this.lblCNgayKy.Location = new System.Drawing.Point(20, 58);
            this.lblCNgayKy.Name = "lblCNgayKy";
            this.lblCNgayKy.Size = new System.Drawing.Size(57, 20);
            this.lblCNgayKy.TabIndex = 2;
            this.lblCNgayKy.Text = "Ngày ký:";
            // 
            // dtCNgayKy
            // 
            this.dtCNgayKy.Location = new System.Drawing.Point(130, 55);
            this.dtCNgayKy.Name = "dtCNgayKy";
            this.dtCNgayKy.Size = new System.Drawing.Size(140, 25);
            this.dtCNgayKy.TabIndex = 3;
            this.dtCNgayKy.CustomFormat = "dd/MM/yyyy";
            this.dtCNgayKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            // 
            // lblCHieuLuc
            // 
            this.lblCHieuLuc.AutoSize = true;
            this.lblCHieuLuc.Location = new System.Drawing.Point(20, 93);
            this.lblCHieuLuc.Name = "lblCHieuLuc";
            this.lblCHieuLuc.Size = new System.Drawing.Size(100, 20);
            this.lblCHieuLuc.TabIndex = 4;
            this.lblCHieuLuc.Text = "Ngày hiệu lực:";
            // 
            // dtCHieuLuc
            // 
            this.dtCHieuLuc.Location = new System.Drawing.Point(130, 90);
            this.dtCHieuLuc.Name = "dtCHieuLuc";
            this.dtCHieuLuc.Size = new System.Drawing.Size(140, 25);
            this.dtCHieuLuc.TabIndex = 5;
            this.dtCHieuLuc.CustomFormat = "dd/MM/yyyy";
            this.dtCHieuLuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            // 
            // lblCNguoiKy
            // 
            this.lblCNguoiKy.AutoSize = true;
            this.lblCNguoiKy.Location = new System.Drawing.Point(20, 128);
            this.lblCNguoiKy.Name = "lblCNguoiKy";
            this.lblCNguoiKy.Size = new System.Drawing.Size(64, 20);
            this.lblCNguoiKy.TabIndex = 6;
            this.lblCNguoiKy.Text = "Người ký:";
            // 
            // txtCNguoiKy
            // 
            this.txtCNguoiKy.Location = new System.Drawing.Point(130, 125);
            this.txtCNguoiKy.Name = "txtCNguoiKy";
            this.txtCNguoiKy.Size = new System.Drawing.Size(200, 25);
            this.txtCNguoiKy.TabIndex = 7;
            // 
            // lblCChucVu
            // 
            this.lblCChucVu.AutoSize = true;
            this.lblCChucVu.Location = new System.Drawing.Point(380, 23);
            this.lblCChucVu.Name = "lblCChucVu";
            this.lblCChucVu.Size = new System.Drawing.Size(57, 20);
            this.lblCChucVu.TabIndex = 8;
            this.lblCChucVu.Text = "Chức vụ:";
            // 
            // cboCChucVu
            // 
            this.cboCChucVu.Location = new System.Drawing.Point(510, 20);
            this.cboCChucVu.Name = "cboCChucVu";
            this.cboCChucVu.Size = new System.Drawing.Size(230, 25);
            this.cboCChucVu.TabIndex = 9;
            this.cboCChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCChucVu.FormattingEnabled = true;
            // 
            // lblCPhongBan
            // 
            this.lblCPhongBan.AutoSize = true;
            this.lblCPhongBan.Location = new System.Drawing.Point(380, 58);
            this.lblCPhongBan.Name = "lblCPhongBan";
            this.lblCPhongBan.Size = new System.Drawing.Size(72, 20);
            this.lblCPhongBan.TabIndex = 10;
            this.lblCPhongBan.Text = "Phòng ban:";
            // 
            // cboCPhongBan
            // 
            this.cboCPhongBan.Location = new System.Drawing.Point(510, 55);
            this.cboCPhongBan.Name = "cboCPhongBan";
            this.cboCPhongBan.Size = new System.Drawing.Size(230, 25);
            this.cboCPhongBan.TabIndex = 11;
            this.cboCPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCPhongBan.FormattingEnabled = true;
            // 
            // lblCPhuCap
            // 
            this.lblCPhuCap.AutoSize = true;
            this.lblCPhuCap.Location = new System.Drawing.Point(380, 93);
            this.lblCPhuCap.Name = "lblCPhuCap";
            this.lblCPhuCap.Size = new System.Drawing.Size(115, 20);
            this.lblCPhuCap.TabIndex = 12;
            this.lblCPhuCap.Text = "Phụ cấp chức vụ:";
            // 
            // numCPhuCap
            // 
            this.numCPhuCap.Location = new System.Drawing.Point(510, 90);
            this.numCPhuCap.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCPhuCap.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numCPhuCap.Name = "numCPhuCap";
            this.numCPhuCap.Size = new System.Drawing.Size(170, 25);
            this.numCPhuCap.TabIndex = 13;
            this.numCPhuCap.ThousandsSeparator = true;
            this.numCPhuCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCLap
            // 
            this.btnCLap.Location = new System.Drawing.Point(760, 17);
            this.btnCLap.Name = "btnCLap";
            this.btnCLap.Size = new System.Drawing.Size(180, 32);
            this.btnCLap.TabIndex = 14;
            this.btnCLap.Text = "Lập QĐ chức vụ";
            this.btnCLap.UseVisualStyleBackColor = true;
            this.btnCLap.Click += new System.EventHandler(this.btnCLap_Click);
            // 
            // btnCMoi
            // 
            this.btnCMoi.Location = new System.Drawing.Point(760, 57);
            this.btnCMoi.Name = "btnCMoi";
            this.btnCMoi.Size = new System.Drawing.Size(180, 32);
            this.btnCMoi.TabIndex = 15;
            this.btnCMoi.Text = "Làm mới";
            this.btnCMoi.UseVisualStyleBackColor = true;
            this.btnCMoi.Click += new System.EventHandler(this.btnCMoi_Click);
            // 
            // dgvChucVu
            // 
            this.dgvChucVu.Location = new System.Drawing.Point(20, 170);
            this.dgvChucVu.Name = "dgvChucVu";
            this.dgvChucVu.AllowUserToAddRows = false;
            this.dgvChucVu.AllowUserToDeleteRows = false;
            this.dgvChucVu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChucVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChucVu.MultiSelect = false;
            this.dgvChucVu.ReadOnly = true;
            this.dgvChucVu.RowHeadersWidth = 30;
            this.dgvChucVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChucVu.Size = new System.Drawing.Size(925, 295);
            this.dgvChucVu.TabIndex = 16;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(888, 612);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 34);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmQuyetDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 660);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.lblHienHanh);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.lblNhanVien);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuyetDinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quyết định lương - Quyết định chức vụ";
            this.Load += new System.EventHandler(this.FrmQuyetDinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLCB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLPCLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLPCDocHai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVu)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabLuong.ResumeLayout(false);
            this.tabLuong.PerformLayout();
            this.tabChucVu.ResumeLayout(false);
            this.tabChucVu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblHienHanh;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabLuong;
        private System.Windows.Forms.TabPage tabChucVu;
        private System.Windows.Forms.Label lblLSoQD;
        private System.Windows.Forms.TextBox txtLSoQD;
        private System.Windows.Forms.Label lblLNgayKy;
        private System.Windows.Forms.DateTimePicker dtLNgayKy;
        private System.Windows.Forms.Label lblLHieuLuc;
        private System.Windows.Forms.DateTimePicker dtLHieuLuc;
        private System.Windows.Forms.Label lblLNguoiKy;
        private System.Windows.Forms.TextBox txtLNguoiKy;
        private System.Windows.Forms.Label lblLCB;
        private System.Windows.Forms.NumericUpDown numLCB;
        private System.Windows.Forms.Label lblLPCLuong;
        private System.Windows.Forms.NumericUpDown numLPCLuong;
        private System.Windows.Forms.Label lblLPCDocHai;
        private System.Windows.Forms.NumericUpDown numLPCDocHai;
        private System.Windows.Forms.Button btnLLap;
        private System.Windows.Forms.Button btnLMoi;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.Label lblCSoQD;
        private System.Windows.Forms.TextBox txtCSoQD;
        private System.Windows.Forms.Label lblCNgayKy;
        private System.Windows.Forms.DateTimePicker dtCNgayKy;
        private System.Windows.Forms.Label lblCHieuLuc;
        private System.Windows.Forms.DateTimePicker dtCHieuLuc;
        private System.Windows.Forms.Label lblCNguoiKy;
        private System.Windows.Forms.TextBox txtCNguoiKy;
        private System.Windows.Forms.Label lblCChucVu;
        private System.Windows.Forms.ComboBox cboCChucVu;
        private System.Windows.Forms.Label lblCPhongBan;
        private System.Windows.Forms.ComboBox cboCPhongBan;
        private System.Windows.Forms.Label lblCPhuCap;
        private System.Windows.Forms.NumericUpDown numCPhuCap;
        private System.Windows.Forms.Button btnCLap;
        private System.Windows.Forms.Button btnCMoi;
        private System.Windows.Forms.DataGridView dgvChucVu;
        private System.Windows.Forms.Button btnDong;
    }
}
