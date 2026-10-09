namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmDanhMuc
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
            this.tabDanhMuc = new System.Windows.Forms.TabControl();
            this.tabPT = new System.Windows.Forms.TabPage();
            this.tabDB = new System.Windows.Forms.TabPage();
            this.tabHDVp = new System.Windows.Forms.TabPage();
            this.tabDTQ = new System.Windows.Forms.TabPage();
            this.dgvPT = new System.Windows.Forms.DataGridView();
            this.lbl01 = new System.Windows.Forms.Label();
            this.txtPTMa = new System.Windows.Forms.TextBox();
            this.lbl02 = new System.Windows.Forms.Label();
            this.txtPTTen = new System.Windows.Forms.TextBox();
            this.lbl03 = new System.Windows.Forms.Label();
            this.txtPTGhiChu = new System.Windows.Forms.TextBox();
            this.btnThemPT = new System.Windows.Forms.Button();
            this.dgvDB = new System.Windows.Forms.DataGridView();
            this.lbl04 = new System.Windows.Forms.Label();
            this.txtDBMa = new System.Windows.Forms.TextBox();
            this.lbl05 = new System.Windows.Forms.Label();
            this.txtDBTen = new System.Windows.Forms.TextBox();
            this.lbl06 = new System.Windows.Forms.Label();
            this.txtDBDiaChi = new System.Windows.Forms.TextBox();
            this.lbl07 = new System.Windows.Forms.Label();
            this.txtDBDT = new System.Windows.Forms.TextBox();
            this.btnThemDB = new System.Windows.Forms.Button();
            this.dgvHDV = new System.Windows.Forms.DataGridView();
            this.lbl08 = new System.Windows.Forms.Label();
            this.txtHDVMa = new System.Windows.Forms.TextBox();
            this.lbl09 = new System.Windows.Forms.Label();
            this.txtHDVTen = new System.Windows.Forms.TextBox();
            this.lbl10 = new System.Windows.Forms.Label();
            this.txtHDVDT = new System.Windows.Forms.TextBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.numLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemHDV = new System.Windows.Forms.Button();
            this.dgvDTQ = new System.Windows.Forms.DataGridView();
            this.lbl12 = new System.Windows.Forms.Label();
            this.txtDTQMa = new System.Windows.Forms.TextBox();
            this.lbl13 = new System.Windows.Forms.Label();
            this.txtDTQTen = new System.Windows.Forms.TextBox();
            this.lbl14 = new System.Windows.Forms.Label();
            this.txtDTQDiaDiem = new System.Windows.Forms.TextBox();
            this.lbl15 = new System.Windows.Forms.Label();
            this.txtDTQNoiDung = new System.Windows.Forms.TextBox();
            this.lbl16 = new System.Windows.Forms.Label();
            this.txtDTQYNghia = new System.Windows.Forms.TextBox();
            this.btnThemDTQ = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTQ)).BeginInit();
            this.tabDanhMuc.SuspendLayout();
            this.tabPT.SuspendLayout();
            this.tabDB.SuspendLayout();
            this.tabHDVp.SuspendLayout();
            this.tabDTQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(20, 14);
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTieuDe.Text = "DANH MỤC";
            this.lblTieuDe.TabIndex = 0;
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.Location = new System.Drawing.Point(10, 70);
            this.tabDanhMuc.Size = new System.Drawing.Size(875, 495);
            this.tabDanhMuc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabDanhMuc.TabIndex = 1;
            // 
            // tabPT
            // 
            this.tabPT.Name = "tabPT";
            this.tabPT.Location = new System.Drawing.Point(4, 26);
            this.tabPT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPT.UseVisualStyleBackColor = true;
            this.tabPT.Size = new System.Drawing.Size(867, 465);
            this.tabPT.Text = "Phương tiện";
            this.tabPT.TabIndex = 2;
            // 
            // tabDB
            // 
            this.tabDB.Name = "tabDB";
            this.tabDB.Location = new System.Drawing.Point(4, 26);
            this.tabDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabDB.UseVisualStyleBackColor = true;
            this.tabDB.Size = new System.Drawing.Size(867, 465);
            this.tabDB.Text = "Điểm bán vé";
            this.tabDB.TabIndex = 3;
            // 
            // tabHDVp
            // 
            this.tabHDVp.Name = "tabHDVp";
            this.tabHDVp.Location = new System.Drawing.Point(4, 26);
            this.tabHDVp.Padding = new System.Windows.Forms.Padding(3);
            this.tabHDVp.UseVisualStyleBackColor = true;
            this.tabHDVp.Size = new System.Drawing.Size(867, 465);
            this.tabHDVp.Text = "Hướng dẫn viên";
            this.tabHDVp.TabIndex = 4;
            // 
            // tabDTQ
            // 
            this.tabDTQ.Name = "tabDTQ";
            this.tabDTQ.Location = new System.Drawing.Point(4, 26);
            this.tabDTQ.Padding = new System.Windows.Forms.Padding(3);
            this.tabDTQ.UseVisualStyleBackColor = true;
            this.tabDTQ.Size = new System.Drawing.Size(867, 465);
            this.tabDTQ.Text = "Điểm tham quan";
            this.tabDTQ.TabIndex = 5;
            // 
            // dgvPT
            // 
            this.dgvPT.Name = "dgvPT";
            this.dgvPT.Location = new System.Drawing.Point(8, 8);
            this.dgvPT.Size = new System.Drawing.Size(850, 300);
            this.dgvPT.AllowUserToAddRows = false;
            this.dgvPT.AllowUserToDeleteRows = false;
            this.dgvPT.ReadOnly = true;
            this.dgvPT.MultiSelect = false;
            this.dgvPT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPT.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvPT.TabIndex = 6;
            // 
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(10, 333);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Mã PT:";
            this.lbl01.TabIndex = 7;
            // 
            // txtPTMa
            // 
            this.txtPTMa.Name = "txtPTMa";
            this.txtPTMa.Location = new System.Drawing.Point(105, 330);
            this.txtPTMa.Size = new System.Drawing.Size(120, 23);
            this.txtPTMa.TabIndex = 8;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(270, 333);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Tên PT:";
            this.lbl02.TabIndex = 9;
            // 
            // txtPTTen
            // 
            this.txtPTTen.Name = "txtPTTen";
            this.txtPTTen.Location = new System.Drawing.Point(330, 330);
            this.txtPTTen.Size = new System.Drawing.Size(300, 23);
            this.txtPTTen.TabIndex = 10;
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(10, 368);
            this.lbl03.AutoSize = true;
            this.lbl03.Text = "Ghi chú:";
            this.lbl03.TabIndex = 11;
            // 
            // txtPTGhiChu
            // 
            this.txtPTGhiChu.Name = "txtPTGhiChu";
            this.txtPTGhiChu.Location = new System.Drawing.Point(105, 365);
            this.txtPTGhiChu.Size = new System.Drawing.Size(475, 23);
            this.txtPTGhiChu.TabIndex = 12;
            // 
            // btnThemPT
            // 
            this.btnThemPT.Name = "btnThemPT";
            this.btnThemPT.Location = new System.Drawing.Point(620, 360);
            this.btnThemPT.Size = new System.Drawing.Size(130, 32);
            this.btnThemPT.UseVisualStyleBackColor = true;
            this.btnThemPT.Text = "Thêm";
            this.btnThemPT.TabIndex = 13;
            this.btnThemPT.Click += new System.EventHandler(this.btnThemPT_Click);
            // 
            // dgvDB
            // 
            this.dgvDB.Name = "dgvDB";
            this.dgvDB.Location = new System.Drawing.Point(8, 8);
            this.dgvDB.Size = new System.Drawing.Size(850, 300);
            this.dgvDB.AllowUserToAddRows = false;
            this.dgvDB.AllowUserToDeleteRows = false;
            this.dgvDB.ReadOnly = true;
            this.dgvDB.MultiSelect = false;
            this.dgvDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDB.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDB.TabIndex = 14;
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(10, 333);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Mã điểm bán:";
            this.lbl04.TabIndex = 15;
            // 
            // txtDBMa
            // 
            this.txtDBMa.Name = "txtDBMa";
            this.txtDBMa.Location = new System.Drawing.Point(105, 330);
            this.txtDBMa.Size = new System.Drawing.Size(120, 23);
            this.txtDBMa.TabIndex = 16;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(270, 333);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Tên điểm bán:";
            this.lbl05.TabIndex = 17;
            // 
            // txtDBTen
            // 
            this.txtDBTen.Name = "txtDBTen";
            this.txtDBTen.Location = new System.Drawing.Point(365, 330);
            this.txtDBTen.Size = new System.Drawing.Size(300, 23);
            this.txtDBTen.TabIndex = 18;
            // 
            // lbl06
            // 
            this.lbl06.Name = "lbl06";
            this.lbl06.Location = new System.Drawing.Point(10, 368);
            this.lbl06.AutoSize = true;
            this.lbl06.Text = "Địa chỉ:";
            this.lbl06.TabIndex = 19;
            // 
            // txtDBDiaChi
            // 
            this.txtDBDiaChi.Name = "txtDBDiaChi";
            this.txtDBDiaChi.Location = new System.Drawing.Point(105, 365);
            this.txtDBDiaChi.Size = new System.Drawing.Size(475, 23);
            this.txtDBDiaChi.TabIndex = 20;
            // 
            // lbl07
            // 
            this.lbl07.Name = "lbl07";
            this.lbl07.Location = new System.Drawing.Point(10, 403);
            this.lbl07.AutoSize = true;
            this.lbl07.Text = "Điện thoại:";
            this.lbl07.TabIndex = 21;
            // 
            // txtDBDT
            // 
            this.txtDBDT.Name = "txtDBDT";
            this.txtDBDT.Location = new System.Drawing.Point(105, 400);
            this.txtDBDT.Size = new System.Drawing.Size(160, 23);
            this.txtDBDT.TabIndex = 22;
            // 
            // btnThemDB
            // 
            this.btnThemDB.Name = "btnThemDB";
            this.btnThemDB.Location = new System.Drawing.Point(620, 395);
            this.btnThemDB.Size = new System.Drawing.Size(130, 32);
            this.btnThemDB.UseVisualStyleBackColor = true;
            this.btnThemDB.Text = "Thêm";
            this.btnThemDB.TabIndex = 23;
            this.btnThemDB.Click += new System.EventHandler(this.btnThemDB_Click);
            // 
            // dgvHDV
            // 
            this.dgvHDV.Name = "dgvHDV";
            this.dgvHDV.Location = new System.Drawing.Point(8, 8);
            this.dgvHDV.Size = new System.Drawing.Size(850, 300);
            this.dgvHDV.AllowUserToAddRows = false;
            this.dgvHDV.AllowUserToDeleteRows = false;
            this.dgvHDV.ReadOnly = true;
            this.dgvHDV.MultiSelect = false;
            this.dgvHDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHDV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHDV.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvHDV.TabIndex = 24;
            // 
            // lbl08
            // 
            this.lbl08.Name = "lbl08";
            this.lbl08.Location = new System.Drawing.Point(10, 333);
            this.lbl08.AutoSize = true;
            this.lbl08.Text = "Mã HDV:";
            this.lbl08.TabIndex = 25;
            // 
            // txtHDVMa
            // 
            this.txtHDVMa.Name = "txtHDVMa";
            this.txtHDVMa.Location = new System.Drawing.Point(105, 330);
            this.txtHDVMa.Size = new System.Drawing.Size(120, 23);
            this.txtHDVMa.TabIndex = 26;
            // 
            // lbl09
            // 
            this.lbl09.Name = "lbl09";
            this.lbl09.Location = new System.Drawing.Point(270, 333);
            this.lbl09.AutoSize = true;
            this.lbl09.Text = "Họ tên:";
            this.lbl09.TabIndex = 27;
            // 
            // txtHDVTen
            // 
            this.txtHDVTen.Name = "txtHDVTen";
            this.txtHDVTen.Location = new System.Drawing.Point(330, 330);
            this.txtHDVTen.Size = new System.Drawing.Size(300, 23);
            this.txtHDVTen.TabIndex = 28;
            // 
            // lbl10
            // 
            this.lbl10.Name = "lbl10";
            this.lbl10.Location = new System.Drawing.Point(10, 368);
            this.lbl10.AutoSize = true;
            this.lbl10.Text = "Điện thoại:";
            this.lbl10.TabIndex = 29;
            // 
            // txtHDVDT
            // 
            this.txtHDVDT.Name = "txtHDVDT";
            this.txtHDVDT.Location = new System.Drawing.Point(105, 365);
            this.txtHDVDT.Size = new System.Drawing.Size(160, 23);
            this.txtHDVDT.TabIndex = 30;
            // 
            // lbl11
            // 
            this.lbl11.Name = "lbl11";
            this.lbl11.Location = new System.Drawing.Point(270, 368);
            this.lbl11.AutoSize = true;
            this.lbl11.Text = "Lương căn bản:";
            this.lbl11.TabIndex = 31;
            // 
            // numLuong
            // 
            this.numLuong.Name = "numLuong";
            this.numLuong.Location = new System.Drawing.Point(385, 365);
            this.numLuong.Size = new System.Drawing.Size(150, 23);
            this.numLuong.Maximum = 1000000000m;
            this.numLuong.Increment = 100000m;
            this.numLuong.ThousandsSeparator = true;
            this.numLuong.TabIndex = 32;
            // 
            // btnThemHDV
            // 
            this.btnThemHDV.Name = "btnThemHDV";
            this.btnThemHDV.Location = new System.Drawing.Point(620, 360);
            this.btnThemHDV.Size = new System.Drawing.Size(130, 32);
            this.btnThemHDV.UseVisualStyleBackColor = true;
            this.btnThemHDV.Text = "Thêm";
            this.btnThemHDV.TabIndex = 33;
            this.btnThemHDV.Click += new System.EventHandler(this.btnThemHDV_Click);
            // 
            // dgvDTQ
            // 
            this.dgvDTQ.Name = "dgvDTQ";
            this.dgvDTQ.Location = new System.Drawing.Point(8, 8);
            this.dgvDTQ.Size = new System.Drawing.Size(850, 280);
            this.dgvDTQ.AllowUserToAddRows = false;
            this.dgvDTQ.AllowUserToDeleteRows = false;
            this.dgvDTQ.ReadOnly = true;
            this.dgvDTQ.MultiSelect = false;
            this.dgvDTQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDTQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDTQ.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDTQ.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDTQ.TabIndex = 34;
            // 
            // lbl12
            // 
            this.lbl12.Name = "lbl12";
            this.lbl12.Location = new System.Drawing.Point(10, 303);
            this.lbl12.AutoSize = true;
            this.lbl12.Text = "Mã điểm TQ:";
            this.lbl12.TabIndex = 35;
            // 
            // txtDTQMa
            // 
            this.txtDTQMa.Name = "txtDTQMa";
            this.txtDTQMa.Location = new System.Drawing.Point(105, 300);
            this.txtDTQMa.Size = new System.Drawing.Size(120, 23);
            this.txtDTQMa.TabIndex = 36;
            // 
            // lbl13
            // 
            this.lbl13.Name = "lbl13";
            this.lbl13.Location = new System.Drawing.Point(270, 303);
            this.lbl13.AutoSize = true;
            this.lbl13.Text = "Tên điểm TQ:";
            this.lbl13.TabIndex = 37;
            // 
            // txtDTQTen
            // 
            this.txtDTQTen.Name = "txtDTQTen";
            this.txtDTQTen.Location = new System.Drawing.Point(365, 300);
            this.txtDTQTen.Size = new System.Drawing.Size(300, 23);
            this.txtDTQTen.TabIndex = 38;
            // 
            // lbl14
            // 
            this.lbl14.Name = "lbl14";
            this.lbl14.Location = new System.Drawing.Point(10, 338);
            this.lbl14.AutoSize = true;
            this.lbl14.Text = "Địa điểm:";
            this.lbl14.TabIndex = 39;
            // 
            // txtDTQDiaDiem
            // 
            this.txtDTQDiaDiem.Name = "txtDTQDiaDiem";
            this.txtDTQDiaDiem.Location = new System.Drawing.Point(105, 335);
            this.txtDTQDiaDiem.Size = new System.Drawing.Size(475, 23);
            this.txtDTQDiaDiem.TabIndex = 40;
            // 
            // lbl15
            // 
            this.lbl15.Name = "lbl15";
            this.lbl15.Location = new System.Drawing.Point(10, 373);
            this.lbl15.AutoSize = true;
            this.lbl15.Text = "Nội dung:";
            this.lbl15.TabIndex = 41;
            // 
            // txtDTQNoiDung
            // 
            this.txtDTQNoiDung.Name = "txtDTQNoiDung";
            this.txtDTQNoiDung.Location = new System.Drawing.Point(105, 370);
            this.txtDTQNoiDung.Size = new System.Drawing.Size(475, 23);
            this.txtDTQNoiDung.TabIndex = 42;
            // 
            // lbl16
            // 
            this.lbl16.Name = "lbl16";
            this.lbl16.Location = new System.Drawing.Point(10, 408);
            this.lbl16.AutoSize = true;
            this.lbl16.Text = "Ý nghĩa:";
            this.lbl16.TabIndex = 43;
            // 
            // txtDTQYNghia
            // 
            this.txtDTQYNghia.Name = "txtDTQYNghia";
            this.txtDTQYNghia.Location = new System.Drawing.Point(105, 405);
            this.txtDTQYNghia.Size = new System.Drawing.Size(475, 23);
            this.txtDTQYNghia.TabIndex = 44;
            // 
            // btnThemDTQ
            // 
            this.btnThemDTQ.Name = "btnThemDTQ";
            this.btnThemDTQ.Location = new System.Drawing.Point(620, 400);
            this.btnThemDTQ.Size = new System.Drawing.Size(130, 32);
            this.btnThemDTQ.UseVisualStyleBackColor = true;
            this.btnThemDTQ.Text = "Thêm";
            this.btnThemDTQ.TabIndex = 45;
            this.btnThemDTQ.Click += new System.EventHandler(this.btnThemDTQ_Click);
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(780, 12);
            this.btnDong.Size = new System.Drawing.Size(100, 36);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 46;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.tabDanhMuc);
            this.tabDanhMuc.Controls.Add(this.tabPT);
            this.tabDanhMuc.Controls.Add(this.tabDB);
            this.tabDanhMuc.Controls.Add(this.tabHDVp);
            this.tabDanhMuc.Controls.Add(this.tabDTQ);
            this.tabPT.Controls.Add(this.dgvPT);
            this.tabPT.Controls.Add(this.lbl01);
            this.tabPT.Controls.Add(this.txtPTMa);
            this.tabPT.Controls.Add(this.lbl02);
            this.tabPT.Controls.Add(this.txtPTTen);
            this.tabPT.Controls.Add(this.lbl03);
            this.tabPT.Controls.Add(this.txtPTGhiChu);
            this.tabPT.Controls.Add(this.btnThemPT);
            this.tabDB.Controls.Add(this.dgvDB);
            this.tabDB.Controls.Add(this.lbl04);
            this.tabDB.Controls.Add(this.txtDBMa);
            this.tabDB.Controls.Add(this.lbl05);
            this.tabDB.Controls.Add(this.txtDBTen);
            this.tabDB.Controls.Add(this.lbl06);
            this.tabDB.Controls.Add(this.txtDBDiaChi);
            this.tabDB.Controls.Add(this.lbl07);
            this.tabDB.Controls.Add(this.txtDBDT);
            this.tabDB.Controls.Add(this.btnThemDB);
            this.tabHDVp.Controls.Add(this.dgvHDV);
            this.tabHDVp.Controls.Add(this.lbl08);
            this.tabHDVp.Controls.Add(this.txtHDVMa);
            this.tabHDVp.Controls.Add(this.lbl09);
            this.tabHDVp.Controls.Add(this.txtHDVTen);
            this.tabHDVp.Controls.Add(this.lbl10);
            this.tabHDVp.Controls.Add(this.txtHDVDT);
            this.tabHDVp.Controls.Add(this.lbl11);
            this.tabHDVp.Controls.Add(this.numLuong);
            this.tabHDVp.Controls.Add(this.btnThemHDV);
            this.tabDTQ.Controls.Add(this.dgvDTQ);
            this.tabDTQ.Controls.Add(this.lbl12);
            this.tabDTQ.Controls.Add(this.txtDTQMa);
            this.tabDTQ.Controls.Add(this.lbl13);
            this.tabDTQ.Controls.Add(this.txtDTQTen);
            this.tabDTQ.Controls.Add(this.lbl14);
            this.tabDTQ.Controls.Add(this.txtDTQDiaDiem);
            this.tabDTQ.Controls.Add(this.lbl15);
            this.tabDTQ.Controls.Add(this.txtDTQNoiDung);
            this.tabDTQ.Controls.Add(this.lbl16);
            this.tabDTQ.Controls.Add(this.txtDTQYNghia);
            this.tabDTQ.Controls.Add(this.btnThemDTQ);
            this.Controls.Add(this.btnDong);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabDanhMuc.ResumeLayout(false);
            this.tabPT.ResumeLayout(false);
            this.tabPT.PerformLayout();
            this.tabDB.ResumeLayout(false);
            this.tabDB.PerformLayout();
            this.tabHDVp.ResumeLayout(false);
            this.tabHDVp.PerformLayout();
            this.tabDTQ.ResumeLayout(false);
            this.tabDTQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TabControl tabDanhMuc;
        private System.Windows.Forms.TabPage tabPT;
        private System.Windows.Forms.TabPage tabDB;
        private System.Windows.Forms.TabPage tabHDVp;
        private System.Windows.Forms.TabPage tabDTQ;
        private System.Windows.Forms.DataGridView dgvPT;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.TextBox txtPTMa;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.TextBox txtPTTen;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.TextBox txtPTGhiChu;
        private System.Windows.Forms.Button btnThemPT;
        private System.Windows.Forms.DataGridView dgvDB;
        private System.Windows.Forms.Label lbl04;
        private System.Windows.Forms.TextBox txtDBMa;
        private System.Windows.Forms.Label lbl05;
        private System.Windows.Forms.TextBox txtDBTen;
        private System.Windows.Forms.Label lbl06;
        private System.Windows.Forms.TextBox txtDBDiaChi;
        private System.Windows.Forms.Label lbl07;
        private System.Windows.Forms.TextBox txtDBDT;
        private System.Windows.Forms.Button btnThemDB;
        private System.Windows.Forms.DataGridView dgvHDV;
        private System.Windows.Forms.Label lbl08;
        private System.Windows.Forms.TextBox txtHDVMa;
        private System.Windows.Forms.Label lbl09;
        private System.Windows.Forms.TextBox txtHDVTen;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.TextBox txtHDVDT;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.NumericUpDown numLuong;
        private System.Windows.Forms.Button btnThemHDV;
        private System.Windows.Forms.DataGridView dgvDTQ;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.TextBox txtDTQMa;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.TextBox txtDTQTen;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.TextBox txtDTQDiaDiem;
        private System.Windows.Forms.Label lbl15;
        private System.Windows.Forms.TextBox txtDTQNoiDung;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.TextBox txtDTQYNghia;
        private System.Windows.Forms.Button btnThemDTQ;
        private System.Windows.Forms.Button btnDong;
    }
}
