using System;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmQuyetDinh : Form
    {
        private readonly QuyetDinhService service = new QuyetDinhService();
        private readonly NhanVienService nhanVien = new NhanVienService();
        private readonly DanhMucService danhMuc = new DanhMucService();
        private bool dangTai = true;

        public FrmQuyetDinh() { InitializeComponent(); }

        private void FrmQuyetDinh_Load(object sender, EventArgs e)
        {
            UiHelper.GanCombo(cboCChucVu, danhMuc.LayChucVu(), "TenCV", "MaCV");
            UiHelper.GanCombo(cboCPhongBan, danhMuc.LayPhongBan(), "TenPB", "MaPB");
            UiHelper.GanCombo(cboNhanVien, nhanVien.LayCombo("Chính thức"), "HienThi", "MaNV");
            dangTai = false;
            LamMoiLuong(); LamMoiChucVu();
            TaiDuLieu();
        }

        private string MaNV { get { return UiHelper.LayMa(cboNhanVien); } }

        private void TaiDuLieu()
        {
            if (dangTai) return;
            UiHelper.HienLuoi(dgvLuong, service.LayQuyetDinhLuong(MaNV));
            UiHelper.HienLuoi(dgvChucVu, service.LayQuyetDinhChucVu(MaNV));
            lblHienHanh.Text = MaNV == "" ? "Chưa chọn nhân viên." : service.MoTaHienHanh(MaNV, DateTime.Today);
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e) { TaiDuLieu(); }

        // ===================== QUYẾT ĐỊNH LƯƠNG =====================
        private void btnLLap_Click(object sender, EventArgs e)
        {
            QuyetDinhLuong qd = new QuyetDinhLuong
            {
                SoQD = txtLSoQD.Text.Trim(), MaNV = MaNV, NgayKy = dtLNgayKy.Value.Date, NgayHieuLuc = dtLHieuLuc.Value.Date,
                LuongCoBan = numLCB.Value, PhuCapLuong = numLPCLuong.Value, PhuCapDocHai = numLPCDocHai.Value,
                NguoiKy = txtLNguoiKy.Text.Trim()
            };
            if (UiHelper.HienKetQua(service.LapQuyetDinhLuong(qd))) { TaiDuLieu(); LamMoiLuong(); }
        }

        private void btnLMoi_Click(object sender, EventArgs e) { LamMoiLuong(); }

        private void LamMoiLuong()
        {
            txtLSoQD.Clear(); txtLNguoiKy.Text = "Trần Quốc Bảo";
            dtLNgayKy.Value = DateTime.Today; dtLHieuLuc.Value = DateTime.Today;
            numLCB.Value = 0; numLPCLuong.Value = 0; numLPCDocHai.Value = 0;
        }

        // ===================== QUYẾT ĐỊNH CHỨC VỤ =====================
        private void btnCLap_Click(object sender, EventArgs e)
        {
            QuyetDinhChucVu qd = new QuyetDinhChucVu
            {
                SoQD = txtCSoQD.Text.Trim(), MaNV = MaNV, MaCV = UiHelper.LayMa(cboCChucVu), MaPB = UiHelper.LayMa(cboCPhongBan),
                NgayKy = dtCNgayKy.Value.Date, NgayHieuLuc = dtCHieuLuc.Value.Date, PhuCapChucVu = numCPhuCap.Value,
                NguoiKy = txtCNguoiKy.Text.Trim()
            };
            if (UiHelper.HienKetQua(service.LapQuyetDinhChucVu(qd))) { TaiDuLieu(); LamMoiChucVu(); }
        }

        private void btnCMoi_Click(object sender, EventArgs e) { LamMoiChucVu(); }

        private void LamMoiChucVu()
        {
            txtCSoQD.Clear(); txtCNguoiKy.Text = "Trần Quốc Bảo";
            dtCNgayKy.Value = DateTime.Today; dtCHieuLuc.Value = DateTime.Today; numCPhuCap.Value = 0;
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
