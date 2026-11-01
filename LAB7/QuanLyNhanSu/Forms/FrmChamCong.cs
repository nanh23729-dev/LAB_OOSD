using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmChamCong : Form
    {
        private readonly ChamCongService service = new ChamCongService();
        private readonly NhanVienService nhanVien = new NhanVienService();
        private readonly DanhMucService danhMuc = new DanhMucService();
        private DataTable nhanVienDangLam;      // NV thử việc + chính thức (có cột MaPB)
        private DataTable dsPhuTroi;            // danh sách tạm NV tham gia phụ trội
        private string maKHDangChon = "";
        private string maBCCDangMo = "";
        private bool dangTai = true;

        public FrmChamCong() { InitializeComponent(); }

        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            nhanVienDangLam = nhanVien.LayCombo(null);
            DataTable pb = danhMuc.LayPhongBan();
            UiHelper.GanCombo(cboKHPhongBan, pb.Copy(), "TenPB", "MaPB");
            UiHelper.GanCombo(cboCCPhongBan, pb.Copy(), "TenPB", "MaPB");
            UiHelper.GanCombo(cboPTPhongBan, pb.Copy(), "TenPB", "MaPB");
            UiHelper.GanCombo(cboKHNguoiLap, nhanVienDangLam.Copy(), "HienThi", "MaNV");
            UiHelper.GanCombo(cboCCNguoiLap, LocTheoPhong("BCC"), "HienThi", "MaNV");
            UiHelper.GanCombo(cboPTNguoiLap, LocTheoPhong("BCC"), "HienThi", "MaNV");
            UiHelper.GanCombo(cboPCCa, danhMuc.LayCaLamViec(), "TenCa", "MaCa");
            cboPTHinhThuc.Items.AddRange(new object[] { "Tăng ca", "Ngày lễ", "Ngày nghỉ" });
            cboPTHinhThuc.SelectedIndex = 0;

            // Tuần mặc định: thứ Hai của tuần sau
            DateTime d = DateTime.Today.AddDays(7);
            while (d.DayOfWeek != DayOfWeek.Monday) d = d.AddDays(-1);
            dtKHTuNgay.Value = d;
            numCCThang.Value = DateTime.Today.Month; numCCNam.Value = DateTime.Today.Year;
            dtPTNgay.Value = DateTime.Today;

            dsPhuTroi = new DataTable();
            dsPhuTroi.Columns.Add("MaNV", typeof(string));
            dsPhuTroi.Columns.Add("HoTen", typeof(string));
            dsPhuTroi.Columns.Add("SoGio", typeof(decimal));
            UiHelper.HienLuoi(dgvPTChon, dsPhuTroi);

            dangTai = false;
            cboKHPhongBan_SelectedIndexChanged(null, EventArgs.Empty);
            cboPTPhongBan_SelectedIndexChanged(null, EventArgs.Empty);
            UiHelper.HienLuoi(dgvPhieuPhuTroi, service.LayPhieuPhuTroi());
        }

        private DataTable LocTheoPhong(string maPB)
        {
            DataView v = new DataView(nhanVienDangLam);
            v.RowFilter = "MaPB = '" + maPB.Replace("'", "''") + "'";
            return v.ToTable();
        }

        // ===================== KẾ HOẠCH PHÂN CÔNG =====================
        private void cboKHPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTai) return;
            string maPB = UiHelper.LayMa(cboKHPhongBan);
            UiHelper.HienLuoi(dgvKeHoach, service.LayKeHoach(maPB));
            UiHelper.GanCombo(cboPCNhanVien, LocTheoPhong(maPB), "HienThi", "MaNV");
            if (dgvKeHoach.Rows.Count == 0) { maKHDangChon = ""; HienPhanCong(); }
        }

        private void dgvKeHoach_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvKeHoach);
            maKHDangChon = r == null ? "" : Convert.ToString(r["MaKH"]);
            if (r != null) dtPCNgay.Value = Convert.ToDateTime(r["TuNgay"]);
            HienPhanCong();
        }

        private void HienPhanCong()
        {
            lblPCTieuDe.Text = "Phân công chi tiết của kế hoạch: " + (maKHDangChon == "" ? "(chưa chọn)" : maKHDangChon);
            UiHelper.HienLuoi(dgvPhanCong, service.LayChiTietPhanCong(maKHDangChon));
        }

        private void btnKHLap_Click(object sender, EventArgs e)
        {
            if (UiHelper.HienKetQua(service.LapKeHoach(UiHelper.LayMa(cboKHPhongBan), dtKHTuNgay.Value, UiHelper.LayMa(cboKHNguoiLap))))
                cboKHPhongBan_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void btnPCThem_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = service.ThemPhanCong(maKHDangChon, UiHelper.LayMa(cboPCNhanVien), dtPCNgay.Value,
                UiHelper.LayMa(cboPCCa), numPCGioPT.Value);
            if (kq.ThanhCong) HienPhanCong(); else UiHelper.HienKetQua(kq);
        }

        private void btnPCXoa_Click(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvPhanCong); if (r == null) return;
            if (!UiHelper.XacNhan("Xóa dòng phân công đang chọn?")) return;
            KetQuaXuLy kq = service.XoaPhanCong(maKHDangChon, Convert.ToString(r["MaNV"]), Convert.ToDateTime(r["NgayLam"]));
            if (kq.ThanhCong) HienPhanCong(); else UiHelper.HienKetQua(kq);
        }

        // ===================== BẢNG CHẤM CÔNG =====================
        private void btnCCMo_Click(object sender, EventArgs e)
        {
            string maBCC;
            string maPB = UiHelper.LayMa(cboCCPhongBan);
            KetQuaXuLy kq = service.MoBangChamCong(maPB, (int)numCCThang.Value, (int)numCCNam.Value, UiHelper.LayMa(cboCCNguoiLap), out maBCC);
            if (!kq.ThanhCong) { UiHelper.HienKetQua(kq); return; }
            maBCCDangMo = maBCC;
            lblCCMa.Text = "Bảng chấm công: " + maBCC;
            UiHelper.GanCombo(cboCCNhanVien, LocTheoPhong(maPB), "HienThi", "MaNV");
            UiHelper.HienLuoi(dgvChamCong, service.LayChiTietChamCong(maBCCDangMo));
        }

        private void btnCCLuu_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = service.LuuChamCong(maBCCDangMo, UiHelper.LayMa(cboCCNhanVien), numCCNgayCong.Value,
                numCCNghiPhep.Value, numCCNghiKP.Value);
            if (kq.ThanhCong) UiHelper.HienLuoi(dgvChamCong, service.LayChiTietChamCong(maBCCDangMo));
            else UiHelper.HienKetQua(kq);
        }

        private void dgvChamCong_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvChamCong); if (r == null) return;
            cboCCNhanVien.SelectedValue = Convert.ToString(r["MaNV"]);
            numCCNgayCong.Value = Convert.ToDecimal(r["SoNgayCong"]);
            numCCNghiPhep.Value = Convert.ToDecimal(r["SoNgayNghiPhep"]);
            numCCNghiKP.Value = Convert.ToDecimal(r["SoNgayNghiKhongPhep"]);
        }

        // ===================== PHIẾU PHỤ TRỘI =====================
        private void cboPTPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTai) return;
            UiHelper.GanCombo(cboPTNhanVien, LocTheoPhong(UiHelper.LayMa(cboPTPhongBan)), "HienThi", "MaNV");
            dsPhuTroi.Rows.Clear();     // đổi phòng thì danh sách tạm phải chọn lại
        }

        private void btnPTThemNV_Click(object sender, EventArgs e)
        {
            DataRowView nv = cboPTNhanVien.SelectedItem as DataRowView; if (nv == null) return;
            string ma = Convert.ToString(nv["MaNV"]);
            foreach (DataRow r in dsPhuTroi.Rows)
                if (Convert.ToString(r["MaNV"]) == ma) { MessageBox.Show("Nhân viên đã có trong phiếu."); return; }
            dsPhuTroi.Rows.Add(ma, Convert.ToString(nv["HienThi"]).Substring(ma.Length + 3), numPTGioNV.Value);
        }

        private void btnPTBoNV_Click(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvPTChon); if (r != null) r.Row.Delete();
            dsPhuTroi.AcceptChanges();
        }

        private void btnPTLap_Click(object sender, EventArgs e)
        {
            PhieuPhuTroi p = new PhieuPhuTroi
            {
                SoPhieu = txtPTSoPhieu.Text.Trim(), NgayPhuTroi = dtPTNgay.Value.Date, SoGioPhuTroi = numPTSoGio.Value,
                HinhThuc = Convert.ToString(cboPTHinhThuc.SelectedItem), MaPB = UiHelper.LayMa(cboPTPhongBan),
                MaNVLap = UiHelper.LayMa(cboPTNguoiLap)
            };
            List<KeyValuePair<string, decimal>> ds = new List<KeyValuePair<string, decimal>>();
            foreach (DataRow r in dsPhuTroi.Rows)
                ds.Add(new KeyValuePair<string, decimal>(Convert.ToString(r["MaNV"]), Convert.ToDecimal(r["SoGio"])));
            if (UiHelper.HienKetQua(service.LapPhieuPhuTroi(p, ds)))
            {
                dsPhuTroi.Rows.Clear(); txtPTSoPhieu.Clear();
                UiHelper.HienLuoi(dgvPhieuPhuTroi, service.LayPhieuPhuTroi());
            }
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
