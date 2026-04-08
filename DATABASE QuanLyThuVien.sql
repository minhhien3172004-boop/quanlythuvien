CREATE DATABASE QuanLyThuVien;
GO
USE QuanLyThuVien;
GO

-- 1. Tạo bảng Thể loại
CREATE TABLE TheLoai (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100) NOT NULL
);

-- 2. Tạo bảng Sách
CREATE TABLE Sach (
    MaSach INT PRIMARY KEY IDENTITY(1,1),
    TenSach NVARCHAR(250) NOT NULL,
    TacGia NVARCHAR(150),
    MaLoai INT,
    SoLuong INT DEFAULT 0
);

-- 3. Nạp dữ liệu mẫu
INSERT INTO TheLoai (TenLoai) VALUES (N'Tin học'), (N'Văn học');
INSERT INTO Sach (TenSach, TacGia, MaLoai, SoLuong) VALUES 
(N'Lập trình C#', N'Admin', 1, 10),
(N'Dế Mèn Phiêu Lưu Ký', N'Tô Hoài', 2, 10),
(N'Đắc Nhân Tâm', N'Dale Carnegie', 1, 15),
(N'Mắt Biếc', N'Nguyễn Nhật Ánh', 2, 5),
(N'Lập trình Java cơ bản', N'Nhiều tác giả', 1, 12),
(N'Nhà giả kim', N'Paulo Coelho', 2, 8);
