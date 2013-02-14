using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteSpecialWordsFromTextFile
{
    private const string PREFIX = "test";

    private static string RemoveWordsWithPrefix(string input, string prefix)
    {
        string pattern = String.Format(@"\b{0}\w+\b", prefix);

        string result = Regex.Replace(input, pattern, String.Empty);
        return result;
    }

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

        string destinationFilePath = sourcefilePath.Insert(sourcefilePath.LastIndexOf(extension), "_result");

        try
        {
            using (StreamReader reader = new StreamReader(sourcefilePath))
            {
                using (StreamWriter writer = new StreamWriter(destinationFilePath, false))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(RemoveWordsWithPrefix(line, PREFIX));
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
