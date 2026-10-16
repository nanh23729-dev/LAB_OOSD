# Hệ thống Quản lý Hồ sơ Bệnh án

Ứng dụng Windows Forms (C#) quản lý hồ sơ bệnh án của phòng khám/bệnh viện: tiếp nhận bệnh nhân, khám bệnh, kê toa, lịch khám định kỳ, viện phí và thống kê. Dữ liệu lưu trên SQL Server.

## Công nghệ

| Thành phần | Chi tiết |
|---|---|
| Ngôn ngữ | C# 7.3 |
| Nền tảng | .NET Framework 4.7.2, Windows Forms |
| Cơ sở dữ liệu | SQL Server (Express/LocalDB đều được) |
| Truy cập dữ liệu | ADO.NET (`System.Data.SqlClient`), truy vấn có tham số |
| IDE khuyến nghị | Visual Studio 2022 + SQL Server Management Studio (SSMS) |

## Cài đặt và chạy

### 1. Tạo cơ sở dữ liệu

1. Mở **SSMS**, kết nối vào SQL Server.
2. Mở file `Database/QuanLyBenhAn.sql` rồi bấm **Execute** (F5).
3. Script sẽ tạo database `QuanLyBenhAn`, các bảng và dữ liệu mẫu (nhân viên, khoa, bác sĩ, xét nghiệm, thuốc).

> Chỉ chạy một lần. Nếu cần chạy lại, hãy xóa database `QuanLyBenhAn` cũ trước (chuột phải trong Object Explorer, chọn Delete).

### 2. Cấu hình chuỗi kết nối

Mở `App.config` và sửa `Data Source` cho đúng tên SQL Server của bạn:

```xml
<add name="QuanLyBenhAnDB"
     connectionString="Data Source=TEN_MAY\TEN_INSTANCE;Initial Catalog=QuanLyBenhAn;Integrated Security=True"
     providerName="System.Data.SqlClient" />
```

Ví dụ: `.\SQLEXPRESS`, `(localdb)\MSSQLLocalDB`, hoặc `DESKTOP-XXXX\SQLEXPRESS01`.

### 3. Chạy ứng dụng

Mở `QuanLyBenhAn.csproj` bằng Visual Studio và bấm **F5**.

## Luồng sử dụng (demo)

1. **Tiếp nhận - Hồ sơ**: đăng ký bệnh nhân khám lần đầu, thu lệ phí năm, hệ thống cấp mã hồ sơ (`HS00001`...).
2. **Khám bệnh**: tìm hồ sơ, lập phiếu khám, chỉ định xét nghiệm, ghi chẩn đoán, lập toa thuốc.
3. **Viện phí - Hoàn tất**: lập hóa đơn, thanh toán, hoàn tất và xuất viện.
4. **Lịch khám định kỳ**: đặt lịch khám sức khỏe theo quý cho hồ sơ.
5. **Thống kê**: xem tổng hợp theo khoảng ngày.

## Chức năng

| Màn hình | Chức năng |
|---|---|
| Danh mục | Thêm và xem Khoa, Bác sĩ, Nhân viên, Thuốc, Xét nghiệm |
| Tiếp nhận - Hồ sơ | Đăng ký lần đầu (kèm ảnh 3x4), cấp hồ sơ, tra cứu theo mã/tên/SĐT, gia hạn lệ phí năm |
| Khám bệnh | Lập phiếu khám (điều trị hoặc định kỳ), chỉ định và ghi kết quả xét nghiệm, chẩn đoán, lập toa thuốc, ghi phản ứng phụ của thuốc |
| Lịch khám định kỳ | Đặt và hủy lịch khám theo quý |
| Viện phí | Lập hóa đơn, thanh toán nhiều lần, hoàn tất đợt điều trị |
| Thống kê | Số bệnh nhân mới, lệ phí thu, số phiếu khám, khám định kỳ, doanh thu viện phí, thuốc đã kê |

## Quy tắc nghiệp vụ

**Tiếp nhận**
- Phải đóng lệ phí năm mới được cấp hồ sơ bệnh án.
- Không đăng ký lại nếu trùng họ tên, ngày sinh và số điện thoại (hãy tra cứu và gia hạn lệ phí).
- Chỉ thu lệ phí cho năm hiện tại hoặc năm kế tiếp. Mỗi hồ sơ chỉ đóng một lần cho mỗi năm.

**Khám bệnh**
- Chỉ lập phiếu khi hồ sơ đã đóng lệ phí của năm khám.
- Bác sĩ phải thuộc khoa đã chọn. Mỗi hồ sơ chỉ có một phiếu khám đang khám tại một thời điểm.
- Khám **điều trị** bắt buộc ghi triệu chứng. Thân nhiệt hợp lệ từ 30 đến 45 °C.
- Khám **định kỳ** phải theo một lịch hẹn còn hiệu lực của hồ sơ.
- Mỗi phiếu khám tối đa một toa thuốc. Toa phải có ít nhất một thuốc, số lượng lớn hơn 0 và có liều dùng.
- Phiếu đã hoàn tất không được sửa. Phiếu đã lập hóa đơn thì không được thay đổi chỉ định xét nghiệm và toa thuốc.

**Lịch khám định kỳ**
- Miễn phí, theo quý. Mỗi hồ sơ chỉ có một lịch còn hiệu lực trong một quý.
- Giờ hẹn phải ở tương lai và nằm trong đúng quý/năm đã chọn. Hồ sơ phải đã đóng lệ phí năm đó.
- Chỉ hủy được lịch ở trạng thái "Đã hẹn".

**Viện phí**
- Hóa đơn = phí khám theo khoa + tiền xét nghiệm + tiền thuốc.
- Khám định kỳ được miễn toàn bộ: hóa đơn 0 đồng và tự động "Đã thanh toán".
- Cho phép thanh toán nhiều lần, tổng không được vượt số tiền hóa đơn.
- Chỉ hoàn tất và xuất viện khi hóa đơn đã thanh toán đủ. Nhân viên CSKH ghi nhận vào hồ sơ.

## Cấu trúc thư mục

```
QuanLyBenhAn/
├── Database/
│   └── QuanLyBenhAn.sql      Script tạo database, bảng, dữ liệu mẫu
├── Data/
│   └── Db.cs                 Kết nối, truy vấn, transaction, sinh mã tự động
├── Services/                 Nghiệp vụ (mỗi thao tác chạy trong transaction)
│   ├── Common.cs             KetQuaXuLy, DongThuoc, hàm kiểm tra
│   ├── DanhMucService.cs
│   ├── TiepNhanService.cs
│   ├── KhamBenhService.cs
│   ├── LichHenService.cs
│   ├── VienPhiService.cs
│   └── ThongKeService.cs
├── Forms/                    Giao diện, dựng bằng code (không dùng Designer)
│   ├── Ui.cs                 Hàm dựng control dùng chung
│   ├── FrmMain.cs
│   ├── FrmDanhMuc.cs
│   ├── FrmTiepNhan.cs
│   ├── FrmKhamBenh.cs
│   ├── FrmLichHen.cs
│   ├── FrmVienPhi.cs
│   └── FrmThongKe.cs
├── TaiLieu/                  Báo cáo và hướng dẫn chạy thử
├── App.config                Chuỗi kết nối
├── Program.cs                Điểm khởi chạy
└── QuanLyBenhAn.csproj
```

Kiến trúc nhiều lớp: **Forms** (giao diện) gọi **Services** (nghiệp vụ) gọi **Data/Db.cs** (truy cập dữ liệu) rồi tới SQL Server. Form không viết SQL.

## Cơ sở dữ liệu

16 bảng chính:

| Nhóm | Bảng |
|---|---|
| Danh mục | `NhanVien`, `Khoa`, `BacSi`, `Thuoc`, `XetNghiem` |
| Bệnh nhân | `BenhNhan`, `PhieuDangKy`, `HoSoBenhAn`, `LePhiNam` |
| Lịch và khám | `LichHen`, `PhieuKham`, `ChiTietXetNghiem` |
| Toa thuốc | `ToaThuoc`, `ChiTietToaThuoc` |
| Viện phí | `HoaDonVienPhi`, `ThanhToanVienPhi` |

Một số ràng buộc đáng chú ý:
- Mỗi bệnh nhân chỉ có một phiếu đăng ký và một hồ sơ. Mỗi hồ sơ chỉ đóng một lệ phí cho mỗi năm.
- Chỉ một lịch hẹn còn hiệu lực cho mỗi hồ sơ trong một quý (unique index có điều kiện).
- `ThanhTien` (chi tiết toa) và `TongTien` (hóa đơn) là cột tính toán, lưu sẵn trong database.

## Xử lý sự cố

| Lỗi | Cách xử lý |
|---|---|
| `Database 'QuanLyBenhAn' does not exist` | Thiếu dòng `GO` sau `CREATE DATABASE`. Dùng đúng file `Database/QuanLyBenhAn.sql` |
| Không kết nối được SQL Server | Kiểm tra `Data Source` trong `App.config` và dịch vụ SQL Server đã chạy chưa |
| `Unexpected character '\'` khi build | File `.cs` bị dính chuỗi `\xef\xbb\xbf` ở dòng đầu. Xóa chuỗi này đi (bản đã sửa không còn lỗi) |
| Tiếng Việt bị lỗi font | Lưu file `.cs` bằng mã hóa UTF-8 (có BOM) |
