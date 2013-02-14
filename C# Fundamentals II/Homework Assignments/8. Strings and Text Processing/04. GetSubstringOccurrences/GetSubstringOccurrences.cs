using System;

class GetSubstringOccurrences
{
    private static int GetStringOccurrences(string input, string value, bool ignoreCase)
    {
        if (ignoreCase)
        {
            input = input.ToUpper();
            value = value.ToUpper();
        }

        int count = 0;
        int index = input.IndexOf(value, 0);

        while (index != -1)
        {
            count++;
            index = input.IndexOf(value, index + 1);
        }

        return count;
    }

    static void Main()
    {
        Console.WriteLine("Enter some text:");
        string text = Console.ReadLine();

        Console.Write("Enter the string to search for: ");
        string stringToSearch = Console.ReadLine();

        int count = GetStringOccurrences(text, stringToSearch, true);

        Console.WriteLine("\"{0}\" occurs {1} times as a substring.", stringToSearch, count);
    }
}
