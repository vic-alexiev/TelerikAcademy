using System;

class PrintAlternatingSequence
{
    static void Main()
    {
        //for (int i = 2; i < 12; i++)
        //{
        //    Console.WriteLine((i * Math.Pow(-1, i)).ToString().PadLeft(3, ' '));
        //}

        int sign = -1;
        for (int j = 2; j < 12; j++)
        {
            sign *= -1;
            Console.WriteLine((sign * j).ToString().PadLeft(3, ' '));
        }
    }
}
