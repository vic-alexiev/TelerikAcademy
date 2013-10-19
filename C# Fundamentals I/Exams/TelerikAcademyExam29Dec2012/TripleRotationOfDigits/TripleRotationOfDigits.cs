using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        string number = Console.ReadLine();
        int n = Int32.Parse(number);

        for (int i = 0; i < 3; i++)
        {
            if (n >= 10)
            {
                int tail = n % 10;
                int head = n / 10;
                n = Int32.Parse("" + tail + head);
            }
        }

        Console.WriteLine(n);
    }
}
