using System;
using System.Linq;
using System.Text;

class ReverseString
{
    private static string Reverse1(string value)
    {
        StringBuilder builder = new StringBuilder(value.Length);

        foreach (char item in value)
        {
            builder.Insert(0, item);
        }

        return builder.ToString();
    }

    private static string Reverse2(string value)
    {
        int n = value.Length;

        char[] reversed = new char[n];

        for (int i = n - 1; i >= 0; i--)
        {
            reversed[n - i - 1] = value[i];
        }

        return new String(reversed);
    }

    static void Main()
    {
        Console.Write("Enter some word: ");
        string word = Console.ReadLine();

        // I solution
        //string wordReversed = new String(word.Reverse().ToArray<char>());

        // II solution
        //string wordReversed = Reverse1(word);

        // III solution
        string wordReversed = Reverse2(word);

        Console.WriteLine("Your word reversed: {0}", wordReversed);
    }
}
