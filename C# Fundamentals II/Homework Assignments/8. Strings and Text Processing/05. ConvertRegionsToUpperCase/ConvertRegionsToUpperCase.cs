using System;
using System.Text.RegularExpressions;

class ConvertRegionsToUpperCase
{
    private static string ConvertToUpperCase(string input)
    {
        string pattern = @"<upcase>(?<content>(.|\s)+?)</upcase>";

        MatchCollection matches = Regex.Matches(input, pattern);

        string result = Regex.Replace(input, pattern, m => m.Groups["content"].Value.ToUpper());

        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter some text:");
        string text = Console.ReadLine();

        string result = ConvertToUpperCase(text);

        Console.WriteLine("Your text with the specified regions converted to uppercase:\n{0}", result);
    }
}
