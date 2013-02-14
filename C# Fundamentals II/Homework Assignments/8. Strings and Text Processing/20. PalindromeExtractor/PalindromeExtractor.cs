using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class PalindromeExtractor
{
    private static List<string> GetPalindromes1(string input)
    {
        string pattern = @"\b\w+\b";

        MatchCollection matches = Regex.Matches(input, pattern);

        List<string> palindromes = new List<string>();

        foreach (Match match in matches)
        {
            char[] asCharArray = match.Value.ToCharArray();
            Array.Reverse(asCharArray);
            if (match.Value == String.Join(String.Empty, asCharArray))
            {
                palindromes.Add(match.Value);
            }
        }

        return palindromes;
    }

    /// <summary>
    /// <see cref="http://blog.stevenlevithan.com/archives/balancing-groups"/>
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static List<string> GetPalindromes2(string input)
    {
        string pattern = @"\b(?<N>.)+.?(?<-N>\k<N>)+(?(N)(?!))\b";

        MatchCollection matches = Regex.Matches(input, pattern);

        List<string> palindromes = new List<string>();

        foreach (Match match in matches)
        {
            palindromes.Add(match.Value);
        }

        return palindromes;
    }

    static void Main()
    {
        string text = "Alsdfglskdjfh ABBA? lamal, weuwyuqichd, drawocoward." +
            "This is your exe.";

        List<string> palindromesList = GetPalindromes1(text);

        Console.WriteLine("Palindromes:");

        foreach (string palindrome in palindromesList)
        {
            Console.WriteLine(palindrome);
        }
    }
}
