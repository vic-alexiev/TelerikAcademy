using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHtmlFileData
{
    private static string GetNonTagData(string input, out string title)
    {
        // first, extract the title of the HTML document
        string pattern = @"<\s*title\s*>(?<title>[^<>]*)<\s*/\s*title\s*>";
        Match titleMatch = Regex.Match(input, pattern);

        title = String.Empty;

        if (titleMatch.Success)
        {
            title = titleMatch.Groups["title"].Value;
        }

        string headPattern = @"<\s*head\s*>(.|\s)*?<\s*/\s*head\s*>";

        // remove the <head> part of the document
        string buffer = Regex.Replace(input, headPattern, String.Empty);

        string bodyPattern = @">(?<content>[^<>]+)<";
        MatchCollection bodyMatches = Regex.Matches(buffer, bodyPattern);

        StringBuilder contentsBuilder = new StringBuilder();

        foreach (Match bodyMatch in bodyMatches)
        {
            contentsBuilder.Append(bodyMatch.Groups["content"].Value.Trim() + " ");
        }

        return contentsBuilder.ToString();
    }
    static void Main()
    {
        string htmlFilePath;

        do
        {
            Console.WriteLine("Enter the path of a local HTML file:");
            htmlFilePath = Console.ReadLine();
        }
        while (!File.Exists(htmlFilePath) ||
            Path.GetExtension(htmlFilePath) != ".html" &&
            Path.GetExtension(htmlFilePath) != ".htm");

        string htmlMarkup = File.ReadAllText(htmlFilePath);

        string title;
        string nonTagData = GetNonTagData(htmlMarkup, out title);

        Console.WriteLine("Title: {0}", title);
        Console.WriteLine("Body:\n{0}", nonTagData);
    }
}
