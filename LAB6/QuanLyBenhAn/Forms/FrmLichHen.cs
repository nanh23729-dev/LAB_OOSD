using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public class FrmLichHen : Form
    {
        readonly LichHenService lh = new LichHenService();
        readonly TiepNhanService tn = new TiepNhanService();
        readonly DanhMucService dm = new DanhMucService();
        readonly TextBox txtTim = Ui.T(200);
        readonly ComboBox cboHS = Ui.C(260), cboQuy = Ui.C(60), cboNV = Ui.C(170);
        readonly NumericUpDown numNam = Ui.N(2000, 2100, DateTime.Now.Year, 0, 70);
        readonly DateTimePicker dtGio = Ui.D("dd/MM/yyyy HH:mm", 140);
        readonly Label lblHS = new Label { AutoSize = true, Margin = new Padding(8, 6, 3, 3) };
        readonly DataGridView dgv = Ui.G();

        public FrmLichHen()
        {
            Ui.Setup(this, "Lịch khám sức khỏe định kỳ theo quý (miễn phí)", 900, 520);
            cboQuy.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cboQuy.SelectedIndex = (DateTime.Now.Month - 1) / 3;
            dtGio.Value = DateTime.Now.AddDays(1).Date.AddHours(8);
            Controls.Add(Ui.Stack(
                Ui.Row(Ui.L("Tra cứu hồ sơ (mã / tên / SĐT):"), txtTim, Ui.B("Tìm", (o, e) => Tim(), 70), cboHS),
                lblHS, dgv,
                Ui.Row(Ui.L("Quý:"), cboQuy, Ui.L("Năm:"), numNam, Ui.L("Ngày giờ hẹn:"), dtGio, Ui.L("NV CSKH:"), cboNV,
                    Ui.B("Đặt lịch", DatLich, 90), Ui.B("Hủy lịch chọn", (o, e) => { var k = lh.Huy(Ui.Cell(dgv, "MaLichHen")); Ui.Msg(k); if (k.ThanhCong) Tai(); }, 120))));
            cboHS.SelectedIndexChanged += (o, e) => Tai();
            Load += (o, e) => Ui.Bind(cboNV, dm.LayNhanVien(), "HoTen", "MaNV");
        }

        void Tim()
        {
            var dt = tn.TraCuuHoSo(txtTim.Text);
            if (dt.Rows.Count == 0) { MessageBox.Show("Không tìm thấy hồ sơ."); return; }
            Ui.BindHoSo(cboHS, dt);
            Tai();
        }

        void Tai()
        {
            string ma = Ui.V(cboHS);
            lblHS.Text = Ui.ThongTinHoSo(cboHS);
            dgv.DataSource = ma == "" ? null : lh.LayLichHen(ma);
        }

        void DatLich(object o, EventArgs e)
        {
            var k = lh.DatLich(Ui.V(cboHS), int.Parse(cboQuy.Text), (int)numNam.Value, dtGio.Value, Ui.V(cboNV));
            Ui.Msg(k);
            if (k.ThanhCong) Tai();
        }
    }
}
