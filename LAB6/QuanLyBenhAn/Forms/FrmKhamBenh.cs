using System;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    /// <summary>Tra cứu hồ sơ + lịch sử, lập phiếu khám, chỉ định xét nghiệm, chẩn đoán, lập toa thuốc, ghi phản ứng phụ.</summary>
    public class FrmKhamBenh : Form
    {
        readonly KhamBenhService kb = new KhamBenhService();
        readonly TiepNhanService tn = new TiepNhanService();
        readonly DanhMucService dm = new DanhMucService();
        readonly BindingList<DongThuoc> chon = new BindingList<DongThuoc>();

        readonly TextBox txtTim = Ui.T(200), txtTC = Ui.T(260), txtHA = Ui.T(70), txtChanDoan = Ui.T(520),
            txtKQ = Ui.T(320), txtLieu = Ui.T(220), txtLoiDan = Ui.T(420), txtPU = Ui.T(320);
        readonly ComboBox cboHS = Ui.C(260), cboKhoa = Ui.C(150), cboBS = Ui.C(160), cboLoai = Ui.C(90),
            cboLich = Ui.C(190), cboXN = Ui.C(220), cboThuoc = Ui.C(220);
        readonly DateTimePicker dtGio = Ui.D("dd/MM/yyyy HH:mm", 140);
        readonly NumericUpDown numNhiet = Ui.N(0, 45, 36.5m, 1, 70), numSL = Ui.N(1, 1000, 1, 0, 70);
        readonly Label lblHS = new Label { AutoSize = true, Margin = new Padding(8, 6, 3, 3) };
        readonly Label lblPhieu = new Label { AutoSize = true, Margin = new Padding(8, 6, 3, 3), ForeColor = System.Drawing.Color.DarkBlue };
        readonly DataGridView dgvLS = Ui.G(), dgvXN = Ui.G(), dgvChon = Ui.G(), dgvToa = Ui.G();

        string Phieu() { return Ui.Cell(dgvLS, "SoPhieuKham"); }

        public FrmKhamBenh()
        {
            Ui.Setup(this, "Khám bệnh - Hồ sơ bệnh án", 1180, 800);
            cboLoai.Items.AddRange(new object[] { "Điều trị", "Định kỳ" }); cboLoai.SelectedIndex = 0;
            cboLich.Enabled = false; dtGio.Value = DateTime.Now;
            dgvLS.Tag = 35;

            var tabs = new TabControl { Dock = DockStyle.Fill, Tag = 65 };
            tabs.TabPages.Add(Ui.Page("Xét nghiệm",
                Ui.Row(Ui.L("Chỉ định:"), cboXN, Ui.B("Thêm chỉ định", (o, e) => Sua(kb.ThemXetNghiem(Phieu(), Ui.V(cboXN))), 120)),
                Ui.Row(Ui.L("Kết quả (chọn dòng bên dưới):"), txtKQ, Ui.B("Ghi kết quả", (o, e) => Sua(kb.CapNhatKetQuaXN(Phieu(), Ui.Cell(dgvXN, "MaXN"), txtKQ.Text.Trim())), 110)),
                dgvXN));
            tabs.TabPages.Add(Ui.Page("Chẩn đoán && toa thuốc",
                Ui.Row(Ui.L("Chẩn đoán:"), txtChanDoan, Ui.B("Lưu chẩn đoán", (o, e) => Sua(kb.CapNhatChanDoan(Phieu(), txtChanDoan.Text.Trim())), 120)),
                Ui.Row(Ui.L("Thuốc:"), cboThuoc, Ui.L("SL:"), numSL, Ui.L("Liều dùng:"), txtLieu,
                    Ui.B("Thêm vào toa", ThemThuoc, 110), Ui.B("Bỏ dòng chọn", BoThuoc, 110)),
                dgvChon,
                Ui.Row(Ui.L("Lời dặn:"), txtLoiDan, Ui.B("Lập toa thuốc", LapToa, 120)),
                Ui.Row(Ui.L("Toa đã lập - phản ứng phụ của thuốc chọn:"), txtPU,
                    Ui.B("Ghi phản ứng phụ", (o, e) => Sua(kb.GhiNhanPhanUng(Phieu(), Ui.Cell(dgvToa, "MaThuoc"), txtPU.Text.Trim())), 130)),
                dgvToa));

            Controls.Add(Ui.Stack(
                Ui.Row(Ui.L("Tra cứu hồ sơ (mã / tên / SĐT):"), txtTim, Ui.B("Tìm", (o, e) => Tim(), 70), cboHS),
                lblHS,
                Ui.Row(Ui.L("Khoa:"), cboKhoa, Ui.L("Bác sĩ:"), cboBS, Ui.L("Loại:"), cboLoai, Ui.L("Lịch định kỳ:"), cboLich,
                    Ui.L("Giờ khám:"), dtGio),
                Ui.Row(Ui.L("Triệu chứng:"), txtTC, Ui.L("Thân nhiệt:"), numNhiet, Ui.L("Huyết áp:"), txtHA,
                    Ui.B("Lập phiếu khám", TaoPhieu, 130)),
                dgvLS, lblPhieu, tabs));

            dgvChon.DataSource = chon;
            cboKhoa.SelectedIndexChanged += (o, e) =>
            {
                var k = cboKhoa.SelectedValue as string;
                if (k != null) Ui.Bind(cboBS, dm.LayBacSiTheoKhoa(k), "HoTen", "MaBS");
            };
            cboLoai.SelectedIndexChanged += (o, e) => { cboLich.Enabled = cboLoai.Text == "Định kỳ"; TaiLich(); };
            cboHS.SelectedIndexChanged += (o, e) => TaiHoSo();
            dgvLS.SelectionChanged += (o, e) => TaiPhieu();
            Load += (o, e) =>
            {
                Ui.Bind(cboKhoa, dm.LayKhoa(), "TenKhoa", "MaKhoa");
                Ui.Bind(cboXN, dm.LayXetNghiem(), "TenXN", "MaXN");
                Ui.Bind(cboThuoc, dm.LayThuoc(), "TenThuoc", "MaThuoc");
            };
        }

        void Tim()
        {
            var dt = tn.TraCuuHoSo(txtTim.Text);
            if (dt.Rows.Count == 0) { MessageBox.Show("Không tìm thấy hồ sơ."); return; }
            Ui.BindHoSo(cboHS, dt);
            TaiHoSo();
        }

        void TaiLich()
        {
            string ma = Ui.V(cboHS);
            if (ma == "") { cboLich.DataSource = null; return; }
            Ui.Bind(cboLich, kb.LayLichHenChoKham(ma), "Hien", "MaLichHen");
        }

        void TaiHoSo()
        {
            string ma = Ui.V(cboHS);
            lblHS.Text = Ui.ThongTinHoSo(cboHS);
            dgvLS.DataSource = ma == "" ? null : kb.LayLichSu(ma);
            TaiLich();
            TaiPhieu();
        }

        void TaiPhieu()
        {
            string so = Phieu();
            lblPhieu.Text = so == "" ? "Chưa chọn phiếu khám." : "Phiếu đang chọn: " + so + "  (" + Ui.Cell(dgvLS, "TrangThai") + ")";
            txtChanDoan.Text = Ui.Cell(dgvLS, "ChanDoan");
            dgvXN.DataSource = so == "" ? null : kb.LayXetNghiem(so);
            dgvToa.DataSource = so == "" ? null : kb.LayToa(so);
        }

        void TaoPhieu(object o, EventArgs e)
        {
            bool dinhKy = cboLoai.Text == "Định kỳ";
            var k = kb.TaoPhieuKham(Ui.V(cboHS), Ui.V(cboBS), Ui.V(cboKhoa), cboLoai.Text, dtGio.Value, txtTC.Text.Trim(),
                numNhiet.Value > 0 ? (decimal?)numNhiet.Value : null, txtHA.Text.Trim(), dinhKy ? Ui.V(cboLich) : null);
            Ui.Msg(k);
            if (k.ThanhCong) { txtTC.Clear(); txtHA.Clear(); TaiHoSo(); }
        }

        void Sua(KetQuaXuLy k)   // sau mỗi thao tác sửa phiếu: báo kết quả rồi nạp lại phiếu đang chọn
        {
            Ui.Msg(k);
            if (!k.ThanhCong) return;
            string giu = Phieu();
            TaiHoSo();
            foreach (DataGridViewRow r in dgvLS.Rows)
                if (Convert.ToString(r.Cells["SoPhieuKham"].Value) == giu) { dgvLS.CurrentCell = r.Cells[0]; break; }
        }

        void ThemThuoc(object o, EventArgs e)
        {
            string ma = Ui.V(cboThuoc);
            if (ma == "") return;
            foreach (var x in chon) if (x.MaThuoc == ma) { MessageBox.Show("Thuốc đã có trong toa."); return; }
            chon.Add(new DongThuoc { MaThuoc = ma, TenThuoc = cboThuoc.Text, SoLuong = (int)numSL.Value, LieuDung = txtLieu.Text.Trim() });
        }

        void BoThuoc(object o, EventArgs e)
        {
            if (dgvChon.CurrentRow != null && dgvChon.CurrentRow.Index < chon.Count) chon.RemoveAt(dgvChon.CurrentRow.Index);
        }

        void LapToa(object o, EventArgs e)
        {
            var k = kb.LapToaThuoc(Phieu(), txtLoiDan.Text.Trim(), new System.Collections.Generic.List<DongThuoc>(chon));
            if (k.ThanhCong) { chon.Clear(); txtLoiDan.Clear(); }
            Sua(k);
        }
    }
}
