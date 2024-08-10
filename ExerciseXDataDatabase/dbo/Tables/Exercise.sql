

CREATE TABLE [dbo].[Exercise]
(
[E_Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
[E_Name] NVARCHAR(128) NOT NULL, 
    [C_Id] NVARCHAR(128) NULL, 
    [E_Image] NCHAR(10) NULL, 
    [E_Times_Performed] INT NULL, 
    [Duration] NCHAR(10) NULL, 
    [E_Description] TEXT NULL, 
    [E_Pros_1] TEXT NOT NULL ,
    [E_Pros_2] TEXT NULL ,
    [E_Pros_3] TEXT NULL ,
    [E_Cons_1] TEXT NOT NULL ,
    [E_Cons_2] TEXT NULL ,
    [E_Cons_3] TEXT NULL 
)