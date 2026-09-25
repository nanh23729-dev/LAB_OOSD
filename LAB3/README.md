LAB 3 – Hệ thống Quản lý Khách sạn
Họ tên: Nguyễn Hoàng Anh
MSSV: 1250080006
Lớp: 12_DH_CNPM1
Tên bài Lab: Bài 3 – Hệ thống Quản lý Khách sạn (Use Case, biểu đồ lớp, biểu đồ trạng thái, biểu đồ tuần tự, Cơ sở dữ liệu SQL Server, WinForms C#)
Môi trường / phiên bản:
Visual Studio 2022
.NET Framework 4.7.2
Ngôn ngữ: C#
SQL Server LocalDB (MSSQLLocalDB) / SQL Server Express
Hệ điều hành: Windows 10/11
Thực thi video (nếu được yêu cầu)

Dán link video demo tại đây trước khi đọc lại phần còn lại (nếu thí sinh yêu cầu).

1. Nội dung đã thực hiện
Khảo sát nghiệp vụ khách sạn: khu vực – phòng – tiện nghi, đặt/nhận phòng, sử dụng dịch vụ, trả phòng – đền bù – hóa đơn – thanh toán.
Vẽ biểu đồ Use Case tổng quát và các Use Case phân rã (Quản lý phòng - tiện nghi, Đặt/nhận phòng, Trả phòng - thanh toán, Thống kê).
Vẽ biểu đồ lớp phân tích, biểu đồ trạng thái (PhieuDatPhong, HoaDon), các biểu đồ tuần tự theo từng chức năng, biểu đồ lớp chi tiết, biểu đồ hoạt động.
Thiết kế cơ sở dữ liệu SQL Server ( Database/QuanLyKhachSan.sql) với khóa chính, khóa ngoại, buộc CHECK/UNIQUE cho toàn bộ dịch vụ.
Cài đặt ứng dụng WinForms (C#, .NET Framework 4.7.2) theo kiến ​​trúc UI → Service → Data → SQL Server, gồm 7 Form: FrmMain, FrmDanhMuc, FrmPhongTienNghi, FrmDatPhong, FrmDichVu, FrmTraPhong, FrmThongKe.
Thử nghiệm các quy tắc nghiệp vụ: sức chứa phòng, sao chép lịch đặt phòng, một thiết bị/1 phòng/1 ngày, cộng dịch vụ cùng ngày, hóa đơn nhiều phương thức thanh toán.
2. Cấu trúc thư mục
LAB3/
├── README.md
├── BaoCao_LAB3.docx          # báo cáo Word: giao diện + CSDL chụp từ máy cá nhân
├── UML/                      # (thêm) file .drawio / hình xuất từ draw.io
├── Database/
│   └── QuanLyKhachSan.sql    # script tạo CSDL + dữ liệu mẫu
└── QuanLyKhachSan/           # solution Visual Studio 2022
    ├── App.config
    ├── Program.cs
    ├── Data/Db.cs
    ├── Models/ (KetQuaXuLy, PhongDatItem, DenBuItem)
    ├── Services/ (DanhMucService, PhongTienNghiService, DatPhongService,
    │              DichVuService, TraPhongService, ThongKeService)
    └── Forms/ (FrmMain, FrmDanhMuc, FrmPhongTienNghi, FrmDatPhong,
                FrmDichVu, FrmTraPhong, FrmThongKe)
3. Kết quả
Ứng dụng đã được chạy, kết nối cơ sở dữ liệu LocalDB đã thành công.
Quy tắc nghiệp vụ được kiểm tra theo trường hợp thử nghiệm trong bảng báo cáo Word (sức chứa, trùng lặp lịch, một thiết bị/1 phòng/1 ngày, cộng dồn dịch vụ, hóa đơn nhiều phương thức thanh toán...).
Ảnh chụp giao diện thực tế và cơ sở dữ liệu thực tế: xem BaoCao_LAB3.docx.
4. Lỗi phải và cách giải quyết

Điền lại lỗi bạn thực hiện khi làm, ví dụ mẫu bên dưới — sửa cho máy bạn khớp:

Lỗi kết nối LocalDB ( Cannot open database ... requested by the login) → Kiểm tra kết nối chuỗi trong App.config, thay đổi Data Sourcephiên bản SQL Server đang cài đặt trên máy tính một cách chính xác (ví dụ .\SQLEXPRESS).
Lỗi Ràng buộc UNIQUE khi lập phiếu gắn thiết bị cùng ngày → đây là hành động đúng theo BR04, không sai; xử lý bằng cách chụp SqlException (mã 2627/2601) và thông báo cho người dùng thay vì chương trình bị lỗi.
5. Cài đặt và chạy lại hướng dẫn
Cài đặt Visual Studio 2022 (Workload ".NET desktop Development") và SQL Server LocalDB (đi kèm Visual Studio) hoặc SQL Server Express.
Mở SQL Server Object Explorer / SSMS, chạy tệp Database/QuanLyKhachSan.sql để tạo QuanLyKhachSancùng một mẫu dữ liệu cơ sở dữ liệu.
Mở giải pháp QuanLyKhachSanbằng Visual Studio 2022.
Kiểm tra App.config→ connectionStrings→ chỉnh sửa Data Sourcenếu máy bạn không sử dụng (localdb)\MSSQLLocalDB.
Nhấn F5để xây dựng và chạy; màn hình FrmMainsẽ hiển thị với 6 nhóm chức năng + nút Thoát.
Kiểm tra lần lượt theo bảng Test case (đặt phòng → nhận phòng → sử dụng dịch vụ → trả phòng → thanh toán → thống kê).
Lưu ý
Kho lưu trữ này chỉ chứa báo cáo, nguồn mã, tập lệnh SQL và giao diện ảnh chụp được làm sạch rõ ràng (không chứa CCCD/số điện thoại thật hay hình ảnh khác).
Không chỉnh sửa nội dung đã được bỏ qua nếu chưa được phép của thành viên.
