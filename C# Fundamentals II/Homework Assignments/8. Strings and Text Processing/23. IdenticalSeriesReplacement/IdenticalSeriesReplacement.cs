using System;
using System.Text;
using System.Text.RegularExpressions;

class IdenticalSeriesReplacement
{
    private static string ReplaceSeriesOfIdenticalLetters1(string input)
    {
        string pattern = @"(\w)\1+";

        string result = Regex.Replace(input, pattern, "$1");

        return result;
    }

    private static string ReplaceSeriesOfIdenticalLetters2(string input)
    {
        char prevCh = '\0';

        StringBuilder builder = new StringBuilder();

        foreach (char ch in input)
        {
            if (ch != prevCh)
            {
                builder.Append(ch);
                prevCh = ch;
            }

        }

        return builder.ToString();
    }

    static void Main(string[] args)
    {
        Console.Write("Enter some string: ");
        string input = Console.ReadLine();

        string result = ReplaceSeriesOfIdenticalLetters1(input);

        Console.WriteLine("The string with the series of identical letters replaced with the same letter:\n{0}", result);
    }
}
