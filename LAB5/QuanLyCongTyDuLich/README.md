# Bài 6 - Quản lý công ty du lịch Văn Hóa Việt (WinForms .NET Framework 4.7.2)

## Chạy
1. Mở SSMS / sqlcmd, chạy `Database/QuanLyCongTyDuLich.sql` trên `(localdb)\MSSQLLocalDB`.
2. Mở `QuanLyCongTyDuLich.sln` bằng Visual Studio 2022 -> kiểm tra `App.config` -> Rebuild -> F5.
3. Chạy 24 test case (mục 9 của đề). Dữ liệu mẫu dùng ngày sau 01/10/2026; nếu chạy muộn hơn hãy dời ngày.

## Kiến trúc: UI -> Service -> Data
- `Data/Db.cs`: Query / Execute / Scalar / P (tham số hóa, rỗng -> DBNull).
- `Services/`: Models (KetQuaXuLy, QuyDinh), DanhMuc, Tour, ChuyenLe, DangKyLe, DangKyDoan (transaction), PhanCong, KetThuc, ThongKe.
- `Forms/`: 9 Form (.cs + .Designer.cs), FormHelper. Form không viết SQL.

## Truy vết
| Yêu cầu | Form | Service | Bảng | Test |
|---|---|---|---|---|
| Tour - hành trình (BR01, BR02) | FrmTour | TourService | Tour, TourDiemDung, TourPhuongTien, TourDiemThamQuan | TC02-03 |
| Khách lẻ (BR03, QD01, QD02) | FrmChuyenLe, FrmDangKyLe | ChuyenLeService, DangKyLeService | ChuyenLe, DangKyLe | TC04-07 |
| Khách đoàn (BR04, BR05) | FrmDangKyDoan | DangKyDoanService | DoanKhach, DangKyDoan, ThanhVienDoan | TC08-12 |
| Phân công HDV (BR06) | FrmPhanCongHDV | PhanCongService | PhanCongHDV | TC13-16 |
| Thanh toán sau tour, khảo sát (BR08) | FrmKetThucKhaoSat | KetThucService | ThanhToanDoan, KhaoSat | TC17-22 |
| Lương HDV (BR07), thống kê | FrmLuongThongKe | ThongKeService | HuongDanVien, PhanCongHDV | TC23-24 |
