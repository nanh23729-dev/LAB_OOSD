# BÀI THỰC HÀNH 4: HỆ THỐNG CỬA HÀNG ONLINE e-SHOPPING

Môn: Phân tích thiết kế hướng đối tượng (OOSD)
Từ phân tích yêu cầu - UML - CSDL - Giao diện - đến code C# WinForms

## Thông tin sinh viên

| | |
|---|---|
| Họ và tên |Nguyễn Hoàng Anh |
| MSSV | 1250080006 |
| Lớp | 12DHCNPM1 |
| Trường | Trường Đại học Tài nguyên và Môi trường TP.HCM |
| Bài | LAB 4 - e-SHOPPING |

## 1. Giới thiệu

Cửa hàng ABC mở thêm hệ thống bán hàng online e-SHOPPING. Bài thực hành xây dựng prototype các nghiệp vụ chính: **đăng ký tài khoản, đăng nhập, tính phí giao hàng và lệ phí thẻ, kiểm tra thẻ tín dụng, đặt hàng, lưu đơn và gửi email xác nhận**.

Hệ thống phân biệt rõ chức năng bên trong với 3 hệ thống/dịch vụ bên ngoài:

| Bên ngoài hệ thống | Cách xử lý trong bài |
|---|---|
| Hệ thống quản lý sản phẩm | Giả lập bằng giỏ hàng mẫu trong `FrmMain` |
| Dịch vụ thanh toán trực tuyến | Adapter `IPaymentGateway` + `MockPaymentGateway` |
| Dịch vụ email | Adapter `IEmailService` + `MockEmailService` |

## 2. Công nghệ

- C# Windows Forms, **.NET Framework 4.7.2**
- SQL Server (Express / LocalDB), ADO.NET (`System.Data.SqlClient`)
- Visual Studio 2022
- Mật khẩu băm bằng PBKDF2 (`Rfc2898DeriveBytes`, SHA256, 100.000 vòng) kèm salt ngẫu nhiên

## 3. Cài đặt và chạy

### Yêu cầu
- Windows, Visual Studio 2022 (workload **.NET desktop development**)
- SQL Server Express hoặc LocalDB, và SQL Server Management Studio (SSMS)

### Bước 1. Lấy mã nguồn
```
git clone https://github.com/giangminhle/LAB_OOSD.git
```
Mở file `LAB4/EShopping/EShopping.sln` bằng Visual Studio.

### Bước 2. Tạo cơ sở dữ liệu
1. Mở SSMS, kết nối vào SQL Server của máy.
2. Mở file `SQL/eShopping.sql` → **Execute (F5)**.
3. Kiểm tra database `eShopping` có 3 bảng: `KhachHang`, `DonHang`, `ChiTietDonHang`.

> Script có lệnh `DROP TABLE`, chạy lại sẽ xóa hết dữ liệu cũ.

### Bước 3. Sửa chuỗi kết nối
Mở `App.config`, sửa `Data Source` cho đúng máy:

```xml
<connectionStrings>
  <add name="eShoppingDb"
       connectionString="Data Source=TEN_MAY\TEN_INSTANCE;Initial Catalog=eShopping;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

| SQL Server | Data Source |
|---|---|
| Mặc định | `.` |
| SQL Express | `.\SQLEXPRESS` |
| LocalDB | `(LocalDB)\MSSQLLocalDB` |

Nếu báo `System.Configuration` không tồn tại: chuột phải **References → Add Reference → Assemblies → Framework → System.Configuration**.

### Bước 4. Build và chạy
**Build → Rebuild Solution**, sau đó nhấn **F5**.
Email xác nhận giả lập xem ở **View → Output** (chọn "Show output from: Debug").

### Cách dùng nhanh
1. Bấm **Đăng ký**, tạo tài khoản (ví dụ user `khach01`, mật khẩu `abc12345`).
2. Đăng nhập ở màn hình chính.
3. Bấm **Tính tiền / Thanh toán**, chọn loại giao, khu vực, loại thẻ, xem phí tự cập nhật.
4. Nhập người nhận và thẻ, bấm **Đặt hàng**.
5. Kiểm tra trong SSMS: `SELECT * FROM DonHang; SELECT * FROM ChiTietDonHang;`

### Dữ liệu để thử

| Mục đích | Dữ liệu |
|---|---|
| Visa hợp lệ | `4111111111111111`, hạn `12/2030`, CSV `123` |
| American Express hợp lệ | `378282246310005`, hạn `12/2030`, CSV 4 số |
| Sai Luhn | `4111111111111112` |
| Thẻ bị từ chối (mock) | `2111111111110000` |
| Hết hạn | hạn `01/2020` |

## 4. Cấu trúc Solution

```
LAB4/
├── EShopping/
│   ├── EShopping.sln
│   └── EShopping/
│       ├── App.config                  Chuỗi kết nối SQL Server
│       ├── Program.cs                  Điểm khởi động (chạy FrmMain)
│       ├── Data/
│       │   └── Db.cs                   Lớp truy cập dữ liệu duy nhất
│       ├── Models/
│       │   ├── Enums.cs                LoaiGiao, KhuVuc, LoaiThe
│       │   ├── KhachHang.cs
│       │   └── DonHang.cs              CartItem, TheTinDung, ChiPhi, DonHangRequest
│       ├── Services/
│       │   ├── ServiceResult.cs        Kết quả xử lý (thành công/thất bại + thông báo)
│       │   ├── KhachHangService.cs     Đăng ký, đăng nhập
│       │   ├── DatHangService.cs       Tính phí, kiểm tra thẻ, đặt hàng
│       │   ├── IPaymentGateway.cs      Adapter thanh toán + MockPaymentGateway
│       │   └── IEmailService.cs        Adapter email + MockEmailService
│       ├── UI/
│       │   ├── FrmMain.cs              Đăng nhập, giỏ hàng, mở chức năng
│       │   ├── FrmDangKy.cs            Đăng ký khách hàng
│       │   └── FrmThanhToan.cs         Chọn giao hàng, nhập thẻ, đặt hàng
│       ├── SQL/
│       │   └── eShopping.sql           Script tạo CSDL
│       └── Properties/
├── e-Shopping_diagram/                 Sơ đồ UML (draw.io)
└── word/                               Báo cáo Word
```

### Kiến trúc 3 lớp: UI → Service/Adapter → Data

| Lớp | Vai trò | Không được làm |
|---|---|---|
| UI (Form) | Thu thập dữ liệu, gọi Service, hiển thị kết quả | Chứa quy tắc nghiệp vụ, truy cập CSDL trực tiếp |
| Service / Adapter | Kiểm tra hợp lệ, tính tiền, điều phối đặt hàng, gọi dịch vụ ngoài | Thao tác điều khiển giao diện |
| Data (`Db.cs`) | Chứa chuỗi kết nối, thực thi `ExecuteQuery`, `ExecuteNonQuery`, `ExecuteScalar` bằng `SqlParameter` | Chứa nghiệp vụ |

## 5. Quy tắc nghiệp vụ chính

| Quy tắc | Nguồn |
|---|---|
| Phải đăng nhập mới được đặt hàng | Đề gốc |
| Tổng từ 1.000.000 đ: chuyển phát nhanh miễn phí; từ 5.000.000 đ: nhanh trong ngày miễn phí | Đề gốc |
| Thẻ Visa/Master/Discover: 16 số, CSV 3 số. Amex: 15 số, CSV 4 số | Đề gốc |
| Kiểm tra thẻ: độ dài, thuật toán Luhn, hạn sử dụng | Đề gốc |
| Chỉ ghi đơn khi dịch vụ thanh toán chấp nhận | Đề gốc |
| Email xác nhận không chứa thông tin thẻ | Đề gốc |
| Chỉ lưu 4 số cuối của thẻ, không lưu CSV | Ràng buộc an ninh |
| Phí giao theo khu vực (Thường 15k/25k/35k, Nhanh 30k/45k/60k, Trong ngày 50k/70k/90k) | **Giả định** |
| Lệ phí thẻ (Visa 1%, Master 1,2%, Discover 1,5%, Amex 2,5%) | **Giả định** |
| Mật khẩu tối thiểu 8 ký tự, có cả chữ và số | **Giả định** |

## 6. Hạn chế của bài

1. **Chưa có chức năng xem sản phẩm thật.** Đề nói dữ liệu sản phẩm do Hệ thống quản lý sản phẩm bên ngoài quản lý. Bài chỉ dùng giỏ hàng mẫu cố định (3 sản phẩm) trong `FrmMain`, chưa có form danh sách sản phẩm theo nhóm, xem chi tiết, thêm/xóa/đổi số lượng trong giỏ.
2. **Dịch vụ ngoài chỉ là giả lập.** `MockPaymentGateway` từ chối thẻ có số kết thúc `0000` và số tiền trên 100 triệu; `MockEmailService` chỉ in ra cửa sổ Output, không gửi email thật. Khi triển khai thật chỉ cần viết lớp mới implement `IPaymentGateway` / `IEmailService`.
3. **Lưu đơn hàng chưa dùng transaction.** `LuuDonHang` lưu `DonHang` rồi mới lưu từng dòng `ChiTietDonHang`. Nếu lỗi giữa chừng có thể còn đơn thiếu chi tiết, vì `Db.cs` theo đề chỉ có 3 phương thức cơ bản. Bản hoàn chỉnh nên dùng `SqlTransaction`.
4. **Các số liệu phí là giả định.** Bảng phí giao, tỷ lệ lệ phí thẻ, quy tắc mật khẩu và tuổi tối thiểu 18 do bài tự đặt vì đề không nêu cụ thể.
5. **Chưa kiểm tra tồn kho và giá thật.** Giá và tình trạng còn hàng lấy từ giỏ mẫu, không đối chiếu với hệ thống sản phẩm.
6. **Chưa có chức năng sau đặt hàng.** Chưa có xem lịch sử đơn, hủy đơn, trạng thái đơn (đang xử lý, đang giao...), đăng xuất, quên mật khẩu, sửa thông tin tài khoản.
7. **Xác thực thẻ chỉ ở mức định dạng.** Chưa kiểm tra đầu số thẻ có khớp loại thẻ đã chọn hay không.
8. **Chuỗi kết nối chưa mã hóa.** Dùng Windows Authentication lưu thẳng trong `App.config`, phù hợp để học, chưa phù hợp môi trường thật.
9. **Chưa có kiểm thử tự động.** Test thực hiện thủ công theo bảng test case trong báo cáo.
10. **Giao diện đơn giản.** Form tạo bằng code với vị trí cố định, chưa tối ưu co giãn theo kích thước màn hình.

## 7. Hướng phát triển

- Thêm `IProductSystem` + `MockProductSystem` và form danh sách sản phẩm theo nhóm.
- Bọc lưu đơn hàng trong `SqlTransaction`.
- Thêm xem lịch sử đơn hàng và trạng thái đơn.
- Thay Mock bằng dịch vụ thanh toán và email thật.
- Viết unit test cho `DatHangService` (tính phí, Luhn, kiểm tra thẻ).

## 8. Truy vết yêu cầu

| Chức năng | Form | Service | Bảng CSDL |
|---|---|---|---|
| Đăng ký | FrmDangKy | KhachHangService.DangKy | KhachHang |
| Đăng nhập | FrmMain | KhachHangService.DangNhap | KhachHang |
| Tính phí giao, lệ phí thẻ | FrmThanhToan | DatHangService.TinhChiPhi | không |
| Kiểm tra thẻ | FrmThanhToan | DatHangService.KiemTraThe | không |
| Thanh toán | FrmThanhToan | IPaymentGateway.Authorize | không |
| Đặt hàng | FrmThanhToan | DatHangService.DatHang | DonHang, ChiTietDonHang |
| Email xác nhận | không | IEmailService.Gui | KhachHang (đọc Email) |
