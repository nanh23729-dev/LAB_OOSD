using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public class FrmDocGia : Form
    {
        private readonly DocGiaService service = new DocGiaService();

        private TextBox txtMa, txtHo, txtTen, txtSDT, txtDiaChi, txtEmail, txtAnh;
        private DateTimePicker dtNgaySinh, dtNgayCap, dtHan;
        private ComboBox cboPhai;
        private CheckBox chkLePhi;
        private Button btnThem, btnCapNhat;
        private DataGridView dgvDocGia;

        public FrmDocGia()
        {
            InitializeComponent();
            this.Load += FrmDocGia_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Độc giả và thẻ";
            this.ClientSize = new Size(1190, 790);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            var l1 = new Label { Text = "Mã độc giả:", Location = new Point(20, 20), Size = new Size(100, 25) };
            txtMa = new TextBox { Location = new Point(130, 20), Size = new Size(150, 25) };
            var l2 = new Label { Text = "Họ:", Location = new Point(20, 55), Size = new Size(100, 25) };
            txtHo = new TextBox { Location = new Point(130, 55), Size = new Size(150, 25) };
            var l3 = new Label { Text = "Tên:", Location = new Point(20, 90), Size = new Size(100, 25) };
            txtTen = new TextBox { Location = new Point(130, 90), Size = new Size(150, 25) };
            var l4 = new Label { Text = "Ngày sinh:", Location = new Point(20, 125), Size = new Size(100, 25) };
            dtNgaySinh = new DateTimePicker { Location = new Point(130, 125), Size = new Size(150, 25), Format = DateTimePickerFormat.Short };
            var l5 = new Label { Text = "Phái:", Location = new Point(20, 160), Size = new Size(100, 25) };
            cboPhai = new ComboBox { Location = new Point(130, 160), Size = new Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            var l6 = new Label { Text = "Điện thoại:", Location = new Point(330, 20), Size = new Size(90, 25) };
            txtSDT = new TextBox { Location = new Point(430, 20), Size = new Size(180, 25) };
            var l7 = new Label { Text = "Địa chỉ:", Location = new Point(330, 55), Size = new Size(90, 25) };
            txtDiaChi = new TextBox { Location = new Point(430, 55), Size = new Size(300, 25) };
            var l8 = new Label { Text = "Email:", Location = new Point(330, 90), Size = new Size(90, 25) };
            txtEmail = new TextBox { Location = new Point(430, 90), Size = new Size(300, 25) };
            var l9 = new Label { Text = "Ảnh 3x4:", Location = new Point(330, 125), Size = new Size(90, 25) };
            txtAnh = new TextBox { Location = new Point(430, 125), Size = new Size(300, 25) };

            var l10 = new Label { Text = "Ngày cấp:", Location = new Point(330, 160), Size = new Size(90, 25) };
            dtNgayCap = new DateTimePicker { Location = new Point(430, 160), Size = new Size(150, 25), Format = DateTimePickerFormat.Short };
            var l11 = new Label { Text = "Hạn sử dụng:", Location = new Point(600, 160), Size = new Size(90, 25) };
            dtHan = new DateTimePicker { Location = new Point(700, 160), Size = new Size(150, 25), Format = DateTimePickerFormat.Short };
            chkLePhi = new CheckBox { Text = "Đã đóng lệ phí", Location = new Point(430, 195), Size = new Size(200, 25) };

            btnThem = new Button { Text = "Thêm", Location = new Point(870, 20), Size = new Size(120, 30) };
            btnCapNhat = new Button { Text = "Cập nhật", Location = new Point(1010, 20), Size = new Size(120, 30), Enabled = false };
            var btnCapThe = new Button { Text = "Cấp thẻ", Location = new Point(870, 60), Size = new Size(120, 30) };
            var btnGiaHan = new Button { Text = "Gia hạn", Location = new Point(1010, 60), Size = new Size(120, 30) };
            var btnLamMoi = new Button { Text = "Làm mới", Location = new Point(870, 100), Size = new Size(120, 30) };

            btnThem.Click += (s, e) => ShowResult(service.Luu(LayForm(), false));
            btnCapNhat.Click += (s, e) => ShowResult(service.Luu(LayForm(), true));
            btnCapThe.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMa.Text)) { MessageBox.Show("Vui lòng chọn độc giả."); return; }
                ShowResult(service.CapThe(txtMa.Text.Trim(), dtNgayCap.Value, dtHan.Value, chkLePhi.Checked));
            };
            btnGiaHan.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMa.Text)) { MessageBox.Show("Vui lòng chọn độc giả."); return; }
                ShowResult(service.GiaHanThe(txtMa.Text.Trim(), dtHan.Value, chkLePhi.Checked));
            };
            btnLamMoi.Click += (s, e) => LamMoi();

            dgvDocGia = new DataGridView
            {
                Location = new Point(20, 240), Size = new Size(1140, 480), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            };
            dgvDocGia.SelectionChanged += (s, e) =>
            {
                if (dgvDocGia.CurrentRow?.DataBoundItem is not DataRowView r) return;
                txtMa.Text = Convert.ToString(r["MaDocGia"]);
                txtHo.Text = Convert.ToString(r["Ho"]);
                txtTen.Text = Convert.ToString(r["Ten"]);
                if (r["NgaySinh"] != DBNull.Value) dtNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
                cboPhai.SelectedItem = Convert.ToString(r["Phai"]);
                txtSDT.Text = Convert.ToString(r["SoDienThoai"]);
                txtDiaChi.Text = Convert.ToString(r["DiaChi"]);
                txtEmail.Text = Convert.ToString(r["Email"]);
                txtAnh.Text = Convert.ToString(r["Anh3x4"]);
                if (r["NgayCap"] != DBNull.Value) dtNgayCap.Value = Convert.ToDateTime(r["NgayCap"]);
                if (r["HanSuDung"] != DBNull.Value) dtHan.Value = Convert.ToDateTime(r["HanSuDung"]);
                chkLePhi.Checked = r["DaDongLePhi"] != DBNull.Value && Convert.ToBoolean(r["DaDongLePhi"]);
                txtMa.ReadOnly = true; btnThem.Enabled = false; btnCapNhat.Enabled = true;
            };

            var btnDong = new Button { Text = "Đóng", Location = new Point(1060, 730), Size = new Size(100, 35) };
            btnDong.Click += (s, e) => Close();

            this.Controls.AddRange(new Control[] {
                l1, txtMa, l2, txtHo, l3, txtTen, l4, dtNgaySinh, l5, cboPhai,
                l6, txtSDT, l7, txtDiaChi, l8, txtEmail, l9, txtAnh,
                l10, dtNgayCap, l11, dtHan, chkLePhi,
                btnThem, btnCapNhat, btnCapThe, btnGiaHan, btnLamMoi,
                dgvDocGia, btnDong
            });
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            cboPhai.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboPhai.SelectedIndex = 0;
            dtNgayCap.Value = DateTime.Today;
            dtHan.Value = DateTime.Today.AddYears(1);
            TaiDuLieu();
            LamMoi();
        }

        private void TaiDuLieu() => dgvDocGia.DataSource = service.LayDanhSach();

        private DocGia LayForm()
        {
            return new DocGia
            {
                MaDocGia = txtMa.Text.Trim(),
                Ho = txtHo.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value.Date,
                Phai = Convert.ToString(cboPhai.SelectedItem),
                SoDienThoai = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Anh3x4 = txtAnh.Text.Trim()
            };
        }

        private void ShowResult(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.ThanhCong) { TaiDuLieu(); LamMoi(); }
        }

        private void LamMoi()
        {
            txtMa.Clear(); txtHo.Clear(); txtTen.Clear(); txtSDT.Clear(); txtDiaChi.Clear(); txtEmail.Clear(); txtAnh.Clear();
            dtNgaySinh.Value = DateTime.Today.AddYears(-18);
            dtNgayCap.Value = DateTime.Today;
            dtHan.Value = DateTime.Today.AddYears(1);
            chkLePhi.Checked = true;
            txtMa.ReadOnly = false; btnThem.Enabled = true; btnCapNhat.Enabled = false;
        }
    }
}