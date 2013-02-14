using System;

class PrintSquareOf12345
{
    static void Main()
    {
        int a = 12345;
        Console.WriteLine(a * a);

        // an overkill since Pow solves a more general problem (=> slower)
        double square = Math.Pow(a, 2);
        Console.WriteLine(square);
    }
}
