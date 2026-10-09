namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmPhanCongHDV
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
            this.txtMaPC = new System.Windows.Forms.TextBox();
            this.lbl02 = new System.Windows.Forms.Label();
            this.cboHDV = new System.Windows.Forms.ComboBox();
            this.lbl03 = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lbl04 = new System.Windows.Forms.Label();
            this.cboDoiTuong = new System.Windows.Forms.ComboBox();
            this.lbl05 = new System.Windows.Forms.Label();
            this.numThuLao = new System.Windows.Forms.NumericUpDown();
            this.lbl06 = new System.Windows.Forms.Label();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThuLao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(15, 18);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Mã phân công:";
            this.lbl01.TabIndex = 0;
            // 
            // txtMaPC
            // 
            this.txtMaPC.Name = "txtMaPC";
            this.txtMaPC.Location = new System.Drawing.Point(115, 15);
            this.txtMaPC.Size = new System.Drawing.Size(130, 23);
            this.txtMaPC.TabIndex = 1;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(320, 18);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Hướng dẫn viên:";
            this.lbl02.TabIndex = 2;
            // 
            // cboHDV
            // 
            this.cboHDV.Name = "cboHDV";
            this.cboHDV.Location = new System.Drawing.Point(425, 15);
            this.cboHDV.Size = new System.Drawing.Size(290, 23);
            this.cboHDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHDV.FormattingEnabled = true;
            this.cboHDV.TabIndex = 3;
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(15, 53);
            this.lbl03.AutoSize = true;
            this.lbl03.Text = "Loại:";
            this.lbl03.TabIndex = 4;
            // 
            // cboLoai
            // 
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Location = new System.Drawing.Point(115, 50);
            this.cboLoai.Size = new System.Drawing.Size(130, 23);
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.TabIndex = 5;
            this.cboLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoai_SelectedIndexChanged);
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(320, 53);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Chuyến / đoàn:";
            this.lbl04.TabIndex = 6;
            // 
            // cboDoiTuong
            // 
            this.cboDoiTuong.Name = "cboDoiTuong";
            this.cboDoiTuong.Location = new System.Drawing.Point(425, 50);
            this.cboDoiTuong.Size = new System.Drawing.Size(480, 23);
            this.cboDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoiTuong.FormattingEnabled = true;
            this.cboDoiTuong.TabIndex = 7;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(15, 88);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Thù lao tour:";
            this.lbl05.TabIndex = 8;
            // 
            // numThuLao
            // 
            this.numThuLao.Name = "numThuLao";
            this.numThuLao.Location = new System.Drawing.Point(115, 85);
            this.numThuLao.Size = new System.Drawing.Size(140, 23);
            this.numThuLao.Maximum = 1000000000m;
            this.numThuLao.Increment = 100000m;
            this.numThuLao.ThousandsSeparator = true;
            this.numThuLao.TabIndex = 9;
            // 
            // lbl06
            // 
            this.lbl06.Name = "lbl06";
            this.lbl06.Location = new System.Drawing.Point(320, 88);
            this.lbl06.AutoSize = true;
            this.lbl06.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl06.Text = "Ngày bắt đầu / kết thúc lấy theo chuyến hoặc phiếu đoàn.";
            this.lbl06.TabIndex = 10;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Location = new System.Drawing.Point(790, 80);
            this.btnPhanCong.Size = new System.Drawing.Size(140, 32);
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.TabIndex = 11;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // dgv
            // 
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(15, 125);
            this.dgv.Size = new System.Drawing.Size(915, 380);
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.MultiSelect = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgv.TabIndex = 12;
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(830, 515);
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 13;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.txtMaPC);
            this.Controls.Add(this.lbl02);
            this.Controls.Add(this.cboHDV);
            this.Controls.Add(this.lbl03);
            this.Controls.Add(this.cboLoai);
            this.Controls.Add(this.lbl04);
            this.Controls.Add(this.cboDoiTuong);
            this.Controls.Add(this.lbl05);
            this.Controls.Add(this.numThuLao);
            this.Controls.Add(this.lbl06);
            this.Controls.Add(this.btnPhanCong);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnDong);
            // 
            // FrmPhanCongHDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmPhanCongHDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân công hướng dẫn viên";
            this.Load += new System.EventHandler(this.FrmPhanCongHDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numThuLao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.TextBox txtMaPC;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.ComboBox cboHDV;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lbl04;
        private System.Windows.Forms.ComboBox cboDoiTuong;
        private System.Windows.Forms.Label lbl05;
        private System.Windows.Forms.NumericUpDown numThuLao;
        private System.Windows.Forms.Label lbl06;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
    }
}
