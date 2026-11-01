using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyCaoOc.Services;

namespace QuanLyCaoOc.Forms
{
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienService service = new NhanVienService();
        private bool dangTai = true;

        public FrmNhanVien() { InitializeComponent(); }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboLoaiXe.Items.AddRange(new object[] { "Xe máy", "Ô tô", "Xe đạp" });
            cboLoaiXe.SelectedIndex = 0;
            dtNgaySinh.Value = new DateTime(1995, 1, 1);
            UiHelper.GanCombo(cboPhong, service.LayPhongDangThue(), "HienThi", "MaPhong");
            dangTai = false;
            TaiNhanVien();
            LamMoi();
        }

        private void TaiNhanVien()
        {
            UiHelper.HienLuoi(dgvNV, service.LayNhanVien(txtTim.Text.Trim()));
            TaiComboNhanVienThe();
        }

        // ===================== NHÂN VIÊN =====================
        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog(this) == DialogResult.OK) { txtHinh.Text = dlg.FileName; HienHinh(dlg.FileName); }
            }
        }

        private void HienHinh(string duongDan)
        {
            if (picHinh.Image != null) { picHinh.Image.Dispose(); picHinh.Image = null; }
            if (!string.IsNullOrEmpty(duongDan) && File.Exists(duongDan))
            {
                // đọc qua bộ nhớ để không khóa file ảnh
                using (Image img = Image.FromFile(duongDan)) picHinh.Image = new Bitmap(img);
            }
        }

        private void btnThem_Click(object sender, EventArgs e) { Luu(false); }
        private void btnCapNhat_Click(object sender, EventArgs e) { Luu(true); }

        private void Luu(bool capNhat)
        {
            KetQuaXuLy kq = service.LuuNhanVien(txtMa.Text, txtTen.Text, Convert.ToString(cboGioiTinh.SelectedItem), dtNgaySinh.Value,
                txtChucVu.Text, txtHinh.Text, UiHelper.LayMa(cboPhong), capNhat);
            if (UiHelper.HienKetQua(kq)) { TaiNhanVien(); if (!capNhat) LamMoi(); }
        }

        private void btnNghi_Click(object sender, EventArgs e)
        {
            if (!UiHelper.XacNhan("Cho nhân viên " + txtMa.Text + " nghỉ việc? Thẻ giữ xe đang dùng sẽ bị thu hồi.")) return;
            if (UiHelper.HienKetQua(service.ChoNghi(txtMa.Text))) { TaiNhanVien(); TaiThe(); }
        }

        private void btnMoi_Click(object sender, EventArgs e) { LamMoi(); }
        private void btnTim_Click(object sender, EventArgs e) { TaiNhanVien(); }

        private void dgvNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dangTai) return;
            DataRowView r = UiHelper.DongChon(dgvNV); if (r == null) return;
            txtMa.Text = Convert.ToString(r["MaNV"]);
            txtTen.Text = Convert.ToString(r["HoTen"]);
            cboGioiTinh.SelectedItem = Convert.ToString(r["GioiTinh"]);
            dtNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
            txtChucVu.Text = Convert.ToString(r["ChucVu"]);
            cboPhong.SelectedValue = Convert.ToString(r["MaPhong"]);
            txtHinh.Text = Convert.ToString(r["HinhAnh"]);
            HienHinh(txtHinh.Text);
            txtMa.ReadOnly = true; btnThem.Enabled = false; btnCapNhat.Enabled = true; btnNghi.Enabled = true;
        }

        private void LamMoi()
        {
            txtMa.Clear(); txtTen.Clear(); txtChucVu.Clear(); txtHinh.Clear(); HienHinh("");
            cboGioiTinh.SelectedIndex = 0; dtNgaySinh.Value = new DateTime(1995, 1, 1);
            txtMa.ReadOnly = false; btnThem.Enabled = true; btnCapNhat.Enabled = false; btnNghi.Enabled = false;
        }

        // ===================== THẺ GIỮ XE =====================
        private void TaiComboNhanVienThe()
        {
            DataTable dt = service.LayNhanVien("");
            DataView dv = new DataView(dt, "TrangThai = 'Đang làm'", "MaNV", DataViewRowState.CurrentRows);
            DataTable ds = dv.ToTable();
            ds.Columns.Add("HienThi", typeof(string));
            foreach (DataRow r in ds.Rows) r["HienThi"] = r["MaNV"] + " - " + r["HoTen"];
            bool cu = dangTai; dangTai = true;
            UiHelper.GanCombo(cboTheNV, ds, "HienThi", "MaNV");
            dangTai = cu;
            TaiThe();
        }

        private void cboTheNV_SelectedIndexChanged(object sender, EventArgs e) { if (!dangTai) TaiThe(); }

        private void TaiThe() { UiHelper.HienLuoi(dgvThe, service.LayThe(UiHelper.LayMa(cboTheNV))); }

        private void btnCapThe_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = service.CapThe(txtMaThe.Text, UiHelper.LayMa(cboTheNV), txtBienSo.Text,
                Convert.ToString(cboLoaiXe.SelectedItem), txtHieuXe.Text, txtMauSac.Text);
            if (UiHelper.HienKetQua(kq)) { TaiThe(); txtMaThe.Clear(); txtBienSo.Clear(); txtHieuXe.Clear(); txtMauSac.Clear(); }
        }

        private void btnThuHoi_Click(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvThe);
            if (r == null) { MessageBox.Show("Hãy chọn thẻ cần thu hồi."); return; }
            if (UiHelper.HienKetQua(service.ThuHoiThe(Convert.ToString(r["MaThe"])))) TaiThe();
        }
    }
}
