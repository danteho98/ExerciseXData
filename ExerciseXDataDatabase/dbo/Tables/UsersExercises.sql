CREATE TABLE [dbo].[UsersExercises]
(
	[UE_Id] INT NOT NULL PRIMARY KEY, 
    [U_Id] NVARCHAR(450) NOT NULL, 
    [E_Id] INT NOT NULL, 
    [Repetition] INT NULL,
    [Sets] Int NULL,
    [Duration(sec)] INT NULL, 
    [UE_Modified_Date] DATE NULL DEFAULT GETUTCDATE(),

    CONSTRAINT FK_UsersExercises_Users 
    FOREIGN KEY (U_Id) REFERENCES [dbo].[AspNetUsers](Id) ON DELETE CASCADE,
    CONSTRAINT FK_UsersExercises_Exercises 
    FOREIGN KEY (E_ID) REFERENCES [dbo].[Exercises](E_Id) ON DELETE CASCADE
    --PRIMARY KEY (U_Id, E_Id)
    
    
)
