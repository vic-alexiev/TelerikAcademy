using System;
using System.Text.RegularExpressions;

class ReplaceForbiddenWords
{
    private static string ReplaceForbiddenWord(string input, string word)
    {
        string pattern = String.Format(@"\b{0}\b", word);

        string result = Regex.Replace(input, pattern, new String('*', word.Length));

        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter some text: ");
        string text = Console.ReadLine();

        Console.Write("Enter the forbidden words separated with commas: ");
        string inputWords = Console.ReadLine();

        string[] forbiddenWords = inputWords.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Your text with no forbidden words:");

        foreach (string word in forbiddenWords)
        {
            text = ReplaceForbiddenWord(text, word);
        }

        Console.WriteLine(text);
    }
}
