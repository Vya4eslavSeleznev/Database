USE Session;

/*1*/
CREATE PROCEDURE Count_Students
AS
SELECT COUNT(*) FROM Students

EXEC Count_Students

/*2*/
CREATE PROCEDURE Count_Students_Sem @Count_sem AS INT
AS
SELECT COUNT(Distinct NumSt)
FROM Balls JOIN Uplans ON Uplans.IdDisc=Balls.IdDisc
WHERE Semestr >= @Count_sem;
GO

EXEC Count_Students_Sem 1

DECLARE @kol int;
SET @kol=1;
EXEC Count_Students_Sem @kol;

/*3.1*/
CREATE PROCEDURE List_Students_Dir(@Dir AS INT, @Disc AS VARCHAR(30))
AS
SELECT Distinct Students.FIO
FROM Students
JOIN Groups ON Students.GroupId = Groups.IdGroup
JOIN Balls ON Students.IdSt=Balls.NumSt
JOIN Uplans ON Uplans.IdDisc=Balls.IdDisc
WHERE Groups.NumDir=@Dir and NumDisc =
(
	SELECT NumDisc
	FROM Disciplines
	WHERE Name = @Disc
);
GO

EXEC List_Students_Dir 1, 'Физика'

DECLARE @dir int, @title varchar(30);
SET @dir = 1;
SET @title ='Физика';
EXEC List_Students_Dir @dir, @title;

/*3.2*/
CREATE PROCEDURE Enter_Students(@Fio AS VARCHAR(30), @Group AS VARCHAR(10)) 
AS
INSERT INTO Students (FIO, GroupId) VALUES (@Fio, @Group);
GO

DECLARE @Stud VARCHAR(30), @Group int;
SET @Stud='Петров Петр';
SET @Group = 1;
EXEC Enter_Students  @Stud, @Group;

/*4*/
CREATE PROCEDURE Next_Course (@Group AS VARCHAR(10)='13504/1')
AS
UPDATE Groups SET NumGr=CONVERT(char(1),CONVERT(int, LEFT(NumGr,1))+1)+ SUBSTRING(NumGr,2,LEN(NumGr)-1)
 WHERE NumGr=@Group;
GO

DECLARE @Group VARCHAR(10);
SET @Group='23504/2';
EXEC Next_Course @Group;
GO

EXEC Next_Course;
GO

/*Task*/
--Напишите процедуру, которая будет возвращать старые номера групп обратно.
CREATE PROCEDURE Previous_Course(@Group AS VARCHAR(10)='13504/1')
AS
UPDATE Groups SET NumGr=CONVERT(char(1),CONVERT(int, LEFT(NumGr,1))-1)+ SUBSTRING(NumGr,2,LEN(NumGr)+1)
WHERE NumGr=@Group;
GO

DECLARE @Group VARCHAR(10);
SET @Group='23504/1';
EXEC Previous_Course @Group;
GO

EXEC Previous_Course;
GO

/*5*/
CREATE PROCEDURE Number_Groups (@Dir AS int, @Number AS int OUTPUT)
AS
SELECT @Number =COUNT(NumGr) FROM Groups WHERE NumDir=@Dir;
GO

DECLARE @Group int;
EXEC Number_Groups 2, @Group OUTPUT;
SELECT @Group;
GO

/*6*/
CREATE PROCEDURE Delete_Students_Complete
AS
INSERT INTO ArchiveStudents
SELECT YEAR(GETDATE()), IdSt, FIO, GroupId 
FROM Students
WHERE LEFT(GroupId,1)=6;
DELETE FROM Students WHERE LEFT(GroupId,1)=6;
GO

CREATE PROCEDURE Next_Course_2 
AS
EXEC Delete_Students_Complete;
UPDATE Groups SET NumGr=CONVERT(char(1),CONVERT(int, LEFT(NumGr,1))+1)+ SUBSTRING(NumGr,2,LEN(NumGr)-1)
WHERE IdGroup IN
(
	SELECT IdGroup
	FROM Students_complete_2
);
GO

EXEC Next_Course_2;
GO

/*Task*/
--Напишите обратную процедуру восстановления
--студентов из архивной таблицы в основную
CREATE PROCEDURE Delete_From_Archive
AS
SET IDENTITY_INSERT dbo.Students ON;
INSERT INTO Students (IdSt, Fio, GroupId)
SELECT NumSt, Fio, NumGr 
FROM ArchiveStudents
WHERE LEFT(NumGr,1)=6;
DELETE FROM ArchiveStudents
WHERE LEFT(NumGr,1)=6;
SET IDENTITY_INSERT dbo.Students OFF;
GO

CREATE PROCEDURE Previous_Course_2 
AS
EXEC Delete_From_Archive;
UPDATE Groups SET NumGr=CONVERT(char(1),CONVERT(int, LEFT(NumGr,1))-1)+ SUBSTRING(NumGr,2,LEN(NumGr)+1)
WHERE IdGroup IN
(
	SELECT IdGroup
	FROM Students_complete_2
);
GO

EXEC Previous_Course_2;
GO