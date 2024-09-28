CREATE TABLE [dbo].[UsersExercises]
(
	
    [U_Id] INT NOT NULL, 
    [E_Id] INT NOT NULL, 
    [Repetition] INT NULL,
    [Sets] Int NULL,
    [Time(sec)] INT NULL, 
    [UE_Modified_Date] DATE NULL DEFAULT GETUTCDATE(),

    CONSTRAINT FK_UsersExercises_Users FOREIGN KEY (U_Id) REFERENCES [dbo].[Users](U_Id) ON DELETE CASCADE,
    CONSTRAINT FK_UsersExercises_Exercises FOREIGN KEY (E_ID) REFERENCES [dbo].[Exercises](E_Id) ON DELETE CASCADE,
    PRIMARY KEY (U_Id, E_Id)
    
    
)
