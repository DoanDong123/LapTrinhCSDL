USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[pro_SanPhamKhongCoDonHangTrongNgay]    Script Date: 07-Jul-20 1:08:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pro_SanPhamKhongCoDonHangTrongNgay]
(
	@date date,
	@page int,
	@size int
)
AS
BEGIN

	SET NOCOUNT ON;

	declare @begin int;
	declare @end int;
	set @begin = (@page -1) * @size +1;
	set @end = @page * @size;

	with s as (
		Select ROW_NUMBER() over (Order by ProductName) as STT, *
		From Products
		Where ProductID not in ( Select od.ProductID
								From Orders o  inner join [Order Details] od on o.OrderID = od.OrderID
								where o.OrderDate = @date)
	)

	select * from s where STT between @begin and @end
END
GO

Exec pro_SanPhamKhongCoDonHangTrongNgay '1996-07-08',1,5


