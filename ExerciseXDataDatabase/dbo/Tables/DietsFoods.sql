

CREATE TABLE [dbo].[DietsFoods]
( 
    [DF_Id] INT NOT NULL PRIMARY KEY, 
    [D_Id] INT NOT NULL, 
    [F_Id] INT NOT NULL,
    [DF_Serving_Size] VARCHAR(50) NULL, 
    [DF_Recommended_Servings] VARCHAR(50) NULL, 
    [DF_Frequency] VARCHAR(20) NULL,
    [DF_Total_Calories] INT NULL,

    [DF_Modified_Date] DATETIME NULL DEFAULT GETUTCDATE() 

    CONSTRAINT FK_DietsFoods_Diets FOREIGN KEY (D_Id) REFERENCES [dbo].Diets(D_Id) ON DELETE CASCADE,
    CONSTRAINT  FK_DietsFoods_Foods FOREIGN KEY (F_ID) REFERENCES [dbo].Foods(F_Id) ON DELETE CASCADE
    --PRIMARY KEY (D_Id, F_Id)
)