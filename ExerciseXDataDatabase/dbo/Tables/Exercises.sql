CREATE TABLE [dbo].[Exercises]
(
    [E_Id] INT PRIMARY KEY IDENTITY(1,1),
    [E_Name] VARCHAR(255) NULL, 
    [C_Id] INT NULL, 
    [E_Image] VARBINARY(MAX) NULL, 
    [E_Description] VARCHAR(MAX) NULL, 
    [E_Pros_1] VARCHAR(255) NULL ,
    [E_Pros_2] VARCHAR(255) NULL ,
    [E_Pros_3] VARCHAR(255) NULL ,
    [E_Cons_1] VARCHAR(255) NULL ,
    [E_Cons_2] VARCHAR(255) NULL ,
    [E_Cons_3] VARCHAR(255) NULL, 
    [E_Modified_Date] DATETIME2 NULL DEFAULT GETUTCDATE() 


)