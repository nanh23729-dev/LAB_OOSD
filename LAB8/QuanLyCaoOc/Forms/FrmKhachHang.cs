using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCaoOc.Services;

namespace QuanLyCaoOc.Forms
{
    public partial class FrmKhachHang : Form
    {
        private readonly KhachHangService service = new KhachHangService();

        public FrmKhachHang() { InitializeComponent(); }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[] { "Công ty", "Cá nhân" });
            TaiLai();
            LamMoi();
        }

        private void TaiLai() { UiHelper.HienLuoi(dgvKH, service.LayKhachHang(txtTim.Text)); }

        private void KetQua(KetQuaXuLy kq)
        {
            if (UiHelper.HienKetQua(kq)) TaiLai();
        }

        private void btnThem_Click(object sender, EventArgs e) { Luu(false); }
        private void btnCapNhat_Click(object sender, EventArgs e) { Luu(true); }

        private void Luu(bool capNhat)
        {
            KetQua(service.Luu(txtMa.Text, txtTen.Text, Convert.ToString(cboLoai.SelectedItem), txtDaiDien.Text,
                txtDienThoai.Text, txtEmail.Text, txtDiaChi.Text, txtMST.Text, capNhat));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UiHelper.XacNhan("Xóa khách hàng đang chọn?")) return;
            KetQua(new DanhMucService().Xoa("KhachHang", "MaKH", txtMa.Text));
        }

        private void btnMoi_Click(object sender, EventArgs e) { LamMoi(); }
        private void btnTim_Click(object sender, EventArgs e) { TaiLai(); }

        private void dgvKH_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvKH); if (r == null) return;
            txtMa.Text = Convert.ToString(r["MaKH"]);
            txtTen.Text = Convert.ToString(r["TenKH"]);
            cboLoai.SelectedItem = Convert.ToString(r["LoaiKH"]);
            txtDaiDien.Text = Convert.ToString(r["NguoiDaiDien"]);
            txtDienThoai.Text = Convert.ToString(r["DienThoai"]);
            txtEmail.Text = Convert.ToString(r["Email"]);
            txtDiaChi.Text = Convert.ToString(r["DiaChi"]);
            txtMST.Text = Convert.ToString(r["MaSoThue"]);
            txtMa.ReadOnly = true; btnThem.Enabled = false; btnCapNhat.Enabled = true; btnXoa.Enabled = true;
        }

        private void LamMoi()
        {
            txtMa.Clear(); txtTen.Clear(); txtDaiDien.Clear(); txtDienThoai.Clear(); txtEmail.Clear(); txtDiaChi.Clear(); txtMST.Clear();
            cboLoai.SelectedIndex = 0;
            txtMa.ReadOnly = false; btnThem.Enabled = true; btnCapNhat.Enabled = false; btnXoa.Enabled = false;
        }
    }
}
