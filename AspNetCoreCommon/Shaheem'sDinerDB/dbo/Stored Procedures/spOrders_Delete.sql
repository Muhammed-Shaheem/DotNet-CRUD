CREATE PROCEDURE [dbo].[spOrders_Delete]
	@id int
AS
begin

set nocount on
	delete from [Order]
	where Id =@id
	
end