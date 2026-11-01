using System;
using System.Data;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienService service = new NhanVienService();
        private readonly DanhMucService danhMuc = new DanhMucService();
        private string soHDDangChon = "";

        public FrmNhanVien() { InitializeComponent(); }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboTDKetQua.Items.AddRange(new object[] { "Đạt", "Không đạt" });
            cboHDLoai.Items.AddRange(new object[] { "Dài hạn", "Ngắn hạn" });
            cboGioiTinh.SelectedIndex = 0; cboTDKetQua.SelectedIndex = 0; cboHDLoai.SelectedIndex = 0;

            // Phòng ban của hồ sơ cho phép để trống (chưa phân bổ)
            DataTable pb = danhMuc.LayPhongBan();
            DataRow rong = pb.NewRow(); rong["MaPB"] = ""; rong["TenPB"] = "(Chưa phân bổ)";
            pb.Rows.InsertAt(rong, 0);
            UiHelper.GanCombo(cboPhongBan, pb, "TenPB", "MaPB");
            UiHelper.GanCombo(cboTDPhongBan, danhMuc.LayPhongBan(), "TenPB", "MaPB");

            TaiHoSo(); TaiTuyenDung(); TaiHopDong();
            LamMoiHoSo(); LamMoiTuyenDung(); LamMoiHopDong();
        }

        // ===================== TAB HỒ SƠ =====================
        private void TaiHoSo()
        {
            UiHelper.HienLuoi(dgvNhanVien, service.LayDanhSach(txtTim.Text));
        }

        private NhanVien LayForm()
        {
            return new NhanVien
            {
                MaNV = txtMa.Text.Trim(), HoTen = txtHoTen.Text.Trim(),
                GioiTinh = Convert.ToString(cboGioiTinh.SelectedItem), NgaySinh = dtNgaySinh.Value.Date,
                CCCD = txtCCCD.Text.Trim(), DiaChi = txtDiaChi.Text.Trim(), DienThoai = txtDienThoai.Text.Trim(),
                MaPB = UiHelper.LayMa(cboPhongBan)
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (UiHelper.HienKetQua(service.Luu(LayForm(), false))) { TaiHoSo(); TaiComboTuyenDung(); LamMoiHoSo(); }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (UiHelper.HienKetQua(service.Luu(LayForm(), true))) { TaiHoSo(); LamMoiHoSo(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoiHoSo(); }
        private void btnTim_Click(object sender, EventArgs e) { TaiHoSo(); }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvNhanVien); if (r == null) return;
            txtMa.Text = Convert.ToString(r["MaNV"]);
            txtHoTen.Text = Convert.ToString(r["HoTen"]);
            cboGioiTinh.SelectedItem = Convert.ToString(r["GioiTinh"]);
            dtNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
            txtCCCD.Text = Convert.ToString(r["CCCD"]);
            txtDiaChi.Text = Convert.ToString(r["DiaChi"]);
            txtDienThoai.Text = Convert.ToString(r["DienThoai"]);
            cboPhongBan.SelectedValue = Convert.ToString(r["MaPB"]);
            txtTrangThai.Text = Convert.ToString(r["TrangThai"]);
            txtMa.ReadOnly = true; btnThem.Enabled = false; btnCapNhat.Enabled = true;
        }

        private void LamMoiHoSo()
        {
            txtMa.Clear(); txtHoTen.Clear(); txtCCCD.Clear(); txtDiaChi.Clear(); txtDienThoai.Clear();
            txtTrangThai.Text = "Hồ sơ"; cboPhongBan.SelectedIndex = 0;
            dtNgaySinh.Value = DateTime.Today.AddYears(-22);
            txtMa.ReadOnly = false; btnThem.Enabled = true; btnCapNhat.Enabled = false; txtMa.Focus();
        }

        // ===================== TAB QUYẾT ĐỊNH TUYỂN DỤNG =====================
        private void TaiTuyenDung()
        {
            UiHelper.HienLuoi(dgvTuyenDung, service.LayQuyetDinhTuyenDung());
            TaiComboTuyenDung();
        }

        private void TaiComboTuyenDung()
        {
            UiHelper.GanCombo(cboTDNhanVien, service.LayCombo("Hồ sơ"), "HienThi", "MaNV");
        }

        private void btnTDLap_Click(object sender, EventArgs e)
        {
            QuyetDinhTuyenDung qd = new QuyetDinhTuyenDung
            {
                SoQD = txtTDSoQD.Text.Trim(), MaNV = UiHelper.LayMa(cboTDNhanVien), MaPB = UiHelper.LayMa(cboTDPhongBan),
                NgayKy = dtTDNgayKy.Value.Date, NgayBatDauThuViec = dtTDTuNgay.Value.Date, NgayKetThucThuViec = dtTDDenNgay.Value.Date,
                LuongThuViec = numTDLuong.Value, DieuKhoan = txtTDDieuKhoan.Text.Trim(), NguoiKy = txtTDNguoiKy.Text.Trim()
            };
            if (UiHelper.HienKetQua(service.LapQuyetDinhTuyenDung(qd)))
            {
                TaiTuyenDung(); TaiHoSo(); LamMoiTuyenDung();
            }
        }

        private void btnTDMoi_Click(object sender, EventArgs e) { LamMoiTuyenDung(); }

        private void btnTDKetQua_Click(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvTuyenDung);
            if (r == null) { MessageBox.Show("Vui lòng chọn quyết định tuyển dụng trên lưới."); return; }
            string soQD = Convert.ToString(r["SoQD"]);
            string kq = Convert.ToString(cboTDKetQua.SelectedItem);
            if (!UiHelper.XacNhan("Ghi nhận kết quả thử việc '" + kq + "' cho quyết định " + soQD + "?")) return;
            if (UiHelper.HienKetQua(service.CapNhatKetQuaThuViec(soQD, kq)))
            {
                TaiTuyenDung(); TaiHoSo(); TaiComboHopDong();
            }
        }

        private void LamMoiTuyenDung()
        {
            txtTDSoQD.Clear(); txtTDDieuKhoan.Clear(); txtTDNguoiKy.Text = "Trần Quốc Bảo";
            dtTDNgayKy.Value = DateTime.Today; dtTDTuNgay.Value = DateTime.Today.AddDays(1);
            dtTDDenNgay.Value = DateTime.Today.AddDays(1).AddMonths(2).AddDays(-1);
            numTDLuong.Value = 6000000;
        }

        // ===================== TAB HỢP ĐỒNG - BẢO HIỂM =====================
        private void TaiHopDong()
        {
            UiHelper.HienLuoi(dgvHopDong, service.LayHopDong());
            TaiComboHopDong();
        }

        private void TaiComboHopDong()
        {
            UiHelper.GanCombo(cboHDQuyetDinh, service.LayQuyetDinhChoKyHopDong(), "HienThi", "SoQD");
        }

        private void cboHDLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hợp đồng dài hạn không có ngày kết thúc
            dtHDKetThuc.Enabled = Convert.ToString(cboHDLoai.SelectedItem) == "Ngắn hạn";
        }

        private void btnHDKy_Click(object sender, EventArgs e)
        {
            string loai = Convert.ToString(cboHDLoai.SelectedItem);
            HopDongLaoDong hd = new HopDongLaoDong
            {
                SoHD = txtHDSo.Text.Trim(), SoQDTuyenDung = UiHelper.LayMa(cboHDQuyetDinh), LoaiHD = loai,
                NgayKy = dtHDNgayKy.Value.Date, NgayBatDau = dtHDBatDau.Value.Date, NguoiKy = txtHDNguoiKy.Text.Trim(),
                NgayKetThuc = loai == "Ngắn hạn" ? (DateTime?)dtHDKetThuc.Value.Date : null
            };
            if (UiHelper.HienKetQua(service.KyHopDong(hd)))
            {
                TaiHopDong(); TaiHoSo(); TaiTuyenDung(); LamMoiHopDong();
            }
        }

        private void btnHDMoi_Click(object sender, EventArgs e) { LamMoiHopDong(); }

        private void dgvHopDong_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvHopDong);
            if (r == null) { soHDDangChon = ""; lblBHHopDong.Text = "Hợp đồng: (chưa chọn)"; return; }
            soHDDangChon = Convert.ToString(r["SoHD"]);
            lblBHHopDong.Text = "Hợp đồng: " + soHDDangChon + " (" + Convert.ToString(r["LoaiHD"]) + ")";
            dtBHNgay.Value = Convert.ToDateTime(r["NgayBatDau"]);
            // Chỉ mở nút lập BH khi là HĐ dài hạn và chưa có hồ sơ
            btnBHLap.Enabled = Convert.ToString(r["LoaiHD"]) == "Dài hạn" && r["MaHSBH"] == DBNull.Value;
        }

        private void btnBHLap_Click(object sender, EventArgs e)
        {
            HoSoBaoHiem bh = new HoSoBaoHiem
            {
                SoHD = soHDDangChon, SoSoBHXH = txtBHSoSo.Text.Trim(), SoTheBHYT = txtBHSoThe.Text.Trim(),
                NgayThamGia = dtBHNgay.Value.Date, TyLeBHXH = numBHXH.Value, TyLeBHYT = numBHYT.Value
            };
            if (UiHelper.HienKetQua(service.LapHoSoBaoHiem(bh)))
            {
                txtBHSoSo.Clear(); txtBHSoThe.Clear(); TaiHopDong();
            }
        }

        private void LamMoiHopDong()
        {
            txtHDSo.Clear(); txtHDNguoiKy.Text = "Trần Quốc Bảo"; cboHDLoai.SelectedIndex = 0;
            dtHDNgayKy.Value = DateTime.Today; dtHDBatDau.Value = DateTime.Today.AddDays(1);
            dtHDKetThuc.Value = DateTime.Today.AddYears(1);
            numBHXH.Value = 8; numBHYT.Value = 1.5m;
            cboHDLoai_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
