USE Session;
CREATE TABLE Disciplines
(
	NumDisc int IDENTITY (1,1) PRIMARY KEY,
	Name varchar(50)
)
CREATE TABLE Directions
(
	IdDir int IDENTITY (1,1) PRIMARY KEY,
	NumDir int,
	Title varchar(50),
	Quantity int
)
CREATE TABLE Uplans
(
	IdDisc int IDENTITY (1,1) PRIMARY KEY,
	NumDir int FOREIGN KEY REFERENCES Directions (IdDir)
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	NumDisc int FOREIGN KEY REFERENCES Disciplines (NumDisc)
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	Semestr int
)

CREATE TABLE Groups
(
	IdGroup INT IDENTITY(1, 1) PRIMARY KEY,
	NumGr varchar(50),
	NumDir int FOREIGN KEY REFERENCES Directions (IdDir)
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	/*NumSt int FOREIGN KEY REFERENCES Students (IdSt)
	ON DELETE SET NULL
	ON UPDATE CASCADE,*/
	Quantity int CHECK (Quantity BETWEEN 0 AND 20)
)

CREATE TABLE Students
(
	IdSt int IDENTITY (1,1) PRIMARY KEY,
	Fio varchar(50),
	GroupId int /*FOREIGN KEY*/ REFERENCES Groups (IdGroup)
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
	
CREATE TABLE Balls
(
	IdBall int IDENTITY (1,1) PRIMARY KEY,
	IdDisc int FOREIGN KEY REFERENCES Disciplines (NumDisc)
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	NumSt int FOREIGN KEY REFERENCES Students (IdSt)
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	Ball int CHECK (Ball BETWEEN 2 AND 5),
	DateEx datetime
)
GO
