

CREATE TABLE [dbo].[Diet]
(
    [D_Id] INT NOT NULL PRIMARY KEY, 
    [D_Name] TEXT NULL, 
    [D_Description] NCHAR(10) NULL, 
    [Food_Quantity] NCHAR(10) NULL, 
    [Total_calories] NCHAR(10) NULL, 
    [D_Pros_1] TEXT NULL,
    [D_Pros_2] TEXT NULL,
    [D_Pros_3] TEXT NULL, 
    [D_Con_1] TEXT NULL,
    [D_Con_2] TEXT NULL,
    [D_Con_3] TEXT NULL
)