CREATE PROCEDURE [dbo].[spOrders_Insert]
	@orderName nvarchar(50),
	@orderDate datetime2(7),
	@foodId int,
	@Quantity int,
	@total money,
	@id int output
AS
begin
set nocount on
insert into [Order](OrderName,OrderDate,FoodId,Quantity,Total)
values(@orderName,@orderDate,@foodId,@Quantity,@total)
	
	set @id  = SCOPE_IDENTITY();
end