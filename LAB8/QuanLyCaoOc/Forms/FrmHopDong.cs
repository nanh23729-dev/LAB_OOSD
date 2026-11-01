using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyCaoOc.Services;

namespace QuanLyCaoOc.Forms
{
    public partial class FrmHopDong : Form
    {
        private readonly HopDongService service = new HopDongService();
        private bool dangTai = true;

        public FrmHopDong() { InitializeComponent(); }

        private void FrmHopDong_Load(object sender, EventArgs e)
        {
            // lưới nhập tay của tab Gia hạn: thêm cột bằng code
            dgvGH.Columns.Add("MaPhong", "Phòng");
            dgvGH.Columns.Add("SoThang", "Số tháng gia hạn");
            dgvGH.Columns.Add("KetThucCu", "Kết thúc hiện tại");
            dgvGH.Columns.Add("KetThucMoi", "Kết thúc mới");
            dgvGH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            numSoThang.Value = 12;
            TaiKhachHang();
            TaiPhongTrong();
            TaiDanhSach();
            UiHelper.GanCombo(cboGHHD, service.LayHopDongHieuLuc(), "HienThi", "SoHD");
            dangTai = false;
            CapNhatTongTien();
            cboGHHD_SelectedIndexChanged(null, null);
        }

        // ===================== LẬP HỢP ĐỒNG =====================
        private void TaiKhachHang() { UiHelper.GanCombo(cboKH, service.LayKhachHang(), "HienThi", "MaKH"); }

        private void TaiPhongTrong()
        {
            DataTable dt = service.LayPhongTrong();
            dt.Columns.Add("HienThi", typeof(string));
            foreach (DataRow r in dt.Rows)
                r["HienThi"] = r["MaPhong"] + " - Tầng " + r["SoTang"] + " - " + Convert.ToDecimal(r["DienTich"]).ToString("N0") + " m2 - "
                             + Convert.ToDecimal(r["GiaThue"]).ToString("N0") + " đ/tháng";
            lstPhong.DataSource = dt;
            lstPhong.DisplayMember = "HienThi";
            lstPhong.ValueMember = "MaPhong";
            lstPhong.ClearSelected();
        }

        private List<string> PhongDaChon()
        {
            List<string> ds = new List<string>();
            foreach (object o in lstPhong.SelectedItems)
                ds.Add(Convert.ToString(((DataRowView)o)["MaPhong"]));
            return ds;
        }

        private void lstPhong_SelectedIndexChanged(object sender, EventArgs e) { if (!dangTai) CapNhatTongTien(); }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (object o in lstPhong.SelectedItems) tong += Convert.ToDecimal(((DataRowView)o)["GiaThue"]);
            lblTongTien.Text = "Tiền thuê mỗi tháng: " + tong.ToString("N0") + " đ"
                + "\r\nPhải trả trước " + HopDongService.SoThangTraTruoc + " tháng đầu: " + (tong * HopDongService.SoThangTraTruoc).ToString("N0") + " đ";
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            HopDongThue hd = new HopDongThue();
            hd.SoHD = txtSoHD.Text;
            hd.MaKH = UiHelper.LayMa(cboKH);
            hd.NgayKy = dtNgayKy.Value.Date;
            hd.NgayBatDau = dtNgayBatDau.Value.Date;
            hd.SoThang = (int)numSoThang.Value;
            hd.DieuKhoan = txtDieuKhoan.Text;
            hd.NguoiLap = txtNguoiLap.Text;
            KetQuaXuLy kq = service.LapHopDong(hd, PhongDaChon());
            if (UiHelper.HienKetQua(kq)) { LamMoiLap(); TaiPhongTrong(); TaiDanhSach(); TaiLaiComboGiaHan(); }
        }

        private void btnLapMoi_Click(object sender, EventArgs e) { LamMoiLap(); }

        private void LamMoiLap()
        {
            txtSoHD.Clear(); txtDieuKhoan.Clear(); numSoThang.Value = 12;
            dtNgayKy.Value = DateTime.Today; dtNgayBatDau.Value = DateTime.Today;
            lstPhong.ClearSelected(); CapNhatTongTien();
        }

        // ===================== DANH SÁCH – THANH LÝ =====================
        private void TaiDanhSach() { UiHelper.HienLuoi(dgvHD, service.LayDanhSachHopDong()); }

        private string SoHDDangChon()
        {
            DataRowView r = UiHelper.DongChon(dgvHD);
            return r == null ? "" : Convert.ToString(r["SoHD"]);
        }

        private void dgvHD_SelectionChanged(object sender, EventArgs e)
        {
            string so = SoHDDangChon();
            if (so == "") return;
            UiHelper.HienLuoi(dgvCT, service.LayChiTiet(so));
            UiHelper.HienLuoi(dgvLich, service.LayLichThanhToan(so));
            CongNoHopDong no = service.TinhCongNo(so);
            lblCongNo.Text = no.CoNo ? "Công nợ: " + no.MoTa() : "Công nợ: không còn nợ tiền thuê và dịch vụ.";
        }

        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            string so = SoHDDangChon();
            if (so == "") { MessageBox.Show("Hãy chọn một hợp đồng."); return; }
            if (!UiHelper.XacNhan("Thanh lý hợp đồng " + so + "?")) return;
            if (UiHelper.HienKetQua(service.ThanhLy(so))) { TaiDanhSach(); TaiPhongTrong(); TaiLaiComboGiaHan(); }
        }

        private void btnTaiLai_Click(object sender, EventArgs e) { TaiDanhSach(); TaiPhongTrong(); }

        // ===================== GIA HẠN =====================
        private void TaiLaiComboGiaHan()
        {
            dangTai = true;
            UiHelper.GanCombo(cboGHHD, service.LayHopDongHieuLuc(), "HienThi", "SoHD");
            dangTai = false;
            cboGHHD_SelectedIndexChanged(null, null);
        }

        private void cboGHHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangTai) return;
            dgvGH.Rows.Clear();
            string so = UiHelper.LayMa(cboGHHD);
            if (so == "")
            {
                cboGHPhong.DataSource = null;
                lblGHThongTin.Text = "Chưa có hợp đồng hiệu lực.";
                dgvGHLichSu.DataSource = null;
                return;
            }
            UiHelper.GanCombo(cboGHPhong, service.LayChiTiet(so), "MaPhong", "MaPhong");
            int toiDa = service.SoThangToiDaGiaHan(so);
            CongNoHopDong no = service.TinhCongNo(so);
            lblGHThongTin.Text = "Mỗi phòng gia hạn tối đa " + toiDa + " tháng (1/2 thời gian thuê).\r\n"
                + (no.CoNo ? "Chưa đủ điều kiện gia hạn. " + no.MoTa() : "Đủ điều kiện công nợ để gia hạn.");
            numGHThang.Maximum = Math.Max(1, toiDa);
            if (numGHThang.Value > numGHThang.Maximum) numGHThang.Value = numGHThang.Maximum;
            UiHelper.HienLuoi(dgvGHLichSu, service.LayPhieuGiaHan(so));
        }

        private void btnGHThem_Click(object sender, EventArgs e)
        {
            string so = UiHelper.LayMa(cboGHHD);
            string phong = UiHelper.LayMa(cboGHPhong);
            if (so == "" || phong == "") { MessageBox.Show("Hãy chọn hợp đồng và phòng."); return; }
            foreach (DataGridViewRow r in dgvGH.Rows)
                if (Convert.ToString(r.Cells[0].Value) == phong) { MessageBox.Show("Phòng này đã có trong phiếu."); return; }
            DataTable ct = service.LayChiTiet(so);
            DateTime cu = DateTime.Today;
            foreach (DataRow r in ct.Rows)
                if (Convert.ToString(r["MaPhong"]) == phong) cu = Convert.ToDateTime(r["NgayKetThuc"]);
            int soThang = (int)numGHThang.Value;
            DateTime moi = cu.AddDays(1).AddMonths(soThang).AddDays(-1);
            dgvGH.Rows.Add(phong, soThang, cu.ToString("dd/MM/yyyy"), moi.ToString("dd/MM/yyyy"));
        }

        private void btnGHBo_Click(object sender, EventArgs e)
        {
            if (dgvGH.CurrentRow != null) dgvGH.Rows.Remove(dgvGH.CurrentRow);
        }

        private void btnGHLap_Click(object sender, EventArgs e)
        {
            string so = UiHelper.LayMa(cboGHHD);
            List<DongGiaHan> ds = new List<DongGiaHan>();
            foreach (DataGridViewRow r in dgvGH.Rows)
            {
                DongGiaHan d = new DongGiaHan();
                d.MaPhong = Convert.ToString(r.Cells[0].Value);
                d.SoThang = Convert.ToInt32(r.Cells[1].Value);
                ds.Add(d);
            }
            KetQuaXuLy kq = service.LapPhieuGiaHan(so, ds, txtGHNguoiLap.Text, txtGHGhiChu.Text);
            if (UiHelper.HienKetQua(kq))
            {
                dgvGH.Rows.Clear();
                TaiDanhSach();
                cboGHHD_SelectedIndexChanged(null, null);
            }
        }
    }
}
