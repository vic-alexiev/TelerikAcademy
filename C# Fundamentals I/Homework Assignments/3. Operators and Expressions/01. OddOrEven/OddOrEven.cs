using System;

class OddOrEven
{
    static void Main()
    {
        string numberFromConsole;
        uint number;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();

        }
        while (!UInt32.TryParse(numberFromConsole, out number));

        Console.WriteLine("Your number is {0}.", (number % 2) == 0 ? "even" : "odd");

        //Console.WriteLine("Your number is {0}.", (number & 1U) == 0 ? "even" : "odd");
    }
}
