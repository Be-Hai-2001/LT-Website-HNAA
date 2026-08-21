
-- Bài 1: Sử dụng toán tử IN và sắp xếp nhiều cột
SELECT BusinessEntityID, JobTitle, HireDate 
FROM HumanResources.Employee
WHERE JobTitle IN ('Sales Representative', 'Marketing Specialist', 'Recruiter')

-- Bài 2: Sử dụng toán tử LIKE và NOT
SELECT ProductID, Name, Color 
FROM Production.Product
WHERE Name LIKE '%Bike%' AND Color <> 'Red'

-- Bài 3: Sử dụng toán tử IS NULL / IS NOT NULL
SELECT BusinessEntityID, Title, FirstName, MiddleName, LastName
FROM Person.Person
WHERE Title IS NULL OR MiddleName IS NULL

-- Bài 4: Kết hợp BETWEEN và hàm xử lý thời gian
SELECT ProductID, Name, Weight, SellStartDate
FROM Production.Product
WHERE Weight BETWEEN 10 AND 50 AND YEAR(SellStartDate) = 2011

-- Bài 5: Bài tập tổng hợp điều kiện logic (AND, OR và gom nhóm)
SELECT BusinessEntityID, Gender, MaritalStatus, VacationHours, SickLeaveHours
FROM HumanResources.Employee
WHERE 
	Gender = 'M' 
	AND MaritalStatus = 'S' 
	AND (VacationHours > 50 OR SickLeaveHours > 40)