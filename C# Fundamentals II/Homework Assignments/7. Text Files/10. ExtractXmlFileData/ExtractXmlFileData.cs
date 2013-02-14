using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class ExtractXmlFileData
{
    private static List<string> ExtractXmlFileContents(string input)
    {
        string pattern = @"<[^/>]+>(?<word>[^<>]*)<\s*/[^>]+>";
        Match match = Regex.Match(input, pattern);

        List<string> matchesList = new List<string>();
        while (match.Success)
        {
            matchesList.Add(match.Groups["word"].Value);
            match = match.NextMatch();
        }

        return matchesList;
    }

    static void Main()
    {
        string filePath;

        do
        {
            Console.Write("Enter the path of an XML file in the local file system: ");
            filePath = Console.ReadLine();
        }
        while (!File.Exists(filePath));

        try
        {
            string fileContents = File.ReadAllText(filePath);

            List<string> words = ExtractXmlFileContents(fileContents);

            if (words.Count > 0)
            {
                Console.WriteLine("File data:");

                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
    }
}
