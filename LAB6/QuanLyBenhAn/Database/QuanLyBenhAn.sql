CREATE DATABASE QuanLyBenhAn;
GO
USE QuanLyBenhAn;
GO

CREATE TABLE NhanVien(
 MaNV varchar(20) NOT NULL PRIMARY KEY,
 HoTen nvarchar(120) NOT NULL,
 VaiTro nvarchar(50) NOT NULL,
 SoDienThoai varchar(20) NULL,
 CONSTRAINT CK_NhanVien_VaiTro CHECK(VaiTro IN (N'Tiếp nhận',N'CSKH',N'Thu ngân',N'Quản lý'))
);

CREATE TABLE Khoa(
 MaKhoa varchar(20) NOT NULL PRIMARY KEY,
 TenKhoa nvarchar(100) NOT NULL UNIQUE,
 PhiKham decimal(18,2) NOT NULL CHECK(PhiKham >= 0)
);

CREATE TABLE BacSi(
 MaBS varchar(20) NOT NULL PRIMARY KEY,
 HoTen nvarchar(120) NOT NULL,
 MaKhoa varchar(20) NOT NULL,
 ChuyenMon nvarchar(100) NULL,
 CONSTRAINT FK_BacSi_Khoa FOREIGN KEY(MaKhoa) REFERENCES Khoa(MaKhoa)
);

CREATE TABLE BenhNhan(
 MaBN varchar(20) NOT NULL PRIMARY KEY,
 HoTen nvarchar(120) NOT NULL,
 DiaChi nvarchar(250) NOT NULL,
 NgaySinh date NOT NULL,
 SoDienThoai varchar(20) NOT NULL,
 Anh varbinary(max) NULL
);

CREATE TABLE PhieuDangKy(
 SoPhieuDK varchar(30) NOT NULL PRIMARY KEY,
 MaBN varchar(20) NOT NULL UNIQUE,
 NgayLap datetime NOT NULL,
 MaNV varchar(20) NOT NULL,
 CONSTRAINT FK_PhieuDK_BN FOREIGN KEY(MaBN) REFERENCES BenhNhan(MaBN),
 CONSTRAINT FK_PhieuDK_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE HoSoBenhAn(
 MaHoSo varchar(20) NOT NULL PRIMARY KEY,
 MaBN varchar(20) NOT NULL UNIQUE,
 SoPhieuDK varchar(30) NOT NULL UNIQUE,
 NgayCap date NOT NULL,
 CONSTRAINT FK_HoSo_BN FOREIGN KEY(MaBN) REFERENCES BenhNhan(MaBN),
 CONSTRAINT FK_HoSo_PhieuDK FOREIGN KEY(SoPhieuDK) REFERENCES PhieuDangKy(SoPhieuDK)
);

CREATE TABLE LePhiNam(
 MaLePhi varchar(30) NOT NULL PRIMARY KEY,
 MaHoSo varchar(20) NOT NULL,
 Nam int NOT NULL CHECK(Nam >= 2000),
 SoTien decimal(18,2) NOT NULL CHECK(SoTien > 0),
 NgayDong datetime NOT NULL,
 MaNV varchar(20) NOT NULL,
 CONSTRAINT UQ_LePhi_HoSo_Nam UNIQUE(MaHoSo,Nam),
 CONSTRAINT FK_LePhi_HoSo FOREIGN KEY(MaHoSo) REFERENCES HoSoBenhAn(MaHoSo),
 CONSTRAINT FK_LePhi_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE LichHen(
 MaLichHen varchar(30) NOT NULL PRIMARY KEY,
 MaHoSo varchar(20) NOT NULL,
 Quy int NOT NULL CHECK(Quy BETWEEN 1 AND 4),
 Nam int NOT NULL,
 NgayGioHen datetime NOT NULL,
 MaNV varchar(20) NOT NULL,
 TrangThai nvarchar(20) NOT NULL DEFAULT N'Đã hẹn',
 CONSTRAINT CK_LichHen_TT CHECK(TrangThai IN (N'Đã hẹn',N'Đã khám',N'Hủy')),
 CONSTRAINT FK_LichHen_HoSo FOREIGN KEY(MaHoSo) REFERENCES HoSoBenhAn(MaHoSo),
 CONSTRAINT FK_LichHen_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);
GO

CREATE UNIQUE INDEX UX_LichHen_Quy ON LichHen(MaHoSo,Quy,Nam) WHERE TrangThai <> N'Hủy';
GO

CREATE TABLE PhieuKham(
 SoPhieuKham varchar(30) NOT NULL PRIMARY KEY,
 MaHoSo varchar(20) NOT NULL,
 NgayGioKham datetime NOT NULL,
 MaBS varchar(20) NOT NULL,
 MaKhoa varchar(20) NOT NULL,
 LoaiKham nvarchar(20) NOT NULL,
 TrieuChung nvarchar(500) NULL,
 ThanNhiet decimal(4,1) NULL CHECK(ThanNhiet IS NULL OR ThanNhiet BETWEEN 30 AND 45),
 HuyetAp varchar(20) NULL,
 ChanDoan nvarchar(500) NULL,
 MaLichHen varchar(30) NULL,
 TrangThai nvarchar(20) NOT NULL DEFAULT N'Đang khám',
 MaNVGhiNhan varchar(20) NULL,
 NgayGhiNhan datetime NULL,
 CONSTRAINT CK_PhieuKham_Loai CHECK(LoaiKham IN (N'Điều trị',N'Định kỳ')),
 CONSTRAINT CK_PhieuKham_TT CHECK(TrangThai IN (N'Đang khám',N'Hoàn tất')),
 CONSTRAINT FK_PhieuKham_HoSo FOREIGN KEY(MaHoSo) REFERENCES HoSoBenhAn(MaHoSo),
 CONSTRAINT FK_PhieuKham_BS FOREIGN KEY(MaBS) REFERENCES BacSi(MaBS),
 CONSTRAINT FK_PhieuKham_Khoa FOREIGN KEY(MaKhoa) REFERENCES Khoa(MaKhoa),
 CONSTRAINT FK_PhieuKham_Lich FOREIGN KEY(MaLichHen) REFERENCES LichHen(MaLichHen),
 CONSTRAINT FK_PhieuKham_NVGN FOREIGN KEY(MaNVGhiNhan) REFERENCES NhanVien(MaNV)
);
GO

CREATE UNIQUE INDEX UX_PhieuKham_Lich ON PhieuKham(MaLichHen) WHERE MaLichHen IS NOT NULL;
GO

CREATE TABLE XetNghiem(
 MaXN varchar(20) NOT NULL PRIMARY KEY,
 TenXN nvarchar(120) NOT NULL,
 DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0)
);

CREATE TABLE ChiTietXetNghiem(
 SoPhieuKham varchar(30) NOT NULL,
 MaXN varchar(20) NOT NULL,
 DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
 KetQua nvarchar(500) NULL,
 NgayThucHien datetime NULL,
 PRIMARY KEY(SoPhieuKham,MaXN),
 CONSTRAINT FK_CTXN_Phieu FOREIGN KEY(SoPhieuKham) REFERENCES PhieuKham(SoPhieuKham),
 CONSTRAINT FK_CTXN_XN FOREIGN KEY(MaXN) REFERENCES XetNghiem(MaXN)
);

CREATE TABLE Thuoc(
 MaThuoc varchar(20) NOT NULL PRIMARY KEY,
 TenThuoc nvarchar(120) NOT NULL,
 DonViTinh nvarchar(40) NOT NULL,
 DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0)
);

CREATE TABLE ToaThuoc(
 SoToa varchar(30) NOT NULL PRIMARY KEY,
 SoPhieuKham varchar(30) NOT NULL UNIQUE,
 NgayLap datetime NOT NULL,
 MaBS varchar(20) NOT NULL,
 LoiDan nvarchar(500) NULL,
 CONSTRAINT FK_Toa_Phieu FOREIGN KEY(SoPhieuKham) REFERENCES PhieuKham(SoPhieuKham),
 CONSTRAINT FK_Toa_BS FOREIGN KEY(MaBS) REFERENCES BacSi(MaBS)
);

CREATE TABLE ChiTietToaThuoc(
 SoToa varchar(30) NOT NULL,
 MaThuoc varchar(20) NOT NULL,
 SoLuong int NOT NULL CHECK(SoLuong > 0),
 DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
 LieuDung nvarchar(200) NOT NULL,
 PhanUngPhu nvarchar(250) NULL,
 ThanhTien AS (CONVERT(decimal(18,2),SoLuong * DonGia)) PERSISTED,
 PRIMARY KEY(SoToa,MaThuoc),
 CONSTRAINT FK_CTToa_Toa FOREIGN KEY(SoToa) REFERENCES ToaThuoc(SoToa),
 CONSTRAINT FK_CTToa_Thuoc FOREIGN KEY(MaThuoc) REFERENCES Thuoc(MaThuoc)
);

CREATE TABLE HoaDonVienPhi(
 SoHoaDon varchar(30) NOT NULL PRIMARY KEY,
 SoPhieuKham varchar(30) NOT NULL UNIQUE,
 NgayLap datetime NOT NULL,
 MaNV varchar(20) NOT NULL,
 TienKham decimal(18,2) NOT NULL CHECK(TienKham >= 0),
 TienXetNghiem decimal(18,2) NOT NULL CHECK(TienXetNghiem >= 0),
 TienThuoc decimal(18,2) NOT NULL CHECK(TienThuoc >= 0),
 TongTien AS (CONVERT(decimal(18,2),TienKham + TienXetNghiem + TienThuoc)) PERSISTED,
 TrangThai nvarchar(30) NOT NULL DEFAULT N'Chưa thanh toán',
 CONSTRAINT CK_HoaDon_TT CHECK(TrangThai IN (N'Chưa thanh toán',N'Đã thanh toán')),
 CONSTRAINT FK_HoaDon_Phieu FOREIGN KEY(SoPhieuKham) REFERENCES PhieuKham(SoPhieuKham),
 CONSTRAINT FK_HoaDon_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ThanhToanVienPhi(
 MaThanhToan varchar(30) NOT NULL PRIMARY KEY,
 SoHoaDon varchar(30) NOT NULL,
 NgayThanhToan datetime NOT NULL,
 HinhThuc nvarchar(30) NOT NULL,
 SoTien decimal(18,2) NOT NULL CHECK(SoTien > 0),
 CONSTRAINT CK_TTVP_HinhThuc CHECK(HinhThuc IN (N'Tiền mặt',N'Chuyển khoản',N'Thẻ',N'Ví điện tử')),
 CONSTRAINT FK_TTVP_HoaDon FOREIGN KEY(SoHoaDon) REFERENCES HoaDonVienPhi(SoHoaDon)
);
GO

CREATE INDEX IX_PhieuKham_HoSo ON PhieuKham(MaHoSo,NgayGioKham);
CREATE INDEX IX_LichHen_HoSo ON LichHen(MaHoSo,Nam,Quy);
GO

INSERT INTO NhanVien(MaNV,HoTen,VaiTro,SoDienThoai) VALUES
('NV01',N'Nguyễn Thu Hà',N'Tiếp nhận','0901000001'),
('NV02',N'Trần Minh An',N'CSKH','0901000002'),
('NV03',N'Lê Hoàng Nam',N'Thu ngân','0901000003'),
('NV04',N'Phạm Quốc Bảo',N'Quản lý','0901000004');

INSERT INTO Khoa(MaKhoa,TenKhoa,PhiKham) VALUES
('NOI',N'Nội tổng quát',150000),
('NGOAI',N'Ngoại tổng quát',200000),
('TMH',N'Tai Mũi Họng',180000);

INSERT INTO BacSi(MaBS,HoTen,MaKhoa,ChuyenMon) VALUES
('BS01',N'BS. Võ Thanh Sơn','NOI',N'Nội tiêu hóa'),
('BS02',N'BS. Đặng Mai Lan','NOI',N'Tim mạch'),
('BS03',N'BS. Hoàng Gia Huy','NGOAI',N'Chấn thương'),
('BS04',N'BS. Bùi Ngọc Anh','TMH',N'Tai Mũi Họng');

INSERT INTO XetNghiem(MaXN,TenXN,DonGia) VALUES
('XN01',N'Công thức máu',120000),
('XN02',N'Đường huyết',60000),
('XN03',N'Nước tiểu 10 thông số',80000),
('XN04',N'X-quang ngực',250000);

INSERT INTO Thuoc(MaThuoc,TenThuoc,DonViTinh,DonGia) VALUES
('T01',N'Paracetamol 500mg',N'Viên',1500),
('T02',N'Amoxicillin 500mg',N'Viên',3500),
('T03',N'Omeprazole 20mg',N'Viên',4000),
('T04',N'Vitamin C 500mg',N'Viên',1000);
GO