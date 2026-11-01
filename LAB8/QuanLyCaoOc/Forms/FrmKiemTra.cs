using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyCaoOc.Services;

namespace QuanLyCaoOc.Forms
{
    public partial class FrmKiemTra : Form
    {
        private readonly KiemTraService service = new KiemTraService();

        public FrmKiemTra() { InitializeComponent(); }

        private void FrmKiemTra_Load(object sender, EventArgs e)
        {
            cboTinhTrang.Items.AddRange(new object[] { "Tốt", "Cần sửa chữa", "Hư hỏng" });
            cboTinhTrang.SelectedIndex = 0;
            dgvDong.Columns.Add("MaPhong", "Phòng");
            dgvDong.Columns.Add("TinhTrang", "Tình trạng");
            dgvDong.Columns.Add("KetCau", "Đổi kết cấu");
            dgvDong.Columns.Add("GhiChu", "Ghi chú");
            dgvDong.Columns.Add("KeHoach", "Kế hoạch tự sửa");
            dgvDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TaiTatCa();
        }

        private void TaiTatCa()
        {
            DataTable denHan = service.LayPhongDenHan();
            UiHelper.HienLuoi(dgvDenHan, denHan);
            UiHelper.GanCombo(cboPhong, denHan, "MaPhong", "MaPhong");
            UiHelper.HienLuoi(dgvPhieu, service.LayPhieuKiemTra());
            UiHelper.HienLuoi(dgvPhat, service.LayPhieuPhat());
        }

        // ===================== LẬP PHIẾU =====================
        private void btnThemDong_Click(object sender, EventArgs e)
        {
            string phong = UiHelper.LayMa(cboPhong);
            if (phong == "") { MessageBox.Show("Hãy chọn phòng cần kiểm tra."); return; }
            foreach (DataGridViewRow r in dgvDong.Rows)
                if (Convert.ToString(r.Cells[0].Value) == phong) { MessageBox.Show("Phòng này đã có trong phiếu."); return; }
            string tinhTrang = Convert.ToString(cboTinhTrang.SelectedItem);
            if (tinhTrang != "Tốt" && txtKeHoach.Text.Trim() == "")
            {
                MessageBox.Show("Phòng " + tinhTrang.ToLower() + ": hãy nhập kế hoạch tự sửa chữa.");
                return;
            }
            dgvDong.Rows.Add(phong, tinhTrang, chkKetCau.Checked ? "Có" : "Không", txtDongGhiChu.Text.Trim(), txtKeHoach.Text.Trim());
            txtKeHoach.Clear(); txtDongGhiChu.Clear(); chkKetCau.Checked = false; cboTinhTrang.SelectedIndex = 0;
        }

        private void btnBoDong_Click(object sender, EventArgs e)
        {
            if (dgvDong.CurrentRow != null) dgvDong.Rows.Remove(dgvDong.CurrentRow);
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            List<DongKiemTra> ds = new List<DongKiemTra>();
            foreach (DataGridViewRow r in dgvDong.Rows)
            {
                DongKiemTra d = new DongKiemTra();
                d.MaPhong = Convert.ToString(r.Cells[0].Value);
                d.TinhTrang = Convert.ToString(r.Cells[1].Value);
                d.ThayDoiKetCau = Convert.ToString(r.Cells[2].Value) == "Có";
                d.GhiChu = Convert.ToString(r.Cells[3].Value);
                d.KeHoachTuSua = Convert.ToString(r.Cells[4].Value);
                ds.Add(d);
            }
            if (UiHelper.HienKetQua(service.LapPhieuKiemTra(txtNguoiKT.Text, "", ds))) { dgvDong.Rows.Clear(); TaiTatCa(); }
        }

        // ===================== PHIẾU ĐÃ LẬP – PHIẾU PHẠT =====================
        private void dgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvPhieu);
            UiHelper.HienLuoi(dgvChiTiet, service.LayChiTiet(r == null ? "" : Convert.ToString(r["SoPhieu"])));
        }

        private void btnThuPhat_Click(object sender, EventArgs e)
        {
            DataRowView r = UiHelper.DongChon(dgvPhat);
            if (r == null) { MessageBox.Show("Hãy chọn phiếu phạt."); return; }
            if (UiHelper.HienKetQua(service.ThuPhat(Convert.ToString(r["SoPhat"])))) TaiTatCa();
        }

        private void btnPhatTaiLai_Click(object sender, EventArgs e) { TaiTatCa(); }
    }
}
