
CREATE TABLE [dbo].[User]
(
    U_Id INT NOT NULL PRIMARY KEY, 
    U_Email NVARCHAR(128) NULL,
    U_Password NVARCHAR(128) NULL,
    U_Name TEXT NULL,
    Gender TEXT NULL,
    Age INT NULL,
    Height_CM FLOAT NULL,
    Weight_KG FLOAT NULL,
    Goal TEXT NULL,
    Lifestyle_Condition_1 TEXT NULL,
    Lifestyle_Condition_2 TEXT NULL,
    Lifestyle_Condition_3 TEXT NULL,
    Lifestyle_Condition_4 TEXT NULL,
    Lifestyle_Condition_5 TEXT NULL
    )
