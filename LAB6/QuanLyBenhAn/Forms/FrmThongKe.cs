using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public class FrmThongKe : Form
    {
        readonly ThongKeService s = new ThongKeService();
        readonly DateTimePicker dtTu = Ui.D(), dtDen = Ui.D();
        readonly DataGridView dgvTongHop = Ui.G(), dgvThuoc = Ui.G();

        public FrmThongKe()
        {
            Ui.Setup(this, "Thống kê", 900, 520);
            dtTu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dgvTongHop.Tag = 30;
            Controls.Add(Ui.Stack(
                Ui.Row(Ui.L("Từ ngày:"), dtTu, Ui.L("Đến ngày:"), dtDen, Ui.B("Thống kê", ThongKe, 100)),
                dgvTongHop, Ui.L("Thuốc đã kê trong khoảng thời gian:"), dgvThuoc));
        }

        void ThongKe(object o, EventArgs e)
        {
            if (dtDen.Value.Date < dtTu.Value.Date) { MessageBox.Show("Đến ngày không được trước từ ngày."); return; }
            dgvTongHop.DataSource = s.TongHop(dtTu.Value, dtDen.Value);
            dgvThuoc.DataSource = s.ThuocSuDung(dtTu.Value, dtDen.Value);
        }
    }
}
