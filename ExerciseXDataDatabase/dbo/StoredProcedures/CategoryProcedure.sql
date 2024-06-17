CREATE PROCEDURE [dbo].[CategoryProcedure]
AS
BEGIN
SELECT
	[C_Id], [C_Image], [C_Name]
FROM Category
END