--> Bài 1: Tạo View bảo mật thông tin nhân viên
create view vw_SafeEmployeeInfo
as 
	select H.BusinessEntityID, FirstName, LastName, JobTitle, HireDate
	from HumanResources.Employee H
	inner join Person.Person P
	on H.BusinessEntityID = P.BusinessEntityID
go

--select * from vw_SafeEmployeeInfo

---------------------------------------------------

--> Bài 2: Tạo View đơn giản hóa báo cáo doanh thu
create view vw_OrderSummary
as
	select 
		SOH.SalesOrderID, 
		OrderDate,
		SUM(SOD.LineTotal) AS TotalDue
	from Sales.SalesOrderHeader SOH
	inner join Sales.SalesOrderDetail SOD
	on SOH.SalesOrderID = SOD.SalesOrderID
	group by SOH.SalesOrderID, OrderDate
go

--select Top 1* from vw_OrderSummary

---------------------------------------------------

--> Bài 3: Cập nhật View (ALTER VIEW)
alter view vw_OrderSummary
as
	select 
		SOH.SalesOrderID, 
		SOH.OrderDate,
		SUM(SOD.LineTotal) AS TotalDue,
		PP.FirstName,
		PP.LastName
	from Sales.SalesOrderHeader SOH

	inner join Sales.SalesOrderDetail SOD
	on SOH.SalesOrderID = SOD.SalesOrderID
	left join Sales.Customer SC
	on SC.CustomerID = SOH.CustomerID
	left join Person.Person PP
	on PP.BusinessEntityID = SC.PersonID

	group by 
		SOH.SalesOrderID, 
		SOH.OrderDate, 
		PP.FirstName, 
		PP.LastName
go

--select Top 1* from vw_OrderSummary

---------------------------------------------------

--> Bài 4: Thực hành tạo Non-Clustered Index
create nonclustered index IX_Product_Name 
on Production.Product (Name)

select * from Production.Product where Name like '%Bike%'