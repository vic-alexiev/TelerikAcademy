using NorthwindModels;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;

internal class NorthwindDbContextDemo
{
    private static void InsertNewCustomer()
    {
        DataAccess.InsertNewCustomer(
            "TELRK",
            "Telerik Corp.",
            "Svetozar Georgiev",
            "Mr.",
            "33 Alexander Malinov Blvd.",
            "Sofia",
            "Sofia",
            "1729",
            "Bulgaria",
            "+359 2 809 98 62",
            "+359 2 809 98 62");
    }

    private static void UpdateCustomerByID()
    {
        DataAccess.UpdateCustomerByID(
            "TELRK",
            "Telerik Corp.",
            "Vassil Terziev",
            "Mr.",
            "33 Alexander Malinov Blvd.",
            "Sofia",
            "Sofia",
            "1729",
            "Bulgaria",
            "+359 2 809 98 62",
            "+359 2 809 98 62");
    }

    private static void RemoveCustomerByID()
    {
        DataAccess.RemoveCustomerByID("TELRK");
    }

    private static void PrintCustomersHavingOrdersFrom1997ForCanada()
    {
        var orders = DataAccess.GetOrders(1997, "Canada").OrderBy(o => o.Customer.ContactName);

        foreach (var order in orders)
        {
            Console.WriteLine(
                "{0,-10}{1,-10}{2,-10}{3,-20}",
                order.OrderID,
                order.OrderDate.Value.Year,
                order.ShipCountry,
                order.Customer.ContactName);
        }
    }

    private static void PrintCustomersHavingOrdersFrom1997ForCanadaNativeQuery()
    {
        var customers = DataAccess.GetCustomersHavingOrderNativeQuery(1997, "Canada");

        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }

    private static void PrintSalesByRegionAndYear()
    {
        var salesByRegionAndYear = DataAccess.GetSalesByRegionAndYear("RJ", new DateTime(1992, 1, 1), new DateTime(2000, 12, 31));

        foreach (var salesByYearResult in salesByRegionAndYear)
        {
            Console.WriteLine(
                "{0,-15:dd.MM.yyyy}{1,-8}{2, -15}{3, -6}",
                salesByYearResult.ShippedDate,
                salesByYearResult.OrderID,
                salesByYearResult.Subtotal,
                salesByYearResult.Year);
        }
    }

    private static void GenerateDatabaseFromModel()
    {
        DataAccess.GenerateDatabaseFromModel("NorthwindTwin");
    }

    private static void InsertNewOrders(int count)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            for (int i = 0; i < count; i++)
            {
                DataAccess.InsertNewOrder(
                    "ALFKI",
                    9,
                    new DateTime(2013, 7, 12),
                    new DateTime(2013, 7, 19),
                    new DateTime(2013, 7, 16),
                    3,
                    20.78M,
                    "Telerik Academy",
                    "33 Alexander Malinov Blvd.",
                    "Sofia",
                    "Sofia",
                    "1729",
                    "Bulgaria");
            }

            scope.Complete();
        }
    }

    private static void PrintSupplierIncomeByYear()
    {
        var supplierIncomeByYear = DataAccess.GetSupplierIncomeByYear("Elio Rossi", new DateTime(1996, 1, 1), new DateTime(2000, 12, 31));

        foreach (var supplierIncome in supplierIncomeByYear)
        {
            Console.WriteLine(
                "{0,-20}{1,-8:C2}",
                supplierIncome.ContactName,
                supplierIncome.Income);
        }
    }

    private static void Main()
    {
        using (NorthwindEntities dbContext = new NorthwindEntities())
        {
            DataAccess.Initialize(dbContext);

            try
            {
                // Task 2
                //InsertNewCustomer();

                //UpdateCustomerByID();

                //RemoveCustomer();

                // Task 3
                //PrintCustomersHavingOrdersFrom1997ForCanada();

                // Task 4
                //PrintCustomersHavingOrdersFrom1997ForCanadaNativeQuery();

                // Task 5
                //PrintSalesByRegionAndYear();

                // Task 6
                // The NorthwindTwin database script can also be created 
                // using the "Generate Database from Model..." command.
                // It's in the \Resources folder (NorthwindTwin.sql).
                //GenerateDatabaseFromModel();

                // Task 7
                // In a separate project

                // Task 8
                // The EmployeeEx.cs class has been created in which
                // the property TerritoriesSet has been added.

                // Task 9
                //InsertNewOrders(10);

                // Task 10
                // The script generating the stored procedure is in the 
                // \Resources folder (SupplierIncomeByYear.sql)

                //PrintSupplierIncomeByYear();

                // Task 11
                // In a separate project
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationResult in ex.EntityValidationErrors)
                {
                    foreach (var error in validationResult.ValidationErrors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
        }
    }
}
