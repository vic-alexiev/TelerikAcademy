using System;
using System.Configuration;
using System.Data.SqlClient;

internal class CategoriesExtractor
{
    private static void Main()
    {
        string column1 = "CategoryName";
        string column2 = "Description";

        SqlConnection dbConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["northwind"].ConnectionString);
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand(
                string.Format("SELECT {0}, {1} FROM Categories", column1, column2), 
                dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("{0, -15} | {1, -60}", column1, column2);
                Console.WriteLine(new String('-', 16) + "+" + new String('-', 60));
                
                while (reader.Read())
                {
                    string field1 = (string)reader[column1];
                    string field2 = (string)reader[column2];
                    Console.WriteLine("{0, -15} | {1, -60}", field1, field2);
                }
            }
        }
    }
}
