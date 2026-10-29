# BÀI 7 – HỆ THỐNG QUẢN LÝ NHÂN SỰ (CÔNG TY SƠN ĐÔNG Á)

| | |
|---|---|
| **Họ và tên** | Nguyễn Hoàng Anh |
| **MSSV** | 1250080006 |
| **Lớp** | CNPM1 |
| **Môn** | Thực hành Phân tích thiết kế hướng đối tượng |

---

## 1. Giới thiệu

Bài 7 yêu cầu tin học hoá việc quản lý nhân sự tại công ty sơn Đông Á. Hệ thống quản lý các nghiệp vụ sau:

- **Tuyển dụng – thử việc:** quyết định tuyển dụng ghi rõ phòng ban, thời gian thử việc, lương thử việc, điều khoản hai bên.
- **Hợp đồng lao động:** sau thử việc, ký hợp đồng dài hạn hoặc ngắn hạn. Hợp đồng dài hạn phải lập hồ sơ BHXH, BHYT và trích trừ trong bảng lương.
- **Quyết định lương, quyết định chức vụ:** lương cơ bản, phụ cấp lương, phụ cấp độc hại, phụ cấp chức vụ. Tăng lương hay bổ nhiệm đều ghi nhận bằng quyết định mới.
- **Phân công – chấm công – phụ trội:** kế hoạch phân công tuần, bảng chấm công tháng, phiếu giờ phụ trội (tính 1,5 lần giờ bình thường).
- **Khen thưởng – kỷ luật:** áp dụng cho cá nhân hoặc tập thể phòng ban, kèm phiếu chi khen thưởng và phiếu thu nộp phạt.
- **Bảng lương hằng tháng:** tổng hợp từ các quyết định, chấm công, phụ trội, thưởng – phạt và bảo hiểm.

Bài làm trả lời **6 câu hỏi** của đề bằng UML, đồng thời hiện thực thêm cơ sở dữ liệu SQL Server và ứng dụng C# WinForms.

## 2. Nội dung 6 câu hỏi

| Câu | Yêu cầu | Sản phẩm |
|---|---|---|
| 1 | Class, thuộc tính, phương thức, ID | 20 Class, bảng chi tiết trong báo cáo |
| 2 | Liên kết giữa các Class – Class Diagram | 3 sơ đồ lớp theo nhóm nghiệp vụ |
| 3 | Actor và Use Case tổng quát | Use Case Diagram tổng quát |
| 4 | Use Case phân rã: thử việc đến ký hợp đồng | Use Case Diagram phân rã |
| 5 | Activity Diagram cho Câu 4 | Activity Diagram có swimlane |
| 6 | Sequence Diagram “Lập quyết định khen thưởng” | Sequence Diagram |

## 3. Cấu trúc thư mục

```
Bai7_QuanLyNhanSu/
├─ README.md                           (file này)
├─ Bai_7_Quan_ly_nhan_su_BaiLam.docx   Báo cáo trả lời 6 câu hỏi
├─ drawio/                             Sơ đồ UML vẽ bằng draw.io (.drawio)
│   ├─ QuanLyNhanSu_Bai7_TatCa.drawio  Tất cả sơ đồ trong một file (mỗi sơ đồ một trang)
│   └─ dio_*.drawio                    Từng sơ đồ riêng
├─ anh/                                Ảnh PNG của các sơ đồ
├─ Database/QuanLyNhanSu.sql           Script tạo CSDL + dữ liệu mẫu
└─ sln/                                Solution Visual Studio (C# WinForms)
    ├─ QuanLyNhanSu.sln
    └─ QuanLyNhanSu/                   Code: Forms (UI), Services, Data
```

## 4. Hướng dẫn chạy ứng dụng

**Yêu cầu:** Windows, Visual Studio 2019/2022, .NET Framework 4.7.2, SQL Server (bản Express cũng được) và SSMS.

### Bước 1 – Tạo cơ sở dữ liệu
1. Mở SSMS, kết nối vào SQL Server.
2. Nếu đã có database `QuanLyNhanSuDB` từ lần chạy trước thì **xoá nó đi** (script không tự xoá).
3. Mở file `Database/QuanLyNhanSu.sql`, nhấn **Execute (F5)**.
   Script tạo database `QuanLyNhanSuDB`, 20 bảng và dữ liệu mẫu của tháng 10/2026.

### Bước 2 – Sửa chuỗi kết nối
Mở `sln/QuanLyNhanSu/App.config`, sửa `Data Source` đúng tên SQL Server trên máy bạn:

```xml
<add name="QuanLyNhanSuDb"
     connectionString="Data Source=.\SQLEXPRESS01;Initial Catalog=QuanLyNhanSuDB;Integrated Security=True;Connect Timeout=5"
     providerName="System.Data.SqlClient" />
```

Tên server thường có dạng `.\SQLEXPRESS`, `.\SQLEXPRESS01` hoặc `TÊN-MÁY\TÊN-INSTANCE`. Chỉ cần sai một ký tự là chương trình không kết nối được.
Có `Connect Timeout=5` nên nếu sai, chương trình báo lỗi sau khoảng 5 giây thay vì treo lâu.

### Bước 3 – Chạy
Mở `sln/QuanLyNhanSu.sln` trong Visual Studio, chọn **Build → Rebuild Solution**, rồi nhấn **F5**.

## 5. Các màn hình chính

| Form | Chức năng |
|---|---|
| FrmMain | Màn hình chính, mở các chức năng |
| FrmDanhMuc | Danh mục phòng ban, chức vụ, ca làm việc |
| FrmNhanVien | Hồ sơ nhân viên, quyết định tuyển dụng, ký hợp đồng, hồ sơ bảo hiểm |
| FrmQuyetDinh | Quyết định lương, quyết định chức vụ |
| FrmChamCong | Kế hoạch phân công tuần, bảng chấm công, phiếu phụ trội |
| FrmKhenThuongKyLuat | Quyết định khen thưởng, kỷ luật, phiếu chi, phiếu thu |
| FrmBangLuong | Lập và xem bảng lương tháng |

Kiến trúc 3 lớp: **UI (Forms) → Service (nghiệp vụ) → Data (ADO.NET)**. Quy tắc nghiệp vụ nằm ở Service; CSDL có thêm CHECK/UNIQUE để chặn dữ liệu sai.

## 6. Quy định tính lương

Đề không nêu một số số liệu nên bài làm quy ước như sau:

- Ngày công chuẩn **26 ngày/tháng**, **8 giờ/ngày**.
- Tiền ngày công = Lương cơ bản / 26 × số ngày công.
- Tiền phụ trội = Lương cơ bản / 26 / 8 × **1,5** × số giờ phụ trội.
- BHXH **8%**, BHYT **1,5%** lương cơ bản (chỉ nhân viên có hồ sơ bảo hiểm).
- **Thực lĩnh** = tiền ngày công + phụ cấp chức vụ + phụ cấp lương + phụ cấp độc hại + tiền phụ trội + thưởng (cộng vào lương) − phạt (trừ lương) − BHXH − BHYT.
- Nhân viên chưa có quyết định lương (đang thử việc) tính theo lương thử việc, không phụ cấp, không bảo hiểm.


---
*Sinh viên thực hiện: Nguyễn Hoàng Anh – MSSV 1250080006 – Lớp CNPM1*
