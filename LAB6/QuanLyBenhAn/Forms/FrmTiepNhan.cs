using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    /// <summary>Đăng ký khám lần đầu + đóng lệ phí năm + cấp hồ sơ; tra cứu hồ sơ; gia hạn lệ phí.</summary>
    public class FrmTiepNhan : Form
    {
        readonly TiepNhanService s = new TiepNhanService();
        readonly DanhMucService dm = new DanhMucService();
        byte[] anh;

        readonly TextBox txtTen = Ui.T(200), txtDiaChi = Ui.T(480), txtSdt = Ui.T(120), txtTim = Ui.T(220), txtHS = Ui.T(90);
        readonly DateTimePicker dtSinh = Ui.D();
        readonly ComboBox cboNV = Ui.C(180), cboNV2 = Ui.C(180);
        readonly NumericUpDown numPhi = Ui.N(0, 100000000, 200000, 0, 110), numNam = Ui.N(2000, 2100, DateTime.Now.Year, 0, 70), numPhi2 = Ui.N(0, 100000000, 200000, 0, 110);
        readonly PictureBox pic = new PictureBox { Width = 90, Height = 120, SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle };
        readonly Label lblKQ = new Label { AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.DarkGreen, Margin = new Padding(8) };
        readonly DataGridView dgvHS = Ui.G(), dgvLP = Ui.G();

        public FrmTiepNhan()
        {
            Ui.Setup(this, "Tiếp nhận - Hồ sơ bệnh án", 960, 600);
            dtSinh.Value = new DateTime(2000, 1, 1); dtSinh.MaxDate = DateTime.Today;
            var tc = new TabControl { Dock = DockStyle.Fill };
            tc.TabPages.Add(Ui.Page("Đăng ký khám lần đầu",
                Ui.Row(Ui.L("Họ tên:"), txtTen, Ui.L("Ngày sinh:"), dtSinh, Ui.L("Điện thoại:"), txtSdt),
                Ui.Row(Ui.L("Địa chỉ:"), txtDiaChi),
                Ui.Row(Ui.L("Ảnh 3x4:"), pic, Ui.B("Chọn ảnh...", ChonAnh, 100)),
                Ui.Row(Ui.L("Nhân viên:"), cboNV, Ui.L("Lệ phí năm:"), numPhi, Ui.B("Đăng ký && cấp hồ sơ", DangKy, 170)),
                lblKQ));
            tc.TabPages.Add(Ui.Page("Tra cứu / gia hạn lệ phí",
                Ui.Row(Ui.L("Mã hồ sơ / tên / SĐT:"), txtTim, Ui.B("Tìm", (o, e) => TimKiem(), 80)),
                dgvHS,
                Ui.Row(Ui.L("Hồ sơ:"), txtHS, Ui.L("Năm:"), numNam, Ui.L("Lệ phí:"), numPhi2, Ui.L("NV:"), cboNV2, Ui.B("Gia hạn lệ phí", GiaHan, 120)),
                dgvLP));
            txtHS.ReadOnly = true;
            Controls.Add(tc);
            dgvHS.SelectionChanged += (o, e) =>
            {
                txtHS.Text = Ui.Cell(dgvHS, "MaHoSo");
                dgvLP.DataSource = txtHS.Text == "" ? null : s.LayLePhi(txtHS.Text);
            };
            Load += (o, e) =>
            {
                Ui.Bind(cboNV, dm.LayNhanVien(), "HoTen", "MaNV");
                Ui.Bind(cboNV2, dm.LayNhanVien(), "HoTen", "MaNV");
                TimKiem();
            };
        }

        void ChonAnh(object o, EventArgs e)
        {
            using (var d = new OpenFileDialog { Filter = "Ảnh|*.jpg;*.jpeg;*.png" })
            {
                if (d.ShowDialog(this) != DialogResult.OK) return;
                var b = File.ReadAllBytes(d.FileName);
                if (b.Length > 2 * 1024 * 1024) { MessageBox.Show("Ảnh tối đa 2 MB."); return; }
                anh = b; pic.Image = Image.FromStream(new MemoryStream(b));
            }
        }

        void DangKy(object o, EventArgs e)
        {
            var k = s.DangKyMoi(txtTen.Text.Trim(), txtDiaChi.Text.Trim(), dtSinh.Value, txtSdt.Text.Trim(), anh, Ui.V(cboNV), numPhi.Value);
            Ui.Msg(k);
            if (!k.ThanhCong) return;
            lblKQ.Text = "Mã hồ sơ: " + k.Ma;
            txtTen.Clear(); txtDiaChi.Clear(); txtSdt.Clear(); anh = null; pic.Image = null;
            TimKiem();
        }

        void TimKiem() { dgvHS.DataSource = s.TraCuuHoSo(txtTim.Text); }

        void GiaHan(object o, EventArgs e)
        {
            var k = s.GiaHanLePhi(txtHS.Text, (int)numNam.Value, numPhi2.Value, Ui.V(cboNV2));
            Ui.Msg(k);
            if (k.ThanhCong) { dgvLP.DataSource = s.LayLePhi(txtHS.Text); TimKiem(); }
        }
    }
}
