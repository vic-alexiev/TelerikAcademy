using System;
using System.Configuration;
using System.Data.SqlClient;

internal class CategoriesCountExtractor
{
    private static void Main()
    {
        SqlConnection dbConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["northwind"].ConnectionString);
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", dbConnection);
            int categoriesCount = (int)command.ExecuteScalar();
            Console.WriteLine("Categories count: {0} ", categoriesCount);
        }
    }
}
