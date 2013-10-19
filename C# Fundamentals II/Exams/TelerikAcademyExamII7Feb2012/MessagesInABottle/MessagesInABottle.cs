using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class MessagesInABottle
{
    private static List<Entry> dictionary = new List<Entry>();
    private static StringBuilder messageBuilder = new StringBuilder();
    private static List<string> originalMessages = new List<string>();

    private class Entry
    {
        public char Letter { get; private set; }
        public string Code { get; private set; }

        public Entry(char letter, string code)
        {
            this.Letter = letter;
            this.Code = code;
        }
    }

    private static void InitializeDictionary(string input)
    {
        string pattern = @"(?<letter>[A-Z])(?<code>\d+)";

        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            dictionary.Add(new Entry(match.Groups["letter"].Value[0], match.Groups["code"].Value));
        }

        dictionary.Sort((e, f) => e.Letter.CompareTo(f.Letter));
    }

    private static void FindOriginalMessage(string secretCode)
    {
        if (secretCode == String.Empty)
        {
            originalMessages.Add(messageBuilder.ToString());
            return;
        }

        foreach (Entry entry in dictionary)
        {
            if (secretCode.StartsWith(entry.Code))
            {
                messageBuilder.Append(entry.Letter);

                string restOfSecretCode = secretCode.Substring(entry.Code.Length);

                FindOriginalMessage(restOfSecretCode);

                messageBuilder.Remove(messageBuilder.Length - 1, 1);
            }
        }
    }

    static void Main()
    {
        string secretCode = Console.ReadLine();

        string cipher = Console.ReadLine();

        InitializeDictionary(cipher);

        FindOriginalMessage(secretCode);

        int n = originalMessages.Count;

        Console.WriteLine(n);

        if (n > 0)
        {
            Console.WriteLine(String.Join("\n", originalMessages));
        }
    }
}
