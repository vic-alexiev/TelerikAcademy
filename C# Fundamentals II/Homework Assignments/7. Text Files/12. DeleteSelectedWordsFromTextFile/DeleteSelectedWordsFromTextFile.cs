using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class DeleteSelectedWordsFromTextFile
{
    private static string RemoveWord(string input, string wordToFind)
    {
        string pattern = String.Format(@"\b{0}\b", wordToFind);

        string result = Regex.Replace(input, pattern, String.Empty);
        return result;
    }

    static void Main()
    {
        string wordsFilePath;

        do
        {
            Console.Write("Enter the path of the file containing words to remove: ");
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

        string tempFilePath = sourceFilePath.Insert(sourceFilePath.LastIndexOf(extension), "_tmp");

        try
        {
            List<string> wordsToRemove = new List<string>();
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string line;
                while ((line = wordsReader.ReadLine()) != null)
                {
                    wordsToRemove.Add(line);
                }
            }

            using (StreamReader reader = new StreamReader(sourceFilePath))
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath, false))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string buffer = line;
                        foreach (string word in wordsToRemove)
                        {
                            buffer = RemoveWord(buffer, word);
                        }

                        writer.WriteLine(buffer);
                    }
                }
            }

            File.Delete(sourceFilePath);

            File.Move(tempFilePath, sourceFilePath);

            Console.WriteLine("\"{0}\" saved successfully.", sourceFilePath);
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
