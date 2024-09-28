
CREATE TABLE [dbo].[Categories]
(
    [C_Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [C_Image] VARBINARY(MAX) NULL, 
    [C_Name] VARCHAR(MAX) NULL, 
    [C_Modified_Date] DATETIME2 NULL DEFAULT getutcdate() 

)