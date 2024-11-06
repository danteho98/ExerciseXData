CREATE TABLE [dbo].[UsersCredentials]
(
	[Cre_Id] INT  PRIMARY KEY  IDENTITY(1,1) NOT NULL, 
    [U_Id] INT NOT NULL, 
    [Password_Hush] NVARCHAR(50) NULL, 
    [Password_Salt] VARCHAR(50) NULL, 
    [Last_Updated] DATETIME2 NULL DEFAULT GETUTCDATE()

    CONSTRAINT U_Id FOREIGN KEY (U_Id)
    REFERENCES Users (U_Id)
    ON DELETE CASCADE
)
