/*4.1*/
SELECT Fio FROM Students
WHERE IdSt IN
(
	SELECT NumSt FROM Balls WHERE Ball > 2
)
Go

/*4.2*/
SELECT Name FROM Disciplines
WHERE NumDisc IN
(
	SELECT IdDisc FROM Balls 
)
GO

/*4.3?*/
SELECT Name FROM Disciplines
WHERE NumDisc IN
(
	SELECT NumDisc FROM Uplans WHERE NumDir = 1
)
GO

/*4.4*/
SELECT Fio FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt
GROUP BY Fio
HAVING COUNT(Balls.NumSt)>1
GO

/*4.5*/
SELECT Fio, Ball FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt AND Ball=3
GO

/*4.6*/
SELECT Fio, Ball FROM Students, Balls
WHERE Balls.NumSt=Students.IdSt AND Ball=5
GO

/*4.7*/

/*4.8*/

/*4.9*/

/*4.10*/