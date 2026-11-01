using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCaoOc.Services;

namespace QuanLyCaoOc.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService service = new DanhMucService();

        public FrmDanhMuc() { InitializeComponent(); }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            cboPhongHuong.Items.AddRange(new object[] { "Đông", "Tây", "Nam", "Bắc" });
            cboPhongTrangThai.Items.AddRange(new object[] { "Trống", "Đang thuê", "Bảo trì" });
            TaiTatCa();
            LamMoiTang(); LamMoiPhong(); LamMoiDV();
        }

        private void TaiTatCa()
        {
            UiHelper.HienLuoi(dgvTang, service.LayTang());
            UiHelper.GanCombo(cboPhongTang, service.LayTang(), "TenTang", "MaTang");
            UiHelper.HienLuoi(dgvPhong, service.LayPhong("", ""));
            UiHelper.HienLuoi(dgvDV, service.LayDichVu());
        }

        private void KetQua(KetQuaXuLy kq)
        {
            if (UiHelper.HienKetQua(kq)) TaiTatCa();
        }

        // ===================== TẦNG =====================
        private void btnTangThem_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuTang(txtTangMa.Text, (int)numTangSo.Value, txtTangTen.Text, numTangCao.Value, numTangDonGia.Value, false));
        }

        private void btnTangCapNhat_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuTang(txtTangMa.Text, (int)numTangSo.Value, txtTangTen.Text, numTangCao.Value, numTangDonGia.Value, true));
        }

        private void btnTangXoa_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Xóa tầng đang chọn?")) KetQua(service.Xoa("Tang", "MaTang", txtTangMa.Text));
        }

        private void btnTangMoi_Click(object sender, EventArgs e) { LamMoiTang(); }

        private void dgvTang_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvTang); if (r == null) return;
            txtTangMa.Text = Convert.ToString(r["MaTang"]);
            numTangSo.Value = Convert.ToDecimal(r["SoTang"]);
            txtTangTen.Text = Convert.ToString(r["TenTang"]);
            numTangCao.Value = Convert.ToDecimal(r["DoCao"]);
            numTangDonGia.Value = Convert.ToDecimal(r["DonGiaM2"]);
            txtTangMa.ReadOnly = true; btnTangThem.Enabled = false; btnTangCapNhat.Enabled = true; btnTangXoa.Enabled = true;
        }

        private void LamMoiTang()
        {
            txtTangMa.Clear(); txtTangTen.Clear(); numTangSo.Value = 1; numTangCao.Value = 4; numTangDonGia.Value = 200000;
            txtTangMa.ReadOnly = false; btnTangThem.Enabled = true; btnTangCapNhat.Enabled = false; btnTangXoa.Enabled = false;
        }

        // ===================== PHÒNG =====================
        private void btnPhongTinhGia_Click(object sender, EventArgs e)
        {
            // giá thuê = diện tích x đơn giá m2 của tầng
            numPhongGia.Value = service.TinhGiaThue(UiHelper.LayMa(cboPhongTang), numPhongDienTich.Value);
        }

        private void btnPhongThem_Click(object sender, EventArgs e) { LuuPhong(false); }
        private void btnPhongCapNhat_Click(object sender, EventArgs e) { LuuPhong(true); }

        private void LuuPhong(bool capNhat)
        {
            KetQua(service.LuuPhong(txtPhongMa.Text, UiHelper.LayMa(cboPhongTang), numPhongDienTich.Value,
                Convert.ToString(cboPhongHuong.SelectedItem), numPhongGia.Value, Convert.ToString(cboPhongTrangThai.SelectedItem), capNhat));
        }

        private void btnPhongXoa_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Xóa phòng đang chọn?")) KetQua(service.Xoa("Phong", "MaPhong", txtPhongMa.Text));
        }

        private void btnPhongMoi_Click(object sender, EventArgs e) { LamMoiPhong(); }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvPhong); if (r == null) return;
            txtPhongMa.Text = Convert.ToString(r["MaPhong"]);
            cboPhongTang.SelectedValue = Convert.ToString(r["MaTang"]);
            numPhongDienTich.Value = Convert.ToDecimal(r["DienTich"]);
            cboPhongHuong.SelectedItem = Convert.ToString(r["Huong"]);
            numPhongGia.Value = Convert.ToDecimal(r["GiaThue"]);
            cboPhongTrangThai.SelectedItem = Convert.ToString(r["TrangThai"]);
            txtPhongMa.ReadOnly = true; btnPhongThem.Enabled = false; btnPhongCapNhat.Enabled = true; btnPhongXoa.Enabled = true;
        }

        private void LamMoiPhong()
        {
            txtPhongMa.Clear(); numPhongDienTich.Value = 50; numPhongGia.Value = 0;
            cboPhongHuong.SelectedIndex = 0; cboPhongTrangThai.SelectedIndex = 0;
            txtPhongMa.ReadOnly = false; btnPhongThem.Enabled = true; btnPhongCapNhat.Enabled = false; btnPhongXoa.Enabled = false;
        }

        // ===================== DỊCH VỤ =====================
        private void btnDVThem_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuDichVu(txtDVMa.Text, txtDVTen.Text, txtDVDonVi.Text, numDVDonGia.Value, false));
        }

        private void btnDVCapNhat_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuDichVu(txtDVMa.Text, txtDVTen.Text, txtDVDonVi.Text, numDVDonGia.Value, true));
        }

        private void btnDVXoa_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Xóa dịch vụ đang chọn?")) KetQua(service.Xoa("LoaiDichVu", "MaDV", txtDVMa.Text));
        }

        private void btnDVMoi_Click(object sender, EventArgs e) { LamMoiDV(); }

        private void dgvDV_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvDV); if (r == null) return;
            txtDVMa.Text = Convert.ToString(r["MaDV"]);
            txtDVTen.Text = Convert.ToString(r["TenDV"]);
            txtDVDonVi.Text = Convert.ToString(r["DonViTinh"]);
            numDVDonGia.Value = Convert.ToDecimal(r["DonGia"]);
            txtDVMa.ReadOnly = true; btnDVThem.Enabled = false; btnDVCapNhat.Enabled = true; btnDVXoa.Enabled = true;
        }

        private void LamMoiDV()
        {
            txtDVMa.Clear(); txtDVTen.Clear(); txtDVDonVi.Clear(); numDVDonGia.Value = 0;
            txtDVMa.ReadOnly = false; btnDVThem.Enabled = true; btnDVCapNhat.Enabled = false; btnDVXoa.Enabled = false;
        }
    }
}
