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
SELECT NumGr, Quantity FROM Groups
GO

/*3.10*/
SELECT NumGr, COUNT(*) FROM Groups 
JOIN Students ON Groups.IdGroup = Students.GroupId
JOIN Balls ON Balls.NumSt = Students.IdSt
GROUP BY Groups.NumGr
GO

/*3.11*/
SELECT NumGr, COUNT(*) FROM Groups 
JOIN Students ON Groups.IdGroup = Students.GroupId
JOIN Balls ON Balls.NumSt = Students.IdSt
GROUP BY Groups.NumGr HAVING COUNT(*) > 1
GO

/*4.1*/
SELECT Fio
FROM Students
WHERE IdSt IN
(
	SELECT NumSt
	FROM Balls
	WHERE Ball > 2
)
Go

/*4.2*/
SELECT Name
FROM Disciplines
WHERE NumDisc IN
(
	SELECT NumDisc
	FROM Uplans
	WHERE IdDisc IN
	(
		SELECT IdDisc
		FROM Balls
	)
)
GO

/*4.3*/
SELECT Name
FROM Disciplines
WHERE NumDisc IN
(
	SELECT NumDisc
	FROM Uplans
	WHERE NumDir = 1
)
GO

/*4.4*/
SELECT Fio
FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt
GROUP BY Fio
HAVING COUNT(Balls.NumSt) > 1
GO

/*4.5*/
SELECT Fio, Ball
FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt AND Ball = 2
GO

/*4.6*/
SELECT Fio, Ball
FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt AND Ball = 5
GO

/*4.7*/
SELECT NumGr
FROM Groups
WHERE IdGroup IN
(
	SELECT GroupId
	FROM Students
	WHERE IdSt IN
	(
		SELECT NumSt
		FROM Balls
		WHERE IdDisc IN
		(
			SELECT IdDisc
			FROM Uplans
			WHERE NumDisc = 1 AND Semestr = 1
		)
	)
)
GO

SELECT DISTINCT NumGr 
FROM Balls 
JOIN Uplans ON Balls.IdDisc = Uplans.IdDisc
JOIN Students ON Students.IdSt = Balls.NumSt
JOIN Groups ON Groups.IdGroup = Students.GroupId
WHERE NumDisc = 1 AND Semestr = 1
GO

/*4.8*/
SELECT Fio, SUM(Ball)
FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt 
GROUP BY Fio
HAVING SUM(Ball) > 9 
GO

SELECT Fio, SUM(Ball)
FROM Students
JOIN Balls ON Balls.NumSt=Students.IdSt 
GROUP BY Fio
HAVING SUM(Ball) > 9 
GO

/*4.9*/
SELECT Semestr
FROM Uplans
JOIN Balls ON Balls.IdDisc=Uplans.IdDisc
GROUP BY Semestr
HAVING COUNT(Balls.NumSt) > 1
GO

/*4.10*/
SELECT Fio
FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt
GROUP BY Fio
HAVING COUNT(Balls.NumSt) > 1
GO