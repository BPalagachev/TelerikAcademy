Use TelerikAcademy
-- Task 4
SELECT *
 FROM Departments

-- Task 5
SELECT Name 
FROM Departments

-- Task 6
SELECT Salary 
FROM Employees

-- Task 7
SELECT FirstName + ' ' + LastName as FullName
FROM Employees

-- Task 8
SELECT FirstName + '.' + LastName + '@telerik.com' as [Full Email Addresses]
 FROM Employees

 -- Task 9
SELECT DISTINCT Salary 
FROM Employees 
ORDER BY Salary


-- Task 10
SELECT * 
FROM Employees 
WHERE JobTitle = 'Sales Representative'

-- Task 11
SELECT FirstName + ' ' + LastName as Name
FROM Employees 
WHERE FirstName  LIKE 'SA%' 

-- Task 12
SELECT FirstName + ' ' + LastName as Name 
FROM Employees
WHERE LastName LIKE '%ei%'

-- Task 13
SELECT Salary 
FROM Employees
where Salary BETWEEN 20000 and 30000

-- Task 14
SELECT FirstName + ' ' + LastName as Name FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

-- Task 15
SELECT *
FROM Employees
WHERE ManagerID is NULL

-- Task 16
SELECT * FROM Employees
WHERE Salary >= 50000 
ORDER BY Salary DESC 

-- Task 17
SELECT TOP 5 FirstName + ' ' + LastName as [Top Best Paid], Salary
FROM Employees
ORDER BY Salary DESC

-- Task 18
SELECT e.FirstName + ' ' + e.LastName as [Full Name], a.AddressText
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID

-- Task 19
SELECT e.FirstName + ' ' + e.LastName as [Full Name], a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

-- Task 20
SELECT e.LastName, e.ManagerID, m.LastName, m.EmployeeID
FROM Employees e
	LEFT JOIN Employees m 
	ON e.ManagerID = m.EmployeeID

-- Task 21
SELECT e.LastName, e.ManagerID, e.AddressID, m.LastName, m.EmployeeID, a.AddressText, a.AddressID
	FROM Employees e
	LEFT JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	LEFT JOIN Addresses a
	On e.AddressID = a.AddressID

-- Task 22
SELECT Name AS Name FROM Departments
UNION
SELECT Name AS Name FROM Towns
UNION
SELECT Name AS Name FROM Projects

-- Task 23
SELECT  e.LastName, e.ManagerID, m.LastName, m.EmployeeID
FROM Employees m 
RIGHT JOIN Employees e
ON e.ManagerID = m.EmployeeID

SELECT e.LastName, e.ManagerID, m.LastName, m.EmployeeID
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- Task 24
SELECT e.FirstName + ' ' + e.LastName AS [Emlployee Name], d.Name AS [Department], e.HireDate
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate >= '1995-01-01' AND 
	  e.HireDate <= '2002-01-01' AND
	  d.Name IN( 'Sales', 'Finance')

