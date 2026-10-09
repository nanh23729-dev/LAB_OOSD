namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmChuyenLe
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
            this.lbl01 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lbl02 = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.lbl03 = new System.Windows.Forms.Label();
            this.dtDi = new System.Windows.Forms.DateTimePicker();
            this.lbl04 = new System.Windows.Forms.Label();
            this.lblNgayVe = new System.Windows.Forms.Label();
            this.lbl05 = new System.Windows.Forms.Label();
            this.txtDon = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnDongDK = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(20, 14);
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTieuDe.Text = "LỊCH CHUYẾN KHÁCH LẺ";
            this.lblTieuDe.TabIndex = 0;
            // 
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(15, 78);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Mã chuyến:";
            this.lbl01.TabIndex = 1;
            // 
            // txtMa
            // 
            this.txtMa.Name = "txtMa";
            this.txtMa.Location = new System.Drawing.Point(110, 75);
            this.txtMa.Size = new System.Drawing.Size(130, 23);
            this.txtMa.TabIndex = 2;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(300, 78);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Tour:";
            this.lbl02.TabIndex = 3;
            // 
            // cboTour
            // 
            this.cboTour.Name = "cboTour";
            this.cboTour.Location = new System.Drawing.Point(345, 75);
            this.cboTour.Size = new System.Drawing.Size(330, 23);
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTour.FormattingEnabled = true;
            this.cboTour.TabIndex = 4;
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.TinhNgayVe);
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(15, 113);
            this.lbl03.AutoSize = true;
            this.lbl03.Text = "Ngày đi:";
            this.lbl03.TabIndex = 5;
            // 
            // dtDi
            // 
            this.dtDi.Name = "dtDi";
            this.dtDi.Location = new System.Drawing.Point(110, 110);
            this.dtDi.Size = new System.Drawing.Size(130, 23);
            this.dtDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDi.TabIndex = 6;
            this.dtDi.ValueChanged += new System.EventHandler(this.TinhNgayVe);
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(300, 113);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Ngày về:";
            this.lbl04.TabIndex = 7;
            // 
            // lblNgayVe
            // 
            this.lblNgayVe.Name = "lblNgayVe";
            this.lblNgayVe.Location = new System.Drawing.Point(365, 113);
            this.lblNgayVe.AutoSize = true;
            this.lblNgayVe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgayVe.Text = "-";
            this.lblNgayVe.TabIndex = 8;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(15, 148);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Địa điểm đón:";
            this.lbl05.TabIndex = 9;
            // 
            // txtDon
            // 
            this.txtDon.Name = "txtDon";
            this.txtDon.Location = new System.Drawing.Point(110, 145);
            this.txtDon.Size = new System.Drawing.Size(480, 23);
            this.txtDon.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Name = "btnThem";
            this.btnThem.Location = new System.Drawing.Point(640, 140);
            this.btnThem.Size = new System.Drawing.Size(110, 32);
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Text = "Tạo chuyến";
            this.btnThem.TabIndex = 11;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnDongDK
            // 
            this.btnDongDK.Name = "btnDongDK";
            this.btnDongDK.Location = new System.Drawing.Point(760, 140);
            this.btnDongDK.Size = new System.Drawing.Size(120, 32);
            this.btnDongDK.UseVisualStyleBackColor = true;
            this.btnDongDK.Text = "Đóng đăng ký";
            this.btnDongDK.TabIndex = 12;
            this.btnDongDK.Click += new System.EventHandler(this.btnDongDK_Click);
            // 
            // dgv
            // 
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(15, 185);
            this.dgv.Size = new System.Drawing.Size(865, 380);
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.MultiSelect = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgv.TabIndex = 13;
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(780, 12);
            this.btnDong.Size = new System.Drawing.Size(100, 36);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 14;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lbl02);
            this.Controls.Add(this.cboTour);
            this.Controls.Add(this.lbl03);
            this.Controls.Add(this.dtDi);
            this.Controls.Add(this.lbl04);
            this.Controls.Add(this.lblNgayVe);
            this.Controls.Add(this.lbl05);
            this.Controls.Add(this.txtDon);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnDongDK);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnDong);
            // 
            // FrmChuyenLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmChuyenLe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch chuyến khách lẻ";
            this.Load += new System.EventHandler(this.FrmChuyenLe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.DateTimePicker dtDi;
        private System.Windows.Forms.Label lbl04;
        private System.Windows.Forms.Label lblNgayVe;
        private System.Windows.Forms.Label lbl05;
        private System.Windows.Forms.TextBox txtDon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDongDK;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
    }
}
