

CREATE TABLE [dbo].[Exercise]
(
[E_Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
[E_Name] NVARCHAR(128) NOT NULL, 
    [C_ID] NVARCHAR(128) NULL, 
    [E_Image] NCHAR(10) NULL, 
    [E_Times_Performed] NCHAR(10) NULL, 
    [Duration] NCHAR(10) NULL, 
    [Description] TEXT NULL, 
    [Pros_1] TEXT NOT NULL ,
    [Pros_2] TEXT NULL ,
    [Pros_3] TEXT NULL ,
    [Cons_1] TEXT NOT NULL ,
    [Cons_2] TEXT NULL ,
    [Cons_3] TEXT NULL 
)