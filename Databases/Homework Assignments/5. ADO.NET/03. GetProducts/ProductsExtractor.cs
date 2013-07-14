using System;
using System.Configuration;
using System.Data.SqlClient;

internal class ProductsExtractor
{
    private static void Main()
    {
        string column1 = "CategoryName";
        string column2 = "ProductName";

        SqlConnection dbConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["northwind"].ConnectionString);
        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand command = new SqlCommand(
                string.Format(
                @"SELECT C.{0},
                         P.{1}
                    FROM Categories AS C
                    JOIN Products AS P
                      ON P.CategoryID = C.CategoryID
                   GROUP BY C.{0}, P.{1}
                   ORDER BY C.{0}, P.{1}", column1, column2),
                dbConnection);

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("{0, -15} | {1, -30}", column1, column2);
                Console.WriteLine(new String('-', 16) + "+" + new String('-', 30));

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
