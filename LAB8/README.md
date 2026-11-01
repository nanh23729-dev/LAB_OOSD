# BÀI 4 – QUẢN LÝ CHO THUÊ VĂN PHÒNG Ở CAO ỐC

| | |
|---|---|
| **Họ và tên** | Nguyễn Hoàng Anh |
| **MSSV** | 1250080006 |
| **Lớp** | CNPM1 |
| **Môn** | Thực hành Phân tích thiết kế hướng đối tượng |

---

## 1. Giới thiệu

Bài 4 tin học hoá việc cho thuê văn phòng ở cao ốc:

- **Tầng – phòng:** giá thuê một phòng = diện tích × đơn giá m² của tầng (tầng càng cao đơn giá càng lớn).
- **Hợp đồng thuê:** thuê một hoặc nhiều phòng, **tối thiểu 6 tháng**, **trả trước 6 tháng đầu**, từ **tháng thứ 7** trả vào đầu mỗi tháng.
- **Dịch vụ:** điện, nước, internet... lập hóa đơn và thanh toán **cuối tháng**.
- **Gia hạn:** mỗi phòng gia hạn không quá **1/2 thời gian thuê**, chỉ khi **không còn nợ** tiền thuê và đã thanh toán đủ dịch vụ.
- **Nhân viên – thẻ giữ xe:** nhân viên của công ty thuê làm việc trong phòng, mỗi người một thẻ xe đang dùng, biển số không trùng, nghỉ việc thì thu hồi thẻ.
- **Kiểm tra phòng:** mỗi phòng một năm một lần; phòng hư hỏng phải có kế hoạch tự sửa; tự ý đổi kết cấu bị phạt 10.000.000 đ.

## 2. Nội dung 6 câu hỏi

| Câu | Yêu cầu | Sản phẩm |
|---|---|---|
| 1 | Class, thuộc tính, phương thức, ID | 16 Class trong báo cáo |
| 2 | Association, multiplicity, Class Diagram | 3 sơ đồ lớp theo nhóm |
| 3 | Actor, Use Case tổng quát | Use Case Diagram tổng quát |
| 4 | Use Case phân rã: ký hợp đồng → thanh toán tháng 7 → hóa đơn dịch vụ | Use Case Diagram phân rã |
| 5 | Activity Diagram cho Câu 4 | Activity có swimlane |
| 6 | Sequence “Lập phiếu gia hạn” | Sequence Diagram |

## 3. Cấu trúc thư mục

```
Bai4_QuanLyCaoOc/
├─ README.md
├─ Bai_4_Cho_thue_van_phong_BaiLam.docx   Báo cáo (phân tích, CSDL, giao diện, code từng Form, test)
├─ drawio/                                Sơ đồ draw.io (.drawio)
│   ├─ QuanLyCaoOc_Bai4_TatCa.drawio      Tất cả sơ đồ, mỗi sơ đồ một trang
│   └─ dio_*.drawio                       Từng sơ đồ riêng
├─ anh/                                   Ảnh PNG sơ đồ và ảnh giao diện các Form
├─ Database/QuanLyCaoOc.sql               Script tạo CSDL + dữ liệu mẫu
└─ sln/                                   Solution Visual Studio (C# WinForms)
    ├─ QuanLyCaoOc.sln
    └─ QuanLyCaoOc/                       Forms (UI), Services, Data
```

## 4. Hướng dẫn chạy

**Yêu cầu:** Windows, Visual Studio 2019/2022, .NET Framework 4.7.2, SQL Server (Express được) và SSMS.

1. **Tạo CSDL:** mở SSMS, nếu đã có database `QuanLyCaoOcDB` thì xoá nó, rồi mở `Database/QuanLyCaoOc.sql` và nhấn **F5**.
2. **Sửa chuỗi kết nối:** mở `sln/QuanLyCaoOc/App.config`, sửa `Data Source` cho đúng tên SQL Server trên máy (ví dụ `.\SQLEXPRESS`, `.\SQLEXPRESS01`, `TÊN-MÁY\TÊN-INSTANCE`). Có `Connect Timeout=5` nên nếu sai tên, chương trình báo lỗi sau khoảng 5 giây.
3. **Chạy:** mở `sln/QuanLyCaoOc.sln`, **Build → Rebuild Solution**, nhấn **F5**.

## 5. Các màn hình

| Form | Chức năng |
|---|---|
| FrmMain | Màn hình chính |
| FrmDanhMuc | Tầng, phòng (tính giá), loại dịch vụ |
| FrmKhachHang | Khách hàng thuê |
| FrmHopDong | Lập hợp đồng, danh sách – thanh lý, gia hạn |
| FrmThanhToan | Thu tiền thuê theo kỳ, hóa đơn dịch vụ, công nợ |
| FrmNhanVien | Nhân viên làm việc, thẻ giữ xe |
| FrmKiemTra | Phiếu kiểm tra phòng, phiếu phạt |

Kiến trúc 3 lớp **UI → Service → Data**; quy tắc nghiệp vụ nằm ở Service, các nghiệp vụ nhiều bảng chạy trong transaction; CSDL có thêm PK/FK/UNIQUE/CHECK.

## 6. Dữ liệu mẫu để thử (tính theo ngày 30/10/2026)

- `HD2026-001` (KH01, P501 + P502): còn nợ kỳ tiền thuê tháng 10 và hóa đơn dịch vụ tháng 9 → **không gia hạn, không thanh lý được**.
- `HD2026-002` (KH02, P302, 12 tháng): không nợ → gia hạn tối đa **6 tháng**.
- `HD2026-003` (KH03, P801, 6 tháng): không nợ → gia hạn tối đa **3 tháng**.
- Phòng đến hạn kiểm tra: P501, P502, P801.
- Danh sách 33 test case ở mục 8 của báo cáo.


*Sinh viên thực hiện: Nguyễn Hoàng Anh – MSSV 1250080006 – Lớp CNPM1*
