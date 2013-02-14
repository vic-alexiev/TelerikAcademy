using System;

class CipherText
{
    private static string Cipher(string input, string key)
    {
        if (String.IsNullOrWhiteSpace(input) || String.IsNullOrWhiteSpace(key))
        {
            return input;
        }

        int n = input.Length;
        int m = key.Length;

        char[] cipheredMessage = new char[n];

        for (int i = 0; i < n; i++)
        {
            if (!Char.IsWhiteSpace(input[i]))
            {
                cipheredMessage[i] = (char)(input[i] ^ key[i % m]);
            }
            else
            {
                cipheredMessage[i] = input[i];
            }
        }

        return new String(cipheredMessage);
    }

    static void Main()
    {
        Console.Write("Enter some string: ");
        string message = Console.ReadLine();

        Console.Write("Enter the cipher: ");
        string key = Console.ReadLine();

        string cipheredMessage = Cipher(message, key);

        Console.WriteLine("Your string ciphered:");

        foreach (char c in cipheredMessage)
        {
            Console.Write("\\u{0:x4}", (ushort)c);
        }

        Console.WriteLine();
    }
}