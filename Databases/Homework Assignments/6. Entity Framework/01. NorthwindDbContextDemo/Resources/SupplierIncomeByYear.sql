if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SupplierIncomeByYear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[SupplierIncomeByYear]
GO

SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE SupplierIncomeByYear
@SupplierContactName nvarchar(30),
@BeginningDate datetime, 
@EndingDate datetime
AS

SELECT Suppliers.ContactName,
	   SUM([Order Subtotals].Subtotal) AS Income
  FROM Orders
  JOIN [Order Subtotals]
    ON Orders.OrderID = [Order Subtotals].OrderID
  JOIN [Order Details]
    ON [Order Subtotals].OrderID = [Order Details].OrderID
  JOIN Products
    ON [Order Details].ProductID = Products.ProductID
  JOIN Suppliers
    ON Products.SupplierID = Suppliers.SupplierID
 WHERE Orders.ShippedDate Between @BeginningDate And @EndingDate
   AND Suppliers.ContactName = @SupplierContactName
 GROUP BY Suppliers.ContactName

GO
SET QUOTED_IDENTIFIER OFF 
GO

--EXEC SupplierIncomeByYear 'Elio Rossi', '1996-01-01', '2000-12-31'