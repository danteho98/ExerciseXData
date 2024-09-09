CREATE PROCEDURE [dbo].[UserProcedure]
AS
BEGIN
SELECT
	[U_Id], [U_Email], [U_Password],
    [U_Name],
    [Gender],
    [Age],
    [Height_CM],
    [Weight_KG],
    [Goal],
    [Lifestyle_Condition_1],
    [Lifestyle_Condition_2],
    [Lifestyle_Condition_3],
    [Lifestyle_Condition_4],
    [Lifestyle_Condition_5]
FROM Users
END