using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CountAndPrintDifferentWords
{
    private static Dictionary<string, int> GetWordsOccurrences(string input)
    {
        string pattern = @"\b[^\s\.,;!?]+\b";
        MatchCollection matches = Regex.Matches(input, pattern);

        Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

        foreach (Match match in matches)
        {
            string word = match.Value;
            if (!wordOccurrences.ContainsKey(word))
            {
                wordOccurrences.Add(word, 0);
            }

            wordOccurrences[word]++;
        }

        return wordOccurrences;
    }

    static void Main()
    {
        Console.WriteLine("Enter some text:");
        string text = Console.ReadLine();

        Dictionary<string, int> words = GetWordsOccurrences(text);

        KeyValuePair<string, int>[] wordsArray = words.ToArray<KeyValuePair<string, int>>();
        Array.Sort(wordsArray, (a, b) => a.Key.CompareTo(b.Key));

        Console.WriteLine("Words:");

        foreach (KeyValuePair<string, int> item in wordsArray)
        {
            Console.WriteLine("{0}: {1} occurrence(s)", item.Key, item.Value);
        }
    }
}
