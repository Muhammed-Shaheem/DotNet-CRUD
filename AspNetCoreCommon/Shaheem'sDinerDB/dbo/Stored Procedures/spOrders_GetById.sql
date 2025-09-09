CREATE PROCEDURE [dbo].[spOrders_GetById]
	@id int 

AS
begin
set nocount on
select [Id], [OrderName], [OrderDate], [FoodId], [Quantity], [Total]
from [Order]
where Id =@id;
end
