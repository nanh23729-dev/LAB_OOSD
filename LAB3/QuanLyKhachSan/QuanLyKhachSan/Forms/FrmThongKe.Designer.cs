namespace QuanLyKhachSan.Forms
{
    partial class FrmThongKe
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
            this.dtTuLbl = new System.Windows.Forms.Label();
            this.dtTuLbl.Location = new System.Drawing.Point(15, 15);
            this.dtTuLbl.Name = "dtTuLbl";
            this.dtTuLbl.Size = new System.Drawing.Size(150, 20);
            this.dtTuLbl.Text = "Từ ngày";
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.dtTu.Location = new System.Drawing.Point(175, 15);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(505, 23);
            this.dtDenLbl = new System.Windows.Forms.Label();
            this.dtDenLbl.Location = new System.Drawing.Point(15, 47);
            this.dtDenLbl.Name = "dtDenLbl";
            this.dtDenLbl.Size = new System.Drawing.Size(150, 20);
            this.dtDenLbl.Text = "Đến ngày";
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.dtDen.Location = new System.Drawing.Point(175, 47);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(505, 23);
            this.btnTK = new System.Windows.Forms.Button();
            this.btnTK.Location = new System.Drawing.Point(15, 79);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(220, 32);
            this.btnTK.Text = "Thống kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).BeginInit();
            this.dgvTongHop.Location = new System.Drawing.Point(15, 119);
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.Size = new System.Drawing.Size(700, 140);
            this.dgvTongHop.AllowUserToAddRows = false;
            this.dgvTongHop.ReadOnly = true;
            this.dgvTongHop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).EndInit();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.dgvDV.Location = new System.Drawing.Point(15, 274);
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.Size = new System.Drawing.Size(700, 200);
            this.dgvDV.AllowUserToAddRows = false;
            this.dgvDV.ReadOnly = true;
            this.dgvDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnDong.Location = new System.Drawing.Point(620, 490);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.Controls.Add(this.dtTuLbl);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.dtDenLbl);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.dgvTongHop);
            this.Controls.Add(this.dgvDV);
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 560);
            this.Name = "FrmThongKe";
            this.Text = "Thống kê";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label dtTuLbl;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label dtDenLbl;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.DataGridView dgvTongHop;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.Button btnDong;
    }
}