using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

internal class BooksManagerEmbedded
{
    private static SQLiteConnection GetConnection(string filePath)
    {
        SQLiteConnection connection = new SQLiteConnection(
            string.Format("Data Source={0};Version=3;", filePath));

        return connection;
    }

    private static DataSet FindBooks(string filePath, string searchString)
    {
        searchString = searchString
            .Replace("%", "!%")
            .Replace("'", "!'")
            .Replace("\"", "!\"")
            .Replace("_", "!_")
            .ToLower();

        SQLiteConnection connection = GetConnection(filePath);

        connection.Open();
        using (connection)
        {
            DataSet dataSet = new DataSet();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(
                string.Format(
                @"SELECT BookTitle, BookAuthor FROM Books
                  WHERE LOWER(BookTitle) LIKE '%{0}%' ESCAPE '!'", searchString),
                connection);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static DataSet GetAllBooks(string filePath)
    {
        SQLiteConnection connection = GetConnection(filePath);

        connection.Open();
        using (connection)
        {
            DataSet dataSet = new DataSet();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(
                "SELECT BookTitle, BookAuthor FROM Books",
                connection);

            adapter.Fill(dataSet);
            return dataSet;
        }
    }

    private static int InsertNewBook(
        string filePath,
        string title,
        string author,
        DateTime publicationDate,
        string isbn)
    {
        SQLiteConnection connection = GetConnection(filePath);

        connection.Open();
        using (connection)
        {
            SQLiteCommand insertBookCommand = new SQLiteCommand(
                @"INSERT INTO Books (BookTitle, BookAuthor, PublicationDate, ISBN)
                  VALUES (@bookTitle, @bookAuthor, @publicationDate, @isbn)", connection);

            insertBookCommand.Parameters.AddWithValue("@bookTitle", title);
            insertBookCommand.Parameters.AddWithValue("@bookAuthor", author);
            insertBookCommand.Parameters.AddWithValue("@publicationDate", publicationDate);
            insertBookCommand.Parameters.AddWithValue("@isbn", isbn);

            int rowsAffected = insertBookCommand.ExecuteNonQuery();
            return rowsAffected;
        }
    }

    private static void Main()
    {
        DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        string resourcesDirectoryName = Path.Combine(currentDirectory.Parent.Parent.FullName, "Resources");
        string dbFilePath = Path.Combine(resourcesDirectoryName, "bookshop.sqlite");

        Console.Write("Search book titles for: ");
        string searchString = Console.ReadLine();

        DataSet booksDataSet = FindBooks(dbFilePath, searchString);

        foreach (DataRow row in booksDataSet.Tables[0].Rows)
        {
            Console.WriteLine("{0, -20}{1, -20}", row["BookTitle"], row["BookAuthor"]);
        }

        //int rowsAffected = InsertNewBook(
        //    dbFilePath,
        //    "Pro ASP.NET MVC 4",
        //    "Adam Freeman",
        //    new DateTime(2013, 1, 16),
        //    "978-1430242369");

        //Console.WriteLine("({0} row(s) affected)", rowsAffected);
    }
}
