using System;
using System.Configuration;
using System.Data.SqlClient;

internal class ProductSearcher
{
    private static void Main()
    {
        Console.Write("Search product names for: ");
        string searchString = Console.ReadLine();

        searchString = searchString
            .Replace("%", "!%")
            .Replace("'", "!'")
            .Replace("\"", "!\"")
            .Replace("_", "!_")
            .ToLower();

        SqlConnection dbConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["northwind"].ConnectionString);
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand(
                string.Format(
                @"SELECT ProductName 
                    FROM Products
                   WHERE LOWER(ProductName) LIKE '%{0}%' ESCAPE '!'",
                searchString),
                dbConnection);

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("Products");
                Console.WriteLine(new String('-', 16));

                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine(productName);
                }
            }
        }
    }
}
