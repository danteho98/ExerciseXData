CREATE TABLE [dbo].[UsersExercises]
(
	[UE_Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [U_Id] NVARCHAR(128) NOT NULL, 
    [E_Id] INT NOT NULL, 
    [Times_Performed] INT NULL, 
    [Time(sec)] INT NOT NULL, 
    [UE_Modify_Date] DATE NOT NULL DEFAULT getutcdate()
    
    
)
