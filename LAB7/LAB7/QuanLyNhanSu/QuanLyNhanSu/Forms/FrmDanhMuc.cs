using System;
using System.Data;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService service = new DanhMucService();

        public FrmDanhMuc() { InitializeComponent(); }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            cboPBLoai.Items.AddRange(new object[] { "Phòng", "Ban", "Phân xưởng" });
            cboPBLoai.SelectedIndex = 0;
            TaiTatCa();
            LamMoiPB(); LamMoiCV(); LamMoiCa();
        }

        private void TaiTatCa()
        {
            UiHelper.HienLuoi(dgvPB, service.LayPhongBan());
            UiHelper.HienLuoi(dgvCV, service.LayChucVu());
            UiHelper.HienLuoi(dgvCa, service.LayCaLamViec());
        }

        private void KetQua(KetQuaXuLy kq)
        {
            if (UiHelper.HienKetQua(kq)) TaiTatCa();
        }

        // ===================== PHÒNG BAN =====================
        private void btnPBThem_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuPhongBan(txtPBMa.Text, txtPBTen.Text, Convert.ToString(cboPBLoai.SelectedItem), txtPBDienThoai.Text, false));
        }

        private void btnPBCapNhat_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuPhongBan(txtPBMa.Text, txtPBTen.Text, Convert.ToString(cboPBLoai.SelectedItem), txtPBDienThoai.Text, true));
        }

        private void btnPBXoa_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Xóa phòng ban đang chọn?")) KetQua(service.Xoa("PhongBan", "MaPB", txtPBMa.Text));
        }

        private void btnPBMoi_Click(object sender, EventArgs e) { LamMoiPB(); }

        private void dgvPB_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvPB); if (r == null) return;
            txtPBMa.Text = Convert.ToString(r["MaPB"]);
            txtPBTen.Text = Convert.ToString(r["TenPB"]);
            cboPBLoai.SelectedItem = Convert.ToString(r["LoaiDonVi"]);
            txtPBDienThoai.Text = Convert.ToString(r["DienThoai"]);
            txtPBMa.ReadOnly = true; btnPBThem.Enabled = false; btnPBCapNhat.Enabled = true; btnPBXoa.Enabled = true;
        }

        private void LamMoiPB()
        {
            txtPBMa.Clear(); txtPBTen.Clear(); txtPBDienThoai.Clear(); cboPBLoai.SelectedIndex = 0;
            txtPBMa.ReadOnly = false; btnPBThem.Enabled = true; btnPBCapNhat.Enabled = false; btnPBXoa.Enabled = false;
        }

        // ===================== CHỨC VỤ =====================
        private void btnCVThem_Click(object sender, EventArgs e) { KetQua(service.LuuChucVu(txtCVMa.Text, txtCVTen.Text, false)); }
        private void btnCVCapNhat_Click(object sender, EventArgs e) { KetQua(service.LuuChucVu(txtCVMa.Text, txtCVTen.Text, true)); }

        private void btnCVXoa_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Xóa chức vụ đang chọn?")) KetQua(service.Xoa("ChucVu", "MaCV", txtCVMa.Text));
        }

        private void btnCVMoi_Click(object sender, EventArgs e) { LamMoiCV(); }

        private void dgvCV_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvCV); if (r == null) return;
            txtCVMa.Text = Convert.ToString(r["MaCV"]);
            txtCVTen.Text = Convert.ToString(r["TenCV"]);
            txtCVMa.ReadOnly = true; btnCVThem.Enabled = false; btnCVCapNhat.Enabled = true; btnCVXoa.Enabled = true;
        }

        private void LamMoiCV()
        {
            txtCVMa.Clear(); txtCVTen.Clear();
            txtCVMa.ReadOnly = false; btnCVThem.Enabled = true; btnCVCapNhat.Enabled = false; btnCVXoa.Enabled = false;
        }

        // ===================== CA LÀM VIỆC =====================
        private void btnCaThem_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuCaLamViec(txtCaMa.Text, txtCaTen.Text, dtCaBatDau.Value, dtCaKetThuc.Value, false));
        }

        private void btnCaCapNhat_Click(object sender, EventArgs e)
        {
            KetQua(service.LuuCaLamViec(txtCaMa.Text, txtCaTen.Text, dtCaBatDau.Value, dtCaKetThuc.Value, true));
        }

        private void btnCaXoa_Click(object sender, EventArgs e)
        {
            if (UiHelper.XacNhan("Xóa ca làm việc đang chọn?")) KetQua(service.Xoa("CaLamViec", "MaCa", txtCaMa.Text));
        }

        private void btnCaMoi_Click(object sender, EventArgs e) { LamMoiCa(); }

        private void dgvCa_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvCa); if (r == null) return;
            txtCaMa.Text = Convert.ToString(r["MaCa"]);
            txtCaTen.Text = Convert.ToString(r["TenCa"]);
            dtCaBatDau.Value = DateTime.Today.Add(TimeSpan.Parse(Convert.ToString(r["GioBatDau"])));
            dtCaKetThuc.Value = DateTime.Today.Add(TimeSpan.Parse(Convert.ToString(r["GioKetThuc"])));
            txtCaMa.ReadOnly = true; btnCaThem.Enabled = false; btnCaCapNhat.Enabled = true; btnCaXoa.Enabled = true;
        }

        private void LamMoiCa()
        {
            txtCaMa.Clear(); txtCaTen.Clear();
            dtCaBatDau.Value = DateTime.Today.AddHours(8); dtCaKetThuc.Value = DateTime.Today.AddHours(17);
            txtCaMa.ReadOnly = false; btnCaThem.Enabled = true; btnCaCapNhat.Enabled = false; btnCaXoa.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
