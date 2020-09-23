USE Session;

/*3.1*/
SELECT Uplans.NumDir
FROM Balls
JOIN Uplans ON Balls.IdDisc = Uplans.IdDisc
WHERE Balls.Ball >= 3
GROUP BY Uplans.NumDir
HAVING COUNT(Balls.NumSt) >= 1

/*3.2*/
SELECT Name
FROM Disciplines
JOIN Uplans ON Disciplines.NumDisc = Uplans.NumDisc
WHERE Semestr = 1
GO

/*3.3*/
SELECT GroupId
FROM Students
WHERE IdSt IN
(
	SELECT IdSt
	FROM Students 
	INTERSECT 
	Select NumSt
	FROM Balls
)
GO

/*3.4*/
SELECT DISTINCT Disciplines.Name, Balls.NumSt
FROM Disciplines
JOIN Uplans ON Disciplines.NumDisc = Uplans.NumDisc
JOIN Balls ON Uplans.IdDisc = Balls.IdDisc
WHERE Ball >= 3
GO

/*3.5*/
SELECT Groups.NumGr
FROM Students
JOIN Groups ON Students.GroupId = Groups.IdGroup
GROUP BY Groups.NumGr, Groups.Quantity
HAVING COUNT(Students.IdSt) < Groups.Quantity
GO

/*3.6*/
SELECT GroupId
FROM Students
JOIN Balls ON Students.GroupId = Balls.NumSt
WHERE Balls.Ball > 2
GROUP BY Students.GroupId
HAVING COUNT(Students.IdSt) > 1 
UNION SELECT IdSt
FROM Students
EXCEPT 
SELECT NumSt
FROM Balls
GO

/*3.7*/
SELECT DISTINCT Name
FROM Disciplines
JOIN Uplans ON Disciplines.NumDisc = Uplans.NumDisc
WHERE Semestr <= 2
GO

/*3.8*/
SELECT DISTINCT Fio
FROM Students
JOIN 
(
	SELECT IdGroup
	FROM Groups
	WHERE IdGroup % 2 = 0
)
AS t ON Students.GroupId <> t.IdGroup
GO

/*3.9*/
SELECT Fio
FROM Balls
RIGHT JOIN Students ON Students.IdSt = Balls.NumSt
WHERE NumSt IS  NULL
GO

/*3.10*/
SELECT Title, COUNT(*)
FROM Directions
JOIN Uplans On Directions.IdDir = Uplans.NumDir
GROUP BY Title
GO

/*4.1*/
SELECT DISTINCT IdSt
FROM Students
WHERE EXISTS
(
	SELECT Balls.IdDisc
	FROM Balls
	WHERE Balls.NumSt = Students.IdSt AND Balls.Ball >= 3
	GROUP BY Balls.IdDisc
	HAVING COUNT(Balls.IdDisc) = 1
)
GO

/*4.2*/
SELECT IdSt
FROM Students
EXCEPT 
SELECT NumSt
FROM Balls
GO

SELECT DISTINCT IdSt
FROM Students
WHERE EXISTS
(
	SELECT DISTINCT Balls.NumSt
	FROM Balls
	WHERE Balls.Ball <= 2 AND Students.IdSt = Balls.NumSt
)

/*4.3*/
SELECT DISTINCT NumGr
FROM Groups
WHERE EXISTS
(
	SELECT Students.IdSt
	FROM Students
	EXCEPT
	SELECT Balls.NumSt
	FROM Balls
	WHERE Balls.Ball <= 2 OR Balls.Ball IS NULL AND
	EXISTS 
	(
		SELECT *
		FROM Uplans
		WHERE Uplans.Semestr = 1 AND ( Balls.IdDisc = Uplans.IdDisc or Balls.IdDisc IS NULL)
	)
)

/*4.4*/
SELECT NumGr
FROM Groups
WHERE EXISTS
(
	SELECT IdSt
	FROM Students
	EXCEPT
	SELECT NumSt
	FROM Balls
	WHERE Ball IS NULL
)
GO

/*4.5*/
SELECT Name
FROM Disciplines
WHERE NOT EXISTS
(
	SELECT *
	FROM Uplans
	WHERE NumDir = 1 AND NumDisc = Disciplines.NumDisc
)
GO

/*4.6*/
SELECT DISTINCT Name
FROM Disciplines
JOIN Uplans ON Disciplines.NumDisc = Uplans.NumDisc
WHERE NOT EXISTS
(
	SELECT *
	FROM Balls
	WHERE NumDir = 1 AND IdDisc = Uplans.IdDisc
)
GO

/*4.7*/
SELECT NumGr
FROM Groups
JOIN Uplans ON Groups.NumDir = Uplans.NumDir
WHERE EXISTS
(
	SELECT *
	FROM Balls
	WHERE NumDisc = 1 AND IdDisc = Uplans.IdDisc
)
GO

/*4.8*/
SELECT Groups.NumGr
FROM Groups
WHERE EXISTS
(
	SELECT 1
	FROM Students
	JOIN Balls ON Students.IdSt = Balls.NumSt
	JOIN Uplans ON Balls.IdDisc = Uplans.IdDisc
	WHERE Uplans.Semestr = 1 AND Students.GroupId = Groups.IdGroup
	GROUP BY Students.IdSt HAVING COUNT(*) = 
	(
		SELECT COUNT(DISTINCT Disciplines.NumDisc)
		FROM Disciplines
		JOIN Uplans ON Disciplines.NumDisc = Uplans.NumDisc
		WHERE Semestr = 1
	)
)
GO

/*4.9*/
SELECT Fio
FROM Students
WHERE NOT EXISTS
(
	SELECT *
	FROM Balls
	WHERE Balls.Ball <= 3 and Students.IdSt = Balls.NumSt
) AND EXISTS
(
	SELECT *
	FROM Balls
	WHERE Students.IdSt = Balls.NumSt
)
GO

/*4.9 (4.10)*/
SELECT Fio, COUNT(*)
FROM Students
JOIN Balls ON Students.IdSt = Balls.NumSt
GROUP BY Students.Fio
ORDER BY COUNT(*) DESC
GO