﻿

CREATE TABLE [dbo].[Diets]
(
    [D_Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [D_Name] VARCHAR(255) NULL, 
    [D_Description] VARCHAR(MAX) NULL,
    [D_Pros_1] VARCHAR(255) NULL,
    [D_Pros_2] VARCHAR(255) NULL,
    [D_Pros_3] VARCHAR(255) NULL, 
    [D_Cons_1] VARCHAR(255) NULL,
    [D_Cons_2] VARCHAR(255) NULL,
    [D_Cons_3] VARCHAR(255) NULL, 
    [D_Modified_Date] DATETIME2 NULL DEFAULT getutcdate()
    
    
)