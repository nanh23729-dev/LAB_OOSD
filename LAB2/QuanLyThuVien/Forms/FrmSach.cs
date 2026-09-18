using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public class FrmSach : Form
    {
        private readonly SachService service = new SachService();
        private readonly DanhMucService danhMuc = new DanhMucService();

        private TextBox txtMa, txtTen, txtTim;
        private NumericUpDown numNam, numSoLuong;
        private ComboBox cboTheLoai, cboNXB;
        private Button btnThem, btnCapNhat, btnXoa;
        private DataGridView dgvSach;

        public FrmSach()
        {
            InitializeComponent();
            this.Load += FrmSach_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Quản lý đầu sách";
            this.ClientSize = new Size(1120, 740);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            var l1 = new Label { Text = "Mã đầu sách:", Location = new Point(20, 20), Size = new Size(100, 25) };
            txtMa = new TextBox { Location = new Point(130, 20), Size = new Size(150, 25) };
            var l2 = new Label { Text = "Tên sách:", Location = new Point(20, 55), Size = new Size(100, 25) };
            txtTen = new TextBox { Location = new Point(130, 55), Size = new Size(300, 25) };
            var l3 = new Label { Text = "Năm xuất bản:", Location = new Point(20, 90), Size = new Size(100, 25) };
            numNam = new NumericUpDown { Location = new Point(130, 90), Size = new Size(100, 25), Minimum = 1000, Maximum = 3000, Value = DateTime.Today.Year };
            var l4 = new Label { Text = "Số lượng hiện có:", Location = new Point(20, 125), Size = new Size(100, 25) };
            numSoLuong = new NumericUpDown { Location = new Point(130, 125), Size = new Size(100, 25), Maximum = 100000 };

            var l5 = new Label { Text = "Thể loại:", Location = new Point(470, 20), Size = new Size(80, 25) };
            cboTheLoai = new ComboBox { Location = new Point(560, 20), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            var l6 = new Label { Text = "Nhà xuất bản:", Location = new Point(470, 55), Size = new Size(80, 25) };
            cboNXB = new ComboBox { Location = new Point(560, 55), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            var l7 = new Label { Text = "Tìm kiếm:", Location = new Point(470, 90), Size = new Size(80, 25) };
            txtTim = new TextBox { Location = new Point(560, 90), Size = new Size(200, 25) };
            var btnTim = new Button { Text = "Tìm", Location = new Point(770, 90), Size = new Size(80, 25) };
            btnTim.Click += (s, e) => TaiDuLieu();

            btnThem = new Button { Text = "Thêm", Location = new Point(890, 20), Size = new Size(100, 30) };
            btnCapNhat = new Button { Text = "Cập nhật", Location = new Point(1000, 20), Size = new Size(100, 30), Enabled = false };
            btnXoa = new Button { Text = "Xóa", Location = new Point(890, 60), Size = new Size(100, 30), Enabled = false };
            var btnLamMoi = new Button { Text = "Làm mới", Location = new Point(1000, 60), Size = new Size(100, 30) };

            btnThem.Click += (s, e) => HienKetQua(service.Luu(LayDuLieuForm(), false));
            btnCapNhat.Click += (s, e) => HienKetQua(service.Luu(LayDuLieuForm(), true));
            btnXoa.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMa.Text)) return;
                if (MessageBox.Show("Xóa đầu sách đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    HienKetQua(service.Xoa(txtMa.Text.Trim()));
            };
            btnLamMoi.Click += (s, e) => LamMoi();

            dgvSach = new DataGridView
            {
                Location = new Point(20, 170), Size = new Size(1080, 480), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvSach.SelectionChanged += (s, e) =>
            {
                if (dgvSach.CurrentRow?.DataBoundItem is not DataRowView r) return;
                txtMa.Text = Convert.ToString(r["MaDauSach"]);
                txtTen.Text = Convert.ToString(r["TenSach"]);
                numNam.Value = Convert.ToDecimal(r["NamXuatBan"]);
                numSoLuong.Value = Convert.ToDecimal(r["SoLuongHienCo"]);
                cboTheLoai.SelectedValue = Convert.ToString(r["MaTheLoai"]);
                cboNXB.SelectedValue = Convert.ToString(r["MaNhaXuatBan"]);
                txtMa.ReadOnly = true; btnThem.Enabled = false; btnCapNhat.Enabled = true; btnXoa.Enabled = true;
            };

            var btnDong = new Button { Text = "Đóng", Location = new Point(1000, 660), Size = new Size(100, 35) };
            btnDong.Click += (s, e) => Close();

            this.Controls.AddRange(new Control[] { l1, txtMa, l2, txtTen, l3, numNam, l4, numSoLuong, l5, cboTheLoai, l6, cboNXB, l7, txtTim, btnTim, btnThem, btnCapNhat, btnXoa, btnLamMoi, dgvSach, btnDong });
        }

        private void FrmSach_Load(object sender, EventArgs e)
        {
            cboTheLoai.DataSource = danhMuc.LayTheLoai();
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";

            cboNXB.DataSource = danhMuc.LayNhaXuatBan();
            cboNXB.DisplayMember = "MaNhaXuatBan";
            cboNXB.ValueMember = "MaNhaXuatBan";

            TaiDuLieu();
            LamMoi();
        }

        private void TaiDuLieu() => dgvSach.DataSource = service.LayDanhSach(txtTim.Text.Trim());

        private DauSach LayDuLieuForm()
        {
            return new DauSach
            {
                MaDauSach = txtMa.Text.Trim(),
                TenSach = txtTen.Text.Trim(),
                NamXuatBan = (int)numNam.Value,
                SoLuongHienCo = (int)numSoLuong.Value,
                MaTheLoai = cboTheLoai.SelectedValue?.ToString() ?? "",
                MaNhaXuatBan = cboNXB.SelectedValue?.ToString() ?? ""
            };
        }

        private void HienKetQua(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.ThanhCong) { TaiDuLieu(); LamMoi(); }
        }

        private void LamMoi()
        {
            txtMa.Clear(); txtTen.Clear(); numNam.Value = DateTime.Today.Year; numSoLuong.Value = 0;
            txtMa.ReadOnly = false; btnThem.Enabled = true; btnCapNhat.Enabled = false; btnXoa.Enabled = false;
        }
    }
}