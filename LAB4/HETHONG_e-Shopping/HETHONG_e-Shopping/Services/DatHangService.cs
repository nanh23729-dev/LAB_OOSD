using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using EShopping.Data;
using EShopping.Models;

namespace EShopping.Services
{
    public class DatHangService
    {
        private IPaymentGateway thanhToan;
        private IEmailService email;

        public DatHangService(IPaymentGateway pg, IEmailService em)
        {
            thanhToan = pg;
            email = em;
        }

        // ---------- Quy tắc tính tiền ----------

        public decimal TinhPhiGiao(LoaiGiao loai, KhuVuc kv, decimal tienHang)
        {
            // Miễn phí theo giá trị đơn hàng
            if (loai == LoaiGiao.Nhanh && tienHang >= 1000000m)
                return 0;
            if (loai == LoaiGiao.TrongNgay && tienHang >= 5000000m)
                return 0;

            // Phí theo loại giao và khu vực (số liệu tự giả định)
            switch (loai)
            {
                case LoaiGiao.Thuong:
                    if (kv == KhuVuc.NoiThanh) return 15000;
                    if (kv == KhuVuc.NgoaiThanh) return 25000;
                    return 35000;

                case LoaiGiao.Nhanh:
                    if (kv == KhuVuc.NoiThanh) return 30000;
                    if (kv == KhuVuc.NgoaiThanh) return 45000;
                    return 60000;

                default: // TrongNgay
                    if (kv == KhuVuc.NoiThanh) return 50000;
                    if (kv == KhuVuc.NgoaiThanh) return 70000;
                    return 90000;
            }
        }

        // Lệ phí thẻ tính theo % của (tiền hàng + phí giao)
        public decimal TinhLePhiThe(LoaiThe loai, decimal soTien)
        {
            decimal tyLe = 0;
            switch (loai)
            {
                case LoaiThe.Visa: tyLe = 0.010m; break;
                case LoaiThe.Master: tyLe = 0.012m; break;
                case LoaiThe.Discover: tyLe = 0.015m; break;
                case LoaiThe.AmericanExpress: tyLe = 0.025m; break;
            }
            return Math.Round(soTien * tyLe, 0);
        }

        public ChiPhi TinhChiPhi(List<CartItem> gio, LoaiGiao lg, KhuVuc kv, LoaiThe lt)
        {
            decimal tienHang = 0;
            foreach (CartItem sp in gio)
            {
                tienHang = tienHang + sp.ThanhTien;
            }

            ChiPhi cp = new ChiPhi();
            cp.TienHang = tienHang;
            cp.PhiGiao = TinhPhiGiao(lg, kv, tienHang);
            cp.LePhiThe = TinhLePhiThe(lt, tienHang + cp.PhiGiao);
            return cp;
        }

        // ---------- Kiểm tra thẻ ----------

        public ServiceResult KiemTraThe(TheTinDung the)
        {
            if (the == null)
                return ServiceResult.Fail("Thiếu thông tin thẻ.");

            bool laAmex = (the.Loai == LoaiThe.AmericanExpress);
            string so = (the.SoThe == null) ? "" : the.SoThe.Replace(" ", "");
            int doDaiSo = laAmex ? 15 : 16;
            int doDaiCsv = laAmex ? 4 : 3;

            if (!Regex.IsMatch(so, @"^\d+$") || so.Length != doDaiSo)
                return ServiceResult.Fail("Số thẻ phải gồm " + doDaiSo + " chữ số.");

            if (KiemTraLuhn(so) == false)
                return ServiceResult.Fail("Số thẻ không hợp lệ (sai thuật toán Luhn).");

            string csv = (the.Csv == null) ? "" : the.Csv;
            if (!Regex.IsMatch(csv, @"^\d+$") || csv.Length != doDaiCsv)
                return ServiceResult.Fail("CSV phải gồm " + doDaiCsv + " chữ số.");

            DateTime hetHan;
            bool ok = DateTime.TryParseExact(the.HetHan, "MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out hetHan);
            if (ok == false)
                return ServiceResult.Fail("Hạn sử dụng phải đúng dạng MM/yyyy.");

            // Thẻ dùng được đến hết tháng hết hạn
            DateTime ngayHetHan = hetHan.AddMonths(1);
            if (ngayHetHan <= DateTime.Today)
                return ServiceResult.Fail("Thẻ đã hết hạn.");

            if (string.IsNullOrWhiteSpace(the.TenChuThe))
                return ServiceResult.Fail("Thiếu họ tên chủ thẻ.");

            return ServiceResult.Ok("Thẻ hợp lệ.");
        }

        // Thuật toán Luhn: từ phải sang trái, cứ chữ số thứ 2 thì nhân đôi
        private bool KiemTraLuhn(string so)
        {
            int tong = 0;
            bool nhanDoi = false;
            for (int i = so.Length - 1; i >= 0; i--)
            {
                int chuSo = so[i] - '0';
                if (nhanDoi)
                {
                    chuSo = chuSo * 2;
                    if (chuSo > 9)
                        chuSo = chuSo - 9;
                }
                tong = tong + chuSo;
                nhanDoi = !nhanDoi;
            }
            return tong % 10 == 0;
        }

        // ---------- Quy trình đặt hàng ----------

        public ServiceResult DatHang(DonHangRequest rq)
        {
            // 1. Kiểm tra đầu vào
            if (rq.MaKH <= 0)
                return ServiceResult.Fail("Bạn cần đăng nhập trước khi đặt hàng.");

            if (rq.Gio == null || rq.Gio.Count == 0)
                return ServiceResult.Fail("Giỏ hàng đang trống.");

            foreach (CartItem sp in rq.Gio)
            {
                if (sp.SoLuong <= 0)
                    return ServiceResult.Fail("Số lượng sản phẩm không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(rq.TenNguoiNhan) || string.IsNullOrWhiteSpace(rq.DiaChiNhan))
                return ServiceResult.Fail("Thiếu họ tên hoặc địa chỉ người nhận.");

            if (!Regex.IsMatch(rq.DienThoaiNhan.Trim(), @"^0\d{9}$"))
                return ServiceResult.Fail("Điện thoại người nhận không hợp lệ.");

            // 2. Kiểm tra thẻ
            ServiceResult kqThe = KiemTraThe(rq.The);
            if (kqThe.Success == false)
                return kqThe;

            // 3. Tính tiền
            ChiPhi cp = TinhChiPhi(rq.Gio, rq.LoaiGiao, rq.KhuVuc, rq.The.Loai);

            // 4. Gọi dịch vụ thanh toán bên ngoài
            ServiceResult kqTT = thanhToan.Authorize(rq.The, cp.Tong);
            if (kqTT.Success == false)
                return kqTT;

            // 5. Lưu đơn hàng
            int maDH = LuuDonHang(rq, cp);

            // 6. Gửi email xác nhận nếu khách có email
            GuiEmailXacNhan(maDH, rq, cp);

            return ServiceResult.Ok("Đặt hàng thành công! Mã đơn: " + maDH +
                ". Tổng thanh toán: " + cp.Tong.ToString("N0") + " đ", maDH);
        }

        private int LuuDonHang(DonHangRequest rq, ChiPhi cp)
        {
            string so = rq.The.SoThe.Replace(" ", "");
            string cuoi4 = so.Substring(so.Length - 4);

            string sql = "INSERT INTO DonHang(MaKH, LoaiGiao, KhuVuc, TenNguoiNhan, DiaChiNhan, " +
                         "DienThoaiNhan, LoaiThe, SoTheCuoi4, TenChuThe, TienHang, PhiGiao, LePhiThe, TongTien) " +
                         "VALUES(@kh, @lg, @kv, @tn, @dc, @dt, @lt, @c4, @ct, @th, @pg, @lp, @tong); " +
                         "SELECT SCOPE_IDENTITY();";

            object kq = Db.ExecuteScalar(sql,
                new SqlParameter("@kh", rq.MaKH),
                new SqlParameter("@lg", rq.LoaiGiao.ToString()),
                new SqlParameter("@kv", rq.KhuVuc.ToString()),
                new SqlParameter("@tn", rq.TenNguoiNhan.Trim()),
                new SqlParameter("@dc", rq.DiaChiNhan.Trim()),
                new SqlParameter("@dt", rq.DienThoaiNhan.Trim()),
                new SqlParameter("@lt", rq.The.Loai.ToString()),
                new SqlParameter("@c4", cuoi4),
                new SqlParameter("@ct", rq.The.TenChuThe.Trim()),
                new SqlParameter("@th", cp.TienHang),
                new SqlParameter("@pg", cp.PhiGiao),
                new SqlParameter("@lp", cp.LePhiThe),
                new SqlParameter("@tong", cp.Tong));

            int maDH = Convert.ToInt32(kq);

            foreach (CartItem sp in rq.Gio)
            {
                Db.ExecuteNonQuery(
                    "INSERT INTO ChiTietDonHang(MaDH, MaSP, TenSP, SoLuong, DonGia) " +
                    "VALUES(@ma, @sp, @ten, @sl, @gia)",
                    new SqlParameter("@ma", maDH),
                    new SqlParameter("@sp", sp.MaSP),
                    new SqlParameter("@ten", sp.TenSP),
                    new SqlParameter("@sl", sp.SoLuong),
                    new SqlParameter("@gia", sp.DonGia));
            }
            return maDH;
        }

        private void GuiEmailXacNhan(int maDH, DonHangRequest rq, ChiPhi cp)
        {
            DataTable dt = Db.ExecuteQuery("SELECT Email FROM KhachHang WHERE MaKH = @id",
                new SqlParameter("@id", rq.MaKH));

            if (dt.Rows.Count == 0 || dt.Rows[0]["Email"] == DBNull.Value)
                return;

            string diaChiMail = dt.Rows[0]["Email"].ToString();

            // Nội dung email KHÔNG có thông tin thẻ
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Don hang #" + maDH + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            foreach (CartItem sp in rq.Gio)
            {
                sb.AppendLine("- " + sp.TenSP + " x" + sp.SoLuong + " = " + sp.ThanhTien.ToString("N0"));
            }
            sb.AppendLine("Nguoi nhan: " + rq.TenNguoiNhan + " | " + rq.DienThoaiNhan + " | " + rq.DiaChiNhan);
            sb.AppendLine("Hinh thuc giao: " + rq.LoaiGiao);
            sb.AppendLine("Tien hang: " + cp.TienHang.ToString("N0"));
            sb.AppendLine("Phi giao: " + cp.PhiGiao.ToString("N0"));
            sb.AppendLine("Le phi the: " + cp.LePhiThe.ToString("N0"));
            sb.AppendLine("TONG: " + cp.Tong.ToString("N0"));

            email.Gui(diaChiMail, "Xac nhan don hang #" + maDH, sb.ToString());
        }
    }
}