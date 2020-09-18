USE Session;

/*3.1*/
SELECT Title FROM Directions
GO

/*3.2*/
SELECT IdGroup FROM Groups
GO

/*3.3*/
SELECT Fio FROM Students
GO

/*3.4*/
SELECT NumSt FROM Balls
GO

/*3.5*/
SELECT DISTINCT NumDir FROM Uplans
Go

SELECT NumDir FROM Uplans
Go

/*3.6*/
SELECT DISTINCT NumDir FROM Uplans
Go

/*3.7*/
SELECT Fio FROM Students WHERE GroupId = 1
GO 

/*3.8*/
SELECT Name FROM Disciplines
WHERE NumDisc IN
(
	SELECT NumDisc FROM Uplans WHERE NumDir = 2
	AND Semestr = 1
)
GO

/*3.9*/