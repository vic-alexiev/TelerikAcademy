/*1.
Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
Use a nested SELECT statement.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName],
	   Emp.Salary
  FROM Employees AS Emp
 WHERE Emp.Salary =
(SELECT MIN(Employees.Salary) AS Salary
  FROM Employees)

/*2.
Write a SQL query to find the names and salaries of the employees that have a salary 
that is up to 10% higher than the minimal salary for the company.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName],
	   Emp.Salary
  FROM Employees AS Emp
 WHERE Emp.Salary <=
(SELECT MIN(Employees.Salary) * 1.1 AS Salary
  FROM Employees) 
  
/*3.
Write a SQL query to find the full name, salary and department of the employees that take 
the minimal salary in their department. Use a nested SELECT statement.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName],
	   Emp.Salary,
	   Dep.Name
  FROM Employees AS Emp
  JOIN Departments AS Dep
    ON Emp.DepartmentID = Dep.DepartmentID
 WHERE Emp.Salary =
(SELECT MIN(Employees.Salary) AS Salary
  FROM Employees
 WHERE Employees.DepartmentID = Dep.DepartmentID) 
 ORDER BY Dep.Name
 
 /*4.
 Write a SQL query to find the average salary in the department #1.
 */
SELECT AVG(Employees.Salary),
	   Departments.Name
  FROM Employees 
  JOIN Departments
    ON Employees.DepartmentID = Departments.DepartmentID
 WHERE Departments.DepartmentID = 1
 GROUP BY Departments.Name
 
 /*5.
 Write a SQL query to find the average salary in the "Sales" department.
 */
SELECT AVG(Employees.Salary),
	   Departments.Name
  FROM Employees 
  JOIN Departments
    ON Employees.DepartmentID = Departments.DepartmentID
 WHERE Departments.Name = 'Sales'
 GROUP BY Departments.Name
 
 /*6.
 Write a SQL query to find the number of employees in the "Sales" department.
 */
SELECT COUNT(*) AS Staff,
	   Departments.Name
  FROM Employees 
  JOIN Departments
    ON Employees.DepartmentID = Departments.DepartmentID
 WHERE Departments.Name = 'Sales'
 GROUP BY Departments.Name
 
/*7.
Write a SQL query to find the number of all employees that have manager.
*/
SELECT COUNT(*) AS [Employees With Manager]
  FROM Employees
 WHERE Employees.ManagerID IS NOT NULL
 
/*8.
Write a SQL query to find the number of all employees that have no manager.
*/
SELECT COUNT(*) AS [Employees With No Manager]
  FROM Employees
 WHERE Employees.ManagerID IS NULL
 
/*9.
Write a SQL query to find all departments and the average salary for each of them.
*/
SELECT AVG(Employees.Salary),
	   Departments.Name
  FROM Employees 
  JOIN Departments
    ON Employees.DepartmentID = Departments.DepartmentID
 GROUP BY Departments.Name
 
 /*10.
 Write a SQL query to find the count of all employees in each department and for each town.
 */
 SELECT COUNT(Emp.EmployeeID) AS [EmployeesCount],
	   Dep.Name,
	   Towns.Name
  FROM Employees AS Emp
  JOIN Departments AS Dep
    ON Emp.DepartmentID = Dep.DepartmentID
  JOIN Addresses AS Addr
    ON Addr.AddressID = Emp.AddressID
  JOIN Towns 
    ON Towns.TownID = Addr.TownID
 GROUP BY Dep.Name, Towns.Name
 ORDER BY Dep.Name
 
/*11.
Write a SQL query to find all managers that have exactly 5 employees. 
Display their first name and last name.
*/
SELECT * FROM
(SELECT Mngr.FirstName + ' ' + Mngr.LastName AS [ManagerName],
        COUNT(Emp.EmployeeID) AS [EmployeesCount] 
   FROM Employees AS Mngr
   JOIN Employees AS Emp
     ON Mngr.EmployeeID = Emp.ManagerID
  GROUP BY Mngr.FirstName, Mngr.LastName) AS Managers
  WHERE Managers.EmployeesCount = 5
  
  ----------------------------------------------------------
  
 SELECT Mngr.FirstName + ' ' + Mngr.LastName AS [ManagerName],
        COUNT(Emp.EmployeeID) AS [EmployeesCount] 
   FROM Employees AS Mngr
   JOIN Employees AS Emp
     ON Mngr.EmployeeID = Emp.ManagerID
  GROUP BY Mngr.FirstName, Mngr.LastName
 HAVING COUNT(Emp.EmployeeID) = 5
 
 ----------------------------------------------------------
 
SELECT Mngr.FirstName + ' ' + Mngr.LastName AS [ManagerName],
       COUNT(*) AS [EmployeesCount] 
  FROM Employees AS Mngr
  JOIN Employees AS Emp
    ON Mngr.EmployeeID = Emp.ManagerID
 GROUP BY Mngr.FirstName, Mngr.LastName
HAVING COUNT(*) = 5
 
/*12.
Write a SQL query to find all employees along with their managers. 
For employees that do not have manager display the value "(no manager)".
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName], 
	   ISNULL(Mngr.FirstName + ' ' + Mngr.LastName, '(no manager)') AS [ManagerName] 
  FROM Employees AS Mngr
 RIGHT JOIN Employees AS Emp
    ON Emp.ManagerID = Mngr.EmployeeID
 ORDER BY Mngr.EmployeeID
 
/*13.
Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
Use the built-in LEN(str) function.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName]
  FROM Employees AS Emp
 WHERE LEN(Emp.LastName) = 5
 
 /*14.
 Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 
 Search in Google to find how to format dates in SQL Server.
 */
 SELECT CONVERT(varchar, GETDATE(), 104) + ' ' + CONVERT(varchar, GETDATE(), 114)
 
 /*15.
 Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
 Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
 Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
 Define a check constraint to ensure the password is at least 5 characters long.
 */
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY,
	[Username] [nvarchar](30) NOT NULL,
	[FullName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[LastLoginTime] [datetime] NULL,
	CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
	CONSTRAINT [UC_Users] UNIQUE NONCLUSTERED ([Username]),
	CONSTRAINT [CC_Users] CHECK ((LEN([Password]) >= 5))
)
GO

/*16.
Write a SQL statement to create a view that displays the users from the Users table 
that have been in the system today. Test if the view works correctly.
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RecentUsers]') and OBJECTPROPERTY(id, N'IsView') = 1)
  drop view [dbo].[RecentUsers]
GO

SET QUOTED_IDENTIFIER ON 
GO
CREATE VIEW dbo.RecentUsers
AS 

SELECT Username,
	   FullName,
	   [Password],
	   LastLoginTime
  FROM Users
 WHERE DATEDIFF(d, LastLoginTime, GETDATE()) = 0

GO
SET QUOTED_IDENTIFIER OFF 
GO

/*17.
Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
Define primary key and identity column.
*/
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupId] [int] IDENTITY,
	[GroupName] [nvarchar](30) NOT NULL,
	CONSTRAINT [PK_Groups] PRIMARY KEY ([GroupId]),
	CONSTRAINT [UC_Groups] UNIQUE NONCLUSTERED ([GroupName])
)
GO

/*18.
Write a SQL statement to add a column GroupID to the table Users. 
Fill some data in this new column and as well in the Groups table. 
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
*/
ALTER TABLE Users ADD [GroupId] int NULL
GO

ALTER TABLE Users ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY ([GroupId])
  REFERENCES Groups([GroupId])
GO

/*19.
Write SQL statements to insert several records in the Users and Groups tables.
*/
INSERT [Groups] (GroupName) VALUES ('Group D')
INSERT [Groups] (GroupName) VALUES ('Group E')
INSERT [Groups] (GroupName) VALUES ('Group F')
GO

INSERT [Users] (Username, FullName, [Password], LastLoginTime, GroupId) 
VALUES ('steve', 'Steven Spielberg', 'steve', '09/06/2012', 8)
INSERT [Users] (Username, FullName, [Password], LastLoginTime, GroupId) 
VALUES ('sergey', 'Sergey Brin', 'sergey', '12/08/2012', 6)
GO

/*20.
Write SQL statements to update some of the records in the Users and Groups tables.
*/
UPDATE Users
SET LastLoginTime = '01/01/2010'
WHERE Username = 'student'

UPDATE Groups
SET GroupName = 'Group D'
WHERE GroupId = 6

UPDATE Groups
SET GroupName = 'Group E'
WHERE GroupId = 7

UPDATE Groups
SET GroupName = 'Group F'
WHERE GroupId = 8
GO

/*21.
Write SQL statements to delete some of the records from the Users and Groups tables.
*/
DELETE FROM Users
WHERE UserId IN (1, 6)
GO

DELETE FROM Groups
WHERE GroupId = 8
GO

/*22.
Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
Use the same for the password, and NULL for last login time.
*/
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY,
	[Username] [nvarchar](30) NOT NULL,
	[FullName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[GroupId] int NULL,
	CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
	CONSTRAINT [FK_Users_Groups] 
	FOREIGN KEY ([GroupId])
	REFERENCES Groups([GroupId])
)
GO

INSERT INTO Users (Username, FullName, [Password])
SELECT LOWER(LEFT(Emp.FirstName, 1) + Emp.LastName),
	   Emp.FirstName + ' ' + Emp.LastName, 
	   LOWER(LEFT(Emp.FirstName, 1) + Emp.LastName) -- the password should be at least 5 characters
FROM Employees AS Emp
GO

/*23.
Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
*/
UPDATE Users
SET [Password] = NULL
WHERE DATEDIFF(d, LastLoginTime, '03/10/2010') >= 0

/*24.
Write a SQL statement that deletes all users without passwords (NULL password).
*/
DELETE FROM Users
WHERE Password IS NULL

/*25.
Write a SQL query to display the average employee salary by department and job title.
*/
SELECT AVG(Emp.Salary) AS [AverageSalary],
	   Dep.Name AS [Department],
	   Emp.JobTitle,
	   COUNT(Emp.EmployeeID)
  FROM Employees AS Emp
  JOIN Departments AS Dep
    ON Emp.DepartmentID = Dep.DepartmentID
 GROUP BY Dep.Name, Emp.JobTitle
 
/*26.
Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
*/
SELECT MIN(Emp.Salary) AS [MinSalary],
	   Dep.Name AS [Department],
	   Emp.JobTitle,
	   MIN(Emp.FirstName + ' ' + Emp.LastName) AS [EmployeeName]
  FROM Employees AS Emp
  JOIN Departments AS Dep
    ON Emp.DepartmentID = Dep.DepartmentID
 GROUP BY Dep.Name, Emp.JobTitle
 
/*27.
Write a SQL query to display the town where maximal number of employees work.
*/
SELECT TOP 1 Towns.Name AS [TownName],
	   COUNT(Emp.EmployeeID) AS [EmployeesCount]
  FROM Towns
  JOIN Addresses AS Addr
    ON Towns.TownID = Addr.TownID
  JOIN Employees AS Emp
    ON Addr.AddressID = Emp.AddressID
 GROUP BY Towns.Name
 ORDER BY EmployeesCount DESC
 
/*28.
Write a SQL query to display the number of managers from each town.
*/
SELECT COUNT(Mngr.EmployeeID) AS [ManagersCount],
	   Towns.Name AS [TownName]
  FROM Employees AS Mngr
  JOIN Employees AS Emp
    ON Mngr.EmployeeID = Emp.ManagerID
  JOIN Addresses Addr
    ON Emp.AddressID = Addr.AddressID
  JOIN Towns
    ON Addr.TownID = Towns.TownID
 GROUP BY Towns.Name
 
/*29.
Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
Don't forget to define  identity, primary key and appropriate foreign key. Issue few SQL statements to insert, update and delete of some data in the table.
Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
For each change keep the old record data, the new record data and the command (insert / update / delete).
*/
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkReports](
	[WorkReportID] [int] IDENTITY,
	[EmployeeID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Task] [nvarchar](30) NOT NULL,
	[Hours] [int] NOT NULL,
	[Comments] [nvarchar](30) NULL,
	CONSTRAINT [PK_WorkReports] PRIMARY KEY ([WorkReportID]),
	CONSTRAINT [FK_WorkReports_Employees] 
	FOREIGN KEY ([EmployeeID])
	REFERENCES Employees ([EmployeeID])
)
GO

INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (1, '07/11/2013', 'Bug fixing', 8)
INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (15, '01/08/2012', 'Code refactoring', 3)
INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (18, '09/09/2013', 'Software Documentation', 6)
INSERT [WorkReports] (EmployeeID, [Date], Task, [Hours])
VALUES (66, '09/10/2014', 'Testing', 1)
GO

UPDATE [WorkReports]
SET [Hours] = 7
WHERE EmployeeID = 15

DELETE FROM [WorkReports]
WHERE EmployeeID = 66

CREATE TABLE [dbo].[WorkReportsLogs](
	[WorkReportID] [int],
	[EmployeeID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Task] [nvarchar](30) NOT NULL,
	[Hours] [int] NOT NULL,
	[Comments] [nvarchar](30) NULL,
	[Action] [nvarchar](30) NOT NULL,
	CONSTRAINT [CC_WorkReportsLogs] CHECK (([Action] in 
	('Insert', 'Delete', 'DeleteAsPartOfUpdate', 'InsertAsPartOfUpdate')))
)
GO

CREATE TRIGGER tr_InsertWorkReports ON WorkReports FOR INSERT
AS
INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'Insert'
      FROM inserted
GO

CREATE TRIGGER tr_DeleteWorkReports ON WorkReports FOR DELETE
AS
INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'Delete'
      FROM deleted
GO

CREATE TRIGGER tr_UpdateWorkReports ON WorkReports FOR UPDATE
AS
INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'DeleteAsPartOfUpdate'
      FROM deleted

INSERT INTO WorkReportsLogs (WorkReportID, EmployeeID, [Date], [Task], [Hours], Comments, [Action])
    SELECT WorkReportID, 
		   EmployeeID, 
		   [Date], 
		   [Task], 
		   [Hours],
		   Comments,
		   'InsertAsPartOfUpdate'
      FROM inserted
GO

--DELETE FROM WorkReports
--GO

--DELETE FROM WorkReportsLogs
--GO

/*30.
Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the other tables. 
In the end roll back the transaction.
*/
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
GO

BEGIN TRANSACTION

DELETE Employees 
  FROM Employees
  JOIN Departments
    ON Employees.DepartmentID = Departments.DepartmentID
   AND Departments.Name = 'Sales'

ROLLBACK TRANSACTION

/*31.
Start a database transaction and drop the table EmployeesProjects. Now how can you restore back the lost table data?
*/
USE TelerikAcademy

BEGIN TRANSACTION

DROP TABLE EmployeesProjects

ROLLBACK TRANSACTION

/*
32.
Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects 
and restore them back after dropping and re-creating the table.
*/
USE TelerikAcademy

SET NOCOUNT ON

BEGIN TRANSACTION

DECLARE @employeesProjects TABLE(
	EmployeeID int,
	ProjectID int
)

INSERT INTO @employeesProjects (EmployeeID, ProjectID)
SELECT EmployeeID,
	   ProjectID
  FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
  EmployeeID int NOT NULL,
  ProjectID int NOT NULL,
  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
SELECT EmployeeID,
	   ProjectID
  FROM @employeesProjects

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID)

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY(ProjectID)
REFERENCES Projects(ProjectID)
GO

COMMIT TRANSACTION