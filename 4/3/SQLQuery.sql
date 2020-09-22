USE Session;

/*3.1*/
SELECT NumDisc FROM Uplans WHERE Semestr = 1
GO


/*3.3*/
SELECT GroupId FROM Students
WHERE IdSt IN
(
	SELECT IdSt FROM Students 
	INTERSECT 
	Select NumSt FROM Balls
)
GO