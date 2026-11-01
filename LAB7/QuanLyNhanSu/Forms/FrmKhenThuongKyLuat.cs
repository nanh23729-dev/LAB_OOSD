using System;
using System.Data;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmKhenThuongKyLuat : Form
    {
        private readonly KhenThuongKyLuatService service = new KhenThuongKyLuatService();
        private readonly NhanVienService nhanVien = new NhanVienService();
        private readonly DanhMucService danhMuc = new DanhMucService();

        public FrmKhenThuongKyLuat() { InitializeComponent(); }

        private void FrmKhenThuongKyLuat_Load(object sender, EventArgs e)
        {
            DataTable nv = nhanVien.LayCombo(null);
            DataTable pb = danhMuc.LayPhongBan();
            UiHelper.GanCombo(cboKTNhanVien, nv.Copy(), "HienThi", "MaNV");
            UiHelper.GanCombo(cboKLNhanVien, nv.Copy(), "HienThi", "MaNV");
            UiHelper.GanCombo(cboKTPhongBan, pb.Copy(), "TenPB", "MaPB");
            UiHelper.GanCombo(cboKLPhongBan, pb.Copy(), "TenPB", "MaPB");
            // Phiếu chi/thu do kế toán (Phòng TC-KT) lập
            DataView kt = new DataView(nv); kt.RowFilter = "MaPB = 'PB02'";
            UiHelper.GanCombo(cboKTNguoiLap, kt.ToTable(), "HienThi", "MaNV");
            UiHelper.GanCombo(cboKLNguoiLap, kt.ToTable(), "HienThi", "MaNV");

            cboKTLoai.Items.AddRange(new object[] { "Thành tích", "Ngày lễ", "Thưởng cuối năm", "Lương tháng 13" });
            cboKTHinhThuc.Items.AddRange(new object[] { "Cộng vào lương", "Phiếu chi" });
            cboKLHinhThuc.Items.AddRange(new object[] { "Trừ lương", "Phiếu thu" });
            LamMoiKT(); LamMoiKL();
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            UiHelper.HienLuoi(dgvKhenThuong, service.LayKhenThuong());
            UiHelper.HienLuoi(dgvKyLuat, service.LayKyLuat());
        }

        // ===================== KHEN THƯỞNG =====================
        private void rdoKTCaNhan_CheckedChanged(object sender, EventArgs e) { CapNhatDoiTuongKT(); }
        private void rdoKTTapThe_CheckedChanged(object sender, EventArgs e) { CapNhatDoiTuongKT(); }

        private void CapNhatDoiTuongKT()
        {
            cboKTNhanVien.Enabled = rdoKTCaNhan.Checked;
            cboKTPhongBan.Enabled = rdoKTTapThe.Checked;
            // Tập thể chỉ được chi bằng phiếu chi
            if (rdoKTTapThe.Checked) cboKTHinhThuc.SelectedItem = "Phiếu chi";
            cboKTHinhThuc.Enabled = rdoKTCaNhan.Checked;
        }

        private void cboKTHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKTNguoiLap.Enabled = Convert.ToString(cboKTHinhThuc.SelectedItem) == "Phiếu chi";
        }

        private void btnKTLap_Click(object sender, EventArgs e)
        {
            QuyetDinhKhenThuong qd = new QuyetDinhKhenThuong
            {
                SoQD = txtKTSoQD.Text.Trim(), NgayKy = dtKTNgayKy.Value.Date, LoaiKhenThuong = Convert.ToString(cboKTLoai.SelectedItem),
                DoiTuong = rdoKTCaNhan.Checked ? "Cá nhân" : "Tập thể",
                MaNV = rdoKTCaNhan.Checked ? UiHelper.LayMa(cboKTNhanVien) : null,
                MaPB = rdoKTTapThe.Checked ? UiHelper.LayMa(cboKTPhongBan) : null,
                NoiDung = txtKTNoiDung.Text.Trim(), SoTien = numKTSoTien.Value,
                HinhThucChi = Convert.ToString(cboKTHinhThuc.SelectedItem), NguoiKy = txtKTNguoiKy.Text.Trim(),
                MaNVLapPhieu = UiHelper.LayMa(cboKTNguoiLap)
            };
            if (UiHelper.HienKetQua(service.LapQuyetDinhKhenThuong(qd))) { TaiDuLieu(); LamMoiKT(); }
        }

        private void btnKTMoi_Click(object sender, EventArgs e) { LamMoiKT(); }

        private void LamMoiKT()
        {
            txtKTSoQD.Clear(); txtKTNoiDung.Clear(); txtKTNguoiKy.Text = "Trần Quốc Bảo";
            dtKTNgayKy.Value = DateTime.Today; numKTSoTien.Value = 0;
            cboKTLoai.SelectedIndex = 0; cboKTHinhThuc.SelectedIndex = 0;
            rdoKTCaNhan.Checked = true; CapNhatDoiTuongKT(); cboKTHinhThuc_SelectedIndexChanged(null, EventArgs.Empty);
        }

        // ===================== KỶ LUẬT =====================
        private void rdoKLCaNhan_CheckedChanged(object sender, EventArgs e) { CapNhatDoiTuongKL(); }
        private void rdoKLTapThe_CheckedChanged(object sender, EventArgs e) { CapNhatDoiTuongKL(); }

        private void CapNhatDoiTuongKL()
        {
            cboKLNhanVien.Enabled = rdoKLCaNhan.Checked;
            cboKLPhongBan.Enabled = rdoKLTapThe.Checked;
            if (rdoKLTapThe.Checked) cboKLHinhThuc.SelectedItem = "Phiếu thu";
            cboKLHinhThuc.Enabled = rdoKLCaNhan.Checked;
        }

        private void cboKLHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKLNguoiLap.Enabled = Convert.ToString(cboKLHinhThuc.SelectedItem) == "Phiếu thu";
        }

        private void btnKLLap_Click(object sender, EventArgs e)
        {
            QuyetDinhKyLuat qd = new QuyetDinhKyLuat
            {
                SoQD = txtKLSoQD.Text.Trim(), NgayKy = dtKLNgayKy.Value.Date,
                DoiTuong = rdoKLCaNhan.Checked ? "Cá nhân" : "Tập thể",
                MaNV = rdoKLCaNhan.Checked ? UiHelper.LayMa(cboKLNhanVien) : null,
                MaPB = rdoKLTapThe.Checked ? UiHelper.LayMa(cboKLPhongBan) : null,
                LyDo = txtKLLyDo.Text.Trim(), SoTienPhat = numKLSoTien.Value,
                HinhThucThu = Convert.ToString(cboKLHinhThuc.SelectedItem), NguoiKy = txtKLNguoiKy.Text.Trim(),
                MaNVLapPhieu = UiHelper.LayMa(cboKLNguoiLap)
            };
            if (UiHelper.HienKetQua(service.LapQuyetDinhKyLuat(qd))) { TaiDuLieu(); LamMoiKL(); }
        }

        private void btnKLMoi_Click(object sender, EventArgs e) { LamMoiKL(); }

        private void LamMoiKL()
        {
            txtKLSoQD.Clear(); txtKLLyDo.Clear(); txtKLNguoiKy.Text = "Trần Quốc Bảo";
            dtKLNgayKy.Value = DateTime.Today; numKLSoTien.Value = 0; cboKLHinhThuc.SelectedIndex = 0;
            rdoKLCaNhan.Checked = true; CapNhatDoiTuongKL(); cboKLHinhThuc_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
