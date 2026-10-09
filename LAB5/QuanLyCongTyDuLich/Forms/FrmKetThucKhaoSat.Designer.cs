namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmKetThucKhaoSat
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
            this.tabKT = new System.Windows.Forms.TabControl();
            this.tpThanhToan = new System.Windows.Forms.TabPage();
            this.tpKhaoSat = new System.Windows.Forms.TabPage();
            this.dgvDoan = new System.Windows.Forms.DataGridView();
            this.lbl01 = new System.Windows.Forms.Label();
            this.txtSoTT = new System.Windows.Forms.TextBox();
            this.lbl02 = new System.Windows.Forms.Label();
            this.txtSoDK = new System.Windows.Forms.TextBox();
            this.lbl03 = new System.Windows.Forms.Label();
            this.dtTT = new System.Windows.Forms.DateTimePicker();
            this.lbl04 = new System.Windows.Forms.Label();
            this.numTien = new System.Windows.Forms.NumericUpDown();
            this.lbl05 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lbl06 = new System.Windows.Forms.Label();
            this.cboLoaiKS = new System.Windows.Forms.ComboBox();
            this.lbl07 = new System.Windows.Forms.Label();
            this.cboDangKy = new System.Windows.Forms.ComboBox();
            this.lbl08 = new System.Windows.Forms.Label();
            this.txtMaKS = new System.Windows.Forms.TextBox();
            this.lbl09 = new System.Windows.Forms.Label();
            this.dtGui = new System.Windows.Forms.DateTimePicker();
            this.btnGui = new System.Windows.Forms.Button();
            this.dgvKS = new System.Windows.Forms.DataGridView();
            this.lbl10 = new System.Windows.Forms.Label();
            this.txtKSChon = new System.Windows.Forms.TextBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.dtPH = new System.Windows.Forms.DateTimePicker();
            this.lbl12 = new System.Windows.Forms.Label();
            this.numDiem = new System.Windows.Forms.NumericUpDown();
            this.lbl13 = new System.Windows.Forms.Label();
            this.txtGopY = new System.Windows.Forms.TextBox();
            this.btnGhiPH = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).BeginInit();
            this.tabKT.SuspendLayout();
            this.tpThanhToan.SuspendLayout();
            this.tpKhaoSat.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(20, 14);
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTieuDe.Text = "KẾT THÚC TOUR - THANH TOÁN - KHẢO SÁT";
            this.lblTieuDe.TabIndex = 0;
            // 
            // tabKT
            // 
            this.tabKT.Name = "tabKT";
            this.tabKT.Location = new System.Drawing.Point(10, 70);
            this.tabKT.Size = new System.Drawing.Size(975, 575);
            this.tabKT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabKT.TabIndex = 1;
            // 
            // tpThanhToan
            // 
            this.tpThanhToan.Name = "tpThanhToan";
            this.tpThanhToan.Location = new System.Drawing.Point(4, 26);
            this.tpThanhToan.Padding = new System.Windows.Forms.Padding(3);
            this.tpThanhToan.UseVisualStyleBackColor = true;
            this.tpThanhToan.Size = new System.Drawing.Size(967, 545);
            this.tpThanhToan.Text = "Thanh toán sau tour (đoàn)";
            this.tpThanhToan.TabIndex = 2;
            // 
            // tpKhaoSat
            // 
            this.tpKhaoSat.Name = "tpKhaoSat";
            this.tpKhaoSat.Location = new System.Drawing.Point(4, 26);
            this.tpKhaoSat.Padding = new System.Windows.Forms.Padding(3);
            this.tpKhaoSat.UseVisualStyleBackColor = true;
            this.tpKhaoSat.Size = new System.Drawing.Size(967, 545);
            this.tpKhaoSat.Text = "Khảo sát khách hàng";
            this.tpKhaoSat.TabIndex = 3;
            // 
            // dgvDoan
            // 
            this.dgvDoan.Name = "dgvDoan";
            this.dgvDoan.Location = new System.Drawing.Point(8, 8);
            this.dgvDoan.Size = new System.Drawing.Size(945, 400);
            this.dgvDoan.AllowUserToAddRows = false;
            this.dgvDoan.AllowUserToDeleteRows = false;
            this.dgvDoan.ReadOnly = true;
            this.dgvDoan.MultiSelect = false;
            this.dgvDoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDoan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDoan.TabIndex = 4;
            this.dgvDoan.SelectionChanged += new System.EventHandler(this.dgvDoan_SelectionChanged);
            // 
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(10, 433);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Số thanh toán:";
            this.lbl01.TabIndex = 5;
            // 
            // txtSoTT
            // 
            this.txtSoTT.Name = "txtSoTT";
            this.txtSoTT.Location = new System.Drawing.Point(105, 430);
            this.txtSoTT.Size = new System.Drawing.Size(130, 23);
            this.txtSoTT.TabIndex = 6;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(270, 433);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Phiếu đoàn:";
            this.lbl02.TabIndex = 7;
            // 
            // txtSoDK
            // 
            this.txtSoDK.Name = "txtSoDK";
            this.txtSoDK.Location = new System.Drawing.Point(345, 430);
            this.txtSoDK.Size = new System.Drawing.Size(130, 23);
            this.txtSoDK.ReadOnly = true;
            this.txtSoDK.TabIndex = 8;
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(500, 433);
            this.lbl03.AutoSize = true;
            this.lbl03.Text = "Ngày thanh toán:";
            this.lbl03.TabIndex = 9;
            // 
            // dtTT
            // 
            this.dtTT.Name = "dtTT";
            this.dtTT.Location = new System.Drawing.Point(625, 430);
            this.dtTT.Size = new System.Drawing.Size(130, 23);
            this.dtTT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTT.TabIndex = 10;
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(10, 473);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Số tiền:";
            this.lbl04.TabIndex = 11;
            // 
            // numTien
            // 
            this.numTien.Name = "numTien";
            this.numTien.Location = new System.Drawing.Point(105, 470);
            this.numTien.Size = new System.Drawing.Size(140, 23);
            this.numTien.Maximum = 100000000000m;
            this.numTien.Increment = 1000000m;
            this.numTien.ThousandsSeparator = true;
            this.numTien.TabIndex = 12;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(270, 473);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Ghi chú:";
            this.lbl05.TabIndex = 13;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Location = new System.Drawing.Point(345, 470);
            this.txtGhiChu.Size = new System.Drawing.Size(330, 23);
            this.txtGhiChu.TabIndex = 14;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Location = new System.Drawing.Point(780, 465);
            this.btnThanhToan.Size = new System.Drawing.Size(150, 32);
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Text = "Ghi nhận thanh toán";
            this.btnThanhToan.TabIndex = 15;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lbl06
            // 
            this.lbl06.Name = "lbl06";
            this.lbl06.Location = new System.Drawing.Point(10, 18);
            this.lbl06.AutoSize = true;
            this.lbl06.Text = "Loại khách:";
            this.lbl06.TabIndex = 16;
            // 
            // cboLoaiKS
            // 
            this.cboLoaiKS.Name = "cboLoaiKS";
            this.cboLoaiKS.Location = new System.Drawing.Point(85, 15);
            this.cboLoaiKS.Size = new System.Drawing.Size(100, 23);
            this.cboLoaiKS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKS.FormattingEnabled = true;
            this.cboLoaiKS.TabIndex = 17;
            this.cboLoaiKS.SelectedIndexChanged += new System.EventHandler(this.cboLoaiKS_SelectedIndexChanged);
            // 
            // lbl07
            // 
            this.lbl07.Name = "lbl07";
            this.lbl07.Location = new System.Drawing.Point(230, 18);
            this.lbl07.AutoSize = true;
            this.lbl07.Text = "Đăng ký đã kết thúc:";
            this.lbl07.TabIndex = 18;
            // 
            // cboDangKy
            // 
            this.cboDangKy.Name = "cboDangKy";
            this.cboDangKy.Location = new System.Drawing.Point(375, 15);
            this.cboDangKy.Size = new System.Drawing.Size(300, 23);
            this.cboDangKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDangKy.FormattingEnabled = true;
            this.cboDangKy.TabIndex = 19;
            // 
            // lbl08
            // 
            this.lbl08.Name = "lbl08";
            this.lbl08.Location = new System.Drawing.Point(730, 18);
            this.lbl08.AutoSize = true;
            this.lbl08.Text = "Mã KS:";
            this.lbl08.TabIndex = 20;
            // 
            // txtMaKS
            // 
            this.txtMaKS.Name = "txtMaKS";
            this.txtMaKS.Location = new System.Drawing.Point(785, 15);
            this.txtMaKS.Size = new System.Drawing.Size(110, 23);
            this.txtMaKS.TabIndex = 21;
            // 
            // lbl09
            // 
            this.lbl09.Name = "lbl09";
            this.lbl09.Location = new System.Drawing.Point(10, 55);
            this.lbl09.AutoSize = true;
            this.lbl09.Text = "Ngày gửi:";
            this.lbl09.TabIndex = 22;
            // 
            // dtGui
            // 
            this.dtGui.Name = "dtGui";
            this.dtGui.Location = new System.Drawing.Point(85, 52);
            this.dtGui.Size = new System.Drawing.Size(130, 23);
            this.dtGui.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtGui.TabIndex = 23;
            // 
            // btnGui
            // 
            this.btnGui.Name = "btnGui";
            this.btnGui.Location = new System.Drawing.Point(780, 47);
            this.btnGui.Size = new System.Drawing.Size(150, 32);
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Text = "Gửi phiếu khảo sát";
            this.btnGui.TabIndex = 24;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // dgvKS
            // 
            this.dgvKS.Name = "dgvKS";
            this.dgvKS.Location = new System.Drawing.Point(8, 90);
            this.dgvKS.Size = new System.Drawing.Size(945, 340);
            this.dgvKS.AllowUserToAddRows = false;
            this.dgvKS.AllowUserToDeleteRows = false;
            this.dgvKS.ReadOnly = true;
            this.dgvKS.MultiSelect = false;
            this.dgvKS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKS.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKS.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvKS.TabIndex = 25;
            this.dgvKS.SelectionChanged += new System.EventHandler(this.dgvKS_SelectionChanged);
            // 
            // lbl10
            // 
            this.lbl10.Name = "lbl10";
            this.lbl10.Location = new System.Drawing.Point(10, 453);
            this.lbl10.AutoSize = true;
            this.lbl10.Text = "Phiếu chọn:";
            this.lbl10.TabIndex = 26;
            // 
            // txtKSChon
            // 
            this.txtKSChon.Name = "txtKSChon";
            this.txtKSChon.Location = new System.Drawing.Point(90, 450);
            this.txtKSChon.Size = new System.Drawing.Size(110, 23);
            this.txtKSChon.ReadOnly = true;
            this.txtKSChon.TabIndex = 27;
            // 
            // lbl11
            // 
            this.lbl11.Name = "lbl11";
            this.lbl11.Location = new System.Drawing.Point(270, 453);
            this.lbl11.AutoSize = true;
            this.lbl11.Text = "Ngày phản hồi:";
            this.lbl11.TabIndex = 28;
            // 
            // dtPH
            // 
            this.dtPH.Name = "dtPH";
            this.dtPH.Location = new System.Drawing.Point(365, 450);
            this.dtPH.Size = new System.Drawing.Size(130, 23);
            this.dtPH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPH.TabIndex = 29;
            // 
            // lbl12
            // 
            this.lbl12.Name = "lbl12";
            this.lbl12.Location = new System.Drawing.Point(530, 453);
            this.lbl12.AutoSize = true;
            this.lbl12.Text = "Điểm (1-5):";
            this.lbl12.TabIndex = 30;
            // 
            // numDiem
            // 
            this.numDiem.Name = "numDiem";
            this.numDiem.Location = new System.Drawing.Point(605, 450);
            this.numDiem.Size = new System.Drawing.Size(60, 23);
            this.numDiem.Minimum = 1m;
            this.numDiem.Maximum = 5m;
            this.numDiem.Value = 5m;
            this.numDiem.TabIndex = 31;
            // 
            // lbl13
            // 
            this.lbl13.Name = "lbl13";
            this.lbl13.Location = new System.Drawing.Point(10, 493);
            this.lbl13.AutoSize = true;
            this.lbl13.Text = "Góp ý:";
            this.lbl13.TabIndex = 32;
            // 
            // txtGopY
            // 
            this.txtGopY.Name = "txtGopY";
            this.txtGopY.Location = new System.Drawing.Point(90, 490);
            this.txtGopY.Size = new System.Drawing.Size(670, 23);
            this.txtGopY.TabIndex = 33;
            // 
            // btnGhiPH
            // 
            this.btnGhiPH.Name = "btnGhiPH";
            this.btnGhiPH.Location = new System.Drawing.Point(780, 485);
            this.btnGhiPH.Size = new System.Drawing.Size(150, 32);
            this.btnGhiPH.UseVisualStyleBackColor = true;
            this.btnGhiPH.Text = "Ghi nhận góp ý";
            this.btnGhiPH.TabIndex = 34;
            this.btnGhiPH.Click += new System.EventHandler(this.btnGhiPH_Click);
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(880, 12);
            this.btnDong.Size = new System.Drawing.Size(100, 36);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 35;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.tabKT);
            this.tabKT.Controls.Add(this.tpThanhToan);
            this.tabKT.Controls.Add(this.tpKhaoSat);
            this.tpThanhToan.Controls.Add(this.dgvDoan);
            this.tpThanhToan.Controls.Add(this.lbl01);
            this.tpThanhToan.Controls.Add(this.txtSoTT);
            this.tpThanhToan.Controls.Add(this.lbl02);
            this.tpThanhToan.Controls.Add(this.txtSoDK);
            this.tpThanhToan.Controls.Add(this.lbl03);
            this.tpThanhToan.Controls.Add(this.dtTT);
            this.tpThanhToan.Controls.Add(this.lbl04);
            this.tpThanhToan.Controls.Add(this.numTien);
            this.tpThanhToan.Controls.Add(this.lbl05);
            this.tpThanhToan.Controls.Add(this.txtGhiChu);
            this.tpThanhToan.Controls.Add(this.btnThanhToan);
            this.tpKhaoSat.Controls.Add(this.lbl06);
            this.tpKhaoSat.Controls.Add(this.cboLoaiKS);
            this.tpKhaoSat.Controls.Add(this.lbl07);
            this.tpKhaoSat.Controls.Add(this.cboDangKy);
            this.tpKhaoSat.Controls.Add(this.lbl08);
            this.tpKhaoSat.Controls.Add(this.txtMaKS);
            this.tpKhaoSat.Controls.Add(this.lbl09);
            this.tpKhaoSat.Controls.Add(this.dtGui);
            this.tpKhaoSat.Controls.Add(this.btnGui);
            this.tpKhaoSat.Controls.Add(this.dgvKS);
            this.tpKhaoSat.Controls.Add(this.lbl10);
            this.tpKhaoSat.Controls.Add(this.txtKSChon);
            this.tpKhaoSat.Controls.Add(this.lbl11);
            this.tpKhaoSat.Controls.Add(this.dtPH);
            this.tpKhaoSat.Controls.Add(this.lbl12);
            this.tpKhaoSat.Controls.Add(this.numDiem);
            this.tpKhaoSat.Controls.Add(this.lbl13);
            this.tpKhaoSat.Controls.Add(this.txtGopY);
            this.tpKhaoSat.Controls.Add(this.btnGhiPH);
            this.Controls.Add(this.btnDong);
            // 
            // FrmKetThucKhaoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 660);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmKetThucKhaoSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết thúc tour - thanh toán đoàn - khảo sát";
            this.Load += new System.EventHandler(this.FrmKetThucKhaoSat_Load);
            this.tabKT.ResumeLayout(false);
            this.tpThanhToan.ResumeLayout(false);
            this.tpThanhToan.PerformLayout();
            this.tpKhaoSat.ResumeLayout(false);
            this.tpKhaoSat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TabControl tabKT;
        private System.Windows.Forms.TabPage tpThanhToan;
        private System.Windows.Forms.TabPage tpKhaoSat;
        private System.Windows.Forms.DataGridView dgvDoan;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.TextBox txtSoTT;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.TextBox txtSoDK;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.DateTimePicker dtTT;
        private System.Windows.Forms.Label lbl04;
        private System.Windows.Forms.NumericUpDown numTien;
        private System.Windows.Forms.Label lbl05;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lbl06;
        private System.Windows.Forms.ComboBox cboLoaiKS;
        private System.Windows.Forms.Label lbl07;
        private System.Windows.Forms.ComboBox cboDangKy;
        private System.Windows.Forms.Label lbl08;
        private System.Windows.Forms.TextBox txtMaKS;
        private System.Windows.Forms.Label lbl09;
        private System.Windows.Forms.DateTimePicker dtGui;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.DataGridView dgvKS;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.TextBox txtKSChon;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.DateTimePicker dtPH;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.NumericUpDown numDiem;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.TextBox txtGopY;
        private System.Windows.Forms.Button btnGhiPH;
        private System.Windows.Forms.Button btnDong;
    }
}
