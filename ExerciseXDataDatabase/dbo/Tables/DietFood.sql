

CREATE TABLE [dbo].[DietFood]
(
    [DF_Id] INT NOT NULL PRIMARY KEY, 
    [D_Id] INT NULL, 
    [F_Id] INT NULL, 
    [Date_Mortified] DATETIME NULL DEFAULT getutcdate() 
)