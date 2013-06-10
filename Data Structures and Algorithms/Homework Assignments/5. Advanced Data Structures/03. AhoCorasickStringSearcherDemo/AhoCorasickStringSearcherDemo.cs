using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class AhoCorasickStringSearcherDemo
{
    private static void Main()
    {
        string sourceFilePath = "../../Resources/PrideAndPrejudice.txt";
        string wordsFilePath = "../../Resources/Words.txt";
        string resultFilePath = "../../Resources/Result.txt";

        string text = File.ReadAllText(sourceFilePath);
        string[] words = File.ReadAllLines(wordsFilePath);

        AhoCorasickStringSearcher searcher = new AhoCorasickStringSearcher(words);

        searcher.OutputTree(Console.Out);

        var results = searcher.FindAll(text, 0);

        SortedDictionary<string, int> occurrences = new SortedDictionary<string, int>();

        // put the results in a dictionary  
        foreach (StringSearchResult result in results)
        {
            if (!occurrences.ContainsKey(result.Value))
            {
                occurrences[result.Value] = 1;
            }
            else
            {
                occurrences[result.Value]++;
            }
        }

        StringBuilder statistics = new StringBuilder();

        int index = 0;

        foreach (var occurrence in occurrences)
        {
            index++;
            statistics.AppendFormat(
                "{0, 5}. {1} -> {2}{3}",
                index,
                occurrence.Key,
                occurrence.Value,
                Environment.NewLine);
        }

        File.WriteAllText(resultFilePath, statistics.ToString());
    }
}
