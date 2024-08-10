CREATE PROCEDURE [dbo].[DietProcedure]
AS
BEGIN
SELECT
	[D_Id], [D_Name], [D_Description], 
	[D_Pros_1], [D_Pros_2], [D_Pros_3], 
	[D_Con_1], [D_Con_2], [D_Con_3] 
FROM Diet
END