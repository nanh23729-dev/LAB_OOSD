namespace QuanLyNhanSu.Forms
{
    partial class FrmBangLuong
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
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.lblCongThuc = new System.Windows.Forms.Label();
            this.dgvBangLuong = new System.Windows.Forms.DataGridView();
            this.lblTongNV = new System.Windows.Forms.Label();
            this.lblTongThucLinh = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(20, 21);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(43, 20);
            this.lblThang.TabIndex = 0;
            this.lblThang.Text = "Tháng:";
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(75, 18);
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
            this.numThang.Size = new System.Drawing.Size(60, 25);
            this.numThang.TabIndex = 1;
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
            this.lblNam.Location = new System.Drawing.Point(150, 21);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(40, 20);
            this.lblNam.TabIndex = 2;
            this.lblNam.Text = "Năm:";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(195, 18);
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
            this.numNam.Size = new System.Drawing.Size(80, 25);
            this.numNam.TabIndex = 3;
            this.numNam.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this.numNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Location = new System.Drawing.Point(300, 14);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(230, 34);
            this.btnTinhLuong.TabIndex = 4;
            this.btnTinhLuong.Text = "Tính / lập lại bảng lương";
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(540, 14);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(160, 34);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem bảng lương";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // lblCongThuc
            // 
            this.lblCongThuc.AutoSize = true;
            this.lblCongThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblCongThuc.Location = new System.Drawing.Point(20, 58);
            this.lblCongThuc.Name = "lblCongThuc";
            this.lblCongThuc.Size = new System.Drawing.Size(1100, 20);
            this.lblCongThuc.TabIndex = 6;
            this.lblCongThuc.Text = "Thực lĩnh = LCB/26 x Ngày công + PC chức vụ + PC lương + PC độc hại + LCB/26/8 x 1.5 x Giờ phụ trội + Thưởng - Phạt - BHXH - BHYT";
            // 
            // dgvBangLuong
            // 
            this.dgvBangLuong.Location = new System.Drawing.Point(20, 88);
            this.dgvBangLuong.Name = "dgvBangLuong";
            this.dgvBangLuong.AllowUserToAddRows = false;
            this.dgvBangLuong.AllowUserToDeleteRows = false;
            this.dgvBangLuong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBangLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangLuong.MultiSelect = false;
            this.dgvBangLuong.ReadOnly = true;
            this.dgvBangLuong.RowHeadersWidth = 30;
            this.dgvBangLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangLuong.Size = new System.Drawing.Size(1110, 500);
            this.dgvBangLuong.TabIndex = 7;
            // 
            // lblTongNV
            // 
            this.lblTongNV.AutoSize = true;
            this.lblTongNV.Location = new System.Drawing.Point(20, 600);
            this.lblTongNV.Name = "lblTongNV";
            this.lblTongNV.Size = new System.Drawing.Size(250, 20);
            this.lblTongNV.TabIndex = 8;
            this.lblTongNV.Text = "Số nhân viên: 6";
            // 
            // lblTongThucLinh
            // 
            this.lblTongThucLinh.AutoSize = true;
            this.lblTongThucLinh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongThucLinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTongThucLinh.Location = new System.Drawing.Point(300, 600);
            this.lblTongThucLinh.Name = "lblTongThucLinh";
            this.lblTongThucLinh.Size = new System.Drawing.Size(500, 22);
            this.lblTongThucLinh.TabIndex = 9;
            this.lblTongThucLinh.Text = "Tổng thực lĩnh: 89,771,500 đ";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1030, 632);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 34);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmBangLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 680);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblTongThucLinh);
            this.Controls.Add(this.lblTongNV);
            this.Controls.Add(this.dgvBangLuong);
            this.Controls.Add(this.lblCongThuc);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.numThang);
            this.Controls.Add(this.lblThang);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBangLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bảng lương hằng tháng";
            this.Load += new System.EventHandler(this.FrmBangLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label lblCongThuc;
        private System.Windows.Forms.DataGridView dgvBangLuong;
        private System.Windows.Forms.Label lblTongNV;
        private System.Windows.Forms.Label lblTongThucLinh;
        private System.Windows.Forms.Button btnDong;
    }
}
