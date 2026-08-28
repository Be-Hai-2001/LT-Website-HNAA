--> Bài 1: Ghi lại lịch sử thay đổi giá (Sử dụng Trigger UPDATE)
create table Production.ProductPriceLog 
(
	LogID int identity(1,1) primary key, 
	ProductID int, 
	OldPrice money, 
	NewPrice money, 
	ModifiedDate datetime default getdate()
)

Go
create trigger trg_LogPriceChange 
on Production.Product
after update
as
begin 
	if update(ListPrice)
	begin
		insert into Production.ProductPriceLog(ProductID, OldPrice, NewPrice, ModifiedDate)
		select 
			i.ProductID,
			d.ListPrice as OldPrice,
			i.ListPrice as NewPrice,
			GETDATE()
		from
			inserted i
			join deleted d on i.ProductID = d.ProductID
		where i.ListPrice <> d.ListPrice
	end
end

--> Câu lệnh demo
select top 50 *
from Production.Product

select top 50 *
from Production.ProductPriceLog
Go 

update Production.Product
set ListPrice = 100
where Product.ProductID = 316
Go 

---------------------------------------------------------------------------------
--> Bài 2: Ngăn chặn thao tác dữ liệu sai quy tắc (Sử dụng Trigger INSERT/UPDATE)
CREATE TRIGGER trg_PreventInvalidOrderQty
ON Sales.SalesOrderDetail
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN Production.ProductInventory P
            ON i.ProductID = P.ProductID
        WHERE i.OrderQty > P.Quantity
    )
    BEGIN
        RAISERROR(N'Số lượng đặt mua vượt quá số lượng tồn kho hiện tại!', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

--> Câu lệnh demo


update Sales.SalesOrderDetail 
set OrderQty = 200
where SalesOrderID = 43659

select * from Sales.SalesOrderDetail where ProductID = 776
select * from Production.ProductInventory where ProductID = 776
Go

------------------------------------------------------------------------------
-->  Bài 3: Đảm bảo tính toàn vẹn khi chuyển đổi tồn kho (Sử dụng Transaction)
CREATE PROC sp_TransferInventory 
(
    @ProductID INT, 
    @FromLocationID INT, 
    @ToLocationID INT, 
    @Quantity SMALLINT
)
AS 
BEGIN
    SET NOCOUNT ON;

    -- 1. Bắt đầu một giao dịch
    BEGIN TRANSACTION;

    BEGIN TRY
        -- 2. Thực hiện update trừ số lượng xuất kho
        UPDATE Production.ProductInventory
        SET Quantity = Quantity - @Quantity
        WHERE ProductID = @ProductID
          AND LocationID = @FromLocationID;

        -- 3. Số lượng tồn kho nhỏ hơn 0 thì rollback lại không thực hiện update
        IF EXISTS 
        (
            SELECT 1 
            FROM Production.ProductInventory
            WHERE LocationID = @FromLocationID 
              AND ProductID = @ProductID 
              AND Quantity < 0
        )
        BEGIN
            RAISERROR(N'Không đủ hàng để chuyển', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- 4. Thực hiện update CỘNG số lượng nhập kho (Sửa dấu - thành +)
        UPDATE Production.ProductInventory
        SET Quantity = Quantity + @Quantity
        WHERE ProductID = @ProductID
          AND LocationID = @ToLocationID;

        -- 5. Thực hiện commit xác nhận giao dịch
        COMMIT TRANSACTION;
        PRINT N'Cập nhật số lượng sản phẩm thành công!';

    END TRY
    BEGIN CATCH
        -- Tự động hủy giao dịch nếu gặp lỗi hệ thống khác
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Đẩy lỗi ra cho người dùng/ứng dụng biết
        THROW;
    END CATCH
END;

--> Bài 4: Xóa dữ liệu có quan hệ phức tạp (Sử dụng Transaction)
CREATE PROC sp_SafeDeleteProduct 
(
	@ProductID INT
)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		-- 1. Xóa các bản ghi liên quan ở bảng con
		DELETE FROM Production.ProductInventory WHERE ProductID = @ProductID
		DELETE FROM Production.ProductCostHistory WHERE ProductID = @ProductID
		--DELETE FROM Production.BillOfMaterials WHERE ProductID = @ProductID OR ComponentID = @ProductID;
		--DELETE FROM Production.ProductListPriceHistory WHERE ProductID = @ProductID;
		--DELETE FROM Production.ProductProductPhoto WHERE ProductID = @ProductID;
		--DELETE FROM Production.ProductReview WHERE ProductID = @ProductID;
		--DELETE FROM Production.TransactionHistory WHERE ProductID = @ProductID;
		--DELETE FROM Sales.SpecialOfferProduct WHERE ProductID = @ProductID;

		-- 2. Xóa bản ghi ở bảng chính (bảng cha)
		DELETE FROM Production.Product WHERE ProductID = @ProductID

		-- 3. Xác nhận giao dịch khi tất cả lệnh xóa thành công
		COMMIT TRANSACTION;
		PRINT N'Xóa sản phẩm thành công!';
	END TRY

	BEGIN CATCH
		-- Tự động hủy giao dịch nếu gặp lỗi hệ thống khác
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Đẩy lỗi ra cho người dùng/ứng dụng biết
        THROW;
	END CATCH
END

--> Bài 5: Xử lý dữ liệu từng dòng (Sử dụng Cursor)

-- Khai báo các biến lưu trữ dữ liệu đọc được từ Cursor
DECLARE @MaNV INT;
DECLARE @ChucDanh NVARCHAR(50);
DECLARE @SoGioNghiPhep SMALLINT;

-- BƯỚC 1: Khai báo con trỏ (DECLARE)
DECLARE cur_NhanVien CURSOR FOR
SELECT 
    HE.BusinessEntityID, 
    HE.JobTitle, 
    HE.VacationHours
FROM HumanResources.Employee AS HE
INNER JOIN HumanResources.EmployeeDepartmentHistory AS EDH 
    ON HE.BusinessEntityID = EDH.BusinessEntityID
INNER JOIN HumanResources.Department AS HD 
    ON EDH.DepartmentID = HD.DepartmentID
WHERE HD.Name = N'Research and Development'
  AND EDH.EndDate IS NULL; -- Lọc nhân viên đang hiện diện tại phòng ban

-- BƯỚC 2: Mở con trỏ (OPEN)
OPEN cur_NhanVien;

-- BƯỚC 3: Đọc dòng dữ liệu đầu tiên (FETCH NEXT)
FETCH NEXT FROM cur_NhanVien INTO @MaNV, @ChucDanh, @SoGioNghiPhep;

-- Vòng lặp: Duyệt qua từng dòng dữ liệu cho đến khi hết (@@FETCH_STATUS = 0)
WHILE @@FETCH_STATUS = 0
BEGIN
    -- In ra tab Messages theo định dạng yêu cầu
    PRINT N'Nhân viên: ' + ISNULL(@ChucDanh, N'') +
          N' - Mã NV: ' + CAST(ISNULL(@MaNV, 0) AS NVARCHAR(10)) +
          N' - Số giờ nghỉ phép hiện tại: ' + CAST(ISNULL(@SoGioNghiPhep, 0) AS NVARCHAR(10));

    -- Đọc dòng dữ liệu tiếp theo
    FETCH NEXT FROM cur_NhanVien INTO @MaNV, @ChucDanh, @SoGioNghiPhep;
END;

-- BƯỚC 4: Đóng con trỏ (CLOSE)
CLOSE cur_NhanVien;

-- BƯỚC 5: Giải phóng tài nguyên con trỏ (DEALLOCATE)
DEALLOCATE cur_NhanVien;