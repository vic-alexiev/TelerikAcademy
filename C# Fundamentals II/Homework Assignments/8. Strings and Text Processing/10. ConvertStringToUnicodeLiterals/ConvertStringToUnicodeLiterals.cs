using System;

class ConvertStringToUnicodeLiterals
{
    static void Main()
    {
        Console.Write("Enter some string: ");
        string input = Console.ReadLine();

        Console.WriteLine("Your string as a sequence of Unicode literals:");

        foreach (char ch in input)
        {
            Console.Write("\\u{0:x4}", (ushort)ch);
        }

        Console.WriteLine();
    }
}
