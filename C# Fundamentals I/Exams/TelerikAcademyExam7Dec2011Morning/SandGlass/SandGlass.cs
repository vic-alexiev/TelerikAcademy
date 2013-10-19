using System;

class SandGlass
{
    static void Main()
    {
        string sandGlassHeight = Console.ReadLine();

        int n = Int32.Parse(sandGlassHeight);

        Console.WriteLine(new String('*', n));

        for (int i = 1; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new String('.', i), new String('*', n - 2 * i));
        }

        for (int i = n / 2; i >= 1; i--)
        {
            Console.WriteLine("{0}{1}{0}", new String('.', i), new String('*', n - 2 * i));
        }

        Console.WriteLine(new String('*', n));
    }
}
