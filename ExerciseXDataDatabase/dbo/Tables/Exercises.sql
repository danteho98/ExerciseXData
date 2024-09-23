

CREATE TABLE [dbo].[Exercise]
(
[E_Id] INT NOT NULL IDENTITY(1,1),
[E_Name] TEXT NULL, 
    [C_Id] INT NULL, 
    [E_Image] NCHAR(10) NULL, 
    [E_Description] TEXT NULL, 
    [E_Pros_1] TEXT NULL ,
    [E_Pros_2] TEXT NULL ,
    [E_Pros_3] TEXT NULL ,
    [E_Cons_1] TEXT NULL ,
    [E_Cons_2] TEXT NULL ,
    [E_Cons_3] TEXT NULL 
)