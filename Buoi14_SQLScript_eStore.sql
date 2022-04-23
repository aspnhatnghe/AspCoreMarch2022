﻿-- Chọn database làm việc
USE eStore20;

-- Lấy 100 hàng hóa rẽ nhất
SELECT TOP 100 TenLoai, MaHH, TenHH, DonGia
FROM vHangHoa
ORDER BY DonGia

--Tạo view lấy thông tin hóa đơn
CREATE VIEW vHoaDon AS
SELECT cthd.*, MaKH, NgayDat, TenHH, TenLoai
FROM ChiTietHD cthd JOIN HoaDon hd
		ON cthd.MaHD = hd.MaHD
	JOIN HangHoa hh ON cthd.MaHH = hh.MaHH
	JOIN Loai lo ON hh.MaLoai = lo.MaLoai

--Lấy thông tin hóa đơn có mã 10248
SELECT *
FROM vHoaDon
WHERE MaHD = 10248


-------PROCEDURE----------
--Định nghĩa procedure lấy danh sách hàng hóa
--theo loại và nhà cung cấp
CREATE PROC spLayHangHoa
(
	@MaLoai int,
	@MaNCC nvarchar(50)
) AS BEGIN
	SELECT * FROM vHangHoa
	WHERE MaLoai = @MaLoai AND MaNCC = @MaNCC
END

--Demo
spLayHangHoa 1001, 'NK'
EXEC spLayHangHoa 1002, 'SS'
EXECUTE spLayHangHoa 1003, 'SS'

--Tạo mới loại
CREATE PROC spThemLoai
(
	@MaLoai int output,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(MAX),
	@Hinh nvarchar(50)
) AS BEGIN
	--chèn mới
	INSERT INTO Loai(TenLoai, MoTa, Hinh)
		VALUES (@TenLoai, @MoTa, @Hinh)
	--gán giá trị vừa tăng
	SELECT @MaLoai = @@IDENTITY
END

deCLARE @ma int
exec spThemLoai @ma output, N'Nước giải khát ALO', null, null
select CONCAT(N'Mã loại vừa sinh: ', @ma)

--Sữa loại
CREATE PROC spSuaLoai
(
	@MaLoai int,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(MAX),
	@Hinh nvarchar(50)
) AS BEGIN
	UPDATE Loai SET TenLoai = @TenLoai, MoTa = @MoTa
	WHERE MaLoai = @MaLoai

	IF @Hinh IS NOT NULL
	BEGIN
		UPDATE Loai SET Hinh = @Hinh
		WHERE MaLoai = @MaLoai
	END
END

--Demo
spSuaLoai 1009, N'Bia Sài Gòn', N'N/A', null
SELECT * FROM Loai WHERE MaLoai = 1009

--Xóa loại
CREATE PROC spXoaLoai
(
	@MaLoai int
) AS BEGIN
	DELETE FROM Loai WHERE MaLoai = @MaLoai
END

spXoaLoai 1001

--Viết store procedure lấy loại
CREATE PROC spLayLoai
(
	@MaLoai int
) AS BEGIN
	IF @MaLoai = 0
	BEGIN
		SELECT * FROM Loai
	END
	ELSE
	BEGIN
		SELECT * FROM Loai WHERE MaLoai = @MaLoai
	END
END

--Viết procedure tìm gần đúng theo loại
ALTER PROC spTimLoai
(
	@Keyword nvarchar(50)
)
AS BEGIN
	SELECT * FROM Loai
	WHERE TenLoai LIKE '%' + @Keyword + '%'
END


SELECT * FROM Loai
spTimLoai N'i'

--------FUNCTION
--Viết hàm tính doanh thu theo khách hàng từ năm ... đến...
CREATE FUNCTION TinhDoanhSo
(
	@MaKh nvarchar(50),
	@TuNgay datetime,
	@DenNgay datetime
)
RETURNS FLOAT
AS BEGIN
	DECLARE @DoanhSo float

	SELECT @DoanhSo = SUM(SoLuong*DonGia*(1-GiamGia))
	FROM ChiTietHD cthd JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
	WHERE MaKH = @MaKh 
		AND NgayDat BETWEEN @TuNgay AND @DenNgay

	RETURN @DoanhSo
END

SELECT dbo.TinhDoanhSo('ANTON', '1996-1-1', '1997-5-21')
SELECT MaKh, HoTen,
	dbo.TinhDoanhSo(MaKH, '1996-1-1', '1997-5-21') as DoanhSo
FROM KhachHang

---TRIGGER
CREATE TRIGGER trgCapNhatThanhTien ON ChiTietHD
AFTER INSERT, UPDATE, DELETE
AS BEGIN
	DECLARE @MaHD int
	DECLARE @Tong float;

	WITH BangTam AS (
		SELECT MAHD FROM inserted
		UNION
		SELECT MAHD FROM deleted
	)
	SELECT @MaHD = MaHD FROM BangTam

	SELECT @Tong = SUM(SoLuong*DonGia*(1-GiamGia))
	FROm ChiTietHD WHERE MaHD = @MaHD

	UPDATE HoaDon SET ThanhTien = @Tong WHERE MaHD = @MaHD
END