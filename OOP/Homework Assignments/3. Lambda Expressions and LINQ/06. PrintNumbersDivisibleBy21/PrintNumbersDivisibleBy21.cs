using System;
using System.Linq;

class PrintNumbersDivisibleBy21
{
    static void Main()
    {
        int[] integers = new int[] { 1, 89, 34, 281, 42, 210, 2319653, 84 };

        // I solution - lambda expressions
        var multiplesOf21 = integers.Where(i => i % 21 == 0);

        foreach (int item in multiplesOf21)
        {
            Console.WriteLine(item);
        }

        // II solution - LINQ
        var multiplesOfBoth3And7 =
            from integer in integers
            where integer % 21 == 0
            select integer;

        foreach (int item in multiplesOfBoth3And7)
        {
            Console.WriteLine(item);
        }
    }
}
