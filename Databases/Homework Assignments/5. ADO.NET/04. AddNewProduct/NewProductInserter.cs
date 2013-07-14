using System;
using System.Configuration;
using System.Data.SqlClient;

internal class NewProductInserter
{
    private static int InsertProduct(
        SqlConnection dbConnection,
        string productName,
        int supplierID,
        int categoryID,
        string quantityPerUnit,
        decimal unitPrice,
        short unitsInStock,
        short unitsOnOrder,
        short reorderLevel,
        bool discontinued)
    {
        SqlCommand insertProductCommand = new SqlCommand(
                @"INSERT Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                  VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)",
                dbConnection);

        insertProductCommand.Parameters.AddWithValue("@productName", productName);
        insertProductCommand.Parameters.AddWithValue("@supplierID", supplierID);
        insertProductCommand.Parameters.AddWithValue("@categoryID", categoryID);
        insertProductCommand.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
        insertProductCommand.Parameters.AddWithValue("@unitPrice", unitPrice);
        insertProductCommand.Parameters.AddWithValue("@unitsInStock", unitsInStock);
        insertProductCommand.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
        insertProductCommand.Parameters.AddWithValue("@reorderLevel", reorderLevel);
        insertProductCommand.Parameters.AddWithValue("@discontinued", discontinued);

        insertProductCommand.ExecuteNonQuery();

        SqlCommand selectIdentityCommand = new SqlCommand("SELECT @@Identity", dbConnection);
        int insertedRecordId = (int)(decimal)selectIdentityCommand.ExecuteScalar();
        return insertedRecordId;
    }

    private static void Main()
    {
        SqlConnection dbConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["northwind"].ConnectionString);

        dbConnection.Open();

        using (dbConnection)
        {
            int newProductId = InsertProduct(dbConnection, "Cabernet Sauvignon", 4, 1, "1 bottle", 15.9M, 200, 6, 1, false);
            Console.WriteLine("Product ID: " + newProductId);
        }
    }
}
