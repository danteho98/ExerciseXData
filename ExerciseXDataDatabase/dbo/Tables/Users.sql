
CREATE TABLE [dbo].[Users]
(
    
    [U_Gender] VARCHAR(20) NULL,
    [U_Role] VARCHAR(10) NULL,
    [U_Age] INT NULL,
    [U_Height_CM] FLOAT NULL,
    [U_Weight_KG] FLOAT NULL,
    [U_Goal] VARCHAR(255) NULL,
    [U_Lifestyle_Condition_1] VARCHAR(255) NULL,
    [U_Lifestyle_Condition_2] VARCHAR(255) NULL,
    [U_Lifestyle_Condition_3] VARCHAR(255) NULL,
    [U_Lifestyle_Condition_4] VARCHAR(255) NULL,
    [U_Lifestyle_Condition_5] VARCHAR(255) NULL, 
    [U_Created_Date] DATETIME2 NULL DEFAULT GETUTCDATE(), 
    [U_Last_Login] DATETIME2 NULL, 
    
    )
