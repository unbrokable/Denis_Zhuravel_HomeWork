-- Task 1 ---
select pr.ProductID , pr.Name, pr.Color , pr.rowguid from SalesLT.Product pr

select c.CustomerID , CONCAT(c.FirstName, ' ',c.MiddleName,' ', c.LastName), c.EmailAddress, c.Phone from SalesLT.Customer c
--Task 2 --
select * from SalesLT.Product pr
where pr.Color = 'Black'

select * from SalesLT.Product pr
where pr.Color = 'Black' or pr.Color = 'Gray' or pr.Color = 'Multi'

select * from SalesLT.Product pr
where pr.Color = 'Black' or pr.Color = 'Yellow' 

select * from SalesLT.Product pr
where pr.Weight > 1000

select * from SalesLT.Product pr
where pr.Weight < 6000

select * from SalesLT.Product pr
where pr.Weight between 2000 and  5000

select * from SalesLT.Product pr
where pr.rowguid like 'BK%' or  pr.rowguid  like 'BB%'

select * from SalesLT.Product pr
where pr.SellEndDate is null or pr.SellEndDate < GETDATE()

--Task 3---
select * from SalesLT.Product pr
order by pr.Color ASC

select * from SalesLT.Product pr
order by pr.Color DESC, pr.Weight ASC

select * from SalesLT.Product pr
order by pr.ProductID , pr.Weight DESC

--Task 4 -- 
select Top(10) * from SalesLT.Product 

select Top(10) * from SalesLT.Product 
order by Weight

select Top(10) * from SalesLT.Product 
order by Weight

select Top(10) * from SalesLT.Product 
order by Weight DESC

select * from SalesLT.Product 
order by Weight
OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY

--Task 5 -- 
select pr.ProductID, pr.Name, pr.rowguid, pr.Weight, sal.UnitPrice,Concat(sal.UnitPriceDiscount* 100,'%') as Discount from SalesLT.Product pr 
join SalesLT.SalesOrderDetail sal on sal.ProductID = pr.ProductID

select distinct c.rowguid, CONCAT(c.FirstName, ' ', c.LastName), c.EmailAddress, c.Phone, ad.City, ad.City , ad.StateProvince, ad.PostalCode, CONCAT (ad.AddressLine1, ad.AddressLine2) as Address
from SalesLT.Customer c
join SalesLT.CustomerAddress a on a.CustomerID = c.CustomerID
join SalesLT.Address ad on a.AddressID = ad.AddressID

select pr.ProductID, pr.Name, pr.ProductNumber,c2.Name,c.Name from  SalesLT.Product pr
join SalesLT.ProductCategory c on pr.ProductCategoryID = c.ProductCategoryID
join SalesLT.ProductCategory c2 on c2.ProductCategoryID = c.ParentProductCategoryID

--Task 6 -- 
select count(*) from SalesLT.Product

select count(*) from SalesLT.Product
WHERE SellEndDate < GETDATE() 

select count(*) from SalesLT.Product
WHERE Weight is null

select AVG(Weight) from SalesLT.Product
WHERE Weight  is not null

select AVG(Weight) from SalesLT.Product

select Max(Weight),Min(Weight) from SalesLT.Product

select ct.ProductCategoryID, ct.Name, count(pr.ProductID) as Amount, Sum(pr.Weight) as Weights, Max(Weight), Min(Weight) , AVG(pr.Weight) from SalesLT.ProductCategory ct 
join SalesLT.Product pr on pr.ProductCategoryID = ct.ProductCategoryID
group by ct.ProductCategoryID, ct.Name

select ct.ProductCategoryID, ct.Name, count(pr.ProductID) as Amount, Sum(pr.Weight) as Weights, Max(Weight), Min(Weight) , AVG(pr.Weight) from SalesLT.ProductCategory ct 
join SalesLT.Product pr on pr.ProductCategoryID = ct.ProductCategoryID
group by ct.ProductCategoryID, ct.Name
Having Sum(pr.Weight) is not null

select ct.ProductCategoryID, ct.Name, count(pr.ProductID) as Amount, Sum(pr.Weight) as Weights, Max(Weight), Min(Weight) , AVG(pr.Weight) from SalesLT.ProductCategory ct 
join SalesLT.Product pr on pr.ProductCategoryID = ct.ProductCategoryID
group by ct.ProductCategoryID, ct.Name
Having Sum(pr.Weight) is not null and  Sum(pr.Weight) >1000

--7 -- 
Select c.ProductCategoryID, c.Name, sum(s.UnitPrice) as 'Sum' from SalesLT.ProductCategory c
join SalesLT.Product pr on pr.ProductCategoryID = c.ProductCategoryID
join SalesLT.SalesOrderDetail s on s.ProductID = pr.ProductID
group by c.ProductCategoryID, c.Name


Select distinct c.CustomerID, CONCAT(FirstName,' ', MiddleName,' ', LastName)  from SalesLT.Customer c 
	join SalesLT.SalesOrderHeader sh on sh.CustomerID = c.CustomerID
	join SalesLT.SalesOrderDetail sd on sd.SalesOrderID  = sh.SalesOrderID
	group by c.CustomerID,CONCAT(FirstName,' ', MiddleName,' ', LastName) 
	having  max(sd.UnitPriceDiscount) >= 0.4


select CustomerID, CONCAT(FirstName,' ', MiddleName,' ', LastName) from SalesLT.Customer 
	where CustomerID in(
	select distinct c.CustomerID from SalesLT.Customer c
	join SalesLT.SalesOrderHeader sh on sh.CustomerID = c.CustomerID
	join SalesLT.SalesOrderDetail sd on sd.SalesOrderID  = sh.SalesOrderID
	group by c.CustomerID
	having  SUM(sd.UnitPrice) > 15000)

	
