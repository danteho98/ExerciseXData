

CREATE TABLE [dbo].[Diet]
(
    [D_Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [D_Name] NVARCHAR(128) NOT NULL, 
    [Description] NCHAR(10) NULL, 
    [Food_Quantity] NCHAR(10) NULL, 
    [Total_calories] NCHAR(10) NULL, 
    [Pros_1] TEXT NULL,
    [Pros_2] TEXT NULL,
    [Pros_3] TEXT NULL, 
    [Con_1] TEXT NULL,
    [Con_2] TEXT NULL,
    [Con_3] TEXT NULL
)