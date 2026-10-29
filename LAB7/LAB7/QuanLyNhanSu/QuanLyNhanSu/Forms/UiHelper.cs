using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    // Các hàm giao diện dùng chung cho mọi Form
    public static class UiHelper
    {
        public static bool HienKetQua(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            return kq.ThanhCong;
        }

        public static bool XacNhan(string noiDung)
        {
            return MessageBox.Show(noiDung, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // Gán DataTable cho lưới, định dạng tiền N0 và ngày dd/MM/yyyy
        public static void HienLuoi(DataGridView dgv, DataTable data)
        {
            dgv.DataSource = data;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.ValueType == typeof(DateTime)) col.DefaultCellStyle.Format = "dd/MM/yyyy";
                else if (col.ValueType == typeof(decimal))
                {
                    string ten = col.Name;
                    bool laSoNgayGio = ten.StartsWith("SoNgay") || ten.StartsWith("SoGio") || ten.StartsWith("Gio") || ten.StartsWith("TyLe");
                    col.DefaultCellStyle.Format = laSoNgayGio ? "N1" : "N0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        public static void GanCombo(ComboBox cbo, DataTable data, string hienThi, string giaTri)
        {
            cbo.DataSource = data;
            cbo.DisplayMember = hienThi;
            cbo.ValueMember = giaTri;
        }

        public static string LayMa(ComboBox cbo)
        {
            return cbo.SelectedValue == null ? "" : cbo.SelectedValue.ToString();
        }

        // Lấy dòng đang chọn của lưới (null nếu chưa chọn)
        public static DataRowView DongChon(DataGridView dgv)
        {
            if (dgv.CurrentRow == null) return null;
            return dgv.CurrentRow.DataBoundItem as DataRowView;
        }
    }
}
