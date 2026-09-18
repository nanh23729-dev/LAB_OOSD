using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public class FrmDanhMuc : Form
    {
        private readonly DanhMucService service = new DanhMucService();

        private TabControl tabs;
        private TabPage tabNV, tabTL, tabNXB;

        private TextBox txtNVMa, txtNVHo, txtNVTen, txtNVChucVu, txtNVSDT;
        private ComboBox cboNVPhai;
        private DateTimePicker dtNVNgaySinh;
        private Button btnNVThem, btnNVCapNhat, btnNVXoa;
        private DataGridView dgvNV;

        private TextBox txtTLMa, txtTLTen;
        private Button btnTLThem, btnTLCapNhat, btnTLXoa;
        private DataGridView dgvTL;

        private TextBox txtNXBMa, txtNXBDiaChi, txtNXBSDT;
        private Button btnNXBThem, btnNXBCapNhat, btnNXBXoa;
        private DataGridView dgvNXB;

        public FrmDanhMuc()
        {
            InitializeComponent();
            this.Load += FrmDanhMuc_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Danh mục và nhân viên";
            this.ClientSize = new Size(1060, 720);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            tabs = new TabControl { Location = new Point(10, 10), Size = new Size(1030, 650) };
            tabNV = new TabPage("Nhân viên");
            tabTL = new TabPage("Thể loại");
            tabNXB = new TabPage("Nhà xuất bản");
            tabs.TabPages.Add(tabNV);
            tabs.TabPages.Add(tabTL);
            tabs.TabPages.Add(tabNXB);

            BuildTabNhanVien();
            BuildTabTheLoai();
            BuildTabNXB();

            Button btnDong = new Button { Text = "Đóng", Location = new Point(920, 670), Size = new Size(100, 35) };
            btnDong.Click += (s, e) => Close();

            this.Controls.Add(tabs);
            this.Controls.Add(btnDong);
        }

        private void BuildTabNhanVien()
        {
            var l1 = new Label { Text = "Mã nhân viên:", Location = new Point(20, 20), Size = new Size(120, 25) };
            txtNVMa = new TextBox { Location = new Point(150, 20), Size = new Size(150, 25) };
            var l2 = new Label { Text = "Họ:", Location = new Point(20, 55), Size = new Size(120, 25) };
            txtNVHo = new TextBox { Location = new Point(150, 55), Size = new Size(150, 25) };
            var l3 = new Label { Text = "Tên:", Location = new Point(20, 90), Size = new Size(120, 25) };
            txtNVTen = new TextBox { Location = new Point(150, 90), Size = new Size(150, 25) };

            var l4 = new Label { Text = "Phái:", Location = new Point(330, 20), Size = new Size(80, 25) };
            cboNVPhai = new ComboBox { Location = new Point(420, 20), Size = new Size(120, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            var l5 = new Label { Text = "Ngày sinh:", Location = new Point(330, 55), Size = new Size(80, 25) };
            dtNVNgaySinh = new DateTimePicker { Location = new Point(420, 55), Size = new Size(120, 25), Format = DateTimePickerFormat.Short };
            var l6 = new Label { Text = "Chức vụ:", Location = new Point(330, 90), Size = new Size(80, 25) };
            txtNVChucVu = new TextBox { Location = new Point(420, 90), Size = new Size(150, 25) };
            var l7 = new Label { Text = "Điện thoại:", Location = new Point(330, 125), Size = new Size(100, 25) };
            txtNVSDT = new TextBox { Location = new Point(440, 125), Size = new Size(150, 25) };

            btnNVThem = new Button { Text = "Thêm", Location = new Point(620, 20), Size = new Size(100, 30) };
            btnNVCapNhat = new Button { Text = "Cập nhật", Location = new Point(730, 20), Size = new Size(100, 30), Enabled = false };
            btnNVXoa = new Button { Text = "Xóa", Location = new Point(620, 60), Size = new Size(100, 30), Enabled = false };
            var btnNVMoi = new Button { Text = "Làm mới", Location = new Point(730, 60), Size = new Size(100, 30) };

            btnNVThem.Click += (s, e) => ShowResult(service.LuuNhanVien(LayNV(), false));
            btnNVCapNhat.Click += (s, e) => ShowResult(service.LuuNhanVien(LayNV(), true));
            btnNVXoa.Click += (s, e) => { if (XacNhanXoa()) ShowResult(service.Xoa("NhanVien", "MaNhanVien", txtNVMa.Text.Trim())); };
            btnNVMoi.Click += (s, e) => LamMoiNV();

            dgvNV = new DataGridView
            {
                Location = new Point(20, 170), Size = new Size(970, 460), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvNV.SelectionChanged += (s, e) =>
            {
                if (dgvNV.CurrentRow?.DataBoundItem is not DataRowView r) return;
                txtNVMa.Text = Convert.ToString(r["MaNhanVien"]);
                txtNVHo.Text = Convert.ToString(r["Ho"]);
                txtNVTen.Text = Convert.ToString(r["Ten"]);
                cboNVPhai.SelectedItem = Convert.ToString(r["Phai"]);
                dtNVNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
                txtNVChucVu.Text = Convert.ToString(r["ChucVu"]);
                txtNVSDT.Text = Convert.ToString(r["SoDienThoai"]);
                txtNVMa.ReadOnly = true; btnNVThem.Enabled = false; btnNVCapNhat.Enabled = true; btnNVXoa.Enabled = true;
            };

            tabNV.Controls.AddRange(new Control[] { l1, txtNVMa, l2, txtNVHo, l3, txtNVTen, l4, cboNVPhai, l5, dtNVNgaySinh, l6, txtNVChucVu, l7, txtNVSDT, btnNVThem, btnNVCapNhat, btnNVXoa, btnNVMoi, dgvNV });
        }

        private void BuildTabTheLoai()
        {
            var l1 = new Label { Text = "Mã thể loại:", Location = new Point(20, 20), Size = new Size(100, 25) };
            txtTLMa = new TextBox { Location = new Point(130, 20), Size = new Size(150, 25) };
            var l2 = new Label { Text = "Tên thể loại:", Location = new Point(20, 55), Size = new Size(100, 25) };
            txtTLTen = new TextBox { Location = new Point(130, 55), Size = new Size(250, 25) };

            btnTLThem = new Button { Text = "Thêm", Location = new Point(420, 20), Size = new Size(100, 30) };
            btnTLCapNhat = new Button { Text = "Cập nhật", Location = new Point(530, 20), Size = new Size(100, 30), Enabled = false };
            btnTLXoa = new Button { Text = "Xóa", Location = new Point(420, 55), Size = new Size(100, 30), Enabled = false };
            var btnTLMoi = new Button { Text = "Làm mới", Location = new Point(530, 55), Size = new Size(100, 30) };

            btnTLThem.Click += (s, e) => ShowResult(service.LuuTheLoai(txtTLMa.Text, txtTLTen.Text, false));
            btnTLCapNhat.Click += (s, e) => ShowResult(service.LuuTheLoai(txtTLMa.Text, txtTLTen.Text, true));
            btnTLXoa.Click += (s, e) => { if (XacNhanXoa()) ShowResult(service.Xoa("TheLoai", "MaTheLoai", txtTLMa.Text.Trim())); };
            btnTLMoi.Click += (s, e) => LamMoiTL();

            dgvTL = new DataGridView
            {
                Location = new Point(20, 110), Size = new Size(970, 520), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvTL.SelectionChanged += (s, e) =>
            {
                if (dgvTL.CurrentRow?.DataBoundItem is not DataRowView r) return;
                txtTLMa.Text = Convert.ToString(r["MaTheLoai"]);
                txtTLTen.Text = Convert.ToString(r["TenTheLoai"]);
                txtTLMa.ReadOnly = true; btnTLThem.Enabled = false; btnTLCapNhat.Enabled = true; btnTLXoa.Enabled = true;
            };

            tabTL.Controls.AddRange(new Control[] { l1, txtTLMa, l2, txtTLTen, btnTLThem, btnTLCapNhat, btnTLXoa, btnTLMoi, dgvTL });
        }

        private void BuildTabNXB()
        {
            var l1 = new Label { Text = "Mã NXB:", Location = new Point(20, 20), Size = new Size(100, 25) };
            txtNXBMa = new TextBox { Location = new Point(130, 20), Size = new Size(150, 25) };
            var l2 = new Label { Text = "Địa chỉ:", Location = new Point(20, 55), Size = new Size(100, 25) };
            txtNXBDiaChi = new TextBox { Location = new Point(130, 55), Size = new Size(300, 25) };
            var l3 = new Label { Text = "Điện thoại:", Location = new Point(20, 90), Size = new Size(100, 25) };
            txtNXBSDT = new TextBox { Location = new Point(130, 90), Size = new Size(150, 25) };

            btnNXBThem = new Button { Text = "Thêm", Location = new Point(470, 20), Size = new Size(100, 30) };
            btnNXBCapNhat = new Button { Text = "Cập nhật", Location = new Point(580, 20), Size = new Size(100, 30), Enabled = false };
            btnNXBXoa = new Button { Text = "Xóa", Location = new Point(470, 55), Size = new Size(100, 30), Enabled = false };
            var btnNXBMoi = new Button { Text = "Làm mới", Location = new Point(580, 55), Size = new Size(100, 30) };

            btnNXBThem.Click += (s, e) => ShowResult(service.LuuNhaXuatBan(txtNXBMa.Text, txtNXBDiaChi.Text, txtNXBSDT.Text, false));
            btnNXBCapNhat.Click += (s, e) => ShowResult(service.LuuNhaXuatBan(txtNXBMa.Text, txtNXBDiaChi.Text, txtNXBSDT.Text, true));
            btnNXBXoa.Click += (s, e) => { if (XacNhanXoa()) ShowResult(service.Xoa("NhaXuatBan", "MaNhaXuatBan", txtNXBMa.Text.Trim())); };
            btnNXBMoi.Click += (s, e) => LamMoiNXB();

            dgvNXB = new DataGridView
            {
                Location = new Point(20, 140), Size = new Size(970, 490), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvNXB.SelectionChanged += (s, e) =>
            {
                if (dgvNXB.CurrentRow?.DataBoundItem is not DataRowView r) return;
                txtNXBMa.Text = Convert.ToString(r["MaNhaXuatBan"]);
                txtNXBDiaChi.Text = Convert.ToString(r["DiaChi"]);
                txtNXBSDT.Text = Convert.ToString(r["SoDienThoai"]);
                txtNXBMa.ReadOnly = true; btnNXBThem.Enabled = false; btnNXBCapNhat.Enabled = true; btnNXBXoa.Enabled = true;
            };

            tabNXB.Controls.AddRange(new Control[] { l1, txtNXBMa, l2, txtNXBDiaChi, l3, txtNXBSDT, btnNXBThem, btnNXBCapNhat, btnNXBXoa, btnNXBMoi, dgvNXB });
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            cboNVPhai.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboNVPhai.SelectedIndex = 0;
            TaiTatCa();
            LamMoiNV();
            LamMoiTL();
            LamMoiNXB();
        }

        private void TaiTatCa()
        {
            dgvNV.DataSource = service.LayNhanVien();
            dgvTL.DataSource = service.LayTheLoai();
            dgvNXB.DataSource = service.LayNhaXuatBan();
        }

        private NhanVien LayNV()
        {
            return new NhanVien
            {
                MaNhanVien = txtNVMa.Text.Trim(),
                Ho = txtNVHo.Text.Trim(),
                Ten = txtNVTen.Text.Trim(),
                Phai = Convert.ToString(cboNVPhai.SelectedItem),
                NgaySinh = dtNVNgaySinh.Value,
                ChucVu = txtNVChucVu.Text.Trim(),
                SoDienThoai = txtNVSDT.Text.Trim()
            };
        }

        private void ShowResult(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.ThanhCong) TaiTatCa();
        }

        private void LamMoiNV()
        {
            txtNVMa.Clear(); txtNVHo.Clear(); txtNVTen.Clear(); txtNVChucVu.Clear(); txtNVSDT.Clear();
            dtNVNgaySinh.Value = DateTime.Today.AddYears(-25);
            txtNVMa.ReadOnly = false; btnNVThem.Enabled = true; btnNVCapNhat.Enabled = false; btnNVXoa.Enabled = false;
        }

        private void LamMoiTL()
        {
            txtTLMa.Clear(); txtTLTen.Clear();
            txtTLMa.ReadOnly = false; btnTLThem.Enabled = true; btnTLCapNhat.Enabled = false; btnTLXoa.Enabled = false;
        }

        private void LamMoiNXB()
        {
            txtNXBMa.Clear(); txtNXBDiaChi.Clear(); txtNXBSDT.Clear();
            txtNXBMa.ReadOnly = false; btnNXBThem.Enabled = true; btnNXBCapNhat.Enabled = false; btnNXBXoa.Enabled = false;
        }

        private bool XacNhanXoa()
        {
            return MessageBox.Show("Xóa dữ liệu đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}