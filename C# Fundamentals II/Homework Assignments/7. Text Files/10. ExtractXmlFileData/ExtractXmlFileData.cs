using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

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

    private static string GetInnerText(XmlNode node)
    {
        if (node == null)
        {
            return String.Empty;
        }

        if (!node.HasChildNodes)
        {
            return String.Format("\n{0}", node.InnerText);
        }
        else
        {
            StringBuilder innerTextBuilder = new StringBuilder();

            foreach (XmlNode child in node.ChildNodes)
            {
                string childText = GetInnerText(child);
                innerTextBuilder.AppendFormat(childText);
            }

            return innerTextBuilder.ToString();
        }
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

        // I solution
        //XmlDocument document = new XmlDocument();
        //document.Load(filePath);

        //string innerText = GetInnerText(document.DocumentElement);
        //Console.WriteLine(innerText);

        // II solution
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