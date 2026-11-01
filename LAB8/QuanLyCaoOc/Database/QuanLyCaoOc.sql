-- Bai 4 - Quan ly cho thue van phong o cao oc
CREATE DATABASE QuanLyCaoOcDB
GO
USE QuanLyCaoOcDB
GO

-- Tang (do cao quyet dinh don gia tren 1 m2)
CREATE TABLE Tang (
    MaTang nvarchar(10) PRIMARY KEY,
    SoTang int NOT NULL UNIQUE CHECK (SoTang > 0),
    TenTang nvarchar(50) NOT NULL,
    DoCao decimal(6,1) NOT NULL CHECK (DoCao > 0),
    DonGiaM2 decimal(12,0) NOT NULL CHECK (DonGiaM2 > 0)
)

-- Phong (gia thue = dien tich x don gia m2 cua tang)
CREATE TABLE Phong (
    MaPhong nvarchar(10) PRIMARY KEY,
    MaTang nvarchar(10) NOT NULL REFERENCES Tang(MaTang),
    DienTich decimal(8,2) NOT NULL CHECK (DienTich > 0),
    Huong nvarchar(20) NOT NULL CHECK (Huong IN (N'Đông', N'Tây', N'Nam', N'Bắc')),
    GiaThue decimal(14,0) NOT NULL CHECK (GiaThue > 0),
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Trống'
        CHECK (TrangThai IN (N'Trống', N'Đang thuê', N'Bảo trì')),
    NgayKiemTraCuoi date
)

-- Khach hang
CREATE TABLE KhachHang (
    MaKH nvarchar(10) PRIMARY KEY,
    TenKH nvarchar(100) NOT NULL,
    LoaiKH nvarchar(20) NOT NULL CHECK (LoaiKH IN (N'Công ty', N'Cá nhân')),
    NguoiDaiDien nvarchar(100) NOT NULL,
    DienThoai nvarchar(15) NOT NULL,
    Email nvarchar(100),
    DiaChi nvarchar(200),
    MaSoThue nvarchar(20)
)

-- Loai dich vu (dien, nuoc, internet...)
CREATE TABLE LoaiDichVu (
    MaDV nvarchar(10) PRIMARY KEY,
    TenDV nvarchar(50) NOT NULL UNIQUE,
    DonViTinh nvarchar(20) NOT NULL,
    DonGia decimal(12,0) NOT NULL CHECK (DonGia >= 0)
)

-- Hop dong thue (thue it nhat 6 thang)
CREATE TABLE HopDongThue (
    SoHD nvarchar(20) PRIMARY KEY,
    MaKH nvarchar(10) NOT NULL REFERENCES KhachHang(MaKH),
    NgayKy date NOT NULL,
    NgayBatDau date NOT NULL,
    SoThang int NOT NULL CHECK (SoThang >= 6),
    NgayKetThuc date NOT NULL,
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Hiệu lực'
        CHECK (TrangThai IN (N'Hiệu lực', N'Thanh lý')),
    DieuKhoan nvarchar(1000),
    NguoiLap nvarchar(100) NOT NULL,
    CHECK (NgayBatDau >= NgayKy AND NgayKetThuc > NgayBatDau)
)

-- Chi tiet hop dong: 1 hop dong thue nhieu phong, chot gia luc ky
CREATE TABLE ChiTietHopDong (
    SoHD nvarchar(20) NOT NULL REFERENCES HopDongThue(SoHD),
    MaPhong nvarchar(10) NOT NULL REFERENCES Phong(MaPhong),
    GiaThue decimal(14,0) NOT NULL CHECK (GiaThue > 0),
    NgayKetThuc date NOT NULL,
    PRIMARY KEY (SoHD, MaPhong)
)

-- Ky thanh toan tien thue: ky 1 tra truoc 6 thang, tu thang 7 moi thang 1 ky
CREATE TABLE KyThanhToan (
    MaKy nvarchar(30) PRIMARY KEY,
    SoHD nvarchar(20) NOT NULL REFERENCES HopDongThue(SoHD),
    TuThang int NOT NULL CHECK (TuThang >= 1),
    DenThang int NOT NULL,
    NgayDenHan date NOT NULL,
    SoTien decimal(16,0) NOT NULL CHECK (SoTien > 0),
    NgayThu date,
    NguoiThu nvarchar(100),
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Chưa thu'
        CHECK (TrangThai IN (N'Chưa thu', N'Đã thu')),
    GhiChu nvarchar(100),
    CHECK (DenThang >= TuThang),
    CHECK ((TrangThai = N'Đã thu' AND NgayThu IS NOT NULL) OR (TrangThai = N'Chưa thu' AND NgayThu IS NULL))
)

-- Hoa don dich vu (thanh toan cuoi thang), moi hop dong 1 hoa don / thang
CREATE TABLE HoaDonDichVu (
    SoHDDV nvarchar(30) PRIMARY KEY,
    SoHD nvarchar(20) NOT NULL REFERENCES HopDongThue(SoHD),
    Thang int NOT NULL CHECK (Thang BETWEEN 1 AND 12),
    Nam int NOT NULL CHECK (Nam >= 2000),
    NgayLap date NOT NULL,
    NgayDenHan date NOT NULL,
    TongTien decimal(16,0) NOT NULL CHECK (TongTien >= 0),
    NgayThanhToan date,
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Chưa thanh toán'
        CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán')),
    UNIQUE (SoHD, Thang, Nam),
    CHECK ((TrangThai = N'Đã thanh toán' AND NgayThanhToan IS NOT NULL) OR (TrangThai = N'Chưa thanh toán' AND NgayThanhToan IS NULL))
)

CREATE TABLE ChiTietHoaDon (
    SoHDDV nvarchar(30) NOT NULL REFERENCES HoaDonDichVu(SoHDDV),
    MaDV nvarchar(10) NOT NULL REFERENCES LoaiDichVu(MaDV),
    SoLuong decimal(12,2) NOT NULL CHECK (SoLuong > 0),
    DonGia decimal(12,0) NOT NULL,
    ThanhTien decimal(16,0) NOT NULL,
    PRIMARY KEY (SoHDDV, MaDV)
)

-- Phieu gia han (ghi ro phong nao, gia han bao nhieu thang)
CREATE TABLE PhieuGiaHan (
    SoPhieu nvarchar(30) PRIMARY KEY,
    SoHD nvarchar(20) NOT NULL REFERENCES HopDongThue(SoHD),
    NgayLap date NOT NULL,
    NguoiLap nvarchar(100) NOT NULL,
    GhiChu nvarchar(200)
)

CREATE TABLE ChiTietGiaHan (
    SoPhieu nvarchar(30) NOT NULL REFERENCES PhieuGiaHan(SoPhieu),
    MaPhong nvarchar(10) NOT NULL REFERENCES Phong(MaPhong),
    SoThangGiaHan int NOT NULL CHECK (SoThangGiaHan > 0),
    NgayKetThucCu date NOT NULL,
    NgayKetThucMoi date NOT NULL,
    PRIMARY KEY (SoPhieu, MaPhong),
    CHECK (NgayKetThucMoi > NgayKetThucCu)
)

-- Nhan vien cua cong ty thue
CREATE TABLE NhanVien (
    MaNV nvarchar(10) PRIMARY KEY,
    HoTen nvarchar(100) NOT NULL,
    GioiTinh nvarchar(5) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    NgaySinh date NOT NULL,
    ChucVu nvarchar(50) NOT NULL,
    HinhAnh nvarchar(260),
    MaKH nvarchar(10) NOT NULL REFERENCES KhachHang(MaKH),
    MaPhong nvarchar(10) NOT NULL REFERENCES Phong(MaPhong),
    NgayBaoCao date NOT NULL,
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Đang làm'
        CHECK (TrangThai IN (N'Đang làm', N'Đã nghỉ'))
)

-- The giu xe (moi nhan vien dang lam chi co 1 the dang dung, bien so khong trung)
CREATE TABLE TheGiuXe (
    MaThe nvarchar(10) PRIMARY KEY,
    MaNV nvarchar(10) NOT NULL REFERENCES NhanVien(MaNV),
    BienSo nvarchar(15) NOT NULL,
    LoaiXe nvarchar(20) NOT NULL CHECK (LoaiXe IN (N'Xe máy', N'Ô tô', N'Xe đạp')),
    HieuXe nvarchar(50),
    MauSac nvarchar(30),
    NgayCap date NOT NULL,
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Đang dùng'
        CHECK (TrangThai IN (N'Đang dùng', N'Đã thu hồi'))
)
CREATE UNIQUE INDEX UQ_The_NhanVien ON TheGiuXe(MaNV) WHERE TrangThai = N'Đang dùng'
CREATE UNIQUE INDEX UQ_The_BienSo ON TheGiuXe(BienSo) WHERE TrangThai = N'Đang dùng'

-- Kiem tra tinh trang phong (1 nam / lan)
CREATE TABLE PhieuKiemTra (
    SoPhieu nvarchar(30) PRIMARY KEY,
    NgayKiemTra date NOT NULL,
    NguoiKiemTra nvarchar(100) NOT NULL,
    GhiChu nvarchar(200)
)

CREATE TABLE ChiTietKiemTra (
    SoPhieu nvarchar(30) NOT NULL REFERENCES PhieuKiemTra(SoPhieu),
    MaPhong nvarchar(10) NOT NULL REFERENCES Phong(MaPhong),
    TinhTrang nvarchar(20) NOT NULL CHECK (TinhTrang IN (N'Tốt', N'Cần sửa chữa', N'Hư hỏng')),
    ThayDoiKetCau bit NOT NULL DEFAULT 0,
    GhiChu nvarchar(300),
    KeHoachTuSua nvarchar(300),
    PRIMARY KEY (SoPhieu, MaPhong)
)

-- Phieu phat phong tu y thay doi ket cau
CREATE TABLE PhieuPhat (
    SoPhat nvarchar(30) PRIMARY KEY,
    SoPhieuKT nvarchar(30) NOT NULL,
    MaPhong nvarchar(10) NOT NULL,
    SoHD nvarchar(20) REFERENCES HopDongThue(SoHD),
    NgayLap date NOT NULL,
    LyDo nvarchar(300) NOT NULL,
    SoTien decimal(14,0) NOT NULL CHECK (SoTien > 0),
    NgayNop date,
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Chưa nộp'
        CHECK (TrangThai IN (N'Chưa nộp', N'Đã nộp')),
    FOREIGN KEY (SoPhieuKT, MaPhong) REFERENCES ChiTietKiemTra(SoPhieu, MaPhong),
    CHECK ((TrangThai = N'Đã nộp' AND NgayNop IS NOT NULL) OR (TrangThai = N'Chưa nộp' AND NgayNop IS NULL))
)
GO

-- ================= DU LIEU MAU =================
INSERT INTO Tang VALUES
(N'T01', 1, N'Tầng 1', 4.5, 200000),
(N'T02', 2, N'Tầng 2', 8.5, 220000),
(N'T03', 3, N'Tầng 3', 12.5, 240000),
(N'T05', 5, N'Tầng 5', 20.5, 280000),
(N'T08', 8, N'Tầng 8', 32.5, 340000)

-- gia thue = dien tich x don gia m2 cua tang
INSERT INTO Phong VALUES
(N'P101', N'T01', 120, N'Đông', 24000000, N'Trống', '2025-10-15'),
(N'P102', N'T01', 80, N'Tây', 16000000, N'Trống', '2026-02-01'),
(N'P201', N'T02', 100, N'Đông', 22000000, N'Trống', '2026-03-01'),
(N'P302', N'T03', 80, N'Nam', 19200000, N'Đang thuê', '2026-04-10'),
(N'P303', N'T03', 60, N'Bắc', 14400000, N'Bảo trì', '2026-03-01'),
(N'P501', N'T05', 75, N'Đông', 21000000, N'Đang thuê', '2025-09-20'),
(N'P502', N'T05', 90, N'Tây', 25200000, N'Đang thuê', '2025-09-20'),
(N'P801', N'T08', 110, N'Nam', 37400000, N'Đang thuê', NULL),
(N'P802', N'T08', 65, N'Bắc', 22100000, N'Trống', NULL)

INSERT INTO KhachHang VALUES
(N'KH01', N'Công ty TNHH Phần mềm An Phát', N'Công ty', N'Nguyễn Văn An', N'0903111001', N'anphat@gmail.com', N'Quận 1, TP.HCM', N'0312345001'),
(N'KH02', N'Công ty CP Thương mại Minh Long', N'Công ty', N'Trần Minh Long', N'0903111002', N'minhlong@gmail.com', N'Quận 3, TP.HCM', N'0312345002'),
(N'KH03', N'Công ty TNHH Thiết kế Hoàng Gia', N'Công ty', N'Hoàng Gia Bảo', N'0903111003', N'hoanggia@gmail.com', N'Quận Bình Thạnh, TP.HCM', N'0312345003'),
(N'KH04', N'Trần Thị Lan', N'Cá nhân', N'Trần Thị Lan', N'0903111004', N'lan.tran@gmail.com', N'TP. Thủ Đức, TP.HCM', NULL)

INSERT INTO LoaiDichVu VALUES
(N'DV01', N'Điện', N'kWh', 3500),
(N'DV02', N'Nước', N'm3', 20000),
(N'DV03', N'Internet', N'tháng', 500000),
(N'DV04', N'Vệ sinh', N'tháng', 300000)

-- HD001: 2 phong P501 + P502, 12 thang, thang 10/2026 chua dong => dang no
-- HD002: 1 phong P302, 12 thang, khong no
-- HD003: 1 phong P801, 6 thang, khong no
INSERT INTO HopDongThue VALUES
(N'HD2026-001', N'KH01', '2026-01-10', '2026-01-15', 12, '2027-01-14', N'Hiệu lực', N'Thuê 2 phòng, trả trước 6 tháng đầu, từ tháng 7 trả đầu mỗi tháng.', N'Lê Thanh Sơn'),
(N'HD2026-002', N'KH02', '2026-02-25', '2026-03-01', 12, '2027-02-28', N'Hiệu lực', N'Thuê 1 phòng, trả trước 6 tháng đầu, từ tháng 7 trả đầu mỗi tháng.', N'Lê Thanh Sơn'),
(N'HD2026-003', N'KH03', '2026-08-28', '2026-09-01', 6, '2027-02-28', N'Hiệu lực', N'Thuê 1 phòng 6 tháng, trả trước toàn bộ.', N'Lê Thanh Sơn')

INSERT INTO ChiTietHopDong VALUES
(N'HD2026-001', N'P501', 21000000, '2027-01-14'),
(N'HD2026-001', N'P502', 25200000, '2027-01-14'),
(N'HD2026-002', N'P302', 19200000, '2027-02-28'),
(N'HD2026-003', N'P801', 37400000, '2027-02-28')

-- HD001: 46.200.000/thang -> ky 1 = 277.200.000 ; HD002: 19.200.000 -> 115.200.000 ; HD003: 37.400.000 -> 224.400.000
INSERT INTO KyThanhToan VALUES
(N'KY-HD2026-001-01', N'HD2026-001', 1, 6, '2026-01-10', 277200000, '2026-01-10', N'Kế toán Phạm Thu Hà', N'Đã thu', N'Trả trước 6 tháng đầu'),
(N'KY-HD2026-001-07', N'HD2026-001', 7, 7, '2026-07-15', 46200000, '2026-07-14', N'Kế toán Phạm Thu Hà', N'Đã thu', NULL),
(N'KY-HD2026-001-08', N'HD2026-001', 8, 8, '2026-08-15', 46200000, '2026-08-14', N'Kế toán Phạm Thu Hà', N'Đã thu', NULL),
(N'KY-HD2026-001-09', N'HD2026-001', 9, 9, '2026-09-15', 46200000, '2026-09-15', N'Kế toán Phạm Thu Hà', N'Đã thu', NULL),
(N'KY-HD2026-001-10', N'HD2026-001', 10, 10, '2026-10-15', 46200000, NULL, NULL, N'Chưa thu', NULL),
(N'KY-HD2026-001-11', N'HD2026-001', 11, 11, '2026-11-15', 46200000, NULL, NULL, N'Chưa thu', NULL),
(N'KY-HD2026-001-12', N'HD2026-001', 12, 12, '2026-12-15', 46200000, NULL, NULL, N'Chưa thu', NULL),
(N'KY-HD2026-002-01', N'HD2026-002', 1, 6, '2026-02-25', 115200000, '2026-02-25', N'Kế toán Phạm Thu Hà', N'Đã thu', N'Trả trước 6 tháng đầu'),
(N'KY-HD2026-002-07', N'HD2026-002', 7, 7, '2026-09-01', 19200000, '2026-08-31', N'Kế toán Phạm Thu Hà', N'Đã thu', NULL),
(N'KY-HD2026-002-08', N'HD2026-002', 8, 8, '2026-10-01', 19200000, '2026-10-01', N'Kế toán Phạm Thu Hà', N'Đã thu', NULL),
(N'KY-HD2026-002-09', N'HD2026-002', 9, 9, '2026-11-01', 19200000, NULL, NULL, N'Chưa thu', NULL),
(N'KY-HD2026-002-10', N'HD2026-002', 10, 10, '2026-12-01', 19200000, NULL, NULL, N'Chưa thu', NULL),
(N'KY-HD2026-002-11', N'HD2026-002', 11, 11, '2027-01-01', 19200000, NULL, NULL, N'Chưa thu', NULL),
(N'KY-HD2026-002-12', N'HD2026-002', 12, 12, '2027-02-01', 19200000, NULL, NULL, N'Chưa thu', NULL),
(N'KY-HD2026-003-01', N'HD2026-003', 1, 6, '2026-08-28', 224400000, '2026-08-28', N'Kế toán Phạm Thu Hà', N'Đã thu', N'Trả trước 6 tháng đầu')

INSERT INTO HoaDonDichVu VALUES
(N'DV-2026-08-001', N'HD2026-001', 8, 2026, '2026-08-31', '2026-08-31', 10100000, '2026-09-02', N'Đã thanh toán'),
(N'DV-2026-09-001', N'HD2026-001', 9, 2026, '2026-09-30', '2026-09-30', 11200000, NULL, N'Chưa thanh toán'),
(N'DV-2026-09-002', N'HD2026-002', 9, 2026, '2026-09-30', '2026-09-30', 5300000, '2026-10-02', N'Đã thanh toán'),
(N'DV-2026-09-003', N'HD2026-003', 9, 2026, '2026-09-30', '2026-09-30', 7900000, '2026-10-01', N'Đã thanh toán')

INSERT INTO ChiTietHoaDon VALUES
(N'DV-2026-08-001', N'DV01', 2400, 3500, 8400000),
(N'DV-2026-08-001', N'DV02', 60, 20000, 1200000),
(N'DV-2026-08-001', N'DV03', 1, 500000, 500000),
(N'DV-2026-09-001', N'DV01', 2600, 3500, 9100000),
(N'DV-2026-09-001', N'DV02', 65, 20000, 1300000),
(N'DV-2026-09-001', N'DV03', 1, 500000, 500000),
(N'DV-2026-09-001', N'DV04', 1, 300000, 300000),
(N'DV-2026-09-002', N'DV01', 1200, 3500, 4200000),
(N'DV-2026-09-002', N'DV02', 30, 20000, 600000),
(N'DV-2026-09-002', N'DV03', 1, 500000, 500000),
(N'DV-2026-09-003', N'DV01', 1800, 3500, 6300000),
(N'DV-2026-09-003', N'DV02', 40, 20000, 800000),
(N'DV-2026-09-003', N'DV03', 1, 500000, 500000),
(N'DV-2026-09-003', N'DV04', 1, 300000, 300000)

INSERT INTO NhanVien VALUES
(N'NV001', N'Nguyễn Văn An', N'Nam', '1982-05-10', N'Giám đốc', NULL, N'KH01', N'P501', '2026-01-15', N'Đang làm'),
(N'NV002', N'Lê Thị Hoa', N'Nữ', '1990-08-21', N'Kế toán trưởng', NULL, N'KH01', N'P501', '2026-01-15', N'Đang làm'),
(N'NV003', N'Phạm Quốc Huy', N'Nam', '1994-02-14', N'Lập trình viên', NULL, N'KH01', N'P502', '2026-02-01', N'Đang làm'),
(N'NV004', N'Trần Minh Long', N'Nam', '1980-12-03', N'Giám đốc', NULL, N'KH02', N'P302', '2026-03-01', N'Đang làm'),
(N'NV005', N'Đỗ Thu Trang', N'Nữ', '1992-07-30', N'Nhân viên kinh doanh', NULL, N'KH02', N'P302', '2026-03-05', N'Đang làm'),
(N'NV006', N'Hoàng Gia Bảo', N'Nam', '1985-09-18', N'Kiến trúc sư trưởng', NULL, N'KH03', N'P801', '2026-09-01', N'Đang làm'),
(N'NV007', N'Vũ Thị Mai', N'Nữ', '1996-04-25', N'Nhân viên thiết kế', NULL, N'KH03', N'P801', '2026-09-03', N'Đang làm')

INSERT INTO TheGiuXe VALUES
(N'TX001', N'NV001', N'51A-123.45', N'Ô tô', N'Toyota Camry', N'Đen', '2026-01-20', N'Đang dùng'),
(N'TX002', N'NV002', N'59X1-234.56', N'Xe máy', N'Honda Vision', N'Trắng', '2026-01-20', N'Đang dùng'),
(N'TX003', N'NV004', N'59P1-888.88', N'Xe máy', N'Yamaha Exciter', N'Xanh', '2026-03-02', N'Đang dùng'),
(N'TX004', N'NV006', N'51G-678.90', N'Ô tô', N'Mazda 3', N'Trắng', '2026-09-02', N'Đang dùng')

INSERT INTO PhieuKiemTra VALUES
(N'KT2025-001', '2025-09-20', N'Nguyễn Thanh Tùng', N'Kiểm tra định kỳ tầng 5'),
(N'KT2025-002', '2025-10-15', N'Nguyễn Thanh Tùng', N'Kiểm tra định kỳ tầng 1'),
(N'KT2026-001', '2026-04-10', N'Nguyễn Thanh Tùng', N'Kiểm tra định kỳ tầng 3'),
(N'KT2026-002', '2026-02-01', N'Nguyễn Thanh Tùng', N'Kiểm tra tầng 1'),
(N'KT2026-003', '2026-03-01', N'Nguyễn Thanh Tùng', N'Kiểm tra tầng 2, 3')

INSERT INTO ChiTietKiemTra VALUES
(N'KT2025-001', N'P501', N'Tốt', 0, NULL, NULL),
(N'KT2025-001', N'P502', N'Tốt', 0, NULL, NULL),
(N'KT2025-002', N'P101', N'Tốt', 0, NULL, NULL),
(N'KT2026-001', N'P302', N'Tốt', 1, N'Khách tự đục tường làm thêm phòng họp', NULL),
(N'KT2026-002', N'P102', N'Cần sửa chữa', 0, N'Thấm trần góc phòng', N'Sơn lại trần trước tháng 6/2026'),
(N'KT2026-003', N'P201', N'Tốt', 0, NULL, NULL),
(N'KT2026-003', N'P303', N'Hư hỏng', 0, N'Hệ thống điện cũ', N'Thay dây điện, tạm ngưng cho thuê')

INSERT INTO PhieuPhat VALUES
(N'PH2026-001', N'KT2026-001', N'P302', N'HD2026-002', '2026-04-12', N'Tự ý thay đổi kết cấu văn phòng (đục tường)', 10000000, '2026-05-10', N'Đã nộp')
GO
