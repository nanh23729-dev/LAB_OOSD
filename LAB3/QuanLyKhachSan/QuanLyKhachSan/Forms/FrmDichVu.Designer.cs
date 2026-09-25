namespace QuanLyKhachSan.Forms
{
    partial class FrmDichVu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cboLuotLbl = new System.Windows.Forms.Label();
            this.cboLuotLbl.Location = new System.Drawing.Point(15, 15);
            this.cboLuotLbl.Name = "cboLuotLbl";
            this.cboLuotLbl.Size = new System.Drawing.Size(150, 20);
            this.cboLuotLbl.Text = "Phiếu đang ở";
            this.cboLuot = new System.Windows.Forms.ComboBox();
            this.cboLuot.Location = new System.Drawing.Point(175, 15);
            this.cboLuot.Name = "cboLuot";
            this.cboLuot.Size = new System.Drawing.Size(505, 23);
            this.cboLuot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLuot.SelectedIndexChanged += new System.EventHandler(this.cboLuot_SelectedIndexChanged);
            this.txtPhongLbl = new System.Windows.Forms.Label();
            this.txtPhongLbl.Location = new System.Drawing.Point(15, 47);
            this.txtPhongLbl.Name = "txtPhongLbl";
            this.txtPhongLbl.Size = new System.Drawing.Size(150, 20);
            this.txtPhongLbl.Text = "Phòng";
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.txtPhong.Location = new System.Drawing.Point(175, 47);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(505, 23);
            this.txtPhong.ReadOnly = true;
            this.dtNgayLbl = new System.Windows.Forms.Label();
            this.dtNgayLbl.Location = new System.Drawing.Point(15, 79);
            this.dtNgayLbl.Name = "dtNgayLbl";
            this.dtNgayLbl.Size = new System.Drawing.Size(150, 20);
            this.dtNgayLbl.Text = "Ngày sử dụng";
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.dtNgay.Location = new System.Drawing.Point(175, 79);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(505, 23);
            this.cboDVLbl = new System.Windows.Forms.Label();
            this.cboDVLbl.Location = new System.Drawing.Point(15, 111);
            this.cboDVLbl.Name = "cboDVLbl";
            this.cboDVLbl.Size = new System.Drawing.Size(150, 20);
            this.cboDVLbl.Text = "Dịch vụ";
            this.cboDV = new System.Windows.Forms.ComboBox();
            this.cboDV.Location = new System.Drawing.Point(175, 111);
            this.cboDV.Name = "cboDV";
            this.cboDV.Size = new System.Drawing.Size(505, 23);
            this.cboDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numSLLbl = new System.Windows.Forms.Label();
            this.numSLLbl.Location = new System.Drawing.Point(15, 143);
            this.numSLLbl.Name = "numSLLbl";
            this.numSLLbl.Size = new System.Drawing.Size(150, 20);
            this.numSLLbl.Text = "Số lượng";
            this.numSL = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            this.numSL.Location = new System.Drawing.Point(175, 143);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(505, 23);
            this.numSL.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            this.cboNVLbl = new System.Windows.Forms.Label();
            this.cboNVLbl.Location = new System.Drawing.Point(15, 175);
            this.cboNVLbl.Name = "cboNVLbl";
            this.cboNVLbl.Size = new System.Drawing.Size(150, 20);
            this.cboNVLbl.Text = "Nhân viên";
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.cboNV.Location = new System.Drawing.Point(175, 175);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(505, 23);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnGhi.Location = new System.Drawing.Point(15, 207);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(220, 32);
            this.btnGhi.Text = "Ghi nhận sử dụng";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.dgvLichSu.Location = new System.Drawing.Point(15, 247);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.Size = new System.Drawing.Size(700, 260);
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnDong.Location = new System.Drawing.Point(620, 490);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.cboLuotLbl);
            this.Controls.Add(this.cboLuot);
            this.Controls.Add(this.txtPhongLbl);
            this.Controls.Add(this.txtPhong);
            this.Controls.Add(this.dtNgayLbl);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.cboDVLbl);
            this.Controls.Add(this.cboDV);
            this.Controls.Add(this.numSLLbl);
            this.Controls.Add(this.numSL);
            this.Controls.Add(this.cboNVLbl);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 560);
            this.Name = "FrmDichVu";
            this.Text = "Sử dụng dịch vụ";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label cboLuotLbl;
        private System.Windows.Forms.ComboBox cboLuot;
        private System.Windows.Forms.Label txtPhongLbl;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label dtNgayLbl;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label cboDVLbl;
        private System.Windows.Forms.ComboBox cboDV;
        private System.Windows.Forms.Label numSLLbl;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Label cboNVLbl;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.Button btnDong;
    }
}