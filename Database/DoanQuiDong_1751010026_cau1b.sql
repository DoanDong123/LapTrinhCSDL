USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[pro_SanPhamKhongConTonKho]    Script Date: 07-Jul-20 1:13:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[pro_SanPhamKhongConTonKho]
(
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
		Select ROW_NUMBER() over (Order by ProductName) as STT, *
		From Products
		Where UnitsInStock = 0
	)

	select * from s where STT between @begin and @end
End
GO

Exec pro_SanPhamKhongConTonKho 1, 4


