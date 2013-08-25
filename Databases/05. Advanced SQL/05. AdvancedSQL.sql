-- Task 1
SELECT FirstName + ' '  + LastName AS Employee, Salary   
FROM Employees 
WHERE Salary = 
	(SELECT MIN(Salary)
	 FROM Employees)

-- Task 2
SELECT FirstName + ' ' + LastName AS Employee, Salary
FROM Employees
WHERE Salary <= 1.1* 
    (SELECT MIN(Salary) FROM Employees)

-- Task 3
SELECT e.LastName, Salary, d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = ( SELECT MIN(Salary) 
				 FROM Employees
				 WHERE e.DepartmentID = DepartmentID)

-- Task 4
SELECT AVG(Salary) 
FROM Employees
WHERE DepartmentID = 1

-- Task 5
SELECT AVG(Salary)
FROM Employees e
WHERE e.DepartmentID = 
	(SELECT DepartmentID 
	 FROM Departments 
	 WHERE Name = 'Sales')

-- Task 6
SELECT COUNT(EmployeeID)
FROM Employees e
WHERE e.DepartmentID = 
	(SELECT DepartmentID 
	 FROM Departments 
	 WHERE Name = 'Sales')

-- Task 7
SELECT COUNT(ManagerID)
FROM Employees

-- Task 8
SELECT Count(EmployeeID)
FROM Employees
WHERE ManagerID IS NULL

-- Task 9
SELECT AVG(e.Salary), d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name

-- Task 10
SELECT d.Name As Department, t.Name as Town, COUNT(e.EmployeeID)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses ad
ON e.AddressID = ad.AddressID
JOIN Towns t
ON ad.TownID = t.TownID
GROUP BY d.Name, t.Name 

-- Task 11
SELECT m.FirstName + ' ' + m.LastName AS [Manager Name], COUNT(e.EmployeeID) AS [Number of subordinates]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
GROUP BY e.ManagerID, m.FirstName, m.LastName
HAVING  COUNT(e.EmployeeID) = 5


-- Task 12
SELECT e.FirstName + ' ' +e.LastName AS [Employee],
	 ISNULL ( m.FirstName + ' ' + m.LastName, '(no manager)' ) AS [Manager]
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID


-- Task 13
SELECT FirstName, LastName, LEN(LastName) AS [Last Name Length]
FROM Employees
WHERE 5 = LEN(LastName)

-- Task 14
SELECT convert(varchar, getdate(), 104) + ' ' + convert(varchar, getdate(), 114)

-- Task 15
-- I have forgotten to create the password column and added it later in Task 23.
CREATE TABLE Users (
  UserID int IDENTITY PRIMARY KEY,
  UserName nvarchar(100) NOT NULL,
  FullName nvarChar(100), 
  LastLogin DATETIME NOT NULL,
  CONSTRAINT uc_UserName UNIQUE (UserName)
)

-- Task 16
CREATE VIEW [Active Today] AS
SELECT * FROM Users
WHERE Convert(varchar(10),LastLogin,120) = CONVERT(varchar(10),GETDATE(),120)

SELECT *
FROM [Active Today]

-- Task 17
CREATE TABLE Groups (
  GroupID int IDENTITY PRIMARY KEY,
  GroupName nvarchar(100) NOT NULL,
  CONSTRAINT uc_GroupName UNIQUE (GroupName)
)

-- Task 18
ALTER TABLE Users ADD GroupID int

INSERT INTO Groups (GroupName) VALUES ('Admin');
INSERT INTO Groups (GroupName) VALUES ('Owner');
INSERT INTO Groups (GroupName) VALUES ('User');

UPDATE Users SET GroupID = 1 WHERE UserID= 1;
UPDATE Users SET GroupID = 2 WHERE UserID= 2;
UPDATE Users SET GroupID = 3 WHERE UserID= 3;


ALTER TABLE Users
ADD CONSTRAINT FK_GroupID_GroupID
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)

-- Task 19

INSERT INTO Groups (GroupName) VALUES ('PowerUser');
Insert INTO Users(UserName, FullName, LastLogin, GroupID) 
VALUES ('PowerUser', 'Power User', getdate(), 4)

-- Task 20
UPDATE Groups SET GroupName = 'Trooper' WHERE GroupID = 3;
UPDATE Users SET FullName = 'Power Spiro' WHERE UserID= 4;

-- Task 21
DELETE 
FROM Users
WHERE UserId = 4

DELETE 
FROM Groups
WHERE GroupID = 4

-- Task 22
Insert INTO Users(UserName, FullName, LastLogin, GroupID) 
SELECT LOWER(SUBSTRING(FirstName, 1, 3) + LastName) AS UserName,
	   FirstName + ' ' + LastName AS FullName,
	   GETDATE(), 
	   3	   
FROM Employees

-- Task 23
ALTER TABLE Users ADD Password nvarchar(30)
ALTER TABLE Users
WITH CHECK ADD CONSTRAINT [CK_MinimumLength]
CHECK ((len(ltrim(rtrim(Password)))>(8)))

UPDATE Users SET Password = 'NewPassword12345' WHERE LastLogin <= '2015-01-01'

-- Task 24
DELETE 
FROM Users
WHERE Password IS NULL

-- Task 25
SELECT d.Name, e.JobTitle,  AVG(Salary) AS [Averadge Salary]
FROM Employees e 
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, JobTitle, d.Name

-- Task 26
SELECT d.Name, e.JobTitle, e.LastName,  MIN(Salary) AS [Minimal Salary]
FROM Employees e 
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, JobTitle, d.Name, e.LastName

-- Task 27
SELECT TOP 1 t.Name, Count(e.EmployeeID) cnt
FROM Employees e
JOIN Addresses ad
ON e.AddressID = ad.AddressID
JOIN Towns t
On ad.TownID = t.TownID 
GROUP BY ad.TownID, t.Name
ORDER BY Count(e.EmployeeID) DESC

-- Task 28
SELECT t.Name, COUNT(m.EmployeeID)
FROM Employees m 
JOIN Addresses adr
ON m.AddressID = adr.AddressID
JOIN Towns t
on adr.TownID = t.TownID
WHERE EXISTS  (
	SELECT e.ManagerID
	FROM Employees e
	GROUP BY e.ManagerID
	HAVING m.EmployeeID = e.ManagerID
)
GROUP BY adr.TownID, t.Name

-- Task 29
CREATE TABLE WorkHours (
  WorkHourID int IDENTITY PRIMARY KEY,
  [Date] DATETIME,
  Task nvarchar(100),
  [Hours] int,
  EmployeeID int
  CONSTRAINT FK_EmployeeID_EmployeeID
	  FOREIGN KEY (EmployeeID)
	  REFERENCES Employees(EmployeeID)
)

Insert INTO WorkHours([Date], Task, [Hours], EmployeeID) 
VALUES (GETDATE(), 'Learn SQL Server', 3, 7)

Insert INTO WorkHours([Date], Task, [Hours], EmployeeID) 
VALUES (GETDATE(), 'Test', 9, 159)

UPDATE WorkHours SET [Hours] = 3 WHERE Task = 'Design Nuclear Plant' AND WorkHourID = 2;

DELETE
FROM WorkHours
WHERE EmployeeID = 159


CREATE TABLE WorkHoursLogs (
  WorkHourLogID int IDENTITY PRIMARY KEY,
  [Date] DATETIME,
  Change nvarChar(100)
)
GO

CREATE TRIGGER WorkHourAfterInsert ON WorkHours
FOR INSERT
AS
BEGIN
	DECLARE @EntryID int;
	DECLARE @ChangeTime DATETIME;
	DECLARE @ChangeMessage NVARCHAR(30);

	SELECT @EntryID = i.WorkHourID FROM inserted i
	SET @ChangeTime = GETDATE();
	SET @ChangeMessage = 'Task Inserted - taskId: ' + CAST(@EntryID AS nvarchar);

	Insert INTO WorkHoursLogs([Date], Change) 
	VALUES (@ChangeTime, @ChangeMessage)
END
GO 

-- Task 31
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

SELECT *
FROM EmployeesProjects