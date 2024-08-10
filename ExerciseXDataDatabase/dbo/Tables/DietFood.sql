

CREATE TABLE [dbo].[DietFood]
(
    [DF_Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [D_Id] NVARCHAR(128) NOT NULL, 
    [F_Id] NVARCHAR(128) NULL, 
    [Date_Mortified] DATE NOT NULL DEFAULT getutcdate() 
)