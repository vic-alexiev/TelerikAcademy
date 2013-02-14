using System;

class PrintThreeNumbers
{
    static void Main()
    {
        for (int i = 1; i <= 9; i += 4)
        {
            // print the binary representation of 1 (1), 5 (101), 9 (1001)
            Console.WriteLine(Convert.ToString(i, 2));
        }
    }
}