using System;
using System.Data.OleDb;
using System.IO;

internal class ExcelFileInserter
{
    private static OleDbConnection GetConnection(string excelFilePath)
    {
        OleDbConnection connection = new OleDbConnection(
            string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
            excelFilePath));

        return connection;
    }

    private static int InsertNewRow(string excelFilePath, string sheetName, string name, int score)
    {
        OleDbConnection connection = GetConnection(excelFilePath);

        connection.Open();

        using (connection)
        {
            OleDbCommand insertCommand = new OleDbCommand(
                string.Format("INSERT INTO [{0}$] (Name, Score) VALUES ('{1}', '{2}')",
                sheetName,
                name,
                score),
                connection);

            int rowsAffected = insertCommand.ExecuteNonQuery();
            return rowsAffected;
        }
    }

    private static void Main()
    {
        DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        string resourcesDirectoryName = Path.Combine(currentDirectory.Parent.Parent.FullName, "Resources");
        string excelFilePath = Path.Combine(resourcesDirectoryName, "Scores.xlsx");

        InsertNewRow(excelFilePath, "Sheet1", "Ina Dobrilova", 100);
    }
}
