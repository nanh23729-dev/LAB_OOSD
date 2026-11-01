namespace QuanLyCaoOc.Forms
{
    partial class FrmThanhToan
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
            this.tabThue = new System.Windows.Forms.TabPage();
            this.tabDV = new System.Windows.Forms.TabPage();
            this.tabNo = new System.Windows.Forms.TabPage();
            this.lblHD = new System.Windows.Forms.Label();
            this.cboHD = new System.Windows.Forms.ComboBox();
            this.lblCongNo = new System.Windows.Forms.Label();
            this.lblKy = new System.Windows.Forms.Label();
            this.dgvKy = new System.Windows.Forms.DataGridView();
            this.lblNguoiThu = new System.Windows.Forms.Label();
            this.txtNguoiThu = new System.Windows.Forms.TextBox();
            this.btnThuKy = new System.Windows.Forms.Button();
            this.lblHDDV = new System.Windows.Forms.Label();
            this.cboHDDV = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnDVThem = new System.Windows.Forms.Button();
            this.btnDVBo = new System.Windows.Forms.Button();
            this.dgvDong = new System.Windows.Forms.DataGridView();
            this.btnLapHD = new System.Windows.Forms.Button();
            this.lblHDTong = new System.Windows.Forms.Label();
            this.lblHDDS = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();
            this.btnThuHD = new System.Windows.Forms.Button();
            this.dgvCongNo = new System.Windows.Forms.DataGridView();
            this.btnNoTaiLai = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabThue.SuspendLayout();
            this.tabDV.SuspendLayout();
            this.tabNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabThue);
            this.tabs.Controls.Add(this.tabDV);
            this.tabs.Controls.Add(this.tabNo);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1016, 640);
            this.tabs.TabIndex = 0;
            // 
            // tabThue
            // 
            this.tabThue.Controls.Add(this.lblHD);
            this.tabThue.Controls.Add(this.cboHD);
            this.tabThue.Controls.Add(this.lblCongNo);
            this.tabThue.Controls.Add(this.lblKy);
            this.tabThue.Controls.Add(this.dgvKy);
            this.tabThue.Controls.Add(this.lblNguoiThu);
            this.tabThue.Controls.Add(this.txtNguoiThu);
            this.tabThue.Controls.Add(this.btnThuKy);
            this.tabThue.Location = new System.Drawing.Point(4, 29);
            this.tabThue.Name = "tabThue";
            this.tabThue.Padding = new System.Windows.Forms.Padding(3);
            this.tabThue.Size = new System.Drawing.Size(1008, 607);
            this.tabThue.TabIndex = 0;
            this.tabThue.Text = "Thu tiền thuê";
            this.tabThue.UseVisualStyleBackColor = true;
            // 
            // lblHD
            // 
            this.lblHD.AutoSize = true;
            this.lblHD.Location = new System.Drawing.Point(20, 23);
            this.lblHD.Name = "lblHD";
            this.lblHD.Size = new System.Drawing.Size(64, 20);
            this.lblHD.TabIndex = 0;
            this.lblHD.Text = "Hợp đồng:";
            // 
            // cboHD
            // 
            this.cboHD.Location = new System.Drawing.Point(120, 20);
            this.cboHD.Name = "cboHD";
            this.cboHD.Size = new System.Drawing.Size(320, 25);
            this.cboHD.TabIndex = 1;
            this.cboHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHD.FormattingEnabled = true;
            this.cboHD.SelectedIndexChanged += new System.EventHandler(this.cboHD_SelectedIndexChanged);
            // 
            // lblCongNo
            // 
            this.lblCongNo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCongNo.Location = new System.Drawing.Point(20, 58);
            this.lblCongNo.Name = "lblCongNo";
            this.lblCongNo.Size = new System.Drawing.Size(960, 40);
            this.lblCongNo.TabIndex = 2;
            this.lblCongNo.Text = "Công nợ: còn 1 kỳ tiền thuê chưa thu";
            // 
            // lblKy
            // 
            this.lblKy.AutoSize = true;
            this.lblKy.Location = new System.Drawing.Point(20, 105);
            this.lblKy.Name = "lblKy";
            this.lblKy.Size = new System.Drawing.Size(300, 20);
            this.lblKy.TabIndex = 3;
            this.lblKy.Text = "Các kỳ chưa thu (thu theo thứ tự tháng):";
            // 
            // dgvKy
            // 
            this.dgvKy.Location = new System.Drawing.Point(20, 130);
            this.dgvKy.Name = "dgvKy";
            this.dgvKy.AllowUserToAddRows = false;
            this.dgvKy.AllowUserToDeleteRows = false;
            this.dgvKy.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKy.MultiSelect = false;
            this.dgvKy.ReadOnly = true;
            this.dgvKy.RowHeadersWidth = 30;
            this.dgvKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKy.Size = new System.Drawing.Size(960, 280);
            this.dgvKy.TabIndex = 4;
            // 
            // lblNguoiThu
            // 
            this.lblNguoiThu.AutoSize = true;
            this.lblNguoiThu.Location = new System.Drawing.Point(20, 428);
            this.lblNguoiThu.Name = "lblNguoiThu";
            this.lblNguoiThu.Size = new System.Drawing.Size(72, 20);
            this.lblNguoiThu.TabIndex = 5;
            this.lblNguoiThu.Text = "Người thu:";
            // 
            // txtNguoiThu
            // 
            this.txtNguoiThu.Location = new System.Drawing.Point(120, 425);
            this.txtNguoiThu.Name = "txtNguoiThu";
            this.txtNguoiThu.Size = new System.Drawing.Size(250, 25);
            this.txtNguoiThu.TabIndex = 6;
            // 
            // btnThuKy
            // 
            this.btnThuKy.Location = new System.Drawing.Point(20, 465);
            this.btnThuKy.Name = "btnThuKy";
            this.btnThuKy.Size = new System.Drawing.Size(170, 36);
            this.btnThuKy.TabIndex = 7;
            this.btnThuKy.Text = "Thu tiền kỳ chọn";
            this.btnThuKy.UseVisualStyleBackColor = true;
            this.btnThuKy.Click += new System.EventHandler(this.btnThuKy_Click);
            // 
            // tabDV
            // 
            this.tabDV.Controls.Add(this.lblHDDV);
            this.tabDV.Controls.Add(this.cboHDDV);
            this.tabDV.Controls.Add(this.lblThang);
            this.tabDV.Controls.Add(this.numThang);
            this.tabDV.Controls.Add(this.lblNam);
            this.tabDV.Controls.Add(this.numNam);
            this.tabDV.Controls.Add(this.lblDichVu);
            this.tabDV.Controls.Add(this.cboDichVu);
            this.tabDV.Controls.Add(this.lblSoLuong);
            this.tabDV.Controls.Add(this.numSoLuong);
            this.tabDV.Controls.Add(this.btnDVThem);
            this.tabDV.Controls.Add(this.btnDVBo);
            this.tabDV.Controls.Add(this.dgvDong);
            this.tabDV.Controls.Add(this.btnLapHD);
            this.tabDV.Controls.Add(this.lblHDTong);
            this.tabDV.Controls.Add(this.lblHDDS);
            this.tabDV.Controls.Add(this.dgvHoaDon);
            this.tabDV.Controls.Add(this.dgvChiTietHD);
            this.tabDV.Controls.Add(this.btnThuHD);
            this.tabDV.Location = new System.Drawing.Point(4, 29);
            this.tabDV.Name = "tabDV";
            this.tabDV.Padding = new System.Windows.Forms.Padding(3);
            this.tabDV.Size = new System.Drawing.Size(1008, 607);
            this.tabDV.TabIndex = 1;
            this.tabDV.Text = "Hóa đơn dịch vụ";
            this.tabDV.UseVisualStyleBackColor = true;
            // 
            // lblHDDV
            // 
            this.lblHDDV.AutoSize = true;
            this.lblHDDV.Location = new System.Drawing.Point(20, 23);
            this.lblHDDV.Name = "lblHDDV";
            this.lblHDDV.Size = new System.Drawing.Size(64, 20);
            this.lblHDDV.TabIndex = 0;
            this.lblHDDV.Text = "Hợp đồng:";
            // 
            // cboHDDV
            // 
            this.cboHDDV.Location = new System.Drawing.Point(120, 20);
            this.cboHDDV.Name = "cboHDDV";
            this.cboHDDV.Size = new System.Drawing.Size(320, 25);
            this.cboHDDV.TabIndex = 1;
            this.cboHDDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHDDV.FormattingEnabled = true;
            this.cboHDDV.SelectedIndexChanged += new System.EventHandler(this.cboHDDV_SelectedIndexChanged);
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(20, 58);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(43, 20);
            this.lblThang.TabIndex = 2;
            this.lblThang.Text = "Tháng:";
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(120, 55);
            this.numThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(80, 25);
            this.numThang.TabIndex = 3;
            this.numThang.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(250, 58);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(40, 20);
            this.lblNam.TabIndex = 4;
            this.lblNam.Text = "Năm:";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(310, 55);
            this.numNam.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(100, 25);
            this.numNam.TabIndex = 5;
            this.numNam.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDichVu
            // 
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Location = new System.Drawing.Point(20, 93);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(57, 20);
            this.lblDichVu.TabIndex = 6;
            this.lblDichVu.Text = "Dịch vụ:";
            // 
            // cboDichVu
            // 
            this.cboDichVu.Location = new System.Drawing.Point(120, 90);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(200, 25);
            this.cboDichVu.TabIndex = 7;
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(20, 128);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 20);
            this.lblSoLuong.TabIndex = 8;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(120, 125);
            this.numSoLuong.DecimalPlaces = 2;
            this.numSoLuong.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(120, 25);
            this.numSoLuong.TabIndex = 9;
            this.numSoLuong.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDVThem
            // 
            this.btnDVThem.Location = new System.Drawing.Point(330, 122);
            this.btnDVThem.Name = "btnDVThem";
            this.btnDVThem.Size = new System.Drawing.Size(120, 32);
            this.btnDVThem.TabIndex = 10;
            this.btnDVThem.Text = "Thêm dòng";
            this.btnDVThem.UseVisualStyleBackColor = true;
            this.btnDVThem.Click += new System.EventHandler(this.btnDVThem_Click);
            // 
            // btnDVBo
            // 
            this.btnDVBo.Location = new System.Drawing.Point(465, 122);
            this.btnDVBo.Name = "btnDVBo";
            this.btnDVBo.Size = new System.Drawing.Size(130, 32);
            this.btnDVBo.TabIndex = 11;
            this.btnDVBo.Text = "Bỏ dòng chọn";
            this.btnDVBo.UseVisualStyleBackColor = true;
            this.btnDVBo.Click += new System.EventHandler(this.btnDVBo_Click);
            // 
            // dgvDong
            // 
            this.dgvDong.Location = new System.Drawing.Point(20, 165);
            this.dgvDong.Name = "dgvDong";
            this.dgvDong.AllowUserToAddRows = false;
            this.dgvDong.AllowUserToDeleteRows = false;
            this.dgvDong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDong.MultiSelect = false;
            this.dgvDong.ReadOnly = true;
            this.dgvDong.RowHeadersWidth = 30;
            this.dgvDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDong.Size = new System.Drawing.Size(520, 150);
            this.dgvDong.TabIndex = 12;
            // 
            // btnLapHD
            // 
            this.btnLapHD.Location = new System.Drawing.Point(560, 165);
            this.btnLapHD.Name = "btnLapHD";
            this.btnLapHD.Size = new System.Drawing.Size(190, 36);
            this.btnLapHD.TabIndex = 13;
            this.btnLapHD.Text = "Lập hóa đơn dịch vụ";
            this.btnLapHD.UseVisualStyleBackColor = true;
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);
            // 
            // lblHDTong
            // 
            this.lblHDTong.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDTong.Location = new System.Drawing.Point(560, 215);
            this.lblHDTong.Name = "lblHDTong";
            this.lblHDTong.Size = new System.Drawing.Size(420, 60);
            this.lblHDTong.TabIndex = 14;
            this.lblHDTong.Text = "Tổng tạm tính: 0 đ";
            // 
            // lblHDDS
            // 
            this.lblHDDS.AutoSize = true;
            this.lblHDDS.Location = new System.Drawing.Point(20, 325);
            this.lblHDDS.Name = "lblHDDS";
            this.lblHDDS.Size = new System.Drawing.Size(300, 20);
            this.lblHDDS.TabIndex = 15;
            this.lblHDDS.Text = "Hóa đơn dịch vụ của hợp đồng:";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.Location = new System.Drawing.Point(20, 350);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 30;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(520, 210);
            this.dgvHoaDon.TabIndex = 16;
            this.dgvHoaDon.SelectionChanged += new System.EventHandler(this.dgvHoaDon_SelectionChanged);
            // 
            // dgvChiTietHD
            // 
            this.dgvChiTietHD.Location = new System.Drawing.Point(560, 350);
            this.dgvChiTietHD.Name = "dgvChiTietHD";
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AllowUserToDeleteRows = false;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHD.MultiSelect = false;
            this.dgvChiTietHD.ReadOnly = true;
            this.dgvChiTietHD.RowHeadersWidth = 30;
            this.dgvChiTietHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHD.Size = new System.Drawing.Size(420, 210);
            this.dgvChiTietHD.TabIndex = 17;
            // 
            // btnThuHD
            // 
            this.btnThuHD.Location = new System.Drawing.Point(560, 285);
            this.btnThuHD.Name = "btnThuHD";
            this.btnThuHD.Size = new System.Drawing.Size(190, 34);
            this.btnThuHD.TabIndex = 18;
            this.btnThuHD.Text = "Thu hóa đơn đã chọn";
            this.btnThuHD.UseVisualStyleBackColor = true;
            this.btnThuHD.Click += new System.EventHandler(this.btnThuHD_Click);
            // 
            // tabNo
            // 
            this.tabNo.Controls.Add(this.dgvCongNo);
            this.tabNo.Controls.Add(this.btnNoTaiLai);
            this.tabNo.Location = new System.Drawing.Point(4, 29);
            this.tabNo.Name = "tabNo";
            this.tabNo.Padding = new System.Windows.Forms.Padding(3);
            this.tabNo.Size = new System.Drawing.Size(1008, 607);
            this.tabNo.TabIndex = 2;
            this.tabNo.Text = "Công nợ";
            this.tabNo.UseVisualStyleBackColor = true;
            // 
            // dgvCongNo
            // 
            this.dgvCongNo.Location = new System.Drawing.Point(20, 20);
            this.dgvCongNo.Name = "dgvCongNo";
            this.dgvCongNo.AllowUserToAddRows = false;
            this.dgvCongNo.AllowUserToDeleteRows = false;
            this.dgvCongNo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCongNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongNo.MultiSelect = false;
            this.dgvCongNo.ReadOnly = true;
            this.dgvCongNo.RowHeadersWidth = 30;
            this.dgvCongNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongNo.Size = new System.Drawing.Size(960, 450);
            this.dgvCongNo.TabIndex = 0;
            // 
            // btnNoTaiLai
            // 
            this.btnNoTaiLai.Location = new System.Drawing.Point(20, 485);
            this.btnNoTaiLai.Name = "btnNoTaiLai";
            this.btnNoTaiLai.Size = new System.Drawing.Size(170, 36);
            this.btnNoTaiLai.TabIndex = 1;
            this.btnNoTaiLai.Text = "Tải lại công nợ";
            this.btnNoTaiLai.UseVisualStyleBackColor = true;
            this.btnNoTaiLai.Click += new System.EventHandler(this.btnNoTaiLai_Click);
            // 
            // FrmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 700);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán tiền thuê - hóa đơn dịch vụ - công nợ";
            this.Load += new System.EventHandler(this.FrmThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNo)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabThue.ResumeLayout(false);
            this.tabThue.PerformLayout();
            this.tabDV.ResumeLayout(false);
            this.tabDV.PerformLayout();
            this.tabNo.ResumeLayout(false);
            this.tabNo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabThue;
        private System.Windows.Forms.TabPage tabDV;
        private System.Windows.Forms.TabPage tabNo;
        private System.Windows.Forms.Label lblHD;
        private System.Windows.Forms.ComboBox cboHD;
        private System.Windows.Forms.Label lblCongNo;
        private System.Windows.Forms.Label lblKy;
        private System.Windows.Forms.DataGridView dgvKy;
        private System.Windows.Forms.Label lblNguoiThu;
        private System.Windows.Forms.TextBox txtNguoiThu;
        private System.Windows.Forms.Button btnThuKy;
        private System.Windows.Forms.Label lblHDDV;
        private System.Windows.Forms.ComboBox cboHDDV;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnDVThem;
        private System.Windows.Forms.Button btnDVBo;
        private System.Windows.Forms.DataGridView dgvDong;
        private System.Windows.Forms.Button btnLapHD;
        private System.Windows.Forms.Label lblHDTong;
        private System.Windows.Forms.Label lblHDDS;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridView dgvChiTietHD;
        private System.Windows.Forms.Button btnThuHD;
        private System.Windows.Forms.DataGridView dgvCongNo;
        private System.Windows.Forms.Button btnNoTaiLai;
    }
}
