
-- Bài 1: Khởi động với các Hàm tổng hợp (Aggregate Functions)
--Tổng số lượng sản phẩm đang có | giá trung bình của tổng sản phẩm đó | giá cao nhất - giá thấp nhất

select 
	COUNT(*) as TongSoSanPham, 
	AVG(ListPrice) as GiaTrungBinh,
	MAX(ListPrice) AS GiaCaoNhat,
    MIN(ListPrice) AS GiaThapNhat
from Production.Product

-- Bài 2: Thực hành nhóm dữ liệu (GROUP BY)
-- Từ bảng chi tiết hóa đơn Sales.SalesOrderDetail, hãy tính tổng số lượng (OrderQty) đã được bán ra cho từng sản phẩm (ProductID).

select S.ProductID , sum(S.OrderQty) as TongSoLuongBan
from Sales.SalesOrderDetail S
group by S.ProductID

-- Bài 3: Phân biệt WHERE và HAVING
--Từ bảng Sales.SalesOrderDetail, hãy thống kê tổng số lượng bán (SUM(OrderQty)) của từng sản phẩm (ProductID). 
-- Tuy nhiên, chỉ lấy ra những sản phẩm nào có tổng số lượng bán ra lớn hơn 1000 chiếc

select S.ProductID , sum(S.OrderQty) as TongSoLuongBan
from Sales.SalesOrderDetail S
group by S.ProductID
having sum(S.OrderQty) > 1000

-- Bài 4: Kết nối 2 bảng cơ bản (INNER JOIN: lấy ra phần chung 2 bản điều có)

select 
	PP.ProductID, 
	PP.Name as N'Tên sản phẩm', 
	PS.Name as N'Tên Danh Mục Phụ'
from 
	Production.Product as PP
	inner join Production.ProductSubcategory PS 
	on PP.ProductSubcategoryID = PS.ProductSubcategoryID

-- Bài 5: Bài tập Tổng hợp (JOIN + GROUP BY + HAVING + ORDER BY)

select HH.DepartmentID , COUNT(HH.DepartmentID) as N'Số lượng nhân viên'
from
	HumanResources.Employee as HE
	inner join HumanResources.EmployeeDepartmentHistory as HH
	on HE.BusinessEntityID = HH.BusinessEntityID
WHERE HH.EndDate IS NULL -- Chỉ lấy những nhân viên chưa thoát khỏi phòng ban
GROUP BY HH.DepartmentID
Having COUNT(HH.DepartmentID) >= 5
ORDER BY COUNT(HH.DepartmentID) DESC
