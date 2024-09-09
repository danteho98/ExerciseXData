CREATE TABLE [dbo].[UsersExercises]
(
	[UE_Id] INT NOT NULL PRIMARY KEY, 
    [U_Id] INT NULL, 
    [E_Id] INT NULL, 
    [Times_Performed] INT NULL, 
    [Time(sec)] INT NULL, 
    [UE_Modify_Date] DATE NULL DEFAULT getutcdate()
    
    
)
