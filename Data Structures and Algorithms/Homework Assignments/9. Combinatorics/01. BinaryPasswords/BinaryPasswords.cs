using System;

internal class BinaryPasswords
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        long passwordsCount = 1;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '*')
            {
                passwordsCount *= 2;
            }
        }

        Console.WriteLine(passwordsCount);
    }
}
