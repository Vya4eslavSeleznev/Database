USE Session;

/*3.1*/
SELECT Uplans.NumDir FROM Balls
INNER JOIN Uplans ON Balls.IdDisc = Uplans.IdDisc
WHERE Balls.Ball >= 3 GROUP BY Uplans.NumDir
HAVING count(Balls.NumSt) >= 1






SELECT DISTINCT Disciplines.NumDisc FROM Uplans inner join Disciplines ON Uplans.NumDisc = Disciplines.NumDisc WHERE Uplans.Semestr = '1'							--3.2
SELECT Students.NumGr FROM Students inner join Balls ON Students.NumSt = Balls.NumSt WHERE Balls.Ball > 2 GROUP BY Students.NumGr HAVING count(Students.NumSt) > 0  --3.3
SELECT Disciplines.Name, Balls.NumSt FROM Balls inner join Disciplines ON Balls.IdDisc = Disciplines.NumDisc WHERE Balls.Ball >= 3									--3.4
SELECT Groups.NumGr FROM Students inner join Groups ON Students.NumGr = Groups.NumGr GROUP BY Groups.NumGr, Groups.Quantity HAVING count(Students.NumSt) < Groups.Quantity --3.5

SELECT Students.NumGr FROM Students inner join Balls ON Students.NumSt = Balls.NumSt WHERE Balls.Ball > 2 GROUP BY Students.NumGr HAVING count(Students.NumSt) > 1 
	UNION SELECT Students.NumSt FROM Students EXCEPT 
		SELECT Balls.NumSt from Balls --3.6

SELECT Disciplines.Name FROM Disciplines inner join Uplans ON Uplans.NumDisc = Disciplines.NumDisc WHERE Uplans.Semestr = 1 OR Uplans.Semestr = 2 GROUP BY Disciplines.Name HAVING count(Disciplines.Name) >= 2 --3.7

SELECT Students.NumSt FROM Students right join Balls ON Students.NumSt = Balls.NumSt AND Balls.Ball > 2 --3.9
SELECT Students.NumSt, Balls.Ball FROM Balls right join Students ON Students.NumSt = Balls.NumSt 
SELECT Students.NumSt FROM Students inner join Balls ON Students.NumSt = Balls.NumSt WHERE EXISTS (SELECT Balls.IdDisc FROM Balls WHERE Balls.Ball > 2) --3.10

--4--
SELECT DISTINCT Students.NumSt FROM Students WHERE EXISTS (SELECT Balls.IdDisc FROM Balls WHERE Balls.NumSt = Students.NumSt AND Balls.Ball >= 3 GROUP BY Balls.IdDisc HAVING count(Balls.IdDisc) = 1) --4.1
SELECT DISTINCT Students.NumSt FROM Students WHERE EXISTS (SELECT DISTINCT Balls.NumSt FROM Balls WHERE Balls.Ball <= 2 AND Students.NumSt = Balls.NumSt) --4.2

SELECT DISTINCT Groups.NumGr FROM Groups  WHERE EXISTS (SELECT Students.NumSt FROM Students --4.3
	EXCEPT SELECT Balls.NumSt FROM Balls WHERE Balls.Ball <= 2 OR Balls.Ball IS NULL AND EXISTS 
		(SELECT * FROM Uplans WHERE Uplans.Semestr = 1 AND ( Balls.IdDisc = Uplans.IdDisc or Balls.IdDisc IS NULL)))


SELECT DISTINCT Groups.NumGr FROM Groups WHERE EXISTS  --4.4
	(SELECT Students.NumGr FROM Balls right join Students ON Students.NumSt = Balls.NumSt WHERE (Balls.Ball < 3 or Balls.Ball is null))

SELECT Disciplines.Name FROM Disciplines WHERE not exists(SELECT * FROM Uplans WHERE Uplans.NumDir = 231000 and Disciplines.NumDisc = Uplans.NumDisc) --4.5


SELECT Disciplines.Name FROM Disciplines WHERE not exists(SELECT * FROM Uplans WHERE exists
	(SELECT * FROM Balls WHERE Balls.Ball >= 3 and Balls.IdDisc = Uplans.IdDisc) and Uplans.NumDir = 231000 and Disciplines.NumDisc = Uplans.NumDisc) --4.6

SELECT DISTINCT Groups.NumGr FROM Groups WHERE not exists  --4.7
	(SELECT * FROM Balls join Students ON Balls.NumSt = Students.NumSt WHERE Balls.Ball < 3 and exists 
		(SELECT * FROM Uplans join Disciplines ON Disciplines.NumDisc = Uplans.NumDisc WHERE Disciplines.Name = 'Физика' and Balls.IdDisc = Uplans.IdDisc) and Students.NumGr = Groups.NumGr)

SELECT Groups.NumGr FROM Groups WHERE not exists --4.8
	(SELECT * FROM Balls join Students ON Students.NumSt = Balls.NumSt WHERE exists
	( SELECT * FROM Uplans WHERE Uplans.Semestr = 1 and Balls.IdDisc = Uplans.IdDisc) and Balls.Ball < 3 and Groups.NumGr = Students.NumGr)

SELECT Students.Fio FROM Students WHERE not exists
	(SELECT * FROM Balls WHERE Balls.Ball <= 3 and Students.NumSt = Balls.NumSt) --4.9

SELECT Balls.NumSt FROM Balls WHERE Balls.Ball >= 3 GROUP BY Balls.NumSt HAVING count(Balls.Ball) = --4.9(2)
	(SELECT max(examTable.pass) FROM 
		(SELECT count(Balls.Ball) as pass FROM Balls WHERE Balls.Ball >= 3 GROUP BY Balls.NumSt) as examTable)
