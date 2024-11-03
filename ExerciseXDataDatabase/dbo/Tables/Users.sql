
CREATE TABLE [dbo].[Users]
(
    U_Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    U_Email NVARCHAR(128) NULL,
    
    U_Name VARCHAR(255) NULL,
    Gender VARCHAR(20) NULL,
    [Role] VARCHAR(10) NULL,
    Age INT NULL,
    Height_CM FLOAT NULL,
    Weight_KG FLOAT NULL,
    Goal VARCHAR(255) NULL,
    Lifestyle_Condition_1 VARCHAR(255) NULL,
    Lifestyle_Condition_2 VARCHAR(255) NULL,
    Lifestyle_Condition_3 VARCHAR(255) NULL,
    Lifestyle_Condition_4 VARCHAR(255) NULL,
    Lifestyle_Condition_5 VARCHAR(255) NULL, 
    U_Modified_Date DATETIME2 NULL DEFAULT GETUTCDATE(), 
    
    )
