using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public class FrmThongKe : Form
    {
        private readonly ThongKeService service = new ThongKeService();

        private DateTimePicker dtTu, dtDen;
        private Label lblMuon, lblQuaHan, lblMat, lblHuHong, lblPhiPhat;
        private DataGridView dgvPhat;

        public FrmThongKe()
        {
            InitializeComponent();
            this.Load += FrmThongKe_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Thống kê";
            this.ClientSize = new Size(1070, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            var l1 = new Label { Text = "Từ ngày:", Location = new Point(20, 20), Size = new Size(70, 25) };
            dtTu = new DateTimePicker { Location = new Point(100, 20), Size = new Size(130, 25), Format = DateTimePickerFormat.Short };
            var l2 = new Label { Text = "Đến ngày:", Location = new Point(250, 20), Size = new Size(80, 25) };
            dtDen = new DateTimePicker { Location = new Point(340, 20), Size = new Size(130, 25), Format = DateTimePickerFormat.Short };
            var btnThongKe = new Button { Text = "Thống kê", Location = new Point(490, 20), Size = new Size(110, 28) };
            btnThongKe.Click += (s, e) => TaiDuLieu();

            lblMuon = new Label { Location = new Point(20, 65), Size = new Size(300, 25) };
            lblQuaHan = new Label { Location = new Point(340, 65), Size = new Size(300, 25) };
            lblMat = new Label { Location = new Point(20, 95), Size = new Size(300, 25) };
            lblHuHong = new Label { Location = new Point(340, 95), Size = new Size(300, 25) };
            lblPhiPhat = new Label { Location = new Point(20, 130), Size = new Size(400, 30), Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            var l3 = new Label { Text = "Chi tiết phiếu phạt:", Location = new Point(20, 175), Size = new Size(200, 25) };
            dgvPhat = new DataGridView
            {
                Location = new Point(20, 200), Size = new Size(1020, 460), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var btnDong = new Button { Text = "Đóng", Location = new Point(940, 670), Size = new Size(100, 35) };
            btnDong.Click += (s, e) => Close();

            this.Controls.AddRange(new Control[] {
                l1, dtTu, l2, dtDen, btnThongKe,
                lblMuon, lblQuaHan, lblMat, lblHuHong, lblPhiPhat,
                l3, dgvPhat, btnDong
            });
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            dtTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtDen.Value = DateTime.Today;
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            ThongKeTongHop t = service.LayTongHop(dtTu.Value, dtDen.Value);
            lblMuon.Text = "Lượt sách mượn: " + t.LuotSachMuon;
            lblQuaHan.Text = "Sách quá hạn: " + t.SachQuaHan;
            lblMat.Text = "Sách mất: " + t.SachMat;
            lblHuHong.Text = "Sách hư hỏng: " + t.SachHuHong;
            lblPhiPhat.Text = "Tổng phí phạt: " + t.TongPhiPhat.ToString("N0") + " đ";
            dgvPhat.DataSource = service.LayChiTietPhat(dtTu.Value, dtDen.Value);
        }
    }
}