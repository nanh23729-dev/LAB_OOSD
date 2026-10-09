using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCongTyDuLich.Services;

namespace QuanLyCongTyDuLich.Forms
{
    /// <summary>Tiện ích dùng chung cho các Form: nạp ComboBox, báo kết quả, và làm đẹp giao diện (lưới, nút).</summary>
    internal static class FormHelper
    {
        public static void Nap(ComboBox cbo, DataTable dt, string display, string value)
        {
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = dt;
        }

        public static string Gia(ComboBox cbo)
        {
            return cbo.SelectedValue == null ? "" : cbo.SelectedValue.ToString();
        }

        public static string O(DataGridView dgv, string cot)
        {
            return dgv.CurrentRow == null ? "" : System.Convert.ToString(dgv.CurrentRow.Cells[cot].Value);
        }

        /// <summary>Hiển thị kết quả; trả về true nếu thành công.</summary>
        public static bool Bao(KetQuaXuLy k)
        {
            MessageBox.Show(k.ThongBao, k.ThanhCong ? "Thông báo" : "Không thực hiện được",
                MessageBoxButtons.OK, k.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            return k.ThanhCong;
        }

        // ------------------------------------------------------------------
        // Giao diện: gọi FormHelper.Dep(this) ngay sau InitializeComponent()
        // ------------------------------------------------------------------
        private static readonly Dictionary<string, string> TieuDeCot = new Dictionary<string, string>
        {
            {"MaPT","Mã PT"}, {"TenPT","Tên phương tiện"}, {"GhiChu","Ghi chú"},
            {"MaDiemBan","Mã điểm bán"}, {"TenDiemBan","Tên điểm bán"}, {"DiaChi","Địa chỉ"}, {"DienThoai","Điện thoại"},
            {"MaHDV","Mã HDV"}, {"HoTen","Họ tên"}, {"LuongCoBan","Lương căn bản"}, {"DangLamViec","Đang làm việc"},
            {"MaDiemTQ","Mã điểm TQ"}, {"TenDiemTQ","Tên điểm tham quan"}, {"DiaDiem","Địa điểm"}, {"NoiDung","Nội dung"}, {"YNghia","Ý nghĩa"},
            {"MaTour","Mã tour"}, {"TenTour","Tên tour"}, {"SoNgay","Số ngày"}, {"SoDem","Số đêm"}, {"DonGiaKhach","Đơn giá / khách"},
            {"MoTa","Mô tả"}, {"DangMoBan","Đang mở bán"}, {"ThuTu","Thứ tự"}, {"TenDiemDung","Tên điểm dừng"}, {"DoiPhuongTien","Đổi phương tiện"},
            {"CoNoiAn","Có nơi ăn"}, {"CoKhachSan","Có khách sạn"}, {"HangSaoKhachSan","Hạng sao"}, {"ThuTuChang","Chặng"},
            {"MaChuyen","Mã chuyến"}, {"NgayDi","Ngày đi"}, {"NgayVe","Ngày về"}, {"DiaDiemDon","Địa điểm đón"}, {"TrangThai","Trạng thái"},
            {"SoDKLe","Số ĐK"}, {"TenNguoiDangKy","Người đăng ký"}, {"SoNguoi","Số người"}, {"ThanhTien","Thành tiền"},
            {"SoDKDoan","Phiếu đoàn"}, {"TenCoQuanDaiDien","Cơ quan / gia đình"}, {"NgayKetThucDuKien","Kết thúc dự kiến"},
            {"MuaBaoHiem","Bảo hiểm"}, {"TienCoc","Tiền cọc"}, {"TongTienDuKien","Tổng dự kiến"}, {"NgaySinh","Ngày sinh"}, {"SoGiayTo","Số giấy tờ"},
            {"MaPC","Mã PC"}, {"LoaiDoiTuong","Loại"}, {"DoiTuong","Chuyến / đoàn"}, {"NgayBatDau","Ngày bắt đầu"}, {"NgayKetThuc","Ngày kết thúc"},
            {"ThuLaoTour","Thù lao tour"}, {"DaTraSauTour","Đã trả sau tour"}, {"ConLai","Còn lại"},
            {"MaKhaoSat","Mã khảo sát"}, {"LoaiKhach","Loại khách"}, {"SoDangKy","Số đăng ký"}, {"NgayGui","Ngày gửi"},
            {"NgayPhanHoi","Ngày phản hồi"}, {"DiemDanhGia","Điểm"}, {"GopY","Góp ý"},
            {"SoTour","Số tour"}, {"LuongTheoTour","Lương theo tour"}, {"TongLuong","Tổng lương"},
            {"ChiSo","Chỉ số"}, {"SoLuong","Số lượng"}, {"GiaTri","Giá trị"}
        };

        public static void Dep(Control goc)
        {
            foreach (Control c in goc.Controls)
            {
                var g = c as DataGridView;
                if (g != null) DepLuoi(g);
                var b = c as Button;
                if (b != null) DepNut(b);
                if (c.HasChildren && g == null) Dep(c);
            }
        }

        private static void DepNut(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.UseVisualStyleBackColor = false;
            b.BackColor = Color.FromArgb(225, 225, 225);
            b.FlatAppearance.BorderColor = Color.FromArgb(173, 173, 173);
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 228, 247);
            b.Cursor = Cursors.Hand;
        }

        private static void DepLuoi(DataGridView g)
        {
            g.BorderStyle = BorderStyle.FixedSingle;
            g.BackgroundColor = Color.White;
            g.GridColor = Color.FromArgb(222, 226, 230);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 32;
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            g.RowHeadersWidth = 30;
            g.RowTemplate.Height = 28;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 253);
            g.DefaultCellStyle.Padding = new Padding(2, 0, 2, 0);

            // Lưới nằm trong tab chưa mở sẽ bị tính sai độ rộng cột: chỉnh lại khi nạp xong dữ liệu và khi hiện ra.
            g.DataBindingComplete += (s, e) => DinhDangCot(g);
            g.VisibleChanged += (s, e) => { if (g.Visible) VuaCot(g); };
        }

        private static void DinhDangCot(DataGridView g)
        {
            foreach (DataGridViewColumn col in g.Columns)
            {
                string h;
                if (TieuDeCot.TryGetValue(col.Name, out h)) col.HeaderText = h;
                Type t = col.ValueType;
                if (t == typeof(decimal) || t == typeof(decimal?))
                {
                    col.DefaultCellStyle.Format = "#,##0.##";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (t == typeof(DateTime) || t == typeof(DateTime?))
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            VuaCot(g);
        }

        private static void VuaCot(DataGridView g)
        {
            try
            {
                foreach (DataGridViewColumn col in g.Columns)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception) { }
        }
    }
}
