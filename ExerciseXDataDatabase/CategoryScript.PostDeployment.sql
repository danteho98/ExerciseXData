/*
IF NOT EXIST (SELECT * FROM dbo.Category)
BEGIN
INSERT INTO dbo.Category(C_Id, C_Image, C_Name)
VALUES
(1, 'null', 'Aerobics '), (2, 'null ', 'Balancing'), (3, ' null', 'Strenching'), (4, 'null ', 'Strength')
END
*/
