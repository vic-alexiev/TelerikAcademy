/*4.
Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
*/
SELECT * FROM Departments

/*5.
Write a SQL query to find all department names.
*/
SELECT Name FROM Departments

/*6.
Write a SQL query to find the salary of each employee.
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName], Salary FROM Employees

/*7.
Write a SQL to find the full name of each employee.
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName] FROM Employees

/*8.
Write a SQL query to find the email addresses of each employee (by his first and last name). 
Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
*/
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] FROM Employees

/*9.
Write a SQL query to find all different employee salaries.
*/
SELECT DISTINCT Salary, MIN(FirstName + ' ' + LastName) AS [EmployeeName] FROM Employees
GROUP BY Salary

/*10.
Write a SQL query to find all information about the employees whose job title is "Sales Representative".
*/
SELECT * FROM Employees
WHERE JobTitle LIKE '%sales representative%' 
COLLATE Latin1_General_CI_AS
--COLLATE Latin1_General_CS_AS

/*11.
Write a SQL query to find the names of all employees whose first name starts with "SA".
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName] FROM Employees
WHERE FirstName LIKE 'sa%' 
COLLATE Latin1_General_CI_AS
--COLLATE Latin1_General_CS_AS

/*12.
Write a SQL query to find the names of all employees whose last name contains "ei".
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName] FROM Employees
WHERE LastName LIKE '%ei%' 
COLLATE Latin1_General_CI_AS
--COLLATE Latin1_General_CS_AS

/*13.
Write a SQL query to find the salary of all employees whose salary is in the range [20000...30000].
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName], Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

/*14.
Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName], Salary FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

/*15.
Write a SQL query to find all employees that do not have manager.
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName] FROM Employees
WHERE ManagerID IS NULL

/*16.
Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
*/
SELECT FirstName + ' ' + LastName AS [EmployeeName], Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

/*17.
Write a SQL query to find the top 5 best paid employees.
*/
SELECT TOP 5 FirstName + ' ' + LastName AS [EmployeeName], Salary FROM Employees
ORDER BY Salary DESC

/*18.
Write a SQL query to find all employees along with their address. Use inner join with ON clause.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName], Addr.AddressText 
  FROM Employees AS Emp 
  JOIN Addresses AS Addr
    ON Emp.AddressID = Addr.AddressID

/*19.
Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName], Addr.AddressText 
  FROM Employees AS Emp, Addresses AS Addr
 WHERE Emp.AddressID = Addr.AddressID

/*20.
Write a SQL query to find all employees along with their manager.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName], Mngr.FirstName + ' ' + Mngr.LastName AS [ManagerName] 
FROM Employees AS Emp
JOIN Employees AS Mngr
  ON Emp.ManagerID = Mngr.EmployeeID
ORDER BY Emp.EmployeeID

/*21.
Write a SQL query to find all employees, along with their manager and their address. 
Join the 3 tables: Employees e, Employees m and Addresses a.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName], 
	   Mngr.FirstName + ' ' + Mngr.LastName AS [ManagerName],
	   Addr.AddressText 
FROM Employees AS Emp
JOIN Employees AS Mngr
  ON Emp.ManagerID = Mngr.EmployeeID
JOIN Addresses Addr
  ON Addr.AddressID = Emp.AddressID
ORDER BY Emp.EmployeeID

/*22.
Write a SQL query to find all departments and all region names, country names and city names as a single list. Use UNION.
*/
SELECT Departments.Name
  FROM Departments
 UNION 
SELECT Towns.Name
  FROM Towns

/*23.
Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
User right outer join. Rewrite the query to use left outer join.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName], 
	   Mngr.FirstName + ' ' + Mngr.LastName AS [ManagerName] 
  FROM Employees AS Emp
  LEFT OUTER JOIN Employees AS Mngr
    ON Emp.ManagerID = Mngr.EmployeeID
 ORDER BY Mngr.EmployeeID

------------------------------------------------------------

SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName], 
	   Mngr.FirstName + ' ' + Mngr.LastName AS [ManagerName] 
  FROM Employees AS Mngr
 RIGHT OUTER JOIN Employees AS Emp
    ON Emp.ManagerID = Mngr.EmployeeID
 ORDER BY Mngr.EmployeeID

/*24.
Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
*/
SELECT Emp.FirstName + ' ' + Emp.LastName AS [EmployeeName],
	   Emp.HireDate,
	   Dep.Name
  FROM Employees AS Emp
  JOIN Departments AS Dep
    ON Emp.DepartmentID = Dep.DepartmentID
 WHERE (Dep.Name = 'Sales' 
    OR Dep.Name = 'Finance')
   AND YEAR(Emp.HireDate) BETWEEN 1995 AND 2005