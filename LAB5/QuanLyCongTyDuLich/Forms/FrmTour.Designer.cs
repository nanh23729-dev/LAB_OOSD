namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmTour
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
            this.lbl01 = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.tabTour = new System.Windows.Forms.TabControl();
            this.tpTour = new System.Windows.Forms.TabPage();
            this.tpDiemDung = new System.Windows.Forms.TabPage();
            this.tpChang = new System.Windows.Forms.TabPage();
            this.tpTQ = new System.Windows.Forms.TabPage();
            this.dgvTour = new System.Windows.Forms.DataGridView();
            this.lbl02 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lbl03 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lbl04 = new System.Windows.Forms.Label();
            this.numNgay = new System.Windows.Forms.NumericUpDown();
            this.lbl05 = new System.Windows.Forms.Label();
            this.numDem = new System.Windows.Forms.NumericUpDown();
            this.lbl06 = new System.Windows.Forms.Label();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.lbl07 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThemTour = new System.Windows.Forms.Button();
            this.dgvDiemDung = new System.Windows.Forms.DataGridView();
            this.lbl08 = new System.Windows.Forms.Label();
            this.numThuTu = new System.Windows.Forms.NumericUpDown();
            this.lbl09 = new System.Windows.Forms.Label();
            this.txtDiemDung = new System.Windows.Forms.TextBox();
            this.chkDoiPT = new System.Windows.Forms.CheckBox();
            this.chkAn = new System.Windows.Forms.CheckBox();
            this.chkKS = new System.Windows.Forms.CheckBox();
            this.lbl10 = new System.Windows.Forms.Label();
            this.numSao = new System.Windows.Forms.NumericUpDown();
            this.lbl11 = new System.Windows.Forms.Label();
            this.txtGhiChuDD = new System.Windows.Forms.TextBox();
            this.btnThemDD = new System.Windows.Forms.Button();
            this.dgvChang = new System.Windows.Forms.DataGridView();
            this.lbl12 = new System.Windows.Forms.Label();
            this.numChang = new System.Windows.Forms.NumericUpDown();
            this.lbl13 = new System.Windows.Forms.Label();
            this.cboPT = new System.Windows.Forms.ComboBox();
            this.lbl14 = new System.Windows.Forms.Label();
            this.txtGhiChuPT = new System.Windows.Forms.TextBox();
            this.btnThemChang = new System.Windows.Forms.Button();
            this.lbl15 = new System.Windows.Forms.Label();
            this.dgvTQ = new System.Windows.Forms.DataGridView();
            this.lbl16 = new System.Windows.Forms.Label();
            this.cboDTQ = new System.Windows.Forms.ComboBox();
            this.lbl17 = new System.Windows.Forms.Label();
            this.numThuTuTQ = new System.Windows.Forms.NumericUpDown();
            this.btnThemTQ = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuTQ)).BeginInit();
            this.tabTour.SuspendLayout();
            this.tpTour.SuspendLayout();
            this.tpDiemDung.SuspendLayout();
            this.tpChang.SuspendLayout();
            this.tpTQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(15, 18);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Tour đang chọn (cho các tab hành trình):";
            this.lbl01.TabIndex = 0;
            // 
            // cboTour
            // 
            this.cboTour.Name = "cboTour";
            this.cboTour.Location = new System.Drawing.Point(300, 15);
            this.cboTour.Size = new System.Drawing.Size(320, 23);
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTour.FormattingEnabled = true;
            this.cboTour.TabIndex = 1;
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.cboTour_SelectedIndexChanged);
            // 
            // tabTour
            // 
            this.tabTour.Name = "tabTour";
            this.tabTour.Location = new System.Drawing.Point(10, 50);
            this.tabTour.Size = new System.Drawing.Size(970, 530);
            this.tabTour.TabIndex = 2;
            // 
            // tpTour
            // 
            this.tpTour.Name = "tpTour";
            this.tpTour.Padding = new System.Windows.Forms.Padding(3);
            this.tpTour.UseVisualStyleBackColor = true;
            this.tpTour.Text = "Tour";
            this.tpTour.TabIndex = 3;
            // 
            // tpDiemDung
            // 
            this.tpDiemDung.Name = "tpDiemDung";
            this.tpDiemDung.Padding = new System.Windows.Forms.Padding(3);
            this.tpDiemDung.UseVisualStyleBackColor = true;
            this.tpDiemDung.Text = "Điểm dừng";
            this.tpDiemDung.TabIndex = 4;
            // 
            // tpChang
            // 
            this.tpChang.Name = "tpChang";
            this.tpChang.Padding = new System.Windows.Forms.Padding(3);
            this.tpChang.UseVisualStyleBackColor = true;
            this.tpChang.Text = "Phương tiện theo chặng";
            this.tpChang.TabIndex = 5;
            // 
            // tpTQ
            // 
            this.tpTQ.Name = "tpTQ";
            this.tpTQ.Padding = new System.Windows.Forms.Padding(3);
            this.tpTQ.UseVisualStyleBackColor = true;
            this.tpTQ.Text = "Điểm tham quan";
            this.tpTQ.TabIndex = 6;
            // 
            // dgvTour
            // 
            this.dgvTour.Name = "dgvTour";
            this.dgvTour.Location = new System.Drawing.Point(8, 8);
            this.dgvTour.Size = new System.Drawing.Size(940, 330);
            this.dgvTour.AllowUserToAddRows = false;
            this.dgvTour.AllowUserToDeleteRows = false;
            this.dgvTour.ReadOnly = true;
            this.dgvTour.MultiSelect = false;
            this.dgvTour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTour.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTour.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvTour.TabIndex = 7;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(10, 358);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Mã tour:";
            this.lbl02.TabIndex = 8;
            // 
            // txtMa
            // 
            this.txtMa.Name = "txtMa";
            this.txtMa.Location = new System.Drawing.Point(105, 355);
            this.txtMa.Size = new System.Drawing.Size(120, 23);
            this.txtMa.TabIndex = 9;
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(270, 358);
            this.lbl03.AutoSize = true;
            this.lbl03.Text = "Tên tour:";
            this.lbl03.TabIndex = 10;
            // 
            // txtTen
            // 
            this.txtTen.Name = "txtTen";
            this.txtTen.Location = new System.Drawing.Point(340, 355);
            this.txtTen.Size = new System.Drawing.Size(400, 23);
            this.txtTen.TabIndex = 11;
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(10, 393);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Số ngày:";
            this.lbl04.TabIndex = 12;
            // 
            // numNgay
            // 
            this.numNgay.Name = "numNgay";
            this.numNgay.Location = new System.Drawing.Point(105, 390);
            this.numNgay.Size = new System.Drawing.Size(80, 23);
            this.numNgay.Minimum = 1m;
            this.numNgay.Maximum = 60m;
            this.numNgay.Value = 3m;
            this.numNgay.TabIndex = 13;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(270, 393);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Số đêm:";
            this.lbl05.TabIndex = 14;
            // 
            // numDem
            // 
            this.numDem.Name = "numDem";
            this.numDem.Location = new System.Drawing.Point(340, 390);
            this.numDem.Size = new System.Drawing.Size(80, 23);
            this.numDem.Maximum = 60m;
            this.numDem.Value = 2m;
            this.numDem.TabIndex = 15;
            // 
            // lbl06
            // 
            this.lbl06.Name = "lbl06";
            this.lbl06.Location = new System.Drawing.Point(470, 393);
            this.lbl06.AutoSize = true;
            this.lbl06.Text = "Đơn giá / khách:";
            this.lbl06.TabIndex = 16;
            // 
            // numGia
            // 
            this.numGia.Name = "numGia";
            this.numGia.Location = new System.Drawing.Point(575, 390);
            this.numGia.Size = new System.Drawing.Size(140, 23);
            this.numGia.Maximum = 1000000000m;
            this.numGia.Increment = 100000m;
            this.numGia.ThousandsSeparator = true;
            this.numGia.TabIndex = 17;
            // 
            // lbl07
            // 
            this.lbl07.Name = "lbl07";
            this.lbl07.Location = new System.Drawing.Point(10, 428);
            this.lbl07.AutoSize = true;
            this.lbl07.Text = "Mô tả:";
            this.lbl07.TabIndex = 18;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Location = new System.Drawing.Point(105, 425);
            this.txtMoTa.Size = new System.Drawing.Size(660, 23);
            this.txtMoTa.TabIndex = 19;
            // 
            // btnThemTour
            // 
            this.btnThemTour.Name = "btnThemTour";
            this.btnThemTour.Location = new System.Drawing.Point(790, 420);
            this.btnThemTour.Size = new System.Drawing.Size(130, 32);
            this.btnThemTour.UseVisualStyleBackColor = true;
            this.btnThemTour.Text = "Thêm tour";
            this.btnThemTour.TabIndex = 20;
            this.btnThemTour.Click += new System.EventHandler(this.btnThemTour_Click);
            // 
            // dgvDiemDung
            // 
            this.dgvDiemDung.Name = "dgvDiemDung";
            this.dgvDiemDung.Location = new System.Drawing.Point(8, 8);
            this.dgvDiemDung.Size = new System.Drawing.Size(940, 330);
            this.dgvDiemDung.AllowUserToAddRows = false;
            this.dgvDiemDung.AllowUserToDeleteRows = false;
            this.dgvDiemDung.ReadOnly = true;
            this.dgvDiemDung.MultiSelect = false;
            this.dgvDiemDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiemDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiemDung.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDiemDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDiemDung.TabIndex = 21;
            // 
            // lbl08
            // 
            this.lbl08.Name = "lbl08";
            this.lbl08.Location = new System.Drawing.Point(10, 358);
            this.lbl08.AutoSize = true;
            this.lbl08.Text = "Thứ tự:";
            this.lbl08.TabIndex = 22;
            // 
            // numThuTu
            // 
            this.numThuTu.Name = "numThuTu";
            this.numThuTu.Location = new System.Drawing.Point(105, 355);
            this.numThuTu.Size = new System.Drawing.Size(80, 23);
            this.numThuTu.Minimum = 1m;
            this.numThuTu.Maximum = 50m;
            this.numThuTu.Value = 1m;
            this.numThuTu.TabIndex = 23;
            // 
            // lbl09
            // 
            this.lbl09.Name = "lbl09";
            this.lbl09.Location = new System.Drawing.Point(270, 358);
            this.lbl09.AutoSize = true;
            this.lbl09.Text = "Tên điểm dừng:";
            this.lbl09.TabIndex = 24;
            // 
            // txtDiemDung
            // 
            this.txtDiemDung.Name = "txtDiemDung";
            this.txtDiemDung.Location = new System.Drawing.Point(370, 355);
            this.txtDiemDung.Size = new System.Drawing.Size(300, 23);
            this.txtDiemDung.TabIndex = 25;
            // 
            // chkDoiPT
            // 
            this.chkDoiPT.Name = "chkDoiPT";
            this.chkDoiPT.Location = new System.Drawing.Point(10, 392);
            this.chkDoiPT.AutoSize = true;
            this.chkDoiPT.Text = "Đổi phương tiện";
            this.chkDoiPT.TabIndex = 26;
            // 
            // chkAn
            // 
            this.chkAn.Name = "chkAn";
            this.chkAn.Location = new System.Drawing.Point(170, 392);
            this.chkAn.AutoSize = true;
            this.chkAn.Text = "Có nơi ăn";
            this.chkAn.TabIndex = 27;
            // 
            // chkKS
            // 
            this.chkKS.Name = "chkKS";
            this.chkKS.Location = new System.Drawing.Point(290, 392);
            this.chkKS.AutoSize = true;
            this.chkKS.Text = "Có khách sạn";
            this.chkKS.TabIndex = 28;
            this.chkKS.CheckedChanged += new System.EventHandler(this.chkKS_CheckedChanged);
            // 
            // lbl10
            // 
            this.lbl10.Name = "lbl10";
            this.lbl10.Location = new System.Drawing.Point(440, 393);
            this.lbl10.AutoSize = true;
            this.lbl10.Text = "Hạng sao:";
            this.lbl10.TabIndex = 29;
            // 
            // numSao
            // 
            this.numSao.Name = "numSao";
            this.numSao.Location = new System.Drawing.Point(510, 390);
            this.numSao.Size = new System.Drawing.Size(60, 23);
            this.numSao.Minimum = 2m;
            this.numSao.Maximum = 5m;
            this.numSao.Value = 3m;
            this.numSao.Enabled = false;
            this.numSao.TabIndex = 30;
            // 
            // lbl11
            // 
            this.lbl11.Name = "lbl11";
            this.lbl11.Location = new System.Drawing.Point(10, 428);
            this.lbl11.AutoSize = true;
            this.lbl11.Text = "Ghi chú:";
            this.lbl11.TabIndex = 31;
            // 
            // txtGhiChuDD
            // 
            this.txtGhiChuDD.Name = "txtGhiChuDD";
            this.txtGhiChuDD.Location = new System.Drawing.Point(105, 425);
            this.txtGhiChuDD.Size = new System.Drawing.Size(560, 23);
            this.txtGhiChuDD.TabIndex = 32;
            // 
            // btnThemDD
            // 
            this.btnThemDD.Name = "btnThemDD";
            this.btnThemDD.Location = new System.Drawing.Point(790, 420);
            this.btnThemDD.Size = new System.Drawing.Size(140, 32);
            this.btnThemDD.UseVisualStyleBackColor = true;
            this.btnThemDD.Text = "Thêm điểm dừng";
            this.btnThemDD.TabIndex = 33;
            this.btnThemDD.Click += new System.EventHandler(this.btnThemDD_Click);
            // 
            // dgvChang
            // 
            this.dgvChang.Name = "dgvChang";
            this.dgvChang.Location = new System.Drawing.Point(8, 8);
            this.dgvChang.Size = new System.Drawing.Size(940, 330);
            this.dgvChang.AllowUserToAddRows = false;
            this.dgvChang.AllowUserToDeleteRows = false;
            this.dgvChang.ReadOnly = true;
            this.dgvChang.MultiSelect = false;
            this.dgvChang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChang.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChang.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvChang.TabIndex = 34;
            // 
            // lbl12
            // 
            this.lbl12.Name = "lbl12";
            this.lbl12.Location = new System.Drawing.Point(10, 358);
            this.lbl12.AutoSize = true;
            this.lbl12.Text = "Chặng thứ:";
            this.lbl12.TabIndex = 35;
            // 
            // numChang
            // 
            this.numChang.Name = "numChang";
            this.numChang.Location = new System.Drawing.Point(105, 355);
            this.numChang.Size = new System.Drawing.Size(80, 23);
            this.numChang.Minimum = 1m;
            this.numChang.Maximum = 50m;
            this.numChang.Value = 1m;
            this.numChang.TabIndex = 36;
            // 
            // lbl13
            // 
            this.lbl13.Name = "lbl13";
            this.lbl13.Location = new System.Drawing.Point(270, 358);
            this.lbl13.AutoSize = true;
            this.lbl13.Text = "Phương tiện:";
            this.lbl13.TabIndex = 37;
            // 
            // cboPT
            // 
            this.cboPT.Name = "cboPT";
            this.cboPT.Location = new System.Drawing.Point(355, 355);
            this.cboPT.Size = new System.Drawing.Size(220, 23);
            this.cboPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPT.FormattingEnabled = true;
            this.cboPT.TabIndex = 38;
            // 
            // lbl14
            // 
            this.lbl14.Name = "lbl14";
            this.lbl14.Location = new System.Drawing.Point(10, 393);
            this.lbl14.AutoSize = true;
            this.lbl14.Text = "Ghi chú:";
            this.lbl14.TabIndex = 39;
            // 
            // txtGhiChuPT
            // 
            this.txtGhiChuPT.Name = "txtGhiChuPT";
            this.txtGhiChuPT.Location = new System.Drawing.Point(105, 390);
            this.txtGhiChuPT.Size = new System.Drawing.Size(480, 23);
            this.txtGhiChuPT.TabIndex = 40;
            // 
            // btnThemChang
            // 
            this.btnThemChang.Name = "btnThemChang";
            this.btnThemChang.Location = new System.Drawing.Point(790, 385);
            this.btnThemChang.Size = new System.Drawing.Size(140, 32);
            this.btnThemChang.UseVisualStyleBackColor = true;
            this.btnThemChang.Text = "Gắn phương tiện";
            this.btnThemChang.TabIndex = 41;
            this.btnThemChang.Click += new System.EventHandler(this.btnThemChang_Click);
            // 
            // lbl15
            // 
            this.lbl15.Name = "lbl15";
            this.lbl15.Location = new System.Drawing.Point(10, 428);
            this.lbl15.AutoSize = true;
            this.lbl15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl15.Text = "Chặng k là đoạn đi tới điểm dừng thứ k; một chặng có thể dùng nhiều phương tiện.";
            this.lbl15.TabIndex = 42;
            // 
            // dgvTQ
            // 
            this.dgvTQ.Name = "dgvTQ";
            this.dgvTQ.Location = new System.Drawing.Point(8, 8);
            this.dgvTQ.Size = new System.Drawing.Size(940, 330);
            this.dgvTQ.AllowUserToAddRows = false;
            this.dgvTQ.AllowUserToDeleteRows = false;
            this.dgvTQ.ReadOnly = true;
            this.dgvTQ.MultiSelect = false;
            this.dgvTQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTQ.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTQ.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvTQ.TabIndex = 43;
            // 
            // lbl16
            // 
            this.lbl16.Name = "lbl16";
            this.lbl16.Location = new System.Drawing.Point(10, 358);
            this.lbl16.AutoSize = true;
            this.lbl16.Text = "Điểm tham quan:";
            this.lbl16.TabIndex = 44;
            // 
            // cboDTQ
            // 
            this.cboDTQ.Name = "cboDTQ";
            this.cboDTQ.Location = new System.Drawing.Point(115, 355);
            this.cboDTQ.Size = new System.Drawing.Size(260, 23);
            this.cboDTQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDTQ.FormattingEnabled = true;
            this.cboDTQ.TabIndex = 45;
            // 
            // lbl17
            // 
            this.lbl17.Name = "lbl17";
            this.lbl17.Location = new System.Drawing.Point(400, 358);
            this.lbl17.AutoSize = true;
            this.lbl17.Text = "Thứ tự:";
            this.lbl17.TabIndex = 46;
            // 
            // numThuTuTQ
            // 
            this.numThuTuTQ.Name = "numThuTuTQ";
            this.numThuTuTQ.Location = new System.Drawing.Point(460, 355);
            this.numThuTuTQ.Size = new System.Drawing.Size(80, 23);
            this.numThuTuTQ.Minimum = 1m;
            this.numThuTuTQ.Maximum = 50m;
            this.numThuTuTQ.Value = 1m;
            this.numThuTuTQ.TabIndex = 47;
            // 
            // btnThemTQ
            // 
            this.btnThemTQ.Name = "btnThemTQ";
            this.btnThemTQ.Location = new System.Drawing.Point(790, 350);
            this.btnThemTQ.Size = new System.Drawing.Size(140, 32);
            this.btnThemTQ.UseVisualStyleBackColor = true;
            this.btnThemTQ.Text = "Gắn điểm TQ";
            this.btnThemTQ.TabIndex = 48;
            this.btnThemTQ.Click += new System.EventHandler(this.btnThemTQ_Click);
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(880, 590);
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 49;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.cboTour);
            this.Controls.Add(this.tabTour);
            this.tabTour.Controls.Add(this.tpTour);
            this.tabTour.Controls.Add(this.tpDiemDung);
            this.tabTour.Controls.Add(this.tpChang);
            this.tabTour.Controls.Add(this.tpTQ);
            this.tpTour.Controls.Add(this.dgvTour);
            this.tpTour.Controls.Add(this.lbl02);
            this.tpTour.Controls.Add(this.txtMa);
            this.tpTour.Controls.Add(this.lbl03);
            this.tpTour.Controls.Add(this.txtTen);
            this.tpTour.Controls.Add(this.lbl04);
            this.tpTour.Controls.Add(this.numNgay);
            this.tpTour.Controls.Add(this.lbl05);
            this.tpTour.Controls.Add(this.numDem);
            this.tpTour.Controls.Add(this.lbl06);
            this.tpTour.Controls.Add(this.numGia);
            this.tpTour.Controls.Add(this.lbl07);
            this.tpTour.Controls.Add(this.txtMoTa);
            this.tpTour.Controls.Add(this.btnThemTour);
            this.tpDiemDung.Controls.Add(this.dgvDiemDung);
            this.tpDiemDung.Controls.Add(this.lbl08);
            this.tpDiemDung.Controls.Add(this.numThuTu);
            this.tpDiemDung.Controls.Add(this.lbl09);
            this.tpDiemDung.Controls.Add(this.txtDiemDung);
            this.tpDiemDung.Controls.Add(this.chkDoiPT);
            this.tpDiemDung.Controls.Add(this.chkAn);
            this.tpDiemDung.Controls.Add(this.chkKS);
            this.tpDiemDung.Controls.Add(this.lbl10);
            this.tpDiemDung.Controls.Add(this.numSao);
            this.tpDiemDung.Controls.Add(this.lbl11);
            this.tpDiemDung.Controls.Add(this.txtGhiChuDD);
            this.tpDiemDung.Controls.Add(this.btnThemDD);
            this.tpChang.Controls.Add(this.dgvChang);
            this.tpChang.Controls.Add(this.lbl12);
            this.tpChang.Controls.Add(this.numChang);
            this.tpChang.Controls.Add(this.lbl13);
            this.tpChang.Controls.Add(this.cboPT);
            this.tpChang.Controls.Add(this.lbl14);
            this.tpChang.Controls.Add(this.txtGhiChuPT);
            this.tpChang.Controls.Add(this.btnThemChang);
            this.tpChang.Controls.Add(this.lbl15);
            this.tpTQ.Controls.Add(this.dgvTQ);
            this.tpTQ.Controls.Add(this.lbl16);
            this.tpTQ.Controls.Add(this.cboDTQ);
            this.tpTQ.Controls.Add(this.lbl17);
            this.tpTQ.Controls.Add(this.numThuTuTQ);
            this.tpTQ.Controls.Add(this.btnThemTQ);
            this.Controls.Add(this.btnDong);
            // 
            // FrmTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmTour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tour - hành trình";
            this.Load += new System.EventHandler(this.FrmTour_Load);
            this.tabTour.ResumeLayout(false);
            this.tpTour.ResumeLayout(false);
            this.tpTour.PerformLayout();
            this.tpDiemDung.ResumeLayout(false);
            this.tpDiemDung.PerformLayout();
            this.tpChang.ResumeLayout(false);
            this.tpChang.PerformLayout();
            this.tpTQ.ResumeLayout(false);
            this.tpTQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuTQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.TabControl tabTour;
        private System.Windows.Forms.TabPage tpTour;
        private System.Windows.Forms.TabPage tpDiemDung;
        private System.Windows.Forms.TabPage tpChang;
        private System.Windows.Forms.TabPage tpTQ;
        private System.Windows.Forms.DataGridView dgvTour;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lbl04;
        private System.Windows.Forms.NumericUpDown numNgay;
        private System.Windows.Forms.Label lbl05;
        private System.Windows.Forms.NumericUpDown numDem;
        private System.Windows.Forms.Label lbl06;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Label lbl07;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThemTour;
        private System.Windows.Forms.DataGridView dgvDiemDung;
        private System.Windows.Forms.Label lbl08;
        private System.Windows.Forms.NumericUpDown numThuTu;
        private System.Windows.Forms.Label lbl09;
        private System.Windows.Forms.TextBox txtDiemDung;
        private System.Windows.Forms.CheckBox chkDoiPT;
        private System.Windows.Forms.CheckBox chkAn;
        private System.Windows.Forms.CheckBox chkKS;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.NumericUpDown numSao;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.TextBox txtGhiChuDD;
        private System.Windows.Forms.Button btnThemDD;
        private System.Windows.Forms.DataGridView dgvChang;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.NumericUpDown numChang;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.ComboBox cboPT;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.TextBox txtGhiChuPT;
        private System.Windows.Forms.Button btnThemChang;
        private System.Windows.Forms.Label lbl15;
        private System.Windows.Forms.DataGridView dgvTQ;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.ComboBox cboDTQ;
        private System.Windows.Forms.Label lbl17;
        private System.Windows.Forms.NumericUpDown numThuTuTQ;
        private System.Windows.Forms.Button btnThemTQ;
        private System.Windows.Forms.Button btnDong;
    }
}
