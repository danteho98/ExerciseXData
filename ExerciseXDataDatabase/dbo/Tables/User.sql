
CREATE TABLE [dbo].[User]
(
	[U_Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
   U_Email NVARCHAR(128) NOT NULL,
   U_Password NVARCHAR(128) NOT NULL,
   U_Name NVARCHAR(128) NOT NULL,
   Gender NVARCHAR(128) NOT NULL,
   Age NVARCHAR(128) NOT NULL,
   Height_CM NVARCHAR(128) NOT NULL,
   Weight_KG NVARCHAR(128) NOT NULL,
   Goal NVARCHAR(128) NOT NULL,
   Lifestyle_Condition_1 NVARCHAR(128) NULL,
   Lifestyle_Condition_2 NVARCHAR(128) NULL,
   Lifestyle_Condition_3 NVARCHAR(128) NULL,
   Lifestyle_Condition_4 NVARCHAR(128) NULL,
   Lifestyle_Condition_5 NVARCHAR(128) NULL
    
    
)
