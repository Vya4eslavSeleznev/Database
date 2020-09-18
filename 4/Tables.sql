USE Session;
CREATE TABLE Disciplines
(
	NumDisc int IDENTITY (1,1) PRIMARY KEY,
	NameDisc varchar(50)
)
GO
CREATE TABLE Uplanes
(
	NumPlan int IDENTITY (1,1) PRIMARY KEY,
	NumDisc int FOREIGN KEY REFERENCES Disciplines
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	NamePlan varchar(50)
)
GO
CREATE TABLE Groups
(
	NumGroup int IDENTITY(1,1) PRIMARY KEY,
	NumPlan int FOREIGN KEY REFERENCES Uplanes
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	NumSt int,
	Quantity int CHECK (Quantity BETWEEN 0 AND 20)
)
GO
CREATE TABLE Students
(
	NumSt int IDENTITY (1,1) PRIMARY KEY,
	Fio varchar(50),
	NumGroup int FOREIGN KEY REFERENCES Groups
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
GO
CREATE TABLE Directions
(
	NumDir int IDENTITY (1,1) PRIMARY KEY,
	NumSt int FOREIGN KEY REFERENCES Students
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	NameDir varchar(50)
)
GO
CREATE TABLE Balls
(
	NumBall int IDENTITY (1,1) PRIMARY KEY,
	NumSt int FOREIGN KEY REFERENCES Students
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	Ball int CHECK (Ball BETWEEN 2 AND 5)
)
GO
