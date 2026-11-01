using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyCaoOc.Services;

namespace QuanLyCaoOc.Forms
{
    public partial class FrmThanhToan : Form
    {
        private readonly HopDongService hopDong = new HopDongService();
        private readonly ThanhToanService service = new ThanhToanService();
        private readonly DanhMucService danhMuc = new DanhMucService();
        private bool dangTai = true;
        private DataTable dichVu;

        public FrmThanhToan() { InitializeComponent(); }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            dgvDong.Columns.Add("MaDV", "Dịch vụ");
            dgvDong.Columns.Add("SoLuong", "Số lượng");
            dgvDong.Columns.Add("DonGia", "Đơn giá");
            dgvDong.Columns.Add("ThanhTien", "Thành tiền");
            dgvDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            numThang.Value = DateTime.Today.Month;
            numNam.Value = DateTime.Today.Year;
            UiHelper.GanCombo(cboHD, hopDong.LayHopDongHieuLuc(), "HienThi", "SoHD");
            UiHelper.GanCombo(cboHDDV, hopDong.LayHopDongHieuLuc(), "HienThi", "SoHD");
            dichVu = danhMuc.LayDichVu();
            dichVu.Columns.Add("HienThi", typeof(string));
            foreach (DataRow r in dichVu.Rows) r["HienThi"] = r["MaDV"] + " - " + r["TenDV"] + " (" + r["DonViTinh"] + ")";
            UiHelper.GanCombo(cboDichVu, dichVu, "HienThi", "MaDV");
            dangTai = false;
            TaiKy(); TaiHoaDon(); TaiCongNo();
        }

        // ===================== THU TIỀN THUÊ =====================
        private void cboHD_SelectedIndexChanged(object sender, EventArgs e) { if (!dangTai) TaiKy(); }

        private void TaiKy()
        {
            string so = UiHelper.LayMa(cboHD);
            UiHelper.HienLuoi(dgvKy, service.LayKyChuaThu(so));
            if (so == "") { lblCongNo.Text = ""; return; }
            CongNoHopDong no = hopDong.TinhCongNo(so);
            lblCongNo.Text = no.CoNo ? "Công nợ: " + no.MoTa() : "Không còn nợ. Các kỳ bên dưới chưa đến hạn.";
        }

        private void btnThuKy_Click(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvKy);
            if (r == null) { MessageBox.Show("Hãy chọn kỳ cần thu."); return; }
            string maKy = Convert.ToString(r["MaKy"]);
            if (!UiHelper.XacNhan("Thu " + Convert.ToDecimal(r["SoTien"]).ToString("N0") + " đ cho kỳ " + maKy + "?")) return;
            if (UiHelper.HienKetQua(service.ThuKy(maKy, txtNguoiThu.Text))) { TaiKy(); TaiCongNo(); }
        }

        // ===================== HÓA ĐƠN DỊCH VỤ =====================
        private void cboHDDV_SelectedIndexChanged(object sender, EventArgs e) { if (!dangTai) TaiHoaDon(); }

        private void TaiHoaDon()
        {
            UiHelper.HienLuoi(dgvHoaDon, service.LayHoaDonDichVu(UiHelper.LayMa(cboHDDV)));
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvHoaDon);
            UiHelper.HienLuoi(dgvChiTietHD, service.LayChiTietHoaDon(r == null ? "" : Convert.ToString(r["SoHDDV"])));
        }

        private void btnDVThem_Click(object sender, EventArgs e)
        {
            string ma = UiHelper.LayMa(cboDichVu);
            if (ma == "" || numSoLuong.Value <= 0) { MessageBox.Show("Hãy chọn dịch vụ và nhập số lượng lớn hơn 0."); return; }
            foreach (DataGridViewRow r in dgvDong.Rows)
                if (Convert.ToString(r.Cells[0].Value) == ma) { MessageBox.Show("Dịch vụ này đã có trong hóa đơn."); return; }
            decimal gia = 0;
            foreach (DataRow r in dichVu.Rows) if (Convert.ToString(r["MaDV"]) == ma) gia = Convert.ToDecimal(r["DonGia"]);
            dgvDong.Rows.Add(ma, numSoLuong.Value, gia.ToString("N0"), Math.Round(gia * numSoLuong.Value, 0).ToString("N0"));
            CapNhatTong();
        }

        private void btnDVBo_Click(object sender, EventArgs e)
        {
            if (dgvDong.CurrentRow != null) dgvDong.Rows.Remove(dgvDong.CurrentRow);
            CapNhatTong();
        }

        private void CapNhatTong()
        {
            decimal tong = 0;
            foreach (DataGridViewRow r in dgvDong.Rows)
                tong += decimal.Parse(Convert.ToString(r.Cells[3].Value).Replace(",", "").Replace(".", ""));
            lblHDTong.Text = "Tổng tạm tính: " + tong.ToString("N0") + " đ";
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            List<DongDichVu> ds = new List<DongDichVu>();
            foreach (DataGridViewRow r in dgvDong.Rows)
            {
                DongDichVu d = new DongDichVu();
                d.MaDV = Convert.ToString(r.Cells[0].Value);
                d.SoLuong = Convert.ToDecimal(r.Cells[1].Value);
                ds.Add(d);
            }
            KetQuaXuLy kq = service.LapHoaDonDichVu(UiHelper.LayMa(cboHDDV), (int)numThang.Value, (int)numNam.Value, ds);
            if (UiHelper.HienKetQua(kq)) { dgvDong.Rows.Clear(); CapNhatTong(); TaiHoaDon(); TaiCongNo(); TaiKy(); }
        }

        private void btnThuHD_Click(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvHoaDon);
            if (r == null) { MessageBox.Show("Hãy chọn hóa đơn cần thu."); return; }
            if (UiHelper.HienKetQua(service.ThuHoaDon(Convert.ToString(r["SoHDDV"])))) { TaiHoaDon(); TaiCongNo(); TaiKy(); }
        }

        // ===================== CÔNG NỢ =====================
        private void TaiCongNo() { UiHelper.HienLuoi(dgvCongNo, service.LayCongNo()); }
        private void btnNoTaiLai_Click(object sender, EventArgs e) { TaiCongNo(); }
    }
}
