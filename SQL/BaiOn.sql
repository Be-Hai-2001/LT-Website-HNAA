



--**Bài 6**: Viết câu truy vấn: Tỉ lệ đóng góp doanh thu của mỗi loại sản phẩm (10 điểm)
--Tính tỷ lệ đóng góp doanh thu của từng loại sản phẩm.

--Mục đích nghiệp vụ:

--- Đánh giá hiệu quả từng danh mục sản phẩm
--- Tối ưu chiến lược bán hàng theo nhóm hàng
--- Quyết định phân bổ ngân sách và sản xuất

--*Table: SalesOrderDetail, Product*

--*Gợi ý: Sử dụng cấu trúc bảng tạm WITH*

WITH
-- 1. CTE tính doanh thu từng sản phẩm ( ở đây select sẽ ra n->row theo số lượng sp
	ProductRevenueCTE AS (
		SELECT 
			PR.ProductID,
			PR.Name AS TenSanPham,
			SUM(SOD.LineTotal) AS DoanhThuSanPham
		FROM Sales.SalesOrderDetail SOD
		INNER JOIN Production.Product PR
			ON PR.ProductID = SOD.ProductID
		GROUP BY 
			PR.ProductID,
			PR.Name
	),

-- 2. CTE tính TỔNG doanh thu toàn hệ thống ( ở đây select chỉ được có 1row => DoanhThuHeThong = xxxxxx )
	TotalRevenueCTE AS (
		SELECT 
			SUM(LineTotal) AS DoanhThuHeThong
		FROM Sales.SalesOrderDetail
	)

-- 3. Tính tỉ lệ đóng góp (%)
SELECT 
    PCTE.ProductID, 
    PCTE.TenSanPham, 
    PCTE.DoanhThuSanPham, 
    TCTE.DoanhThuHeThong,
    ROUND(
        (PCTE.DoanhThuSanPham * 100.0) / NULLIF(TCTE.DoanhThuHeThong, 0), 2
    ) AS TiLeDongGopPercent
FROM ProductRevenueCTE PCTE
CROSS JOIN TotalRevenueCTE TCTE
ORDER BY 
    PCTE.DoanhThuSanPham DESC;

-------------------------------------------------------------------------------------

--Bài 07: Xây dựng các bài toán trên thành thủ tục – store procedure. Được lưu trữ trong database AventureWork

--> Bài 02: Viết câu truy vấn giải quyết bài toán: Xếp hạng sản phẩm bán chạy

--	Tính tổng số lượng bán ra của từng sản phẩm, sau đó xếp hạng theo số lượng giảm dần. Nếu số lượng bằng nhau thì sắp theo tên sản phẩm.
--	Mục đích nghiệp vụ: Doanh nghiệp cần nhận diện sản phẩm có nhu cầu cao để:
--- Lên kế hoạch nhập hàng, sản xuất, tồn kho
--- Đẩy mạnh quảng cáo cho nhóm sản phẩm phổ biến
--- Phân tích xu hướng tiêu dùng theo từng giai đoạn
--	Gợi ý table: SalesOrderDetail, Product
GO
create proc sp_SanPhamBanChay (
 @year INT = NULL
)
AS 
BEGIN
	SELECT 
		P.ProductID, 
		P.Name, SUM(S.OrderQty) as TongSoLuongBanRa, 
		DENSE_RANK() OVER (ORDER BY SUM(S.OrderQty) DESC) AS XepHang
	FROM 
		Production.Product P
	INNER JOIN Sales.SalesOrderDetail S
		ON P.ProductID = S.ProductID
	INNER JOIN Sales.SalesOrderHeader H
        ON S.SalesOrderID = H.SalesOrderID
    WHERE (@year IS NULL OR YEAR(H.OrderDate) = @year)
	GROUP BY 
		P.ProductID, 
		P.Name
	ORDER BY 
		SUM(S.OrderQty) DESC, 
		P.Name ASC;
END;

EXEC sp_SanPhamBanChay;
EXEC sp_SanPhamBanChay @year = 2025;

--> Bài 03: Viết truy vấn giải quyết bài toán: Doanh thu trung bình theo tháng

--	Tính doanh thu trung bình từng tháng trong năm @year. Nếu tháng không có đơn hàng, vẫn hiển thị tháng đó với doanh thu bằng 0.
--	Mục đích nghiệp vụ: Phục vụ mục tiêu:
-- Theo dõi chu kỳ hoạt động kinh doanh
-- Nhận diện thời điểm thấp để tung chiến dịch khuyến mãi
-- Hỗ trợ lập kế hoạch ngân sách theo mùa vụ
GO
create proc sp_DoanhThuTrungBinhTheoThang(
	@year INT
)
AS
BEGIN
	-- 1. Sử dụng CTE tạo ra một bảng tháng ảo để hiển thị nhóm danh thu theo cột
	WITH Months AS (
		SELECT 1 AS Thang
		UNION ALL
		SELECT Thang + 1
		FROM Months
		WHERE Thang < 12
	)

	-- 2. Kết nối bảng 12 tháng với bảng SalesOrderHeader để tính toán
	SELECT 
		Thang,
		ISNULL(AVG(SOH.TotalDue), 0) AS DoanhThuTrungBinh
	FROM Months
	LEFT JOIN Sales.SalesOrderHeader SOH
		ON Months.Thang = Month(SOH.OrderDate)
		AND YEAR(SOH.OrderDate) = @year
	GROUP BY 
		Thang
	ORDER BY
		Thang
END

EXEC sp_DoanhThuTrungBinhTheoThang @year = 2025
--> Bài 04: Tìm các khách hàng có từ 3 đơn hàng trở lên trong năm @year

--- Tìm các khách hàng có từ 3 đơn hàng trở lên trong năm @year.
--- Mục đích nghiệp vụ: Hỗ trợ xây dựng chương trình chăm sóc khách hàng:
--- Tạo danh sách khách hàng thân thiết
--- Cung cấp mã giảm giá, khuyến mãi riêng
--- Nâng cao trải nghiệm và giữ chân khách hàng lâu dài

--*Table: SalesOrderHeader, @year là biến được người dùng nhập vào*.

create proc sp_GetKhachHangMuaTu3DonHang(
	@year INT
)
AS
BEGIN
	SELECT 
		SC.CustomerID,
		PS.LastName + ' ' + PS.FirstName AS HoTen,
		COUNT(SOH.SalesOrderID) AS SL_DonHang
	FROM 
		Sales.SalesOrderHeader SOH
	JOIN 
		Sales.Customer SC
			ON SC.CustomerID = SOH.CustomerID
	LEFT JOIN 
		Person.Person PS
			ON PS.BusinessEntityID = SC.PersonID
	WHERE YEAR(SOH.OrderDate) = @year
	GROUP BY
		SC.CustomerID,
		PS.LastName,
		PS.FirstName
	HAVING COUNT(SOH.SalesOrderID) >= 3
	ORDER BY COUNT(SOH.SalesOrderID) DESC
END

EXEC sp_GetKhachHangMuaTu3DonHang @year = 2013

--> Bài 05: Viết câu truy vấn tìm 3 sản phẩm có số lượng bán thấp nhất 

create proc sp_Get3SanPhamCoSoLuongBanThapNhat(
	@year INT = NULL
)
AS
BEGIN
	SELECT 
		TOP 3
		PR.ProductID, 
		PR.Name ,
		SUM(SOD.OrderQty) as TongSoLuongOrder
	FROM Sales.SalesOrderDetail SOD
	LEFT JOIN 
		Production.Product PR
		ON PR.ProductID = SOD.ProductID
	LEFT JOIN
		Sales.SalesOrderHeader SOH
		ON SOH.SalesOrderID = SOD.SalesOrderID
	WHERE (@year IS NULL OR YEAR(SOH.OrderDate) = @year)
	GROUP BY 
		PR.ProductID, 
		PR.Name
	ORDER BY SUM(SOD.OrderQty) ASC
END

EXEC sp_Get3SanPhamCoSoLuongBanThapNhat;

--> Bài 06:  Viết câu truy vấn: Tỉ lệ đóng góp doanh thu của mỗi loại sản phẩm
--- Tính tỷ lệ đóng góp doanh thu của từng loại sản phẩm.

--> Mục đích nghiệp vụ:
--- Đánh giá hiệu quả từng danh mục sản phẩm
--- Tối ưu chiến lược bán hàng theo nhóm hàng
--- Quyết định phân bổ ngân sách và sản xuất

--*Table: SalesOrderDetail, Product*

create proc sp_TiLeDongGopDoanhThuTheoLoaiSanPham (@year INT = NULL)
AS 
BEGIN
	WITH 
		-- 1. Tính danh thu của toàn bộ hệ thống
		DoanhThuHeThong AS (
			SELECT 
				SUM(SOD.LineTotal) as DoanhThu
			FROM 
				Sales.SalesOrderDetail SOD
			INNER JOIN 
				Sales.SalesOrderHeader H
				ON SOD.SalesOrderID = H.SalesOrderID
			WHERE (@year IS NULL OR YEAR(H.OrderDate) = @year)
		),

		-- 2. Tính danh thu theo loai sản phẩm
		DoanhThuTheoLoaiSP AS (
			SELECT 
				SUM(SOD.LineTotal) AS DoanhThu, 
				PC.ProductSubcategoryID, 
				PC.Name
			FROM 
				Sales.SalesOrderDetail SOD
			INNER JOIN 
				Production.Product PR
				ON PR.ProductID = SOD.ProductID
			LEFT JOIN 
				Production.ProductSubcategory PC
				ON PC.ProductSubcategoryID = PR.ProductSubcategoryID
			INNER JOIN 
				Sales.SalesOrderHeader H
				ON SOD.SalesOrderID = H.SalesOrderID
			WHERE (@year IS NULL OR YEAR(H.OrderDate) = @year)
			GROUP BY 
				PC.ProductSubcategoryID,
				PC.Name
		)

		-- 3. Tính tỉ lệ đóng góp doanh thu của từng loại sản phẩm
		SELECT 
			DTSP.ProductSubcategoryID,
			DTSP.Name,
			ROUND(
					(DTSP.DoanhThu * 100 ) / NULLIF(DTHT.DoanhThu,0), 2
				) AS TiLeDongGopDoanhThu
		FROM DoanhThuTheoLoaiSP DTSP
		CROSS JOIN DoanhThuHeThong DTHT
		ORDER BY DTSP.DoanhThu DESC;
END

