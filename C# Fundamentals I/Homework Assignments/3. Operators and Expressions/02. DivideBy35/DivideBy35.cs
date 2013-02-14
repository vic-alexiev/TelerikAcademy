using System;

class DivideBy35
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

        Console.WriteLine("Your number is{0} a multiple of 35.", number % 35 == 0 ? String.Empty : " not");
    }
}
