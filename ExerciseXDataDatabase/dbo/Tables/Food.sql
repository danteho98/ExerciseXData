

CREATE TABLE [dbo].[Foods]
(
    [F_Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [F_Image] VARBINARY(MAX) NULL, 
    [F_Name] VARCHAR(100) NULL,
    [F_Group] VARCHAR(50) NULL,
    [F_Calories] INT NULL,
    [F_Modified_Date] DATETIME2 NULL DEFAULT GETUTCDATE(), 
    
)