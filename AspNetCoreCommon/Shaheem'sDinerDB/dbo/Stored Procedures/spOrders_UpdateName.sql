CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@id int,
	@orderName nvarchar(50)
	
AS
begin
set nocount on
	update [Order]
	set OrderName = @orderName
	where Id = @id
end 
