using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    /// <summary>Sau khi khám: lập hóa đơn viện phí -> thanh toán -> xuất viện/ghi nhận hồ sơ.</summary>
    public class FrmVienPhi : Form
    {
        readonly VienPhiService vp = new VienPhiService();
        readonly DanhMucService dm = new DanhMucService();
        readonly DataGridView dgvPhieu = Ui.G(), dgvHD = Ui.G(), dgvTT = Ui.G();
        readonly ComboBox cboThuNgan = Ui.C(170), cboHT = Ui.C(130), cboCSKH = Ui.C(170);
        readonly NumericUpDown numTien = Ui.N(0, 1000000000, 0, 0, 120);

        string Phieu() { return Ui.Cell(dgvPhieu, "SoPhieuKham"); }
        string HD() { return Ui.Cell(dgvHD, "SoHoaDon"); }

        public FrmVienPhi()
        {
            Ui.Setup(this, "Viện phí - Thanh toán - Hoàn tất đợt điều trị", 1000, 700);
            cboHT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" }); cboHT.SelectedIndex = 0;
            Controls.Add(Ui.Stack(
                Ui.L("1) Phiếu khám đang điều trị:"), dgvPhieu,
                Ui.Row(Ui.L("Thu ngân:"), cboThuNgan, Ui.B("Lập hóa đơn", (o, e) => { Ui.Msg(vp.LapHoaDon(Phieu(), Ui.V(cboThuNgan))); Tai(); }, 120)),
                dgvHD,
                Ui.Row(Ui.L("2) Hình thức:"), cboHT, Ui.L("Số tiền:"), numTien, Ui.B("Thanh toán", ThanhToan, 110)),
                dgvTT,
                Ui.Row(Ui.L("3) NV CSKH ghi nhận:"), cboCSKH, Ui.B("Hoàn tất && xuất viện", (o, e) => { Ui.Msg(vp.HoanTat(Phieu(), Ui.V(cboCSKH))); Tai(); }, 160))));
            dgvPhieu.SelectionChanged += (o, e) => TaiHD();
            dgvHD.SelectionChanged += (o, e) => TaiTT();
            Load += (o, e) =>
            {
                Ui.Bind(cboThuNgan, dm.LayNhanVien(), "HoTen", "MaNV");
                Ui.Bind(cboCSKH, dm.LayNhanVien(), "HoTen", "MaNV");
                Tai();
            };
        }

        void Tai()
        {
            string giu = Phieu();
            dgvPhieu.DataSource = vp.LayPhieuCanXuLy();
            foreach (DataGridViewRow r in dgvPhieu.Rows)
                if (Convert.ToString(r.Cells["SoPhieuKham"].Value) == giu) { dgvPhieu.CurrentCell = r.Cells[0]; break; }
            TaiHD();
        }

        void TaiHD() { string p = Phieu(); dgvHD.DataSource = p == "" ? null : vp.LayHoaDon(p); }

        void TaiTT()
        {
            string h = HD();
            dgvTT.DataSource = h == "" ? null : vp.LayThanhToan(h);
            if (dgvHD.CurrentRow != null && dgvHD.Columns.Contains("ConLai"))
            {
                decimal con = Convert.ToDecimal(dgvHD.CurrentRow.Cells["ConLai"].Value);
                numTien.Value = Math.Max(0, Math.Min(numTien.Maximum, con));
            }
        }

        void ThanhToan(object o, EventArgs e)
        {
            var k = vp.ThanhToan(HD(), cboHT.Text, numTien.Value);
            Ui.Msg(k);
            if (k.ThanhCong) Tai();
        }
    }
}
