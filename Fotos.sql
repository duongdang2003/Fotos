USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyFotos')
BEGIN
    ALTER DATABASE QuanLyFotos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyFotos;
END

CREATE DATABASE QuanLyFotos
GO

USE QuanLyFotos
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Nguoi_dung(
	id_nguoi_dung INT IDENTITY(1, 1) NOT NULL,
	ten_nguoi_dung NVARCHAR(255) NOT NULL,
	email VARCHAR(255) UNIQUE NOT NULL,
	mat_khau_hashed CHAR(64) NOT NULL,
	salt CHAR(32) NOT NULL,
	ten_day_du NVARCHAR(255) NOT NULL,
	so_dien_thoai VARCHAR(20) NOT NULL,
	ngay_dang_ky DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_id_nguoi_dung PRIMARY KEY (id_nguoi_dung)
)
GO

CREATE TABLE dbo.Albums(
	id_album INT IDENTITY(1, 1) NOT NULL,
	so_luong_anh INT NOT NULL,
	id_nguoi_dung INT NOT NULL,
	tieu_de_album NVARCHAR(255) NOT NULL,
	mo_ta_album NVARCHAR(255) NULL,
	ngay_tao_album DATETIME DEFAULT GETDATE(),
	so_luot_danh_gia INT,
	so_luot_thich INT,
	CONSTRAINT PK_id_album PRIMARY KEY (id_album),
	CONSTRAINT FK_id_album_nguoi_dung FOREIGN KEY (id_nguoi_dung) REFERENCES dbo.Nguoi_dung (id_nguoi_dung)
)
GO

CREATE TABLE dbo.Photos(
	id_photo INT IDENTITY(1, 1) NOT NULL,
	id_nguoi_dung INT NOT NULL,
	id_album INT NULL,
	tieu_de_anh NVARCHAR(255) NOT NULL,
	mo_ta_anh NVARCHAR(255) NULL,
	url_anh VARCHAR(254) NOT NULL,
	ngay_tai_anh_len DATETIME DEFAULT GETDATE(),
	so_luot_danh_gia INT,
	so_luot_thich INT,
	CONSTRAINT PK_id_photo PRIMARY KEY (id_photo),
	CONSTRAINT FK_id_album FOREIGN KEY (id_album) REFERENCES dbo.Albums (id_album),
	CONSTRAINT FK_id_photo_nguoi_dung FOREIGN KEY (id_nguoi_dung) REFERENCES dbo.Nguoi_dung (id_nguoi_dung)
)
GO
CREATE TABLE dbo.Albumn_Photos(
	id_album INT NOT NULL,
	id_photo INT NOT NULL,
	FOREIGN KEY (id_album) REFERENCES dbo.Albums (id_album),
	FOREIGN KEY (id_photo) REFERENCES dbo.Photos (id_photo)
)

GO
CREATE TABLE dbo.Danh_gia_album(
	id_danh_gia INT IDENTITY(1, 1) NOT NULL,
	id_nguoi_dung INT NOT NULL,
	id_album INT NULL,
	binh_luan NVARCHAR(255) NULL,
	ngay_binh_luan DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_id_danh_gia_album PRIMARY KEY (id_danh_gia),
	CONSTRAINT FK_id_danh_gia_album_nguoi_dung FOREIGN KEY (id_nguoi_dung) REFERENCES dbo.Nguoi_dung (id_nguoi_dung),
	CONSTRAINT FK_id_danh_gia_album FOREIGN KEY (id_album) REFERENCES dbo.Albums (id_album)
)
GO

CREATE TABLE dbo.Danh_gia_anh(
	id_danh_gia INT IDENTITY(1, 1) NOT NULL,
	id_nguoi_dung INT NOT NULL,
	id_anh INT NULL,
	binh_luan NVARCHAR(255) NULL,
	ngay_binh_luan DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_id_danh_gia_anh PRIMARY KEY (id_danh_gia),
	CONSTRAINT FK_id_danh_gia_anh_nguoi_dung FOREIGN KEY (id_nguoi_dung) REFERENCES dbo.Nguoi_dung (id_nguoi_dung),
	CONSTRAINT FK_id_danh_gia_anh FOREIGN KEY (id_anh) REFERENCES dbo.Photos (id_photo)
)
GO

CREATE TABLE dbo.Giao_dich(
	id_giao_dich INT IDENTITY(1, 1) NOT NULL,
	id_nguoi_mua INT NOT NULL,
	id_nguoi_ban INT NOT NULL,
	id_album INT NOT NULL,
	gia_tien MONEY NOT NULL,
	ngay_giao_dich DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_id_giao_dich PRIMARY KEY (id_giao_dich),
	CONSTRAINT FK_id_giao_dich_nguoi_mua FOREIGN KEY (id_nguoi_mua) REFERENCES dbo.Nguoi_dung (id_nguoi_dung),
	CONSTRAINT FK_id_giao_dich_nguoi_ban FOREIGN KEY (id_nguoi_ban) REFERENCES dbo.Nguoi_dung (id_nguoi_dung),
	CONSTRAINT FK_id_giao_dich_album FOREIGN KEY (id_album) REFERENCES dbo.Albums (id_album),
)
GO

CREATE TABLE dbo.Luot_thich_album(
	id_luot_thich INT IDENTITY(1, 1) NOT NULL,
	id_nguoi_dung INT NOT NULL,
	id_album INT NULL,
	--id_anh INT NULL,
	ngay_thich DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_id_luot_thich_album PRIMARY KEY (id_luot_thich),
	CONSTRAINT FK_id_luot_thich_nguoi_dung FOREIGN KEY (id_nguoi_dung) REFERENCES dbo.Nguoi_dung (id_nguoi_dung),
	CONSTRAINT FK_id_luot_thich_album FOREIGN KEY (id_album) REFERENCES dbo.Albums (id_album),
	--CONSTRAINT FK_id_luot_thich_anh FOREIGN KEY (id_anh) REFERENCES dbo.Photos (id_photo)
)
GO

CREATE TABLE dbo.Luot_thich_anh(
	id_luot_thich INT IDENTITY(1, 1) NOT NULL,
	id_nguoi_dung INT NOT NULL,
	--id_album INT NULL,
	id_anh INT NULL,
	ngay_thich DATETIME DEFAULT GETDATE(),
	CONSTRAINT PK_id_luot_thich_anh PRIMARY KEY (id_luot_thich),
	CONSTRAINT FK_id_luot_thich_anh_nguoi_dung FOREIGN KEY (id_nguoi_dung) REFERENCES dbo.Nguoi_dung (id_nguoi_dung),
	--CONSTRAINT FK_id_luot_thich_album FOREIGN KEY (id_album) REFERENCES dbo.Albums (id_album),
	CONSTRAINT FK_id_luot_thich_anh_anh FOREIGN KEY (id_anh) REFERENCES dbo.Photos (id_photo)
)
GO

CREATE TABLE dbo.Anh_yeu_thich(
	id_anh_yeu_thich INT IDENTITY(1, 1) NOT NULL,
	id_nguoi_dung INT NOT NULL,
	id_anh INT NULL,
	ngay_yeu_thich DATETIME DEFAULT GETDATE()
	CONSTRAINT PK_id_anh_yeu_thich PRIMARY KEY (id_anh_yeu_thich),
	CONSTRAINT FK_id_anh_yeu_thich_nguoi_dung FOREIGN KEY (id_nguoi_dung) REFERENCES dbo.Nguoi_dung (id_nguoi_dung),
	CONSTRAINT FK_id_anh_yeu_thich_anh FOREIGN KEY (id_anh) REFERENCES dbo.Photos (id_photo) 
)
GO

CREATE TRIGGER UpdatePhotoCount
ON dbo.Photos
AFTER INSERT
AS
BEGIN
    UPDATE A
    SET A.so_luong_anh = (SELECT COUNT(*) FROM dbo.Photos WHERE id_album = A.id_album)
    FROM dbo.Albums A
    INNER JOIN inserted I ON A.id_album = I.id_album
END;
GO

-- Thêm dữ liệu

-- Nguoi Dung
INSERT INTO dbo.Nguoi_dung (ten_nguoi_dung, email, mat_khau_hashed, salt, ten_day_du, so_dien_thoai, ngay_dang_ky)
VALUES
(N'Admin', 'admin@gmail.com', '123456', 'abc', N'admin', '0123456789', GETDATE()),
(N'AnVipPro', 'nguyentuongan@gmail.com', '123456', 'abc', N'Nguyễn Tường An', '0123456789', GETDATE()),
(N'DangVipPro', 'duonghaidang@gmail.com', '123456', 'abc', N'Dương Hải Đăng', '0123456789', GETDATE()),
(N'KhaiVipPro', 'truongtrongkhai@gmail.com', '123456', 'abc', N'Trương Trọng Khải', '0123456789', GETDATE());


-- Albums
INSERT INTO dbo.Albums (so_luong_anh, id_nguoi_dung, tieu_de_album, mo_ta_album, ngay_tao_album, so_luot_danh_gia, so_luot_thich)
VALUES
(0, 1, N'Natural', N'Thiên nhiên', GETDATE(), 100, 100),
(0, 2, N'Animals', N'Động vật', GETDATE(), 200, 150);

--Ảnh
INSERT INTO dbo.Photos (id_nguoi_dung, id_album, tieu_de_anh, mo_ta_anh, url_anh, ngay_tai_anh_len, so_luot_danh_gia, so_luot_thich)
VALUES
(1, 1, N'Trees', N'Cây cối', 'pic01.jpg', GETDATE(), 10, 10),
(1, 1, N'Trees', N'Cây cối', 'pic02.jpg', GETDATE(), 10, 10),
(1, 1, N'Trees', N'Cây cối', 'pic03.jpg', GETDATE(), 10, 10),
(1, 1, N'Trees', N'Cây cối', 'pic04.jpg', GETDATE(), 10, 10),
(1, 1, N'Trees', N'Cây cối', 'pic05.jpg', GETDATE(), 10, 10),
(1, 1, N'Trees', N'Cây cối', 'pic06.jpg', GETDATE(), 10, 10),

(2, 2, N'Animals', N'Động vật', 'pic07.jpg', GETDATE(), 10, 10),
(2, 2, N'Animals', N'Động vật', 'pic08.jpg', GETDATE(), 10, 10),
(2, 2, N'Animals', N'Động vật', 'pic09.jpg', GETDATE(), 10, 10),
(2, 2, N'Animals', N'Động vật', 'pic10.jpg', GETDATE(), 10, 10),
(2, 2, N'Animals', N'Động vật', 'pic11.jpg', GETDATE(), 10, 10),
(2, 2, N'Animals', N'Động vật', 'pic12.jpg', GETDATE(), 10, 10);

-- Đánh giá album
INSERT INTO dbo.Danh_gia_album (id_nguoi_dung, id_album, binh_luan, ngay_binh_luan)
VALUES
(1, 1, N'Một album rất đẹp, có rất nhiều cây cối phong phú', GETDATE()),
(1, 2, N'Các con vật rất đa dạng', GETDATE()),
(2, 1, N'Còn ít cây quá, chưa đa dạng', GETDATE()),
(2, 2, N'Không có mèo, không thích', GETDATE());

-- Đánh giá ảnh
INSERT INTO dbo.Danh_gia_anh (id_nguoi_dung, id_anh, binh_luan, ngay_binh_luan)
VALUES
(1, 1, N'Cây rất đẹp', GETDATE()),
(1, 2, N'Cây rất đẹp', GETDATE()),
(1, 3, N'Cây rất đẹp', GETDATE()),
(1, 4, N'Cây rất đẹp', GETDATE()),
(1, 5, N'Cây rất đẹp', GETDATE()),
(2, 6, N'Cây rất đẹp', GETDATE()),
(2, 7, N'Con này dễ thương', GETDATE()),
(2, 8, N'Con này đẹp', GETDATE()),
(2, 9, N'Con này đẹp', GETDATE()),
(2, 10, N'Con này đẹp', GETDATE());

-- GIao dịch
INSERT INTO dbo.Giao_dich (id_nguoi_mua, id_nguoi_ban, id_album, gia_tien, ngay_giao_dich)
VALUES
(1, 2, 2, 1000000, GETDATE()),
(2, 1, 1, 5000000, GETDATE());

--Lượt thích album
INSERT INTO dbo.Luot_thich_album (id_nguoi_dung, id_album, ngay_thich)
VALUES
(1, 1, GETDATE()),
(1, 2, GETDATE()),
(2, 1, GETDATE()),
(2, 2, GETDATE());

-- Lượt thích ảnh
INSERT INTO dbo.Luot_thich_anh (id_nguoi_dung, id_anh, ngay_thich)
VALUES
(1, 1, GETDATE()),
(1, 2, GETDATE()),
(2, 3, GETDATE()),
(2, 4, GETDATE());

--Ảnh yêu thích
INSERT INTO dbo.Anh_yeu_thich(id_nguoi_dung, id_anh, ngay_yeu_thich)
VALUES
(1, 1, GETDATE()),
(1, 2, GETDATE()),
(1, 3, GETDATE()),
(1, 4, GETDATE()),
(1, 5, GETDATE()),
(2, 6, GETDATE()),
(2, 7, GETDATE()),
(2, 8, GETDATE()),
(2, 9, GETDATE()),
(2, 10, GETDATE());

SELECT * FROM dbo.Nguoi_dung
SELECT * FROM dbo.Albums
SELECT * FROM dbo.Photos
SELECT * FROM dbo.Danh_gia_album
SELECT * FROM dbo.Danh_gia_anh
SELECT * FROM dbo.Giao_dich
SELECT * FROM dbo.Luot_thich_album
SELECT * FROM dbo.Luot_thich_anh
SELECT * FROM dbo.Anh_yeu_thich
