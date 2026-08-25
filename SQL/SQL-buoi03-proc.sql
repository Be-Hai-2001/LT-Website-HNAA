-- SQL Buổi 02 --
--Bài 1: Làm quen với khai báo và sử dụng Biến

	declare @MauSac nvarchar(50)
	set @MauSac = 'Black'

	select top 100 *
	from Production.Product
	where Product.Color = @MauSac

--Bài 2: Sử dụng cấu trúc IF...ELSE kết hợp IF EXISTS
	declare @chucdanh nvarchar(100)
	set @chucdanh = 'Chief Executive Officer'

	IF 
		EXISTS
		(
			select 1 
			from HumanResources.Employee 
			Where JobTitle = @chucdanh
		)
		BEGIN
			print(N'Đã tìm thấy Giám đốc điều hành trong hệ thống.');
		END
	ELSE
		BEGIN
			print(N'Hệ thống hiện chưa có thông tin Giám đốc điều hành.');
		END

	Go -- KẾT THÚC

--Bài 3: Viết Stored Procedure cơ bản (Không tham số)
create proc sp_LayDanhSachNhanVienSale 
(
	@chucdanh nvarchar(100)
)
as
BEGIN
	select HE.BusinessEntityID, HE.JobTitle, HE.VacationHours
	from HumanResources.Employee as HE
	where HE.JobTitle like '%' + @chucdanh  + '%'
END
EXEC sp_LayDanhSachNhanVienSale @chucdanh = 'Sales'

Go -- KẾT THÚC

--Bài 4: Viết Stored Procedure có tham số đầu vào
	create proc sp_TimKiemSanPhamTheoGia 
	(
		@GiaToiThieu MONEY,
		@GiaToiDa  MONEY
	)
	as
		BEGIN
			select ProductID, Name, ListPrice
			from Production.Product
			where Product.ListPrice Between @GiaToiThieu AND @GiaToiDa
		End

	EXEC sp_TimKiemSanPhamTheoGia @GiaToiThieu = 100, @GiaToiDa = 500

	Go -- KẾT THÚC

--Bài 5: Bài tập Tổng hợp (Biến + IF/ELSE + Stored Procedure)
	create proc sp_KiemTraVaCapNhatGia 
	(
		@ProductID INT,
		@GiaMoi MONEY
	)
	as

	BEGIN
		IF 
			EXISTS 
			(
				select * 
				from Production.Product
				where Product.ProductID = @ProductID
			)
			BEGIN
				IF (@GiaMoi > 0)
					BEGIN
						update Production.Product
						set ListPrice = @GiaMoi
						print (N'Cập nhật giá thành công!')
					END
				ELSE 
					print (N'Lỗi: Giá sản phẩm phải lớn hơn 0')
			END
		ELSE
			print (N'Lỗi: Không tìm thấy mã sản phẩm này!')
	END

	EXEC sp_KiemTraVaCapNhatGia @ProductID = 316, @GiaMoi = 200

