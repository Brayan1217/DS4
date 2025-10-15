-- EJEMPLOS LABORATORIO 13---
--ejmplo 1
SELECT * FROM Products

--Ejemplo 2
SELECT productID, ProductName, UnitPrice from Products

--Ejemplo 3
select ProductID, ProductName, UnitPrice
from Products
where UnitPrice > 15

--Ejemplo 4
select ProductID, ProductName, UnitPrice
from Products
where UnitPrice >=15 AND UnitPrice <=50

--Ejemplo 5
SELECT ProductID, ProductName,UnitPrice
FROM Products
where UnitPrice BETWEEN 15 AND 50

--Ejemplo 6
SELECT ProductID,ProductName,UnitPrice
from Products
where NOT UnitPrice >15

--Ejemplo 7
select ProductID,ProductName,UnitPrice
from Products
where ProductID > 15 OR UnitPrice < 10

--Ejemplo 8
select EmployeeID, LastName from Employees
where LastName Like 'D%'

--Ejemplo 9
select EmployeeID,LastName from Employees
where LastName LIKe '%N'

--Ejemplo 10
select EmployeeID, LastName, Title from Employees
where Title LIKE '%SALES%'

--Ejemplo 11
select EmployeeID, LastName FROM Employees
where LastName NOT LIKE 'D%'

--Ejemplo 12
SELECT ProductID,ProductName, UnitPrice
from Products
order by ProductID asc


--ejemplo 13
SELECT ProductID,ProductName, UnitPrice
from Products
order by ProductID desc

--ejemplo 14
select DISTINCT OrderID from [Order Details]

--ejemplo 15
select TOP 5 OrderID, ProductID, Quantity
from [Order Details]

--ejemplo 16
select TOP 10 Percent OrderID, ProductID, Quantity
from [Order Details]

--ejemplo 17
select CategoryName AS [Nombre de Categoria]
from Categories

--ejemplo 18
select OrderId, orderDate, ShippedDate, ShippedDate + 5 RetrasoEnvio
from Orders

--ejemplo 19
select OrderID, P.ProductID, ProductName
from Products P
INNER JOIN [Order Details] OD
on P.ProductID=OD.ProductID

--ejemplo 20
Select ProductName, CompanyName, ContactName
from Products P
Full JOIN Suppliers S
on P.SupplierID=S.SupplierID
