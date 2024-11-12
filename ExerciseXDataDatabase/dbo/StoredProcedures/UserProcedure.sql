CREATE PROCEDURE [dbo].[UserProcedure]
AS
BEGIN
SELECT
	[U_Id],
    [U_Email],
    [U_Name],
    [U_Gender],
    [U_Age],
    [U_Height_CM],
    [U_Weight_KG],
    [U_Goal],
    [U_Lifestyle_Condition_1],
    [U_Lifestyle_Condition_2],
    [U_Lifestyle_Condition_3],
    [U_Lifestyle_Condition_4],
    [U_Lifestyle_Condition_5]
FROM Users
END