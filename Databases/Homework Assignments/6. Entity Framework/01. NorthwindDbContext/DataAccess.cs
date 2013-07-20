using NorthwindModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Configuration;

public static class DataAccess
{
    private static NorthwindEntities northwind;

    public static void Initialize(NorthwindEntities northwindContext)
    {
        northwind = northwindContext;
    }

    public static void InsertNewCustomer(
        string customerID,
        string companyName,
        string contactName,
        string contactTitle,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone,
        string fax)
    {

        Customer newCustomer = new Customer()
        {
            CustomerID = customerID,
            CompanyName = companyName,
            ContactName = contactName,
            ContactTitle = contactTitle,
            Address = address,
            City = city,
            Region = region,
            PostalCode = postalCode,
            Country = country,
            Phone = phone,
            Fax = fax
        };

        northwind.Customers.Add(newCustomer);

        northwind.SaveChanges();
    }

    public static Customer GetCustomerByID(string customerID)
    {
        Customer customer = northwind.Customers.FirstOrDefault(c => c.CustomerID == customerID);
        return customer;
    }

    public static void UpdateCustomerByID(
        string customerID,
        string companyName,
        string contactName,
        string contactTitle,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone,
        string fax)
    {
        Customer customerToUpdate = northwind.Customers.FirstOrDefault(c => c.CustomerID == customerID);

        if (customerToUpdate != null)
        {
            customerToUpdate.CompanyName = companyName;
            customerToUpdate.ContactName = contactName;
            customerToUpdate.ContactTitle = contactTitle;
            customerToUpdate.Address = address;
            customerToUpdate.City = city;
            customerToUpdate.Region = region;
            customerToUpdate.PostalCode = postalCode;
            customerToUpdate.Country = country;
            customerToUpdate.Phone = phone;
            customerToUpdate.Fax = fax;

            northwind.SaveChanges();
        }
    }

    public static void RemoveCustomerByID(string customerID)
    {
        Customer customerToRemove = northwind.Customers.FirstOrDefault(c => c.CustomerID == customerID);

        if (customerToRemove != null)
        {
            northwind.Customers.Remove(customerToRemove);
            northwind.SaveChanges();
        }
    }

    public static IEnumerable<Order> GetOrders(int year, string shipCountry)
    {
        var orders = northwind.Orders.Where(
                o => o.OrderDate.HasValue &&
                o.OrderDate.Value.Year == year &&
                o.ShipCountry == shipCountry);

        return orders;
    }

    public static IEnumerable<string> GetCustomersHavingOrderNativeQuery(int year, string shipCountry)
    {
        string query =
            @"SELECT C.ContactName
                FROM Orders AS O
                JOIN Customers AS C
                  ON O.CustomerID = C.CustomerID
                 AND YEAR(O.ORDERDATE) = {0}
                 AND O.ShipCountry = {1}
               ORDER BY C.ContactName";

        object[] parameters = { year, shipCountry };
        var result = northwind.Database.SqlQuery<string>(query, parameters);

        return result;
    }

    public static IEnumerable<Sales_by_Year_Result> GetSalesByRegionAndYear(string shipRegion, DateTime? beginningDate, DateTime? endingDate)
    {
        var salesByRegionAndYear =
            from salesByYear in northwind.Sales_by_Year(beginningDate, endingDate)
            join order in northwind.Orders
                .Where(o => o.ShipRegion == shipRegion)
            on salesByYear.OrderID equals order.OrderID
            select salesByYear;

        return salesByRegionAndYear;
    }

    public static IEnumerable<SupplierIncomeByYear_Result> GetSupplierIncomeByYear(string supplierContactName, DateTime? beginningDate, DateTime? endingDate)
    {
        var supplierIncomeByYear = northwind.SupplierIncomeByYear(supplierContactName, beginningDate, endingDate);
        return supplierIncomeByYear;
    }

    public static void InsertNewOrder(
        string customerID,
        int employeeID,
        DateTime orderDate,
        DateTime requiredDate,
        DateTime shippedDate,
        int shipVia,
        decimal freight,
        string shipName,
        string shipAddress,
        string shipCity,
        string shipRegion,
        string shipPostalCode,
        string shipCountry)
    {
        Order newOrder = new Order()
        {
            CustomerID = customerID,
            EmployeeID = employeeID,
            OrderDate = orderDate,
            RequiredDate = requiredDate,
            ShippedDate = shippedDate,
            ShipVia = shipVia,
            Freight = freight,
            ShipName = shipName,
            ShipAddress = shipAddress,
            ShipCity = shipCity,
            ShipRegion = shipRegion,
            ShipPostalCode = shipPostalCode,
            ShipCountry = shipCountry
        };

        northwind.Orders.Add(newOrder);
        northwind.SaveChanges();
    }

    public static void GenerateDatabaseFromModel(string databaseName)
    {
        string createDatabaseScript = (northwind as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();

        SqlConnection connection = new SqlConnection(
            ConfigurationManager.ConnectionStrings[databaseName].ConnectionString);
        connection.Open();

        using (connection)
        {
            SqlCommand useMasterCommand = new SqlCommand("USE master", connection);
            useMasterCommand.ExecuteNonQuery();

            SqlCommand createDatabaseCommand = new SqlCommand(
                "CREATE DATABASE NorthwindTwin",
                connection);
            createDatabaseCommand.ExecuteNonQuery();

            SqlCommand useNewDatabaseCommand = new SqlCommand("USE NorthwindTwin", connection);
            useNewDatabaseCommand.ExecuteNonQuery();

            SqlCommand copySchemaCommand = new SqlCommand(createDatabaseScript, connection);
            copySchemaCommand.ExecuteNonQuery();
        }
    }
}
