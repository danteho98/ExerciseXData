CREATE PROCEDURE [dbo].[FoodProcedure]
AS
BEGIN
SELECT
	[F_Id], [F_Image], [F_Name], [F_Food_Calories]
FROM Food
END