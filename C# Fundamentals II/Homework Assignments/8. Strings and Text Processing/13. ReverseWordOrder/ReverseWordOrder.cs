using System;
using System.Text.RegularExpressions;

class ReverseWordOrder
{
    private static string ReverseWordsOrder(string input)
    {
        string pattern = @"[^\s\.;,?!]+";

        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(input);

        int startAt = 0;
        string buffer = input;
        int n = matches.Count;

        // take the last match and put it at first position, take the next to the last match and
        // put it at second position, etc.
        for (int i = n - 1; i >= 0; i--)
        {
            string word = matches[i].Value;
            buffer = regex.Replace(buffer, word, 1, startAt);
            // re-calculate the value of startAt index - put it always after the word that has just been replaced
            startAt = buffer.IndexOf(word, startAt) + word.Length;
        }

        return buffer;
    }

    static void Main()
    {
        Console.WriteLine("Enter a valid sentence:");
        string sentence = Console.ReadLine();

        string result = ReverseWordsOrder(sentence);

        Console.WriteLine("The sentence with words in reversed order:\n{0}", result);
    }
}
