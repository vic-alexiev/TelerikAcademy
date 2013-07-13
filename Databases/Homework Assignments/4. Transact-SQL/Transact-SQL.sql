/*1.
Create a database with two tables: Customers(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), CustomerId(FK), Balance). 
Insert a few records for testing. Write a stored procedure that selects the full names of all customers.
*/
CREATE DATABASE Bank
ON (NAME = 'Bank_Data',
FILENAME = 'F:\Telerik Academy\Databases\Projects\4. Transact-SQL\Bank.mdf',
SIZE = 20 MB,
FILEGROWTH = 0)
LOG ON (NAME = 'TestDB_Log',
FILENAME = 'F:\Telerik Academy\Databases\Projects\4. Transact-SQL\Bank_Log.ldf',
SIZE = 5 MB,
FILEGROWTH = 0)

USE Bank

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[SSN] [nvarchar](30),
	CONSTRAINT [PK_People] PRIMARY KEY ([CustomerId]),
)
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY,
	[CustomerId] [int] NOT NULL,
	[Balance] [money] NOT NULL,
	CONSTRAINT [PK_Accounts] PRIMARY KEY ([AccountId]),
	CONSTRAINT FK_Accounts_Customers
	FOREIGN KEY ([CustomerId])
	REFERENCES Customers ([CustomerId])
)
GO

INSERT Customers (FirstName, LastName, SSN) VALUES ('Guy', 'Gilbert', '721-07-4426')
INSERT Customers (FirstName, LastName, SSN) VALUES ('Ruth', 'Ellerbrock', '824-60-9117')
INSERT Customers (FirstName, LastName, SSN) VALUES ('Jeffrey', 'Ford', '812-09-2815')
INSERT Customers (FirstName, LastName, SSN) VALUES ('David', 'Bradley', '391-06-6917')
GO

INSERT Accounts (CustomerId, Balance) VALUES (1, 2500)
INSERT Accounts (CustomerId, Balance) VALUES (2, 125000)
INSERT Accounts (CustomerId, Balance) VALUES (3, 15000)
INSERT Accounts (CustomerId, Balance) VALUES (4, 10000)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[up_SelectCustomers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[up_SelectCustomers]
GO

SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE up_SelectCustomers
@CustomerId int
AS

SELECT C.FirstName + ' ' + C.LastName AS CustomerName
  FROM Customers AS C
 WHERE C.CustomerId = @CustomerId 
    OR @CustomerId IS NULL

GO
SET QUOTED_IDENTIFIER OFF 
GO

EXEC up_SelectCustomers NULL

/*2.
Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[up_SelectCustomersHavingBalanceGreaterThan]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[up_SelectCustomersHavingBalanceGreaterThan]
GO

SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE up_SelectCustomersHavingBalanceGreaterThan
@minBalance money
AS

SELECT C.FirstName + ' ' + C.LastName AS CustomerName,
       A.Balance AS Balance
  FROM Customers AS C
  JOIN Accounts AS A
    ON A.CustomerId = C.CustomerId
 WHERE A.Balance > @minBalance

GO
SET QUOTED_IDENTIFIER OFF 
GO

EXEC up_SelectCustomersHavingBalanceGreaterThan 10000

/*3.
Create a function that accepts as parameters sum, yearly interest rate and number of months. 
It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ufn_CalcInterest]') and type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
  drop function [dbo].[ufn_CalcInterest]
GO

CREATE FUNCTION ufn_CalcInterest(@sum money, @yearlyInterest float, @months int)
  RETURNS money
AS
BEGIN
  RETURN @sum + ((@yearlyInterest / 100.0) / 12) * @months * @sum
END
GO

SELECT dbo.ufn_CalcInterest(10000, 10, 5)

/*4.
Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. 
It should take the AccountId and the interest rate as parameters.
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[up_UpdateBalance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[up_UpdateBalance]
GO

SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE up_UpdateBalance
@accountId int,
@interestRate float,
@months int
AS

 UPDATE Accounts
 SET Balance = dbo.ufn_CalcInterest(Balance, @interestRate, @months)
 WHERE AccountId = @accountId

GO
SET QUOTED_IDENTIFIER OFF 
GO

EXEC up_UpdateBalance 4, 10, 1

/*5.
Add two more stored procedures: WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[up_WithdrawMoney]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[up_WithdrawMoney]
GO

SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE up_WithdrawMoney
@accountId int,
@sum money
AS

BEGIN TRANSACTION

UPDATE Accounts
   SET Balance = Balance - @sum
 WHERE AccountId = @accountId

COMMIT TRANSACTION
GO

SET QUOTED_IDENTIFIER OFF 
GO

EXEC up_WithdrawMoney 4, 200

------------------------------------------------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[up_DepositMoney]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[up_DepositMoney]
GO

SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE up_DepositMoney
@accountId int,
@sum money
AS

BEGIN TRANSACTION

UPDATE Accounts
   SET Balance = Balance + @sum
 WHERE AccountId = @accountId

COMMIT TRANSACTION
GO

SET QUOTED_IDENTIFIER OFF 
GO

EXEC up_DepositMoney 4, 200

/*6.
Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
*/
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY,
	[AccountId] [int],
	[OldSum] [money],
	[NewSum] [money],
	CONSTRAINT [PK_Logs] PRIMARY KEY ([LogId]),
	CONSTRAINT FK_Logs_Accounts
	FOREIGN KEY ([AccountId])
	REFERENCES Accounts ([AccountId])
)
GO

CREATE TRIGGER tr_UpdateAccounts ON Accounts FOR UPDATE
AS

INSERT INTO Logs (AccountId, OldSum, NewSum)
SELECT d.AccountId,
	   d.Balance,
	   i.Balance
  FROM deleted AS d
  JOIN inserted AS i
    ON d.AccountID = i.AccountID
GO

EXEC dbo.up_DepositMoney 1, 200

/*7.
Define a function in the database TelerikAcademy that returns all employees' names (first or middle or last name) and all towns' names which 
consist of a given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', ... but not 'Rob' and 'Guy'.
The solution uses a .NET DLL (written in C#, SqlRegularExpressions.dll) to create the function which checks for matches.
When creating the assembly in SSMS, the path to this DLL should be specified.
See also http://www.codeproject.com/Articles/42764/Regular-Expressions-in-MS-SQL-Server-2005-2008.
*/
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

USE TelerikAcademy

CREATE ASSEMBLY 
--assembly name for references from SQL script
SqlRegularExpressions 
-- assembly name and full path to assembly dll,
-- SqlRegularExpressions in this case
from 'F:\Telerik Academy\Databases\Projects\4. Transact-SQL\SqlRegularExpressions.dll' 
WITH PERMISSION_SET = SAFE
GO
--function signature
CREATE FUNCTION RegExpLike(@input nvarchar(max), @pattern nvarchar(255)) RETURNS BIT
--function external name
AS EXTERNAL NAME SqlRegularExpressions.SqlRegularExpressions.[Like]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ufn_FindMatches]') and type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
  drop function [dbo].[ufn_FindMatches]
GO

CREATE FUNCTION ufn_FindMatches(@pattern nvarchar(255))
  RETURNS TABLE
AS
RETURN 
SELECT Emp.FirstName,
	   Emp.MiddleName,
	   Emp.LastName,
	   Towns.Name
  FROM Employees AS Emp
  JOIN Addresses As Addr
    ON Emp.AddressID = Addr.AddressID
  JOIN Towns
    ON Addr.TownID = Towns.TownID
 WHERE 1 = dbo.RegExpLike(LOWER(Towns.Name), @pattern)
   AND (1 = dbo.RegExpLike(LOWER(Emp.FirstName), @pattern)
    OR 1 = dbo.RegExpLike(LOWER(ISNULL(Emp.MiddleName, '')), @pattern)
    OR 1 = dbo.RegExpLike(LOWER(Emp.LastName), @pattern))
GO

SELECT * FROM ufn_FindMatches('^[oistmiahf]+$')

/*8.
Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
*/
USE TelerikAcademy

DECLARE empCursor CURSOR READ_ONLY FOR 

SELECT Emp1.FirstName, Emp1.LastName, T1.Name, Emp2.FirstName, Emp2.LastName
  FROM Employees AS Emp1 
  JOIN Addresses AS Addr1
    ON Addr1.AddressID = Emp1.AddressID
  JOIN Towns AS T1
    ON T1.TownID = Addr1.TownID,
	   Employees AS Emp2
  JOIN Addresses AS Addr2
	ON Addr2.AddressID = Emp2.AddressID
  JOIN Towns AS T2
	ON T2.TownID = Addr2.TownID  
 WHERE T1.Name = T2.Name
   AND Emp1.EmployeeID <> Emp2.EmployeeID
 ORDER BY Emp1.FirstName, Emp2.FirstName             
 
OPEN empCursor
DECLARE @firstName1 NVARCHAR(50), 
		@lastName1 NVARCHAR(50),
        @town NVARCHAR(50),
        @firstName2 NVARCHAR(50),
        @lastName2 NVARCHAR(50)
FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @firstName1 + ' ' + @lastName1 + ' ' + @town + ' ' + @firstName2 + ' ' + @lastName2
    FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
END
 
CLOSE empCursor
DEALLOCATE empCursor

/*9.
* Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:

Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
Ottawa -> Jose Saraiva

The solution uses a .NET DLL (written in C#, SqlStringConcatenation.dll) to create the function which concatenates the names.
When creating the assembly in SSMS, the path to this DLL should be specified.
See also http://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/
*/
-- Remove the aggregate and assembly if they're there
IF OBJECT_ID('dbo.concat') IS NOT NULL DROP AGGREGATE concat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP ASSEMBLY concat_assembly; 
GO      

CREATE ASSEMBLY concat_assembly 
   AUTHORIZATION dbo 
   FROM 'F:\Telerik Academy\Databases\Projects\4. Transact-SQL\SqlStringConcatenation.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 

    @Value NVARCHAR(MAX) 
  , @Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.concat; 
GO  

USE TelerikAcademy

DECLARE townsCursor CURSOR READ_ONLY FOR 

SELECT Towns.Name AS TownName, 
	   dbo.concat(Emp.FirstName + ' ' + Emp.LastName, ', ') AS Employees  
  FROM Towns
  JOIN Addresses AS Addr
    ON Towns.TownID = Addr.TownID
  JOIN Employees AS Emp
    ON Emp.AddressID = Addr.AddressID
 GROUP BY Towns.Name
 ORDER BY Towns.Name
 
OPEN townsCursor
DECLARE @town NVARCHAR(50), 
		@employeesInTown NVARCHAR(MAX)
FETCH NEXT FROM townsCursor INTO @town, @employeesInTown
 
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @town + ' -> ' + @employeesInTown
    FETCH NEXT FROM townsCursor INTO @town, @employeesInTown
END
 
CLOSE townsCursor
DEALLOCATE townsCursor

/*10.
Define a .NET aggregate function StrConcat that takes as input a sequence of strings and returns a single string 
that consists of the input strings separated by ','. For example the following SQL statement should return a single string:

SELECT StrConcat(FirstName + ' ' + LastName)
FROM Employees

The solution uses a .NET DLL (written in C#, SqlStringConcatenation.dll) to create the function which concatenates the names.
When creating the assembly in SSMS, the path to this DLL should be specified.
See also http://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/
*/
IF OBJECT_ID('dbo.concat') IS NOT NULL DROP AGGREGATE concat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP ASSEMBLY concat_assembly; 
GO      

CREATE ASSEMBLY concat_assembly 
   AUTHORIZATION dbo 
   FROM 'F:\Telerik Academy\Databases\Projects\4. Transact-SQL\SqlStringConcatenation.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 

    @Value NVARCHAR(MAX) 
  , @Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.concat; 
GO

SELECT dbo.concat(FirstName + ' ' + LastName, ', ') AS Employees
FROM Employees