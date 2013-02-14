using System;

class PadStringRight
{
    static void Main()
    {
        int width = 20;
        Console.Write("Enter some string: ");
        string input = Console.ReadLine();

        Console.WriteLine("Your text padded with asterisks (*) to {0} characters:\n{1}", width, input.PadRight(width, '*'));
    }
}
