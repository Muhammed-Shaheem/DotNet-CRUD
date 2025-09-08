/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from Food)
begin
insert into Food(Title,Description,Price) 
values('Cheesburger Meal', 'A cheeseburger, fries, and a drink' , 300 ),
('Eid Meal', 'A Beef biriyani and Semiya payasam' , 250),
('Marriage Meal', 'Chicken Mandi with alfaham chicken',500)
end