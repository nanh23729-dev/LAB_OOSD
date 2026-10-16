# Hướng dẫn chạy
1. SSMS / SQL Server Object Explorer -> chạy `Database/QuanLyBenhAn.sql` (tạo DB `QuanLyBenhAn` + dữ liệu mẫu).
2. Mở `QuanLyBenhAn.csproj` bằng Visual Studio 2022 (.NET Framework 4.7.2). Không dùng LocalDB thì sửa `Data Source` trong `App.config`.
3. F5. Luồng demo: **Tiếp nhận** (đăng ký, lấy mã hồ sơ) → **Khám bệnh** (tìm hồ sơ → lập phiếu → xét nghiệm → chẩn đoán → toa thuốc) → **Viện phí** (lập hóa đơn → thanh toán → hoàn tất) → **Lịch khám định kỳ** → **Thống kê**.

Cấu trúc: Forms (UI dựng bằng code, không cần Designer) → Services (nghiệp vụ, transaction) → Data/Db.cs → SQL Server. Form không viết SQL.
Dùng project theo kiểu Bài 3 (tự tạo Windows Forms App): tạo project rỗng tên `QuanLyBenhAn`, copy các thư mục Data/Services/Forms + Program.cs + App.config vào, thêm reference System.Configuration.
