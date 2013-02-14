using System;
using System.IO;

class ReplaceSubstringsInTextFile
{
    private const string OLD_VALUE = "start";
    private const string NEW_VALUE = "finish";

    static void Main()
    {
        string sourcefilePath;

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourcefilePath = Console.ReadLine();
        }
        while (!File.Exists(sourcefilePath));

        string extension = Path.GetExtension(sourcefilePath);

        string destinationFilePath = sourcefilePath.Insert(sourcefilePath.LastIndexOf(extension), "_out");

        try
        {
            using (StreamReader reader = new StreamReader(sourcefilePath))
            {
                using (StreamWriter writer = new StreamWriter(destinationFilePath, false))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line.Replace(OLD_VALUE, NEW_VALUE));
                    }
                }
            }

            Console.WriteLine("\"{0}\" saved successfully.", destinationFilePath);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
    }
}
