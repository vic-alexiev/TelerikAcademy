using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWordInTextFile
{
    private const string OLD_VALUE = "start";
    private const string NEW_VALUE = "finish";

    private static string ReplaceWord(string input, string wordToFind, string replacement)
    {
        string pattern = String.Format(@"\b{0}\b", wordToFind);

        string result = Regex.Replace(input, pattern, replacement);
        return result;
    }

    static void Main()
    {
        string sourceFilePath;

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourceFilePath = Console.ReadLine();
        }
        while (!File.Exists(sourceFilePath));

        string extension = Path.GetExtension(sourceFilePath);

        string destinationFilePath = sourceFilePath.Insert(sourceFilePath.LastIndexOf(extension), "_out");

        try
        {
            using (StreamReader reader = new StreamReader(sourceFilePath))
            {
                using (StreamWriter writer = new StreamWriter(destinationFilePath, false))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(ReplaceWord(line, OLD_VALUE, NEW_VALUE));
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
