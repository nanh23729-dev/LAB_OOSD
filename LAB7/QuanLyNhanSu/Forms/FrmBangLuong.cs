using System;
using System.Data;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmBangLuong : Form
    {
        private readonly BangLuongService service = new BangLuongService();

        public FrmBangLuong() { InitializeComponent(); }

        private void FrmBangLuong_Load(object sender, EventArgs e)
        {
            numThang.Value = DateTime.Today.Month;
            numNam.Value = DateTime.Today.Year;
            TaiBangLuong();
        }

        private void TaiBangLuong()
        {
            DataTable t = service.LayBangLuong((int)numThang.Value, (int)numNam.Value);
            UiHelper.HienLuoi(dgvBangLuong, t);
            decimal tong = 0;
            foreach (DataRow r in t.Rows) tong += Convert.ToDecimal(r["ThucLinh"]);
            lblTongNV.Text = "Số nhân viên: " + t.Rows.Count;
            lblTongThucLinh.Text = "Tổng thực lĩnh: " + tong.ToString("N0") + " đ";
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (!UiHelper.XacNhan("Lập (lại) bảng lương tháng " + numThang.Value + "/" + numNam.Value +
                                  "? Bảng lương cũ của tháng này sẽ được tính lại.")) return;
            UiHelper.HienKetQua(service.TinhBangLuong((int)numThang.Value, (int)numNam.Value));
            TaiBangLuong();
        }

        private void btnXem_Click(object sender, EventArgs e) { TaiBangLuong(); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
