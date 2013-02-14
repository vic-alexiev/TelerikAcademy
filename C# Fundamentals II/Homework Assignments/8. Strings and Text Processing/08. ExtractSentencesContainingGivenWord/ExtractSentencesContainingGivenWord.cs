using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ExtractSentencesContainingGivenWord
{
    private static bool Contains(string input, string wordToFind)
    {
        string pattern = String.Format(@"\b{0}\b", wordToFind);

        Match match = Regex.Match(input, pattern);

        return match.Success;
    }

    private static List<string> GetSentencesContaining(string input, string wordToFind)
    {
        string pattern = String.Format(@"[^\.]*?\b{0}\b[^\.?!]*[\.?!]", wordToFind);

        MatchCollection matches = Regex.Matches(input, pattern);

        List<string> matchesList = new List<string>();

        foreach (Match match in matches)
        {
            matchesList.Add(match.Value.TrimStart());
        }

        return matchesList;
    }

    static void Main()
    {
        Console.WriteLine("Enter some text: ");
        string text = Console.ReadLine();

        Console.Write("Enter the word to search for: ");
        string wordToFind = Console.ReadLine();

        // I solution
        //List<string> sentences = GetSentencesContaining(text, wordToFind);

        //Console.WriteLine("List of the sentences containing \"{0}\":", wordToFind);

        //Console.WriteLine(String.Join("\n", sentences));

        // II solution
        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("List of the sentences containing \"{0}\":", wordToFind);

        foreach (string sentence in sentences)
        {
            if (Contains(sentence, wordToFind))
            {
                Console.WriteLine("{0}.", sentence.TrimStart());
            }
        }
    }
}