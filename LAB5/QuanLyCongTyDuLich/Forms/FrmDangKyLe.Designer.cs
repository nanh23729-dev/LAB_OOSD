namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmDangKyLe
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
            this.txtSo = new System.Windows.Forms.TextBox();
            this.lbl02 = new System.Windows.Forms.Label();
            this.cboChuyen = new System.Windows.Forms.ComboBox();
            this.lbl03 = new System.Windows.Forms.Label();
            this.cboDiemBan = new System.Windows.Forms.ComboBox();
            this.lbl04 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lbl05 = new System.Windows.Forms.Label();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.lbl06 = new System.Windows.Forms.Label();
            this.numNguoi = new System.Windows.Forms.NumericUpDown();
            this.lbl07 = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).BeginInit();
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
            this.lblTieuDe.Text = "ĐĂNG KÝ KHÁCH LẺ THEO CHUYẾN";
            this.lblTieuDe.TabIndex = 0;
            // 
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(15, 78);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Số đăng ký:";
            this.lbl01.TabIndex = 1;
            // 
            // txtSo
            // 
            this.txtSo.Name = "txtSo";
            this.txtSo.Location = new System.Drawing.Point(110, 75);
            this.txtSo.Size = new System.Drawing.Size(130, 23);
            this.txtSo.TabIndex = 2;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(300, 78);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Chuyến:";
            this.lbl02.TabIndex = 3;
            // 
            // cboChuyen
            // 
            this.cboChuyen.Name = "cboChuyen";
            this.cboChuyen.Location = new System.Drawing.Point(355, 75);
            this.cboChuyen.Size = new System.Drawing.Size(330, 23);
            this.cboChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyen.FormattingEnabled = true;
            this.cboChuyen.TabIndex = 4;
            this.cboChuyen.SelectedIndexChanged += new System.EventHandler(this.TinhTien);
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(15, 113);
            this.lbl03.AutoSize = true;
            this.lbl03.Text = "Điểm bán vé:";
            this.lbl03.TabIndex = 5;
            // 
            // cboDiemBan
            // 
            this.cboDiemBan.Name = "cboDiemBan";
            this.cboDiemBan.Location = new System.Drawing.Point(110, 110);
            this.cboDiemBan.Size = new System.Drawing.Size(200, 23);
            this.cboDiemBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiemBan.FormattingEnabled = true;
            this.cboDiemBan.TabIndex = 6;
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(340, 113);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Người đăng ký:";
            this.lbl04.TabIndex = 7;
            // 
            // txtTen
            // 
            this.txtTen.Name = "txtTen";
            this.txtTen.Location = new System.Drawing.Point(435, 110);
            this.txtTen.Size = new System.Drawing.Size(210, 23);
            this.txtTen.TabIndex = 8;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(650, 113);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Điện thoại:";
            this.lbl05.TabIndex = 9;
            // 
            // txtDT
            // 
            this.txtDT.Name = "txtDT";
            this.txtDT.Location = new System.Drawing.Point(720, 110);
            this.txtDT.Size = new System.Drawing.Size(140, 23);
            this.txtDT.TabIndex = 10;
            // 
            // lbl06
            // 
            this.lbl06.Name = "lbl06";
            this.lbl06.Location = new System.Drawing.Point(15, 148);
            this.lbl06.AutoSize = true;
            this.lbl06.Text = "Số người:";
            this.lbl06.TabIndex = 11;
            // 
            // numNguoi
            // 
            this.numNguoi.Name = "numNguoi";
            this.numNguoi.Location = new System.Drawing.Point(110, 145);
            this.numNguoi.Size = new System.Drawing.Size(70, 23);
            this.numNguoi.Minimum = 1m;
            this.numNguoi.Maximum = 11m;
            this.numNguoi.Value = 1m;
            this.numNguoi.TabIndex = 12;
            this.numNguoi.ValueChanged += new System.EventHandler(this.TinhTien);
            // 
            // lbl07
            // 
            this.lbl07.Name = "lbl07";
            this.lbl07.Location = new System.Drawing.Point(230, 148);
            this.lbl07.AutoSize = true;
            this.lbl07.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl07.Text = "Thành tiền:";
            this.lbl07.TabIndex = 13;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Location = new System.Drawing.Point(310, 148);
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblThanhTien.Text = "0 đ";
            this.lblThanhTien.TabIndex = 14;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Location = new System.Drawing.Point(640, 140);
            this.btnDangKy.Size = new System.Drawing.Size(240, 32);
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Text = "Đăng ký và thanh toán vé";
            this.btnDangKy.TabIndex = 15;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
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
            this.dgv.TabIndex = 16;
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(780, 12);
            this.btnDong.Size = new System.Drawing.Size(100, 36);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 17;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.txtSo);
            this.Controls.Add(this.lbl02);
            this.Controls.Add(this.cboChuyen);
            this.Controls.Add(this.lbl03);
            this.Controls.Add(this.cboDiemBan);
            this.Controls.Add(this.lbl04);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lbl05);
            this.Controls.Add(this.txtDT);
            this.Controls.Add(this.lbl06);
            this.Controls.Add(this.numNguoi);
            this.Controls.Add(this.lbl07);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnDong);
            // 
            // FrmDangKyLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmDangKyLe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký khách lẻ theo chuyến";
            this.Load += new System.EventHandler(this.FrmDangKyLe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.ComboBox cboChuyen;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.ComboBox cboDiemBan;
        private System.Windows.Forms.Label lbl04;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lbl05;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.Label lbl06;
        private System.Windows.Forms.NumericUpDown numNguoi;
        private System.Windows.Forms.Label lbl07;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
    }
}
