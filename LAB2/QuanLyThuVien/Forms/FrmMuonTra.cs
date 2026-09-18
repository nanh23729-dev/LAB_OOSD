using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public class FrmMuonTra : Form
    {
        private readonly MuonTraService service = new MuonTraService();
        private readonly SachService sachService = new SachService();
        private readonly DocGiaService docGiaService = new DocGiaService();
        private readonly DanhMucService danhMuc = new DanhMucService();
        private DataTable selectedBooks;

        private ComboBox cboDocGia, cboNhanVienMuon;
        private Label lblTrangThai;
        private DateTimePicker dtNgayMuon, dtHenTra;
        private DataGridView dgvSachCon, dgvSachChon;

        private ComboBox cboDocGiaTra, cboNhanVienTra, cboTinhTrang;
        private DataGridView dgvDangMuon;
        private DateTimePicker dtNgayTra;
        private NumericUpDown numPhiPhat;

        public FrmMuonTra()
        {
            InitializeComponent();
            this.Load += FrmMuonTra_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Mượn - Trả sách";
            this.ClientSize = new Size(1210, 765);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 9.5f);

            var tabs = new TabControl { Location = new Point(10, 10), Size = new Size(1180, 690) };
            var tabMuon = new TabPage("Mượn sách");
            var tabTra = new TabPage("Trả sách");
            tabs.TabPages.Add(tabMuon);
            tabs.TabPages.Add(tabTra);

            BuildTabMuon(tabMuon);
            BuildTabTra(tabTra);

            var btnDong = new Button { Text = "Đóng", Location = new Point(1080, 715), Size = new Size(100, 35) };
            btnDong.Click += (s, e) => Close();

            this.Controls.Add(tabs);
            this.Controls.Add(btnDong);
        }

        private void BuildTabMuon(TabPage tabMuon)
        {
            var l1 = new Label { Text = "Độc giả:", Location = new Point(20, 20), Size = new Size(80, 25) };
            cboDocGia = new ComboBox { Location = new Point(110, 20), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            var btnKiemTra = new Button { Text = "Kiểm tra điều kiện", Location = new Point(340, 20), Size = new Size(150, 25) };
            lblTrangThai = new Label { Location = new Point(500, 20), Size = new Size(650, 25) };
            btnKiemTra.Click += (s, e) =>
            {
                KetQuaXuLy kq = service.KiemTraDieuKienMuon(MaDocGiaMuon, Math.Max(1, selectedBooks.Rows.Count));
                lblTrangThai.Text = kq.ThongBao;
                lblTrangThai.ForeColor = kq.ThanhCong ? Color.DarkGreen : Color.DarkRed;
            };

            var l2 = new Label { Text = "Nhân viên lập phiếu:", Location = new Point(20, 55), Size = new Size(140, 25) };
            cboNhanVienMuon = new ComboBox { Location = new Point(160, 55), Size = new Size(120, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            var l3 = new Label { Text = "Ngày mượn:", Location = new Point(310, 55), Size = new Size(90, 25) };
            dtNgayMuon = new DateTimePicker { Location = new Point(400, 55), Size = new Size(130, 25), Format = DateTimePickerFormat.Short };
            var l4 = new Label { Text = "Hẹn trả:", Location = new Point(550, 55), Size = new Size(70, 25) };
            dtHenTra = new DateTimePicker { Location = new Point(620, 55), Size = new Size(130, 25), Format = DateTimePickerFormat.Short };

            var l5 = new Label { Text = "Sách còn trong kho:", Location = new Point(20, 95), Size = new Size(200, 25) };
            dgvSachCon = new DataGridView
            {
                Location = new Point(20, 120), Size = new Size(480, 460), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var btnThemSach = new Button { Text = "Thêm >>", Location = new Point(520, 250), Size = new Size(100, 30) };
            var btnBoSach = new Button { Text = "<< Bỏ", Location = new Point(520, 290), Size = new Size(100, 30) };
            btnThemSach.Click += (s, e) =>
            {
                if (dgvSachCon.CurrentRow?.DataBoundItem is not DataRowView r) return;
                if (selectedBooks.Rows.Count >= 3) { MessageBox.Show("Chỉ được chọn tối đa 3 đầu sách khác nhau."); return; }
                string ma = Convert.ToString(r["MaDauSach"]);
                foreach (DataRow row in selectedBooks.Rows)
                    if (string.Equals(Convert.ToString(row["MaDauSach"]), ma, StringComparison.OrdinalIgnoreCase))
                    { MessageBox.Show("Đầu sách này đã có trong danh sách mượn."); return; }
                selectedBooks.Rows.Add(ma, Convert.ToString(r["TenSach"]));
            };
            btnBoSach.Click += (s, e) => { if (dgvSachChon.CurrentRow?.DataBoundItem is DataRowView r) r.Row.Delete(); };

            var l6 = new Label { Text = "Sách đã chọn (tối đa 3):", Location = new Point(640, 95), Size = new Size(220, 25) };
            dgvSachChon = new DataGridView
            {
                Location = new Point(640, 120), Size = new Size(500, 200), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var btnLapPhieu = new Button { Text = "Lập phiếu mượn", Location = new Point(1000, 340), Size = new Size(140, 35) };
            btnLapPhieu.Click += (s, e) =>
            {
                List<string> ds = new List<string>();
                foreach (DataRow r in selectedBooks.Rows)
                    if (r.RowState != DataRowState.Deleted) ds.Add(Convert.ToString(r["MaDauSach"]));

                KetQuaXuLy kq = service.LapPhieuMuon(MaDocGiaMuon, MaNhanVienMuon, ds, dtNgayMuon.Value, dtHenTra.Value);
                MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                    kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (kq.ThanhCong)
                {
                    selectedBooks.Rows.Clear();
                    TaiSachCon();
                    TaiSachDangMuon();
                    lblTrangThai.Text = "";
                }
            };

            tabMuon.Controls.AddRange(new Control[] {
                l1, cboDocGia, btnKiemTra, lblTrangThai,
                l2, cboNhanVienMuon, l3, dtNgayMuon, l4, dtHenTra,
                l5, dgvSachCon, btnThemSach, btnBoSach,
                l6, dgvSachChon, btnLapPhieu
            });
        }

        private void BuildTabTra(TabPage tabTra)
        {
            var l1 = new Label { Text = "Độc giả:", Location = new Point(20, 20), Size = new Size(80, 25) };
            cboDocGiaTra = new ComboBox { Location = new Point(110, 20), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            var btnTaiSachMuon = new Button { Text = "Tải sách đang mượn", Location = new Point(340, 20), Size = new Size(160, 25) };
            btnTaiSachMuon.Click += (s, e) => TaiSachDangMuon();
            cboDocGiaTra.SelectedIndexChanged += (s, e) => TaiSachDangMuon();

            var l2 = new Label { Text = "Nhân viên nhận trả:", Location = new Point(20, 55), Size = new Size(140, 25) };
            cboNhanVienTra = new ComboBox { Location = new Point(160, 55), Size = new Size(120, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            var l3 = new Label { Text = "Sách chưa trả:", Location = new Point(20, 95), Size = new Size(200, 25) };
            dgvDangMuon = new DataGridView
            {
                Location = new Point(20, 120), Size = new Size(1120, 380), ReadOnly = true,
                AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var l4 = new Label { Text = "Ngày trả:", Location = new Point(20, 515), Size = new Size(80, 25) };
            dtNgayTra = new DateTimePicker { Location = new Point(110, 515), Size = new Size(130, 25), Format = DateTimePickerFormat.Short };
            var l5 = new Label { Text = "Tình trạng:", Location = new Point(260, 515), Size = new Size(80, 25) };
            cboTinhTrang = new ComboBox { Location = new Point(350, 515), Size = new Size(160, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            var l6 = new Label { Text = "Phí phạt:", Location = new Point(530, 515), Size = new Size(80, 25) };
            numPhiPhat = new NumericUpDown { Location = new Point(620, 515), Size = new Size(120, 25), Maximum = 1000000000 };

            var btnTraSach = new Button { Text = "Xác nhận trả sách", Location = new Point(770, 512), Size = new Size(150, 30) };
            btnTraSach.Click += (s, e) =>
            {
                if (dgvDangMuon.CurrentRow?.DataBoundItem is not DataRowView r) { MessageBox.Show("Vui lòng chọn sách cần trả."); return; }
                string maCT = Convert.ToString(r["MaChiTiet"]);
                KetQuaXuLy kq = service.TraSach(maCT, MaNhanVienTra, dtNgayTra.Value, Convert.ToString(cboTinhTrang.SelectedItem), numPhiPhat.Value);
                MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                    kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (kq.ThanhCong)
                {
                    TaiSachDangMuon(); TaiSachCon();
                    numPhiPhat.Value = 0; cboTinhTrang.SelectedIndex = 0;
                }
            };

            tabTra.Controls.AddRange(new Control[] {
                l1, cboDocGiaTra, btnTaiSachMuon,
                l2, cboNhanVienTra,
                l3, dgvDangMuon,
                l4, dtNgayTra, l5, cboTinhTrang, l6, numPhiPhat, btnTraSach
            });
        }

        private void FrmMuonTra_Load(object sender, EventArgs e)
        {
            DataTable readers = docGiaService.LayComboDocGia();
            cboDocGia.DataSource = readers.Copy(); cboDocGia.DisplayMember = "HoTen"; cboDocGia.ValueMember = "MaDocGia";
            cboDocGiaTra.DataSource = readers.Copy(); cboDocGiaTra.DisplayMember = "HoTen"; cboDocGiaTra.ValueMember = "MaDocGia";

            DataTable staff = danhMuc.LayNhanVien();
            cboNhanVienMuon.DataSource = staff.Copy(); cboNhanVienMuon.DisplayMember = "MaNhanVien"; cboNhanVienMuon.ValueMember = "MaNhanVien";
            cboNhanVienTra.DataSource = staff.Copy(); cboNhanVienTra.DisplayMember = "MaNhanVien"; cboNhanVienTra.ValueMember = "MaNhanVien";

            cboTinhTrang.Items.AddRange(new object[] { "Bình thường", "Rách/Hư hỏng", "Mất" });
            cboTinhTrang.SelectedIndex = 0;

            dtNgayMuon.Value = DateTime.Today;
            dtHenTra.Value = DateTime.Today.AddDays(7);
            dtNgayTra.Value = DateTime.Today;

            selectedBooks = new DataTable();
            selectedBooks.Columns.Add("MaDauSach", typeof(string));
            selectedBooks.Columns.Add("TenSach", typeof(string));
            dgvSachChon.DataSource = selectedBooks;

            TaiSachCon();
        }

        private string MaDocGiaMuon => cboDocGia.SelectedValue?.ToString() ?? "";
        private string MaDocGiaTra => cboDocGiaTra.SelectedValue?.ToString() ?? "";
        private string MaNhanVienMuon => cboNhanVienMuon.SelectedValue?.ToString() ?? "";
        private string MaNhanVienTra => cboNhanVienTra.SelectedValue?.ToString() ?? "";

        private void TaiSachCon() => dgvSachCon.DataSource = sachService.LaySachConTrongKho();

        private void TaiSachDangMuon()
        {
            if (string.IsNullOrWhiteSpace(MaDocGiaTra)) return;
            dgvDangMuon.DataSource = service.LaySachDangMuon(MaDocGiaTra);
        }
    }
}