use master
GO
IF DB_ID (N'CourseWork') IS NOT NULL
DROP DATABASE CourseWork
GO
--Create Database
CREATE DATABASE CourseWork
ON
(
	NAME = CourseWork_data,
	FILENAME = 'C:\Database\dAtEtImE\CourseWork.mdf'
)
LOG ON
(
	NAME = СourseWork_log,
	FILENAME = 'C:\Database\dAtEtImE\CourseWork.ldf'
)
GO
use CourseWork
GO
CREATE RULE level_max_person
as
@level >= $1 and @level <= $32
GO
CREATE RULE minSymbols
AS
len(@value) >= $6
GO
CREATE RULE level_max_talant
as
@level >= $1 and @level <=$5
GO
CREATE RULE procent_chance
as
@procent >=$1 and @procent <= $99
GO
CREATE TYPE names
FROM nvarchar(20) NOT NULL 
GO
CREATE TYPE DescrText
FROM ntext NOT NULL
GO
CREATE TYPE numbers
FROM char(12) NOT NULL
GO
CREATE RULE Number
AS @value LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
GO
exec sp_bindrule 'Number', 'numbers'
GO
	CREATE TYPE ItemsType
	from nchar(6) not null
GO
	CREATE RULE type_rule  
	AS   
	@value IN ('boots', 'bow', 'sword', 'hammer','armor','shield','staff');  
GO
exec sp_bindrule 'type_rule', 'ItemsType'
GO
CREATE DEFAULT minLevel as 1
GO
CREATE DEFAULT minSDVIFL as '010101010101'
GO
CREATE DEFAULT minTalantLevel as 1
GO
use CourseWork

--Create table
CREATE TABLE Achivments
(
	ID int IDENTITY,
	A_Name names UNIQUE,
	A_Description DescrText
	CONSTRAINT PK_ID_Achivments PRIMARY KEY (ID)
)
CREATE TABLE Race
(
	ID int NOT NULL IDENTITY,
	R_Name names UNIQUE,
	R_History DescrText 
	CONSTRAINT PK_Race_Name PRIMARY KEY (ID)
)
CREATE TABLE Class
(
	ID int IDENTITY,
	C_Name names UNIQUE,
	C_Description DescrText,
	C_Race int NOT NULL
	CONSTRAINT PK_Class_Name PRIMARY KEY (ID),
	CONSTRAINT FK_Class_Race FOREIGN KEY (C_Race)
	REFERENCES Race(ID)
)
CREATE TABLE Person
(
	ID int IDENTITY,
	P_Login nchar(12) NOT NULL UNIQUE,
	P_Password varchar(16) NOT NULL,
	P_Nickname nvarchar(16) NOT NULL UNIQUE,
	P_SDVIFL numbers,
	P_SpecPoint tinyint NOT NULL DEFAULT 0,
	P_TalantPoint tinyint NOT NULL DEFAULT 0,
	P_Level tinyint NOT NULL,
	P_Class int NOT NULL,
	P_Admin bit NOT NULL DEFAULT 0,
	CONSTRAINT PK_ID_Person PRIMARY KEY (ID),
	CONSTRAINT FK_Person_Class FOREIGN KEY (P_Class)
	REFERENCES Class(ID),
	CONSTRAINT Check_PointTalant CHECK (P_TalantPoint >= 0),
	CONSTRAINT Check_PointSpec CHECK (P_SpecPoint >= 0)
)
GO
use CourseWork
exec sp_bindrule 'minSymbols', 'Person.P_Login'
exec sp_bindrule 'minSymbols', 'Person.P_Password'
exec sp_bindrule 'minSymbols', 'Person.P_Nickname'

exec sp_bindrule 'level_max_person', 'Person.P_Level' 
exec sp_bindefault 'minLevel', 'Person.P_Level'
exec sp_bindefault 'minSDVIFL', 'Person.P_SDVIFL'
CREATE TABLE Talants
(
	ID int IDENTITY,
	T_Name nvarchar(20) NOT NULL UNIQUE,
	T_Description DescrText,
	ID_Class int NOT NULL
	CONSTRAINT PK_ID_Talants PRIMARY KEY (ID),
	CONSTRAINT FK_Talants_Class FOREIGN KEY (ID_Class)
	REFERENCES Class(ID)
)
CREATE TABLE Monsters
(
	ID int IDENTITY,
    M_Name nvarchar(20) NOT NULL UNIQUE,
	M_Description DescrText,
	M_Level tinyint NOT NULL,
	Damage int NOT NULL,
	HealthPoint int NOT NULL,
	Defence int NOT NULL,
	IsBoss bit NOT NULL
	CONSTRAINT PK_ID_Monster PRIMARY KEY (ID)
)
GO
USE CourseWork
exec sp_bindrule 'procent_chance', 'Monsters.Defence'
CREATE TABLE Items
(
	ID int IDENTITY,
	I_Name nvarchar(20) NOT NULL UNIQUE,
	I_Description DescrText,
	I_Type ItemsType,
	I_SDVIFL numbers,
	CONSTRAINT PK_ID_Item PRIMARY KEY(ID) 
)
--Connection objects
CREATE TABLE Person_Talants
(
	ID_Person int,
	ID_Talant int,
	Talant_Level tinyint NOT NULL,
	CONSTRAINT PK_Person_Talant PRIMARY KEY (ID_Person, ID_Talant),
	CONSTRAINT FK_Talant_Person FOREIGN KEY (ID_Person)
	REFERENCES Person(ID),
	CONSTRAINT FK_PersonTalant_Talant FOREIGN KEY (ID_Talant)
	REFERENCES Talants(ID)
)
GO
USE CourseWork
exec sp_bindrule 'level_max_talant', 'Person_Talants.Talant_Level'
exec sp_bindefault 'minTalantLevel', 'Person_Talants.Talant_Level'
CREATE TABLE Person_Items
(
	ID_Person int,
	ID_Item int
	CONSTRAINT PK_Person_Item PRIMARY KEY (ID_Person, ID_Item),
	CONSTRAINT FK_Item_Person FOREIGN KEY (ID_Person)
	REFERENCES Person(ID),
	CONSTRAINT FK_PersonItem_Item FOREIGN KEY (ID_Item)
	REFERENCES Items(ID)
)
CREATE TABLE Person_Achivments
(
	ID_Person int,
	ID_Achivment int,
	Achiv_Percent int NOT NULL
	CONSTRAINT PK_Person_Achivment PRIMARY KEY(ID_Person, ID_Achivment),
	CONSTRAINT FK_Achivment_Person FOREIGN KEY (ID_Person)
	REFERENCES Person(ID),
	CONSTRAINT FK_PersonAchivment_Achivment FOREIGN KEY (ID_Achivment)
	REFERENCES Achivments(ID)
)
CREATE TABLE Class_Items
(
	ID_Item int,
	ID_Class int
	CONSTRAINT PK_Class_Item PRIMARY KEY (ID_Item, ID_Class),
	CONSTRAINT FK_ItemClass_Class FOREIGN KEY (ID_Class)
	REFERENCES Class(ID),
	CONSTRAINT FK_ItemClass_Item FOREIGN KEY (ID_Item)
	REFERENCES Items(ID)
)
CREATE TABLE LootMonster
(
	ID_Monster int,
	ID_Item int,
	ChanceDrop int NOT NULL
	CONSTRAINT PK_LootMonster PRIMARY KEY (ID_Monster, ID_Item),
	CONSTRAINT FK_LootMonster_Monster FOREIGN KEY (ID_Monster)
	REFERENCES Monsters(ID),
	CONSTRAINT FK_LootMonster_Item FOREIGN KEY (ID_Item)
	REFERENCES Items(ID)
)
GO
USE CourseWork
exec sp_bindrule 'procent_chance', 'LootMonster.ChanceDrop'
GO
--Create DELETE TRIGGER
CREATE TRIGGER Delete_Person
ON Person
INSTEAD OF DELETE
AS
DELETE
FROM Person_Talants
WHERE ID_Person IN (SELECT ID FROM deleted)
DELETE
FROM Person_Achivments
WHERE ID_Person IN (SELECT ID FROM deleted)
DELETE
FROM Person_Items
WHERE ID_Person IN (SELECT ID FROM deleted)
DELETE
FROM Person
WHERE ID IN (SELECT ID FROM deleted)
GO
CREATE TRIGGER Delete_Talant
ON Talants
INSTEAD OF DELETE
AS
DELETE
FROM Person_Talants
WHERE ID_Talant IN (SELECT ID FROM deleted)
DELETE
FROM Talants
WHERE ID IN (SELECT ID FROM deleted)
GO
CREATE TRIGGER Delete_Class
ON Class
INSTEAD OF DELETE
AS
DELETE
FROM Talants
WHERE ID_Class IN (SELECT ID FROM deleted)
DELETE
FROM Person
WHERE P_Class IN (SELECT ID FROM deleted)
DELETE
FROM Class_Items
WHERE ID_Class IN (SELECT ID FROM deleted)
DELETE
FROM Class
WHERE ID IN (SELECT ID FROM deleted)
GO
CREATE TRIGGER Delete_Achivment
ON Achivments
INSTEAD OF DELETE
AS
DELETE
FROM Person_Achivments
WHERE ID_Achivment IN (SELECT ID FROM deleted)
DELETE
FROM Achivments
WHERE ID IN (SELECT ID FROM deleted)
GO
CREATE TRIGGER Delete_Race
ON Race
INSTEAD OF DELETE
AS
DELETE
FROM Class
WHERE C_Race IN (SELECT ID FROM deleted)
DELETE
FROM Race
WHERE ID IN (SELECT ID FROM deleted)
GO
CREATE TRIGGER Delete_Monster
ON Monsters
INSTEAD OF DELETE
AS
BEGIN
	DELETE
	FROM LootMonster
	WHERE LootMonster.ID_Monster in (Select ID FROM deleted)
	DELETE
	FROM Monsters
	WHERE ID in (Select ID From deleted)
END
GO
--Create Procedure
CREATE PROCEDURE Update_PersonTalents
(
	@idPers int,
	@idTalent int,
	@lvl tinyint
)
AS
BEGIN
	Update Person_Talants
	set Talant_Level = @lvl
	where ID_Person = @idPers and ID_Talant = @idTalent
END
GO
CREATE PROCEDURE Update_PersonAchivments
(
	@idPerson int,
	@idAchivments int,
	@Percent int
)
AS
BEGIN
	Update Person_Achivments
	Set Achiv_Percent = @Percent
	Where ID_Person = @idPerson AND ID_Achivment = @idAchivments
END
GO
CREATE PROCEDURE Update_Achivments
(
	@idAchiv int,
	@Name nvarchar(20) NULL,
	@Description ntext
)
AS
BEGIN
	IF (@Name = NULL)
	Update Achivments
	Set A_Description = @Description
	Where ID = @idAchiv
	ELSE
	Update Achivments
	Set A_Name = @Name, A_Description = @Description
	Where ID = @idAchiv
END
GO
CREATE PROCEDURE Update_LootMonster
(
	@idMonster int,
	@idItem int,
	@ChanceDrop int
)
AS
BEGIN
	Update LootMonster
	Set ChanceDrop = @ChanceDrop
	Where ID_Monster = @idMonster AND ID_Item = @idItem
END
GO
CREATE PROCEDURE Update_Talants
(
	@idTalants int,
	@Name nvarchar(20) NULL,
	@Description ntext
)
AS
BEGIN
	IF(@Name = NULL)
	Update Talants
	Set T_Description = @Description
	Where ID = @idTalants
	ELSE
	Update Talants
	Set T_Name = @Name, T_Description = @Description
	Where ID = @idTalants
END
GO
CREATE PROCEDURE Update_Race
(
	@idRace int,
	@Name nchar(8) NULL,
	@Description ntext
)
AS
BEGIN
	IF(@Name = null)
	Update Race
	Set @Description = R_History
	Where ID = @idRace
	else
	Update Race
	Set R_Name = @Name, R_History = @Description
	Where ID = @idRace
END
GO
CREATE PROCEDURE Update_Class
(
	@idClass int,
	@Name nchar(8) NULL,
	@Description ntext
)
AS
BEGIN
	IF(@Name = NULL)
	Update Class
	Set C_Description = @Description
	WHERE @idClass = ID
	ELSE
	Update Class
	Set C_Description = @Description, C_Name = @Name
	Where @idClass = ID
END
GO
CREATE PROCEDURE Update_Login
(
	@Login nchar(11),
	@Password varchar(16)
)
AS
BEGIN
	Update Person
	Set P_Password = @Password
	Where @Login = P_Login
END
GO
CREATE PROCEDURE Update_PersonLevel
(
	@idPerson int,
	@lvl tinyint
)
AS
BEGIN
	Update Person
	Set P_Level = @lvl
	Where ID = @idPerson
END
GO
--Create View
Create View InformationPersonAll
AS
SELECT Person.ID AS ID, P_Nickname AS Nickname, P_Login AS [Login], P_Password AS [Password], P_SDVIFL AS Specifications, P_Level AS [Level], C_Name AS Class, R_Name AS Race
From Person  INNER JOIN Class on P_Class = Class.ID INNER JOIN Race on C_Race = Race.ID
GO
--Triggers Pain
CREATE TRIGGER DeletedPersonInformation
ON InformationPersonAll
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @IDPerson int
	DECLARE Cursor_Dead CURSOR FOR
	SELECT ID FROM deleted
	
	OPEN Cursor_Dead

	FETCH NEXT FROM Cursor_Dead 
	INTO @IDPerson

	WHILE @@FETCH_STATUS = 0
	BEGIN
		DELETE FROM Person
		WHERE ID = @IDPerson

		FETCH NEXT FROM Cursor_Dead
		INTO @IDPerson
	END
	CLOSE Cursor_Dead
	DEALLOCATE Cursor_Dead
END
GO
--Create View2
Create View InformationAboutTalantPersonAll
AS
SELECT Person.ID AS IdPerson, T_Name AS [Name], T_Description AS [Description], Talant_Level AS lvl
FROM Person INNER JOIN Person_Talants ON Person.ID = Person_Talants.ID_Person INNER JOIN Talants ON Talants.ID = Person_Talants.ID_Talant
GO
Create Procedure InformationAboutTalantsPerson
(
	@idPerson int
)
AS
SELECT [Name], [Description], lvl
From InformationAboutTalantPersonAll
Where @idPerson = IdPerson
GO
--Create View3
CREATE VIEW InformationAboutItemsPersonAll
AS
SELECT Person.ID AS IdPerson, I_Name AS NameItem, I_Description AS [Description], I_Type AS [Type], I_SDVIFL AS Specification,
Class.C_Name AS Class
FROM Person INNER JOIN Person_Items ON Person.ID = Person_Items.ID_Person INNER JOIN Items ON Items.ID = Person_Items.ID_Person
INNER JOIN Class_Items ON Class_Items.ID_Item = Items.ID INNER JOIN Class ON Class.ID = Class_Items.ID_Class
GO
CREATE PROCEDURE InfromationAboutItemsPerson
(
	@IDPerson INT
)
AS
SELECT NameItem, [Description], [Type], Specification
FROM InformationAboutItemsPersonAll
Where @IDPerson = IdPerson
GO
--Create View4
CREATE VIEW InformationAboutAchivmentsPersonAll
AS
SELECT Person.ID AS IdPerson, A_Name AS [Name], A_Description AS [Description]
FROM Person INNER JOIN Person_Achivments ON Person.ID = ID_Person INNER JOIN Achivments ON Achivments.ID = ID_Achivment
GO
CREATE PROCEDURE InformationAboutAchivmentsPerson
(
	@IDPerson int
)
AS
SELECT [Name], [Description]
FROM InformationAboutAchivmentsPersonAll
WHERE @IDPerson = IdPerson
GO

--I NEED HELP PLS
CREATE TRIGGER Delete_Item
ON Items
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @IDItems INT
	DECLARE Cursor_Dead CURSOR FOR
	SELECT ID FROM deleted

	OPEN Cursor_Dead

	FETCH NEXT FROM Cursor_Dead
	INTO @IDItems

	WHILE @@FETCH_STATUS = 0
	BEGIN
	DECLARE @Nick NVARCHAR(50)
	DECLARE @Name NVARCHAR(50)
		--1 цикл
		DECLARE Cursor_Life	CURSOR FOR
		SELECT P_Nickname, I_Name 
		FROM Person INNER JOIN Person_Items ON Person.ID = ID_Person INNER JOIN Items ON ID_Item = Items.ID
		WHERE Items.ID = @IDItems

		OPEN Cursor_Life
		FETCH NEXT FROM Cursor_Life
		INTO @Nick, @Name

		WHILE @@FETCH_STATUS <> 0
		BEGIN
			PRINT N'Игрок ' + @Nick + N' потерял предмет ' + @Name
			FETCH NEXT FROM Cursor_Life
			INTO @Nick, @Name
		END
		CLOSE Cursor_Life
		DEALLOCATE Cursor_Life
		DELETE
		FROM Person_Items
		WHERE ID_Item = @IDItems

		--2 цикл
		DECLARE Cursor_Life	CURSOR FOR
		SELECT C_Name, I_Name 
		FROM Class INNER JOIN Class_Items ON Class.ID = ID_Class INNER JOIN Items ON ID_Item = Items.ID
		WHERE Items.ID = @IDItems

		OPEN Cursor_Life
		FETCH NEXT FROM Cursor_Life
		INTO @Nick, @Name

		WHILE @@FETCH_STATUS <> 0
		BEGIN
			PRINT N'Класс ' + @Nick + N' больше не имеет предмет ' + @Name
			FETCH NEXT FROM Cursor_Life
			INTO @Nick, @Name
		END
		CLOSE Cursor_Life
		DEALLOCATE Cursor_Life
		DELETE
		FROM Class_Items
		WHERE ID_Item = @IDItems

		--3 цикл
		DECLARE Cursor_Life	CURSOR FOR
		SELECT M_Name, I_Name 
		FROM Monsters INNER JOIN LootMonster ON Monsters.ID = ID_Monster INNER JOIN Items ON ID_Item = Items.ID
		WHERE Items.ID = @IDItems

		OPEN Cursor_Life
		FETCH NEXT FROM Cursor_Life
		INTO @Nick, @Name

		WHILE @@FETCH_STATUS <> 0
		BEGIN
			PRINT N'Монстер ' + @Nick + N' больше не имеет предмет ' + @Name
			FETCH NEXT FROM Cursor_Life
			INTO @Nick, @Name
		END
		CLOSE Cursor_Life
		DEALLOCATE Cursor_Life

		DELETE
		FROM LootMonster
		WHERE ID_Item = @IDItems
	DELETE
	FROM Items
	WHERE ID = @IDItems
	END
	CLOSE Cursor_Dead
	DEALLOCATE Cursor_Dead
END
GO

--Procedurchiki
CREATE PROC Registration
(
	@login nchar(12),
	@password varchar(16),
	@nickname nvarchar(16),
	@nameClass nvarchar(16),
	@admin bit
)
AS
BEGIN
	INSERT INTO Person (P_Login, P_Password, P_Nickname, P_Class, P_Admin)
	VALUES(@login, @password, @nickname, (SELECT ID FROM Class Where C_Name = @nameClass), @admin)
END