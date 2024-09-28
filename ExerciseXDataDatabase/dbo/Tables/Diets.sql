

CREATE TABLE [dbo].[Diets]
(
    [D_Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [D_Name] VARCHAR(255) NULL, 
    [D_Description] VARCHAR(MAX) NULL,
    Food_Name VARCHAR(255) NULL,
    [Food_Quantity] INT NULL, 
    [Total_calories] INT NULL, 
    [D_Pros_1] VARCHAR(255) NULL,
    [D_Pros_2] VARCHAR(255) NULL,
    [D_Pros_3] VARCHAR(255) NULL, 
    [D_Con_1] VARCHAR(255) NULL,
    [D_Con_2] VARCHAR(255) NULL,
    [D_Con_3] VARCHAR(255) NULL, 
    [D_Modified_Date] DATETIME2 NULL DEFAULT getutcdate()
)