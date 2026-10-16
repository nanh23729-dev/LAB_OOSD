using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    /// <summary>Hàm dựng control dùng chung: các Form được dựng bằng code nên không cần file Designer.</summary>
    static class Ui
    {
        public static void Setup(Form f, string title, int w, int h)
        {
            f.Text = title; f.ClientSize = new Size(w, h);
            f.StartPosition = FormStartPosition.CenterParent;
            f.Font = new Font("Segoe UI", 9.5f);
        }
        public static Label L(string t) { return new Label { Text = t, AutoSize = true, Margin = new Padding(8, 9, 2, 0) }; }
        public static TextBox T(int w = 140) { return new TextBox { Width = w, Margin = new Padding(2, 5, 2, 2) }; }
        public static NumericUpDown N(decimal min, decimal max, decimal val, int dec = 0, int w = 100)
        {
            return new NumericUpDown { Minimum = min, Maximum = max, Value = val, DecimalPlaces = dec, Width = w, ThousandsSeparator = true, Margin = new Padding(2, 5, 2, 2) };
        }
        public static ComboBox C(int w = 160) { return new ComboBox { Width = w, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(2, 5, 2, 2) }; }
        public static DateTimePicker D(string fmt = "dd/MM/yyyy", int w = 110)
        {
            return new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = fmt, Width = w, Margin = new Padding(2, 5, 2, 2) };
        }
        public static Button B(string t, EventHandler h, int w = 140)
        {
            var b = new Button { Text = t, Width = w, Height = 28, Margin = new Padding(4, 3, 4, 3) };
            b.Click += h; return b;
        }
        public static DataGridView G()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false, RowHeadersVisible = false, BackgroundColor = SystemColors.Window
            };
        }
        public static FlowLayoutPanel Row(params Control[] c)
        {
            var f = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
            f.Controls.AddRange(c); return f;
        }
        /// <summary>Xếp các control từ trên xuống. DataGridView/TabControl giãn hết chỗ còn lại (Tag = trọng số, mặc định 100).</summary>
        public static TableLayoutPanel Stack(params Control[] rows)
        {
            var t = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = rows.Length };
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < rows.Length; i++)
            {
                bool fill = rows[i] is DataGridView || rows[i] is TabControl;
                float w = rows[i].Tag is int ? (int)rows[i].Tag : 100;
                t.RowStyles.Add(fill ? new RowStyle(SizeType.Percent, w) : new RowStyle(SizeType.AutoSize));
                rows[i].Dock = DockStyle.Fill;
                t.Controls.Add(rows[i], 0, i);
            }
            return t;
        }
        public static TabPage Page(string title, params Control[] rows)
        {
            var p = new TabPage(title); p.Controls.Add(Stack(rows)); return p;
        }
        public static void Bind(ComboBox c, DataTable dt, string disp, string val)
        {
            c.DataSource = dt; c.DisplayMember = disp; c.ValueMember = val;
        }
        public static void BindHoSo(ComboBox c, DataTable dt)
        {
            if (!dt.Columns.Contains("Hien")) dt.Columns.Add("Hien", typeof(string), "MaHoSo + ' - ' + HoTen");
            Bind(c, dt, "Hien", "MaHoSo");
        }
        public static string ThongTinHoSo(ComboBox c)
        {
            var r = c.SelectedItem as DataRowView;
            if (r == null) return "";
            string sinh = r["NgaySinh"] is DateTime ? ((DateTime)r["NgaySinh"]).ToString("dd/MM/yyyy") : "";
            return "Bệnh nhân: " + r["HoTen"] + "  |  Ngày sinh: " + sinh + "  |  SĐT: " + r["SoDienThoai"]
                 + "  |  Lệ phí đã đóng đến năm: " + (r["LePhiDenNam"] == DBNull.Value ? "chưa" : r["LePhiDenNam"].ToString());
        }
        public static string V(ComboBox c)
        {
            if (c.SelectedValue is string) return (string)c.SelectedValue;
            return c.DataSource == null ? c.Text : "";
        }
        public static string Cell(DataGridView g, string col)
        {
            if (g.CurrentRow == null || !g.Columns.Contains(col)) return "";
            return Convert.ToString(g.CurrentRow.Cells[col].Value);
        }
        public static decimal Dec(string s)
        {
            decimal d; return decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out d) ? d : -1;
        }
        public static void Msg(KetQuaXuLy k)
        {
            MessageBox.Show(k.ThongBao, k.ThanhCong ? "Thành công" : "Từ chối", MessageBoxButtons.OK,
                k.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
