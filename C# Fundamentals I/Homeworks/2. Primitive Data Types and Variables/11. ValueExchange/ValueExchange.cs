using System;

class ValueExchange
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        Console.WriteLine("a: {0}, b: {1}", a, b);

        // swap the values using a third variable
        //int c = b;
        //b = a;
        //a = c;

        // swap the values with no extra variable
        a = a + b;
        b = a - b;
        a = a - b;

        //b ^= a;
        //a ^= b;
        //b ^= a;

        Console.WriteLine("a: {0}, b: {1}", a, b);        
    }
}
