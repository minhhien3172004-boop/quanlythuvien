-- 1. Tạo Database và sử dụng
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyThuVien')
    CREATE DATABASE QuanLyThuVien;
GO
USE QuanLyThuVien;
GO

-- 2. Xóa các bảng cũ theo thứ tự (để tránh lỗi khóa ngoại khi tạo lại)
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'PhieuMuon') DROP TABLE PhieuMuon;
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'Sach') DROP TABLE Sach;
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'TheLoai') DROP TABLE TheLoai;
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'DocGia') DROP TABLE DocGia;
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'TaiKhoan') DROP TABLE TaiKhoan;
GO

-- 3. Tạo bảng Thể loại
CREATE TABLE TheLoai (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100) NOT NULL
);

-- 4. Tạo bảng Sách
CREATE TABLE Sach (
    MaSach INT PRIMARY KEY IDENTITY(1,1),
    TenSach NVARCHAR(250) NOT NULL,
    TacGia NVARCHAR(150),
    MaLoai INT,
    SoLuong INT DEFAULT 0,
    CONSTRAINT FK_Sach_TheLoai FOREIGN KEY (MaLoai) REFERENCES TheLoai(MaLoai)
);

-- 5. Tạo bảng Tài khoản (Cho chức năng Đăng nhập)
CREATE TABLE TaiKhoan (
    TenDN VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(50) NOT NULL,
    TenHienThi NVARCHAR(100)
);

-- 6. Tạo bảng Độc giả (Người mượn)
CREATE TABLE DocGia (
    MaDG INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15)
);

-- 7. Tạo bảng Phiếu mượn (Cho chức năng Mượn - Trả)
CREATE TABLE PhieuMuon (
    MaPhieu INT PRIMARY KEY IDENTITY(1,1),
    MaDG INT,
    MaSach INT,
    NgayMuon DATE DEFAULT GETDATE(),
    NgayHenTra DATE,
    TrangThai NVARCHAR(50) DEFAULT N'Đang mượn',
    CONSTRAINT FK_PM_DocGia FOREIGN KEY (MaDG) REFERENCES DocGia(MaDG),
    CONSTRAINT FK_PM_Sach FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- 8. Chèn dữ liệu mẫu (Để thầy cô vào là có cái test luôn)
INSERT INTO TaiKhoan VALUES ('admin', '123', N'Quản trị viên');
INSERT INTO TheLoai (TenLoai) VALUES (N'Công nghệ'), (N'Văn học');
INSERT INTO DocGia (HoTen, SDT) VALUES (N'Nguyễn Văn A', '0912345678');
INSERT INTO Sach (TenSach, TacGia, MaLoai, SoLuong) VALUES 
(N'Lập trình C#', N'Admin', 1, 10),
(N'Dế Mèn Phiêu Lưu Ký', N'Tô Hoài', 2, 10),
(N'Đắc Nhân Tâm', N'Dale Carnegie', 1, 15),
(N'Mắt Biếc', N'Nguyễn Nhật Ánh', 2, 5),
(N'Lập trình Java cơ bản', N'Nhiều tác giả', 1, 12),
(N'Nhà giả kim', N'Paulo Coelho', 2, 8);
GO
