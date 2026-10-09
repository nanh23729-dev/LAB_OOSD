namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmLuongThongKe
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
            this.tabTK = new System.Windows.Forms.TabControl();
            this.tpLuong = new System.Windows.Forms.TabPage();
            this.tpTongHop = new System.Windows.Forms.TabPage();
            this.lbl01 = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lbl02 = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.btnLuong = new System.Windows.Forms.Button();
            this.lbl03 = new System.Windows.Forms.Label();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.lbl04 = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.lbl05 = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTongHop = new System.Windows.Forms.Button();
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).BeginInit();
            this.tabTK.SuspendLayout();
            this.tpLuong.SuspendLayout();
            this.tpTongHop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTK
            // 
            this.tabTK.Name = "tabTK";
            this.tabTK.Location = new System.Drawing.Point(10, 10);
            this.tabTK.Size = new System.Drawing.Size(875, 495);
            this.tabTK.TabIndex = 0;
            // 
            // tpLuong
            // 
            this.tpLuong.Name = "tpLuong";
            this.tpLuong.Padding = new System.Windows.Forms.Padding(3);
            this.tpLuong.UseVisualStyleBackColor = true;
            this.tpLuong.Text = "Lương hướng dẫn viên";
            this.tpLuong.TabIndex = 1;
            // 
            // tpTongHop
            // 
            this.tpTongHop.Name = "tpTongHop";
            this.tpTongHop.Padding = new System.Windows.Forms.Padding(3);
            this.tpTongHop.UseVisualStyleBackColor = true;
            this.tpTongHop.Text = "Thống kê tổng hợp";
            this.tpTongHop.TabIndex = 2;
            // 
            // lbl01
            // 
            this.lbl01.Name = "lbl01";
            this.lbl01.Location = new System.Drawing.Point(10, 18);
            this.lbl01.AutoSize = true;
            this.lbl01.Text = "Tháng:";
            this.lbl01.TabIndex = 3;
            // 
            // numThang
            // 
            this.numThang.Name = "numThang";
            this.numThang.Location = new System.Drawing.Point(60, 15);
            this.numThang.Size = new System.Drawing.Size(70, 23);
            this.numThang.Minimum = 1m;
            this.numThang.Maximum = 12m;
            this.numThang.Value = 1m;
            this.numThang.TabIndex = 4;
            // 
            // lbl02
            // 
            this.lbl02.Name = "lbl02";
            this.lbl02.Location = new System.Drawing.Point(180, 18);
            this.lbl02.AutoSize = true;
            this.lbl02.Text = "Năm:";
            this.lbl02.TabIndex = 5;
            // 
            // numNam
            // 
            this.numNam.Name = "numNam";
            this.numNam.Location = new System.Drawing.Point(220, 15);
            this.numNam.Size = new System.Drawing.Size(90, 23);
            this.numNam.Minimum = 2000m;
            this.numNam.Maximum = 2100m;
            this.numNam.Value = 2026m;
            this.numNam.TabIndex = 6;
            // 
            // btnLuong
            // 
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Location = new System.Drawing.Point(340, 10);
            this.btnLuong.Size = new System.Drawing.Size(130, 32);
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.Text = "Tính lương";
            this.btnLuong.TabIndex = 7;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // lbl03
            // 
            this.lbl03.Name = "lbl03";
            this.lbl03.Location = new System.Drawing.Point(490, 18);
            this.lbl03.AutoSize = true;
            this.lbl03.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl03.Text = "Lương = lương căn bản + thù lao các tour kết thúc trong tháng";
            this.lbl03.TabIndex = 8;
            // 
            // dgvLuong
            // 
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.Location = new System.Drawing.Point(8, 55);
            this.dgvLuong.Size = new System.Drawing.Size(850, 400);
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.ReadOnly = true;
            this.dgvLuong.MultiSelect = false;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLuong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvLuong.TabIndex = 9;
            // 
            // lbl04
            // 
            this.lbl04.Name = "lbl04";
            this.lbl04.Location = new System.Drawing.Point(10, 18);
            this.lbl04.AutoSize = true;
            this.lbl04.Text = "Từ ngày:";
            this.lbl04.TabIndex = 10;
            // 
            // dtTu
            // 
            this.dtTu.Name = "dtTu";
            this.dtTu.Location = new System.Drawing.Point(70, 15);
            this.dtTu.Size = new System.Drawing.Size(130, 23);
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTu.TabIndex = 11;
            // 
            // lbl05
            // 
            this.lbl05.Name = "lbl05";
            this.lbl05.Location = new System.Drawing.Point(250, 18);
            this.lbl05.AutoSize = true;
            this.lbl05.Text = "Đến ngày:";
            this.lbl05.TabIndex = 12;
            // 
            // dtDen
            // 
            this.dtDen.Name = "dtDen";
            this.dtDen.Location = new System.Drawing.Point(315, 15);
            this.dtDen.Size = new System.Drawing.Size(130, 23);
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDen.TabIndex = 13;
            // 
            // btnTongHop
            // 
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Location = new System.Drawing.Point(490, 10);
            this.btnTongHop.Size = new System.Drawing.Size(130, 32);
            this.btnTongHop.UseVisualStyleBackColor = true;
            this.btnTongHop.Text = "Thống kê";
            this.btnTongHop.TabIndex = 14;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // dgvTongHop
            // 
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.Location = new System.Drawing.Point(8, 55);
            this.dgvTongHop.Size = new System.Drawing.Size(850, 400);
            this.dgvTongHop.AllowUserToAddRows = false;
            this.dgvTongHop.AllowUserToDeleteRows = false;
            this.dgvTongHop.ReadOnly = true;
            this.dgvTongHop.MultiSelect = false;
            this.dgvTongHop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTongHop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTongHop.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTongHop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvTongHop.TabIndex = 15;
            // 
            // btnDong
            // 
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(785, 515);
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Text = "Đóng";
            this.btnDong.TabIndex = 16;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.tabTK);
            this.tabTK.Controls.Add(this.tpLuong);
            this.tabTK.Controls.Add(this.tpTongHop);
            this.tpLuong.Controls.Add(this.lbl01);
            this.tpLuong.Controls.Add(this.numThang);
            this.tpLuong.Controls.Add(this.lbl02);
            this.tpLuong.Controls.Add(this.numNam);
            this.tpLuong.Controls.Add(this.btnLuong);
            this.tpLuong.Controls.Add(this.lbl03);
            this.tpLuong.Controls.Add(this.dgvLuong);
            this.tpTongHop.Controls.Add(this.lbl04);
            this.tpTongHop.Controls.Add(this.dtTu);
            this.tpTongHop.Controls.Add(this.lbl05);
            this.tpTongHop.Controls.Add(this.dtDen);
            this.tpTongHop.Controls.Add(this.btnTongHop);
            this.tpTongHop.Controls.Add(this.dgvTongHop);
            this.Controls.Add(this.btnDong);
            // 
            // FrmLuongThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmLuongThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lương hướng dẫn viên - thống kê";
            this.Load += new System.EventHandler(this.FrmLuongThongKe_Load);
            this.tabTK.ResumeLayout(false);
            this.tpLuong.ResumeLayout(false);
            this.tpLuong.PerformLayout();
            this.tpTongHop.ResumeLayout(false);
            this.tpTongHop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabTK;
        private System.Windows.Forms.TabPage tpLuong;
        private System.Windows.Forms.TabPage tpTongHop;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.Label lbl04;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label lbl05;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTongHop;
        private System.Windows.Forms.DataGridView dgvTongHop;
        private System.Windows.Forms.Button btnDong;
    }
}
