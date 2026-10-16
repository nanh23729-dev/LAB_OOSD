using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public class FrmDanhMuc : Form
    {
        readonly DanhMucService s = new DanhMucService();
        readonly List<Action> nap = new List<Action>();
        readonly ComboBox cboKhoa = Ui.C(150), cboVaiTro = Ui.C(110);

        public FrmDanhMuc()
        {
            Ui.Setup(this, "Danh mục", 960, 540);
            cboVaiTro.Items.AddRange(new object[] { "Tiếp nhận", "CSKH", "Thu ngân", "Quản lý" });
            cboVaiTro.SelectedIndex = 0;
            var tc = new TabControl { Dock = DockStyle.Fill };
            tc.TabPages.Add(Tab("Khoa", new[] { "Mã khoa", "Tên khoa", "Phí khám" },
                a => s.ThemKhoa(a[0], a[1], Ui.Dec(a[2])), s.LayKhoa, null));
            tc.TabPages.Add(Tab("Bác sĩ", new[] { "Mã BS", "Họ tên", "Chuyên môn" },
                a => s.ThemBacSi(a[0], a[1], a[3], a[2]), s.LayBacSi, cboKhoa));
            tc.TabPages.Add(Tab("Nhân viên", new[] { "Mã NV", "Họ tên", "SĐT" },
                a => s.ThemNhanVien(a[0], a[1], a[2], a[3]), s.LayNhanVien, cboVaiTro));
            tc.TabPages.Add(Tab("Thuốc", new[] { "Mã thuốc", "Tên thuốc", "Đơn vị tính", "Đơn giá" },
                a => s.ThemThuoc(a[0], a[1], a[2], Ui.Dec(a[3])), s.LayThuoc, null));
            tc.TabPages.Add(Tab("Xét nghiệm", new[] { "Mã XN", "Tên XN", "Đơn giá" },
                a => s.ThemXetNghiem(a[0], a[1], Ui.Dec(a[2])), s.LayXetNghiem, null));
            Controls.Add(tc);
            Load += (o, e) => Tai();
        }

        void Tai()
        {
            Ui.Bind(cboKhoa, s.LayKhoa(), "TenKhoa", "MaKhoa");
            foreach (var n in nap) n();
        }

        TabPage Tab(string title, string[] labels, Func<string[], KetQuaXuLy> them, Func<DataTable> lay, ComboBox extra)
        {
            var tb = labels.Select(x => Ui.T(120)).ToArray();
            var g = Ui.G();
            var row = Ui.Row();
            for (int i = 0; i < labels.Length; i++) { row.Controls.Add(Ui.L(labels[i] + ":")); row.Controls.Add(tb[i]); }
            if (extra != null) { row.Controls.Add(Ui.L(extra == cboKhoa ? "Khoa:" : "Vai trò:")); row.Controls.Add(extra); }
            row.Controls.Add(Ui.B("Thêm", (o, e) =>
            {
                var a = tb.Select(x => x.Text.Trim()).ToList();
                if (extra != null) a.Add(Ui.V(extra));
                var k = them(a.ToArray());
                Ui.Msg(k);
                if (k.ThanhCong) { foreach (var x in tb) x.Clear(); Tai(); }
            }, 80));
            nap.Add(() => g.DataSource = lay());
            return Ui.Page(title, row, g);
        }
    }
}
