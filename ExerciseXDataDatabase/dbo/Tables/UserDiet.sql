

CREATE TABLE [dbo].[UsersDiets]
(
     
    [U_Id] INT NOT NULL, 
    [D_Id] INT NOT NULL, 
    [Quantity] INT NULL, 
    [Weight(grams)] INT NULL,
    [UD_Modified_Date] DATETIME2 NULL DEFAULT getutcdate(),
         
    CONSTRAINT FK_UsersDiets_Users FOREIGN KEY (U_Id) REFERENCES [dbo].Users(U_Id) ON DELETE CASCADE,
    CONSTRAINT  FK_UsersDiets_Diets FOREIGN KEY (D_ID) REFERENCES [dbo].Diets(D_Id) ON DELETE CASCADE,
    PRIMARY KEY (U_Id, D_Id )
)
