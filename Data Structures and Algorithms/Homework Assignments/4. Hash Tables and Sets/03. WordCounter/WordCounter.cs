using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal class WordCounter
{
    private static IOrderedEnumerable<KeyValuePair<string, int>> GetWordOccurrences(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("path cannot be null or empty.", "path");
        }

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Could not find the file specified.", path);
        }

        Dictionary<string, int> occurrences = new Dictionary<string, int>();

        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(
                    new char[] { ' ', ',', ';', '.', '?', '!', '"', '\'', ':' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    string wordNoCaps = word.ToLower();
                    if (!occurrences.ContainsKey(wordNoCaps))
                    {
                        occurrences[wordNoCaps] = 1;
                    }
                    else
                    {
                        occurrences[wordNoCaps]++;
                    }
                }
            }
        }

        var occurrencesSorted =
            from entry in occurrences
            orderby entry.Value ascending
            select entry;

        return occurrencesSorted;
    }

    private static void Main()
    {
        string sourceFilePath = "../../Resources/PrideAndPrejudice.txt";
        string resultFilePath = "../../Resources/result.txt";

        var occurrences = GetWordOccurrences(sourceFilePath);

        StringBuilder result = new StringBuilder();

        int index = 0;

        foreach (var occurrence in occurrences)
        {
            index++;
            result.AppendFormat(
                "{0, 5}. {1} -> {2}{3}",
                index,
                occurrence.Key,
                occurrence.Value,
                Environment.NewLine);
        }

        File.WriteAllText(resultFilePath, result.ToString());
    }
}
