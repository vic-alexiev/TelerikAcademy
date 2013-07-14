using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

/// <summary>
/// See also http://tihomir.me/tag/northwind
/// </summary>
internal class ImageExtractor
{
    private const int OLE_METAFILEPICT_START_POSITION = 78;

    private static void ExtractCategoryImagesFromDB(SqlConnection dbConnection, string directoryName)
    {
        SqlCommand extractImagesCommand = new SqlCommand(
            "SELECT CategoryName, Picture FROM Categories", dbConnection);

        SqlDataReader reader = extractImagesCommand.ExecuteReader();
        using (reader)
        {
            while (reader.Read())
            {
                string imageName = (string)reader["CategoryName"];

                if (imageName.Contains('/'))
                {
                    imageName = imageName.Replace('/', ' ');
                }

                byte[] imageData = (byte[])reader["Picture"];

                MemoryStream stream = new MemoryStream(imageData, OLE_METAFILEPICT_START_POSITION,
                imageData.Length - OLE_METAFILEPICT_START_POSITION);
                Image picture = Image.FromStream(stream);

                using (picture)
                {
                    picture.Save(Path.Combine(directoryName, imageName + ".jpg"), ImageFormat.Jpeg);
                }
            }
        }
    }

    private static void Main()
    {
        DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        string imagesDirectoryName = Path.Combine(currentDirectory.Parent.Parent.FullName, "Images");

        SqlConnection dbConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["northwind"].ConnectionString);

        dbConnection.Open();

        using (dbConnection)
        {
            ExtractCategoryImagesFromDB(dbConnection, imagesDirectoryName);
        }
    }
}
