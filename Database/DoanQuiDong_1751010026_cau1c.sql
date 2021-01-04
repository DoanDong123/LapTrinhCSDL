USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[pro_TimKiemOrderTheoCtyVaNhanVien]    Script Date: 07-Jul-20 1:14:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter Proc [dbo].[pro_TimKiemOrderTheoCtyVaNhanVien]
(
	@keyword nvarchar (50),
	@page int,
	@size int
)
As
Begin
	
	declare @begin int;
	declare @end int;
	set @begin = (@page -1) * @size +1;
	set @end = @page * @size;

	with s as (
		Select ROW_NUMBER() over (Order by OrderID) as STT, o.*
		From Orders o inner join Customers c on o.CustomerID = c.CustomerID inner join Employees e on e.EmployeeID = o.EmployeeID
		Where c.CompanyName like @keyword or e.FirstName like @keyword or e.LastName like @keyword
	)

	select * from s where STT between @begin and @end
End
GO

Exec pro_TimKiemOrderTheoCtyVaNhanVien 'Alfreds Futterkiste', 1, 6