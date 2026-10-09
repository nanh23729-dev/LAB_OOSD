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
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(15, 18);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Số đăng ký:";
            this.lbl01.TabIndex = 0;
            // 
            // txtSo
            // 
            this.txtSo.Name = "txtSo";
            this.txtSo.Location = new System.Drawing.Point(110, 15);
            this.txtSo.Size = new System.Drawing.Size(130, 23);
            this.txtSo.TabIndex = 1;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(300, 18);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Chuyến:";
            this.lbl02.TabIndex = 2;
            // 
            // cboChuyen
            // 
            this.cboChuyen.Name = "cboChuyen";
            this.cboChuyen.Location = new System.Drawing.Point(355, 15);
            this.cboChuyen.Size = new System.Drawing.Size(330, 23);
            this.cboChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyen.FormattingEnabled = true;
            this.cboChuyen.TabIndex = 3;
            this.cboChuyen.SelectedIndexChanged += new System.EventHandler(this.TinhTien);
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(15, 53);
            this.lbl03.AutoSize = true;
            this.lbl03.Text = "Điểm bán vé:";
            this.lbl03.TabIndex = 4;
            // 
            // cboDiemBan
            // 
            this.cboDiemBan.Name = "cboDiemBan";
            this.cboDiemBan.Location = new System.Drawing.Point(110, 50);
            this.cboDiemBan.Size = new System.Drawing.Size(200, 23);
            this.cboDiemBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiemBan.FormattingEnabled = true;
            this.cboDiemBan.TabIndex = 5;
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(340, 53);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Người đăng ký:";
            this.lbl04.TabIndex = 6;
            // 
            // txtTen
            // 
            this.txtTen.Name = "txtTen";
            this.txtTen.Location = new System.Drawing.Point(435, 50);
            this.txtTen.Size = new System.Drawing.Size(210, 23);
            this.txtTen.TabIndex = 7;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(650, 53);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Điện thoại:";
            this.lbl05.TabIndex = 8;
            // 
            // txtDT
            // 
            this.txtDT.Name = "txtDT";
            this.txtDT.Location = new System.Drawing.Point(720, 50);
            this.txtDT.Size = new System.Drawing.Size(140, 23);
            this.txtDT.TabIndex = 9;
            // 
            // lbl06
            // 
            this.lbl06.Name = "lbl06";
            this.lbl06.Location = new System.Drawing.Point(15, 88);
            this.lbl06.AutoSize = true;
            this.lbl06.Text = "Số người:";
            this.lbl06.TabIndex = 10;
            // 
            // numNguoi
            // 
            this.numNguoi.Name = "numNguoi";
            this.numNguoi.Location = new System.Drawing.Point(110, 85);
            this.numNguoi.Size = new System.Drawing.Size(70, 23);
            this.numNguoi.Minimum = 1m;
            this.numNguoi.Maximum = 11m;
            this.numNguoi.Value = 1m;
            this.numNguoi.TabIndex = 11;
            this.numNguoi.ValueChanged += new System.EventHandler(this.TinhTien);
            // 
            // lbl07
            // 
            this.lbl07.Name = "lbl07";
            this.lbl07.Location = new System.Drawing.Point(230, 88);
            this.lbl07.AutoSize = true;
            this.lbl07.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl07.Text = "Thành tiền:";
            this.lbl07.TabIndex = 12;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Location = new System.Drawing.Point(310, 88);
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblThanhTien.Text = "0 đ";
            this.lblThanhTien.TabIndex = 13;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Location = new System.Drawing.Point(640, 80);
            this.btnDangKy.Size = new System.Drawing.Size(240, 32);
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Text = "Đăng ký và thanh toán vé";
            this.btnDangKy.TabIndex = 14;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // dgv
            // 
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(15, 125);
            this.dgv.Size = new System.Drawing.Size(865, 380);
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.MultiSelect = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgv.TabIndex = 15;
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(780, 515);
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 16;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 560);
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
