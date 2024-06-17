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
if not exists (select * from dbo.Category)
begin
insert into dbo.Category(C_Id, C_Image, C_Name)
values
(1, 'null', 'Aerobics '), (2, 'null ', 'Balancing'), (3, ' null', 'Strenching'), (4, 'null ', 'Strength')
end