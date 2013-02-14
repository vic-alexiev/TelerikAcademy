using System;
using System.Collections.Generic;

class EnglishToEnglishDictionary
{
    private static Dictionary<string, string> glossary;

    private static void InitializeGLossary(string data)
    {
        string[] entries = data.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        glossary = new Dictionary<string, string>();

        foreach (string entry in entries)
        {
            // when data comes from text editing software (e.g. MS Word) its hyphen (minus) characters
            // could come (and most often do) as figure dash, en dash, em dash and other typography dashes
            // which can break the Split function - so we add them too
            string[] entryData = entry.Split(new char[] { '\u002D', '\u2012', '\u2013', '\u2014', '\u2015' }, StringSplitOptions.RemoveEmptyEntries);
            glossary.Add(entryData[0].Trim(), entryData[1].Trim());
        }
    }

    static void Main()
    {
        string data = ".NET – platform for applications from Microsoft\n" +
            "CLR – managed execution environment for .NET\n" +
            "namespace – hierarchical organization of classes";

        InitializeGLossary(data);

        Console.Write("Enter a word to see its meaning: ");
        string word = Console.ReadLine();

        word = word.Trim();

        if (glossary.ContainsKey(word))
        {
            Console.WriteLine("Meaning: {0}", glossary[word]);
        }
        else
        {
            Console.WriteLine("We regret to inform you that \"{0}\" is not in our glossary.", word);
        }
    }
}
