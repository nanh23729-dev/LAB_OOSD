/* =====================================================================
   BÀI 7 - HỆ THỐNG QUẢN LÝ NHÂN SỰ - CÔNG TY SƠN ĐÔNG Á
   Script tạo CSDL QuanLyNhanSuDB, ràng buộc và dữ liệu mẫu
   SQL Server 2016+ / LocalDB
   ===================================================================== */
IF DB_ID(N'QuanLyNhanSuDB') IS NULL
    CREATE DATABASE QuanLyNhanSuDB;
GO
USE QuanLyNhanSuDB;
GO

/* ---------- Xóa bảng cũ theo thứ tự phụ thuộc ---------- */
IF OBJECT_ID('dbo.BangLuong','U') IS NOT NULL DROP TABLE dbo.BangLuong;
IF OBJECT_ID('dbo.PhieuThuNopPhat','U') IS NOT NULL DROP TABLE dbo.PhieuThuNopPhat;
IF OBJECT_ID('dbo.QuyetDinhKyLuat','U') IS NOT NULL DROP TABLE dbo.QuyetDinhKyLuat;
IF OBJECT_ID('dbo.PhieuChiKhenThuong','U') IS NOT NULL DROP TABLE dbo.PhieuChiKhenThuong;
IF OBJECT_ID('dbo.QuyetDinhKhenThuong','U') IS NOT NULL DROP TABLE dbo.QuyetDinhKhenThuong;
IF OBJECT_ID('dbo.ChiTietPhuTroi','U') IS NOT NULL DROP TABLE dbo.ChiTietPhuTroi;
IF OBJECT_ID('dbo.PhieuPhuTroi','U') IS NOT NULL DROP TABLE dbo.PhieuPhuTroi;
IF OBJECT_ID('dbo.ChiTietChamCong','U') IS NOT NULL DROP TABLE dbo.ChiTietChamCong;
IF OBJECT_ID('dbo.BangChamCong','U') IS NOT NULL DROP TABLE dbo.BangChamCong;
IF OBJECT_ID('dbo.ChiTietPhanCong','U') IS NOT NULL DROP TABLE dbo.ChiTietPhanCong;
IF OBJECT_ID('dbo.KeHoachPhanCong','U') IS NOT NULL DROP TABLE dbo.KeHoachPhanCong;
IF OBJECT_ID('dbo.QuyetDinhChucVu','U') IS NOT NULL DROP TABLE dbo.QuyetDinhChucVu;
IF OBJECT_ID('dbo.QuyetDinhLuong','U') IS NOT NULL DROP TABLE dbo.QuyetDinhLuong;
IF OBJECT_ID('dbo.HoSoBaoHiem','U') IS NOT NULL DROP TABLE dbo.HoSoBaoHiem;
IF OBJECT_ID('dbo.HopDongLaoDong','U') IS NOT NULL DROP TABLE dbo.HopDongLaoDong;
IF OBJECT_ID('dbo.QuyetDinhTuyenDung','U') IS NOT NULL DROP TABLE dbo.QuyetDinhTuyenDung;
IF OBJECT_ID('dbo.NhanVien','U') IS NOT NULL DROP TABLE dbo.NhanVien;
IF OBJECT_ID('dbo.CaLamViec','U') IS NOT NULL DROP TABLE dbo.CaLamViec;
IF OBJECT_ID('dbo.ChucVu','U') IS NOT NULL DROP TABLE dbo.ChucVu;
IF OBJECT_ID('dbo.PhongBan','U') IS NOT NULL DROP TABLE dbo.PhongBan;
GO

/* =========================== DANH MỤC =========================== */
CREATE TABLE dbo.PhongBan (
    MaPB        NVARCHAR(10)  NOT NULL PRIMARY KEY,
    TenPB       NVARCHAR(100) NOT NULL UNIQUE,
    LoaiDonVi   NVARCHAR(20)  NOT NULL
        CONSTRAINT CK_PhongBan_Loai CHECK (LoaiDonVi IN (N'Phòng', N'Ban', N'Phân xưởng')),
    DienThoai   NVARCHAR(20)  NULL
);

CREATE TABLE dbo.ChucVu (
    MaCV        NVARCHAR(10)  NOT NULL PRIMARY KEY,
    TenCV       NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE dbo.CaLamViec (
    MaCa        NVARCHAR(10)  NOT NULL PRIMARY KEY,
    TenCa       NVARCHAR(50)  NOT NULL,
    GioBatDau   TIME          NOT NULL,
    GioKetThuc  TIME          NOT NULL,
    SoGio       DECIMAL(4,1)  NOT NULL CONSTRAINT CK_Ca_SoGio CHECK (SoGio > 0 AND SoGio <= 12)
);

/* =========================== NHÂN VIÊN =========================== */
-- TrangThai: Hồ sơ -> Thử việc -> Chính thức -> Nghỉ việc
CREATE TABLE dbo.NhanVien (
    MaNV        NVARCHAR(10)  NOT NULL PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    GioiTinh    NVARCHAR(5)   NOT NULL CONSTRAINT CK_NV_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    NgaySinh    DATE          NOT NULL,
    CCCD        NVARCHAR(12)  NOT NULL UNIQUE,
    DiaChi      NVARCHAR(200) NULL,
    DienThoai   NVARCHAR(20)  NULL,
    MaPB        NVARCHAR(10)  NULL,
    TrangThai   NVARCHAR(20)  NOT NULL CONSTRAINT DF_NV_TrangThai DEFAULT (N'Hồ sơ')
        CONSTRAINT CK_NV_TrangThai CHECK (TrangThai IN (N'Hồ sơ', N'Thử việc', N'Chính thức', N'Nghỉ việc')),
    CONSTRAINT FK_NV_PhongBan FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB)
);

/* =========================== TUYỂN DỤNG - HỢP ĐỒNG =========================== */
CREATE TABLE dbo.QuyetDinhTuyenDung (
    SoQD                NVARCHAR(20)  NOT NULL PRIMARY KEY,
    MaNV                NVARCHAR(10)  NOT NULL,
    MaPB                NVARCHAR(10)  NOT NULL,
    NgayKy              DATE          NOT NULL,
    NgayBatDauThuViec   DATE          NOT NULL,
    NgayKetThucThuViec  DATE          NOT NULL,
    LuongThuViec        DECIMAL(18,0) NOT NULL CONSTRAINT CK_QDTD_Luong CHECK (LuongThuViec > 0),
    DieuKhoan           NVARCHAR(1000) NOT NULL,
    NguoiKy             NVARCHAR(100) NOT NULL,
    KetQuaThuViec       NVARCHAR(20)  NULL
        CONSTRAINT CK_QDTD_KetQua CHECK (KetQuaThuViec IS NULL OR KetQuaThuViec IN (N'Đạt', N'Không đạt')),
    CONSTRAINT CK_QDTD_Ngay CHECK (NgayKetThucThuViec > NgayBatDauThuViec AND NgayBatDauThuViec >= NgayKy),
    CONSTRAINT FK_QDTD_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT FK_QDTD_PB FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB)
);

CREATE TABLE dbo.HopDongLaoDong (
    SoHD          NVARCHAR(20)  NOT NULL PRIMARY KEY,
    MaNV          NVARCHAR(10)  NOT NULL,
    SoQDTuyenDung NVARCHAR(20)  NOT NULL,
    LoaiHD        NVARCHAR(20)  NOT NULL CONSTRAINT CK_HD_Loai CHECK (LoaiHD IN (N'Dài hạn', N'Ngắn hạn')),
    NgayKy        DATE          NOT NULL,
    NgayBatDau    DATE          NOT NULL,
    NgayKetThuc   DATE          NULL,
    NguoiKy       NVARCHAR(100) NOT NULL,
    CONSTRAINT CK_HD_NgayKetThuc CHECK (
        (LoaiHD = N'Dài hạn' AND NgayKetThuc IS NULL) OR
        (LoaiHD = N'Ngắn hạn' AND NgayKetThuc IS NOT NULL AND NgayKetThuc > NgayBatDau)),
    CONSTRAINT FK_HD_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT FK_HD_QDTD FOREIGN KEY (SoQDTuyenDung) REFERENCES dbo.QuyetDinhTuyenDung(SoQD)
);
-- Một quyết định tuyển dụng chỉ dẫn tới một hợp đồng chính thức
CREATE UNIQUE INDEX UX_HD_QDTD ON dbo.HopDongLaoDong(SoQDTuyenDung);

CREATE TABLE dbo.HoSoBaoHiem (
    MaHSBH      NVARCHAR(20)  NOT NULL PRIMARY KEY,
    MaNV        NVARCHAR(10)  NOT NULL UNIQUE,
    SoHD        NVARCHAR(20)  NOT NULL,
    SoSoBHXH    NVARCHAR(20)  NOT NULL UNIQUE,
    SoTheBHYT   NVARCHAR(20)  NOT NULL UNIQUE,
    NgayThamGia DATE          NOT NULL,
    TyLeBHXH    DECIMAL(5,2)  NOT NULL CONSTRAINT DF_BH_XH DEFAULT (8),
    TyLeBHYT    DECIMAL(5,2)  NOT NULL CONSTRAINT DF_BH_YT DEFAULT (1.5),
    CONSTRAINT CK_BH_TyLe CHECK (TyLeBHXH BETWEEN 0 AND 100 AND TyLeBHYT BETWEEN 0 AND 100),
    CONSTRAINT FK_BH_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT FK_BH_HD FOREIGN KEY (SoHD) REFERENCES dbo.HopDongLaoDong(SoHD)
);

/* =========================== QUYẾT ĐỊNH LƯƠNG - CHỨC VỤ =========================== */
CREATE TABLE dbo.QuyetDinhLuong (
    SoQD          NVARCHAR(20)  NOT NULL PRIMARY KEY,
    MaNV          NVARCHAR(10)  NOT NULL,
    NgayKy        DATE          NOT NULL,
    NgayHieuLuc   DATE          NOT NULL,
    LuongCoBan    DECIMAL(18,0) NOT NULL CONSTRAINT CK_QDL_LCB CHECK (LuongCoBan > 0),
    PhuCapLuong   DECIMAL(18,0) NOT NULL CONSTRAINT DF_QDL_PCL DEFAULT (0),
    PhuCapDocHai  DECIMAL(18,0) NOT NULL CONSTRAINT DF_QDL_PCDH DEFAULT (0),
    NguoiKy       NVARCHAR(100) NOT NULL,
    CONSTRAINT CK_QDL_PhuCap CHECK (PhuCapLuong >= 0 AND PhuCapDocHai >= 0),
    CONSTRAINT CK_QDL_Ngay CHECK (NgayHieuLuc >= NgayKy),
    CONSTRAINT FK_QDL_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
);
CREATE UNIQUE INDEX UX_QDL_NV_HieuLuc ON dbo.QuyetDinhLuong(MaNV, NgayHieuLuc);

CREATE TABLE dbo.QuyetDinhChucVu (
    SoQD          NVARCHAR(20)  NOT NULL PRIMARY KEY,
    MaNV          NVARCHAR(10)  NOT NULL,
    MaCV          NVARCHAR(10)  NOT NULL,
    MaPB          NVARCHAR(10)  NOT NULL,
    NgayKy        DATE          NOT NULL,
    NgayHieuLuc   DATE          NOT NULL,
    PhuCapChucVu  DECIMAL(18,0) NOT NULL CONSTRAINT DF_QDCV_PC DEFAULT (0)
        CONSTRAINT CK_QDCV_PC CHECK (PhuCapChucVu >= 0),
    NguoiKy       NVARCHAR(100) NOT NULL,
    CONSTRAINT CK_QDCV_Ngay CHECK (NgayHieuLuc >= NgayKy),
    CONSTRAINT FK_QDCV_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT FK_QDCV_CV FOREIGN KEY (MaCV) REFERENCES dbo.ChucVu(MaCV),
    CONSTRAINT FK_QDCV_PB FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB)
);
CREATE UNIQUE INDEX UX_QDCV_NV_HieuLuc ON dbo.QuyetDinhChucVu(MaNV, NgayHieuLuc);

/* =========================== PHÂN CÔNG - CHẤM CÔNG - PHỤ TRỘI =========================== */
CREATE TABLE dbo.KeHoachPhanCong (
    MaKH      NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaPB      NVARCHAR(10) NOT NULL,
    TuNgay    DATE         NOT NULL,
    DenNgay   DATE         NOT NULL,
    MaNVLap   NVARCHAR(10) NOT NULL,
    NgayLap   DATE         NOT NULL,
    CONSTRAINT CK_KH_Tuan CHECK (DenNgay = DATEADD(DAY, 6, TuNgay)),
    CONSTRAINT UQ_KH_PB_Tuan UNIQUE (MaPB, TuNgay),
    CONSTRAINT FK_KH_PB FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB),
    CONSTRAINT FK_KH_NVLap FOREIGN KEY (MaNVLap) REFERENCES dbo.NhanVien(MaNV)
);

CREATE TABLE dbo.ChiTietPhanCong (
    MaKH              NVARCHAR(20) NOT NULL,
    MaNV              NVARCHAR(10) NOT NULL,
    NgayLam           DATE         NOT NULL,
    MaCa              NVARCHAR(10) NOT NULL,
    GioPhuTroiDuKien  DECIMAL(4,1) NOT NULL CONSTRAINT DF_CTPC_PT DEFAULT (0)
        CONSTRAINT CK_CTPC_PT CHECK (GioPhuTroiDuKien >= 0),
    CONSTRAINT PK_ChiTietPhanCong PRIMARY KEY (MaKH, MaNV, NgayLam),
    CONSTRAINT FK_CTPC_KH FOREIGN KEY (MaKH) REFERENCES dbo.KeHoachPhanCong(MaKH),
    CONSTRAINT FK_CTPC_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT FK_CTPC_Ca FOREIGN KEY (MaCa) REFERENCES dbo.CaLamViec(MaCa)
);

CREATE TABLE dbo.BangChamCong (
    MaBCC     NVARCHAR(20) NOT NULL PRIMARY KEY,
    MaPB      NVARCHAR(10) NOT NULL,
    Thang     INT          NOT NULL CONSTRAINT CK_BCC_Thang CHECK (Thang BETWEEN 1 AND 12),
    Nam       INT          NOT NULL CONSTRAINT CK_BCC_Nam CHECK (Nam BETWEEN 2000 AND 2100),
    NgayLap   DATE         NOT NULL,
    MaNVLap   NVARCHAR(10) NOT NULL,
    CONSTRAINT UQ_BCC_PB_Thang UNIQUE (MaPB, Thang, Nam),
    CONSTRAINT FK_BCC_PB FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB),
    CONSTRAINT FK_BCC_NVLap FOREIGN KEY (MaNVLap) REFERENCES dbo.NhanVien(MaNV)
);

CREATE TABLE dbo.ChiTietChamCong (
    MaBCC                NVARCHAR(20) NOT NULL,
    MaNV                 NVARCHAR(10) NOT NULL,
    SoNgayCong           DECIMAL(4,1) NOT NULL,
    SoNgayNghiPhep       DECIMAL(4,1) NOT NULL CONSTRAINT DF_CTCC_NP DEFAULT (0),
    SoNgayNghiKhongPhep  DECIMAL(4,1) NOT NULL CONSTRAINT DF_CTCC_NKP DEFAULT (0),
    CONSTRAINT PK_ChiTietChamCong PRIMARY KEY (MaBCC, MaNV),
    CONSTRAINT CK_CTCC_SoNgay CHECK (SoNgayCong >= 0 AND SoNgayNghiPhep >= 0 AND SoNgayNghiKhongPhep >= 0
                                     AND SoNgayCong + SoNgayNghiPhep + SoNgayNghiKhongPhep <= 31),
    CONSTRAINT FK_CTCC_BCC FOREIGN KEY (MaBCC) REFERENCES dbo.BangChamCong(MaBCC),
    CONSTRAINT FK_CTCC_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
);

CREATE TABLE dbo.PhieuPhuTroi (
    SoPhieu       NVARCHAR(20) NOT NULL PRIMARY KEY,
    NgayPhuTroi   DATE         NOT NULL,
    SoGioPhuTroi  DECIMAL(4,1) NOT NULL CONSTRAINT CK_PPT_SoGio CHECK (SoGioPhuTroi > 0 AND SoGioPhuTroi <= 12),
    HinhThuc      NVARCHAR(20) NOT NULL
        CONSTRAINT CK_PPT_HinhThuc CHECK (HinhThuc IN (N'Tăng ca', N'Ngày lễ', N'Ngày nghỉ')),
    MaPB          NVARCHAR(10) NOT NULL,
    MaNVLap       NVARCHAR(10) NOT NULL,
    CONSTRAINT FK_PPT_PB FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB),
    CONSTRAINT FK_PPT_NVLap FOREIGN KEY (MaNVLap) REFERENCES dbo.NhanVien(MaNV)
);

CREATE TABLE dbo.ChiTietPhuTroi (
    SoPhieu  NVARCHAR(20) NOT NULL,
    MaNV     NVARCHAR(10) NOT NULL,
    SoGio    DECIMAL(4,1) NOT NULL CONSTRAINT CK_CTPT_SoGio CHECK (SoGio > 0),
    CONSTRAINT PK_ChiTietPhuTroi PRIMARY KEY (SoPhieu, MaNV),
    CONSTRAINT FK_CTPT_PPT FOREIGN KEY (SoPhieu) REFERENCES dbo.PhieuPhuTroi(SoPhieu),
    CONSTRAINT FK_CTPT_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
);

/* =========================== KHEN THƯỞNG - KỶ LUẬT =========================== */
CREATE TABLE dbo.QuyetDinhKhenThuong (
    SoQD            NVARCHAR(20)  NOT NULL PRIMARY KEY,
    NgayKy          DATE          NOT NULL,
    LoaiKhenThuong  NVARCHAR(30)  NOT NULL
        CONSTRAINT CK_QDKT_Loai CHECK (LoaiKhenThuong IN (N'Thành tích', N'Ngày lễ', N'Thưởng cuối năm', N'Lương tháng 13')),
    DoiTuong        NVARCHAR(10)  NOT NULL CONSTRAINT CK_QDKT_DoiTuong CHECK (DoiTuong IN (N'Cá nhân', N'Tập thể')),
    MaNV            NVARCHAR(10)  NULL,
    MaPB            NVARCHAR(10)  NULL,
    NoiDung         NVARCHAR(500) NOT NULL,
    SoTien          DECIMAL(18,0) NOT NULL CONSTRAINT CK_QDKT_SoTien CHECK (SoTien > 0),
    HinhThucChi     NVARCHAR(20)  NOT NULL
        CONSTRAINT CK_QDKT_HinhThuc CHECK (HinhThucChi IN (N'Phiếu chi', N'Cộng vào lương')),
    NguoiKy         NVARCHAR(100) NOT NULL,
    CONSTRAINT CK_QDKT_DoiTuongHopLe CHECK (
        (DoiTuong = N'Cá nhân' AND MaNV IS NOT NULL AND MaPB IS NULL) OR
        (DoiTuong = N'Tập thể' AND MaPB IS NOT NULL AND MaNV IS NULL AND HinhThucChi = N'Phiếu chi')),
    CONSTRAINT FK_QDKT_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT FK_QDKT_PB FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB)
);

CREATE TABLE dbo.PhieuChiKhenThuong (
    SoPhieuChi  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    SoQD        NVARCHAR(20)  NOT NULL UNIQUE,
    NgayChi     DATE          NOT NULL,
    SoTien      DECIMAL(18,0) NOT NULL CONSTRAINT CK_PCKT_SoTien CHECK (SoTien > 0),
    NguoiNhan   NVARCHAR(100) NOT NULL,
    MaNVLap     NVARCHAR(10)  NOT NULL,
    CONSTRAINT FK_PCKT_QD FOREIGN KEY (SoQD) REFERENCES dbo.QuyetDinhKhenThuong(SoQD),
    CONSTRAINT FK_PCKT_NVLap FOREIGN KEY (MaNVLap) REFERENCES dbo.NhanVien(MaNV)
);

CREATE TABLE dbo.QuyetDinhKyLuat (
    SoQD          NVARCHAR(20)  NOT NULL PRIMARY KEY,
    NgayKy        DATE          NOT NULL,
    DoiTuong      NVARCHAR(10)  NOT NULL CONSTRAINT CK_QDKL_DoiTuong CHECK (DoiTuong IN (N'Cá nhân', N'Tập thể')),
    MaNV          NVARCHAR(10)  NULL,
    MaPB          NVARCHAR(10)  NULL,
    LyDo          NVARCHAR(500) NOT NULL,
    SoTienPhat    DECIMAL(18,0) NOT NULL CONSTRAINT CK_QDKL_SoTien CHECK (SoTienPhat > 0),
    HinhThucThu   NVARCHAR(20)  NOT NULL
        CONSTRAINT CK_QDKL_HinhThuc CHECK (HinhThucThu IN (N'Phiếu thu', N'Trừ lương')),
    NguoiKy       NVARCHAR(100) NOT NULL,
    CONSTRAINT CK_QDKL_DoiTuongHopLe CHECK (
        (DoiTuong = N'Cá nhân' AND MaNV IS NOT NULL AND MaPB IS NULL) OR
        (DoiTuong = N'Tập thể' AND MaPB IS NOT NULL AND MaNV IS NULL AND HinhThucThu = N'Phiếu thu')),
    CONSTRAINT FK_QDKL_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT FK_QDKL_PB FOREIGN KEY (MaPB) REFERENCES dbo.PhongBan(MaPB)
);

CREATE TABLE dbo.PhieuThuNopPhat (
    SoPhieuThu  NVARCHAR(20)  NOT NULL PRIMARY KEY,
    SoQD        NVARCHAR(20)  NOT NULL UNIQUE,
    NgayThu     DATE          NOT NULL,
    SoTien      DECIMAL(18,0) NOT NULL CONSTRAINT CK_PTNP_SoTien CHECK (SoTien > 0),
    NguoiNop    NVARCHAR(100) NOT NULL,
    MaNVLap     NVARCHAR(10)  NOT NULL,
    CONSTRAINT FK_PTNP_QD FOREIGN KEY (SoQD) REFERENCES dbo.QuyetDinhKyLuat(SoQD),
    CONSTRAINT FK_PTNP_NVLap FOREIGN KEY (MaNVLap) REFERENCES dbo.NhanVien(MaNV)
);

/* =========================== BẢNG LƯƠNG =========================== */
CREATE TABLE dbo.BangLuong (
    MaBL               NVARCHAR(30)  NOT NULL PRIMARY KEY,
    MaNV               NVARCHAR(10)  NOT NULL,
    Thang              INT           NOT NULL CONSTRAINT CK_BL_Thang CHECK (Thang BETWEEN 1 AND 12),
    Nam                INT           NOT NULL,
    LuongCoBan         DECIMAL(18,0) NOT NULL,
    PhuCapChucVu       DECIMAL(18,0) NOT NULL,
    PhuCapLuong        DECIMAL(18,0) NOT NULL,
    PhuCapDocHai       DECIMAL(18,0) NOT NULL,
    SoNgayCong         DECIMAL(4,1)  NOT NULL,
    TienNgayCong       DECIMAL(18,0) NOT NULL,
    SoGioPhuTroi       DECIMAL(6,1)  NOT NULL,
    TienPhuTroi        DECIMAL(18,0) NOT NULL,
    TienThuong         DECIMAL(18,0) NOT NULL,
    TienPhat           DECIMAL(18,0) NOT NULL,
    TruBHXH            DECIMAL(18,0) NOT NULL,
    TruBHYT            DECIMAL(18,0) NOT NULL,
    ThucLinh           DECIMAL(18,0) NOT NULL,
    NgayLap            DATE          NOT NULL,
    CONSTRAINT UQ_BL_NV_Thang UNIQUE (MaNV, Thang, Nam),
    CONSTRAINT FK_BL_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
);
GO

CREATE INDEX IX_QDTD_MaNV  ON dbo.QuyetDinhTuyenDung(MaNV);
CREATE INDEX IX_HD_MaNV    ON dbo.HopDongLaoDong(MaNV);
CREATE INDEX IX_CTPT_MaNV  ON dbo.ChiTietPhuTroi(MaNV);
CREATE INDEX IX_PPT_Ngay   ON dbo.PhieuPhuTroi(NgayPhuTroi);
CREATE INDEX IX_QDKT_NgayKy ON dbo.QuyetDinhKhenThuong(NgayKy);
CREATE INDEX IX_QDKL_NgayKy ON dbo.QuyetDinhKyLuat(NgayKy);
GO

/* =========================== DỮ LIỆU MẪU =========================== */
INSERT INTO dbo.PhongBan(MaPB, TenPB, LoaiDonVi, DienThoai) VALUES
(N'PB01', N'Phòng Tổ chức - Hành chính', N'Phòng',      N'02837500001'),
(N'PB02', N'Phòng Tài chính - Kế toán',  N'Phòng',      N'02837500002'),
(N'PB03', N'Phòng Kỹ thuật',             N'Phòng',      N'02837500003'),
(N'BCC',  N'Ban Chấm công',              N'Ban',        N'02837500004'),
(N'PX01', N'Phân xưởng Sản xuất sơn',    N'Phân xưởng', N'02837500005');

INSERT INTO dbo.ChucVu(MaCV, TenCV) VALUES
(N'CV01', N'Giám đốc'), (N'CV02', N'Trưởng phòng'), (N'CV03', N'Quản đốc phân xưởng'),
(N'CV04', N'Nhân viên'), (N'CV05', N'Công nhân');

INSERT INTO dbo.CaLamViec(MaCa, TenCa, GioBatDau, GioKetThuc, SoGio) VALUES
(N'CA1', N'Ca sáng',      '06:00', '14:00', 8),
(N'CA2', N'Ca chiều',     '14:00', '22:00', 8),
(N'CAHC', N'Hành chính',  '08:00', '17:00', 8);

INSERT INTO dbo.NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, CCCD, DiaChi, DienThoai, MaPB, TrangThai) VALUES
(N'NV001', N'Trần Quốc Bảo',  N'Nam', '1975-03-12', N'079075000001', N'Quận 1, TP.HCM',      N'0903000001', N'PB01', N'Chính thức'),
(N'NV002', N'Lê Thị Mai',     N'Nữ',  '1988-07-20', N'079188000002', N'Quận 3, TP.HCM',      N'0903000002', N'PB01', N'Chính thức'),
(N'NV003', N'Phạm Minh Tuấn', N'Nam', '1985-11-02', N'079085000003', N'TP. Thủ Đức, TP.HCM', N'0903000003', N'PX01', N'Chính thức'),
(N'NV004', N'Nguyễn Văn Nam', N'Nam', '1995-01-15', N'079095000004', N'Bình Tân, TP.HCM',    N'0903000004', N'PX01', N'Chính thức'),
(N'NV005', N'Võ Thị Hồng',    N'Nữ',  '1997-05-30', N'079197000005', N'Gò Vấp, TP.HCM',      N'0903000005', N'PB02', N'Chính thức'),
(N'NV006', N'Đặng Văn Khoa',  N'Nam', '2000-09-09', N'079200000006', N'Quận 12, TP.HCM',     N'0903000006', N'PX01', N'Thử việc'),
(N'NV007', N'Huỳnh Thị Lan',  N'Nữ',  '1992-12-01', N'079192000007', N'Tân Bình, TP.HCM',    N'0903000007', N'BCC',  N'Chính thức'),
(N'NV008', N'Bùi Thanh Tâm',  N'Nam', '2001-04-18', N'079201000008', N'Bình Thạnh, TP.HCM',  N'0903000008', NULL,    N'Hồ sơ');

INSERT INTO dbo.QuyetDinhTuyenDung(SoQD, MaNV, MaPB, NgayKy, NgayBatDauThuViec, NgayKetThucThuViec, LuongThuViec, DieuKhoan, NguoiKy, KetQuaThuViec) VALUES
(N'QDTD-2020-01', N'NV002', N'PB01', '2020-02-25', '2020-03-01', '2020-04-30', 8000000,  N'Thử việc 2 tháng, hưởng 85% lương chính thức; công ty bố trí công việc tại phòng TC-HC.', N'Trần Quốc Bảo', N'Đạt'),
(N'QDTD-2021-03', N'NV003', N'PX01', '2021-05-25', '2021-06-01', '2021-07-31', 9000000,  N'Thử việc 2 tháng tại phân xưởng; tuân thủ nội quy an toàn hóa chất.', N'Trần Quốc Bảo', N'Đạt'),
(N'QDTD-2023-07', N'NV004', N'PX01', '2023-06-25', '2023-07-01', '2023-08-31', 6000000,  N'Thử việc 2 tháng, làm việc theo ca; được cấp bảo hộ lao động.', N'Trần Quốc Bảo', N'Đạt'),
(N'QDTD-2024-02', N'NV005', N'PB02', '2024-01-25', '2024-02-01', '2024-03-31', 7000000,  N'Thử việc 2 tháng tại phòng TC-KT.', N'Trần Quốc Bảo', N'Đạt'),
(N'QDTD-2022-01', N'NV007', N'BCC',  '2022-01-03', '2022-01-04', '2022-03-03', 6500000,  N'Thử việc 2 tháng tại Ban chấm công.', N'Trần Quốc Bảo', N'Đạt'),
(N'QDTD-2026-09', N'NV006', N'PX01', '2026-08-28', '2026-09-01', '2026-10-31', 6000000,  N'Thử việc 2 tháng tại phân xưởng, hưởng lương thử việc 6.000.000 đ/tháng; bên B tuân thủ nội quy an toàn.', N'Trần Quốc Bảo', NULL);

INSERT INTO dbo.HopDongLaoDong(SoHD, MaNV, SoQDTuyenDung, LoaiHD, NgayKy, NgayBatDau, NgayKetThuc, NguoiKy) VALUES
(N'HD-2020-01', N'NV002', N'QDTD-2020-01', N'Dài hạn',  '2020-05-01', '2020-05-01', NULL, N'Trần Quốc Bảo'),
(N'HD-2021-03', N'NV003', N'QDTD-2021-03', N'Dài hạn',  '2021-08-01', '2021-08-01', NULL, N'Trần Quốc Bảo'),
(N'HD-2023-07', N'NV004', N'QDTD-2023-07', N'Dài hạn',  '2023-09-01', '2023-09-01', NULL, N'Trần Quốc Bảo'),
(N'HD-2024-02', N'NV005', N'QDTD-2024-02', N'Ngắn hạn', '2024-04-01', '2024-04-01', '2027-03-31', N'Trần Quốc Bảo'),
(N'HD-2022-01', N'NV007', N'QDTD-2022-01', N'Dài hạn',  '2022-03-04', '2022-03-04', NULL, N'Trần Quốc Bảo');

INSERT INTO dbo.HoSoBaoHiem(MaHSBH, MaNV, SoHD, SoSoBHXH, SoTheBHYT, NgayThamGia, TyLeBHXH, TyLeBHYT) VALUES
(N'BH-NV002', N'NV002', N'HD-2020-01', N'7920000002', N'DN4797920000002', '2020-05-01', 8, 1.5),
(N'BH-NV003', N'NV003', N'HD-2021-03', N'7920000003', N'DN4797920000003', '2021-08-01', 8, 1.5),
(N'BH-NV004', N'NV004', N'HD-2023-07', N'7920000004', N'DN4797920000004', '2023-09-01', 8, 1.5),
(N'BH-NV007', N'NV007', N'HD-2022-01', N'7920000007', N'DN4797920000007', '2022-03-04', 8, 1.5);

INSERT INTO dbo.QuyetDinhLuong(SoQD, MaNV, NgayKy, NgayHieuLuc, LuongCoBan, PhuCapLuong, PhuCapDocHai, NguoiKy) VALUES
(N'QDL-NV001-01', N'NV001', '2015-01-01', '2015-01-01', 30000000, 2000000, 0,      N'Hội đồng thành viên'),
(N'QDL-NV002-01', N'NV002', '2020-05-01', '2020-05-01', 10000000, 500000,  0,      N'Trần Quốc Bảo'),
(N'QDL-NV002-02', N'NV002', '2025-01-01', '2025-01-01', 13000000, 800000,  0,      N'Trần Quốc Bảo'),
(N'QDL-NV003-01', N'NV003', '2021-08-01', '2021-08-01', 12000000, 500000,  800000, N'Trần Quốc Bảo'),
(N'QDL-NV004-01', N'NV004', '2023-09-01', '2023-09-01', 7800000,  300000,  600000, N'Trần Quốc Bảo'),
(N'QDL-NV005-01', N'NV005', '2024-04-01', '2024-04-01', 9100000,  300000,  0,      N'Trần Quốc Bảo'),
(N'QDL-NV007-01', N'NV007', '2022-03-04', '2022-03-04', 8000000,  300000,  0,      N'Trần Quốc Bảo');

INSERT INTO dbo.QuyetDinhChucVu(SoQD, MaNV, MaCV, MaPB, NgayKy, NgayHieuLuc, PhuCapChucVu, NguoiKy) VALUES
(N'QDCV-NV001-01', N'NV001', N'CV01', N'PB01', '2015-01-01', '2015-01-01', 5000000, N'Hội đồng thành viên'),
(N'QDCV-NV002-01', N'NV002', N'CV04', N'PB01', '2020-05-01', '2020-05-01', 0,       N'Trần Quốc Bảo'),
(N'QDCV-NV002-02', N'NV002', N'CV02', N'PB01', '2025-01-01', '2025-01-01', 2000000, N'Trần Quốc Bảo'),
(N'QDCV-NV003-01', N'NV003', N'CV03', N'PX01', '2021-08-01', '2021-08-01', 2000000, N'Trần Quốc Bảo'),
(N'QDCV-NV004-01', N'NV004', N'CV05', N'PX01', '2023-09-01', '2023-09-01', 0,       N'Trần Quốc Bảo'),
(N'QDCV-NV005-01', N'NV005', N'CV04', N'PB02', '2024-04-01', '2024-04-01', 0,       N'Trần Quốc Bảo'),
(N'QDCV-NV007-01', N'NV007', N'CV04', N'BCC',  '2022-03-04', '2022-03-04', 0,       N'Trần Quốc Bảo');

INSERT INTO dbo.KeHoachPhanCong(MaKH, MaPB, TuNgay, DenNgay, MaNVLap, NgayLap) VALUES
(N'KH-PX01-20261005', N'PX01', '2026-10-05', '2026-10-11', N'NV003', '2026-10-02');
INSERT INTO dbo.ChiTietPhanCong(MaKH, MaNV, NgayLam, MaCa, GioPhuTroiDuKien) VALUES
(N'KH-PX01-20261005', N'NV004', '2026-10-05', N'CA1', 0),
(N'KH-PX01-20261005', N'NV004', '2026-10-06', N'CA1', 2),
(N'KH-PX01-20261005', N'NV006', '2026-10-05', N'CA2', 0),
(N'KH-PX01-20261005', N'NV006', '2026-10-06', N'CA2', 2);

INSERT INTO dbo.BangChamCong(MaBCC, MaPB, Thang, Nam, NgayLap, MaNVLap) VALUES
(N'BCC-PX01-202610', N'PX01', 10, 2026, '2026-10-31', N'NV007'),
(N'BCC-PB01-202610', N'PB01', 10, 2026, '2026-10-31', N'NV007'),
(N'BCC-PB02-202610', N'PB02', 10, 2026, '2026-10-31', N'NV007');
INSERT INTO dbo.ChiTietChamCong(MaBCC, MaNV, SoNgayCong, SoNgayNghiPhep, SoNgayNghiKhongPhep) VALUES
(N'BCC-PX01-202610', N'NV003', 26, 0, 0),
(N'BCC-PX01-202610', N'NV004', 25, 1, 0),
(N'BCC-PX01-202610', N'NV006', 24, 0, 2),
(N'BCC-PB01-202610', N'NV001', 26, 0, 0),
(N'BCC-PB01-202610', N'NV002', 26, 0, 0),
(N'BCC-PB02-202610', N'NV005', 26, 0, 0);

INSERT INTO dbo.PhieuPhuTroi(SoPhieu, NgayPhuTroi, SoGioPhuTroi, HinhThuc, MaPB, MaNVLap) VALUES
(N'PPT-2026-10-06', '2026-10-06', 2, N'Tăng ca',   N'PX01', N'NV007'),
(N'PPT-2026-10-18', '2026-10-18', 8, N'Ngày nghỉ', N'PX01', N'NV007');
INSERT INTO dbo.ChiTietPhuTroi(SoPhieu, MaNV, SoGio) VALUES
(N'PPT-2026-10-06', N'NV004', 2), (N'PPT-2026-10-06', N'NV006', 2),
(N'PPT-2026-10-18', N'NV004', 8);

INSERT INTO dbo.QuyetDinhKhenThuong(SoQD, NgayKy, LoaiKhenThuong, DoiTuong, MaNV, MaPB, NoiDung, SoTien, HinhThucChi, NguoiKy) VALUES
(N'QDKT-2026-015', '2026-10-10', N'Thành tích', N'Cá nhân', N'NV004', NULL,   N'Đề xuất cải tiến quy trình pha màu giảm hao hụt.', 1000000, N'Cộng vào lương', N'Trần Quốc Bảo'),
(N'QDKT-2026-016', '2026-10-15', N'Thành tích', N'Tập thể', NULL,    N'PX01', N'Phân xưởng vượt 110% kế hoạch sản lượng quý III.', 5000000, N'Phiếu chi',      N'Trần Quốc Bảo');
INSERT INTO dbo.PhieuChiKhenThuong(SoPhieuChi, SoQD, NgayChi, SoTien, NguoiNhan, MaNVLap) VALUES
(N'PC-2026-0101', N'QDKT-2026-016', '2026-10-16', 5000000, N'Phạm Minh Tuấn (đại diện PX01)', N'NV005');

INSERT INTO dbo.QuyetDinhKyLuat(SoQD, NgayKy, DoiTuong, MaNV, MaPB, LyDo, SoTienPhat, HinhThucThu, NguoiKy) VALUES
(N'QDKL-2026-004', '2026-10-20', N'Cá nhân', N'NV006', NULL, N'Không mang bảo hộ khi pha chế dung môi.', 200000, N'Trừ lương', N'Trần Quốc Bảo');
GO

PRINT N'Tạo CSDL QuanLyNhanSuDB thành công.';
