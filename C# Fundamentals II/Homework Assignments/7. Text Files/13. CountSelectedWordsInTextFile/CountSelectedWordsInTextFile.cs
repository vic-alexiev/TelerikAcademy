using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class CountSelectedWordsInTextFile
{
    private static int CountWordOccurrences(string input, string wordToFind)
    {
        string pattern = String.Format(@"\b{0}\b", wordToFind);

        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
        return matches.Count;
    }

    static void Main()
    {
        string wordsFilePath;

        do
        {
            Console.Write("Enter the path of the file containing words to count: ");
            wordsFilePath = Console.ReadLine();
        }
        while (!File.Exists(wordsFilePath));

        string sourceFilePath;

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourceFilePath = Console.ReadLine();
        }
        while (!File.Exists(sourceFilePath));

        string extension = Path.GetExtension(sourceFilePath);

        string resultFilePath = sourceFilePath.Replace(extension, "_wordscount.txt");

        try
        {
            Dictionary<string, int> wordsToCount = new Dictionary<string, int>();
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string line;
                while ((line = wordsReader.ReadLine()) != null)
                {
                    // initially word count for each word is 0
                    wordsToCount.Add(line, 0);
                }
            }

            // it is not possible to iterate over the dictionary and update
            // its contents at the same time, so we need an extra list
            List<string> wordsList = new List<string>(wordsToCount.Keys);

            using (StreamReader reader = new StreamReader(sourceFilePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    foreach (string word in wordsList)
                    {
                        wordsToCount[word] += CountWordOccurrences(line, word);
                    }
                }
            }

            KeyValuePair<string, int>[] wordOccurrences = wordsToCount.ToArray<KeyValuePair<string, int>>();

            Array.Sort(wordOccurrences, (v, w) => w.Value.CompareTo(v.Value));

            using (StreamWriter writer = new StreamWriter(resultFilePath, false))
            {
                foreach (KeyValuePair<string, int> record in wordOccurrences)
                {
                    writer.WriteLine("{0}: {1}", record.Key, record.Value);
                }
            }

            Console.WriteLine("\"{0}\" saved successfully.", resultFilePath);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
    }
}
