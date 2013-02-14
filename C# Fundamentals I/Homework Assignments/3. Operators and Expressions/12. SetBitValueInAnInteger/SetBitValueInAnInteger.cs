using System;

class SetBitValueInAnInteger
{
    static void Main()
    {
        string numberFromConsole;
        string bitIndexFromConsole;
        string newBitValueFromConsole;

        uint number;
        byte bitIndex;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();
        }
        while (!UInt32.TryParse(numberFromConsole, out number));

        Console.WriteLine("Your number in binary representation is {0}.",
            Convert.ToString(number, 2));

        do
        {
            Console.WriteLine("Bit index (starting from 0, right to left):");
            bitIndexFromConsole = Console.ReadLine();
        }
        while (!Byte.TryParse(bitIndexFromConsole, out bitIndex));

        do
        {
            Console.WriteLine("New bit value (0 or 1):");
            newBitValueFromConsole = Console.ReadLine();
        }
        while (newBitValueFromConsole != "0" && newBitValueFromConsole != "1");

        uint mask = 1U << bitIndex;

        if (newBitValueFromConsole == "1")
        {
            number |= mask;
        }
        else
        {
            number &= ~mask;
        }

        Console.WriteLine("Your new number ({0}) in binary representation is {1}.",
            number,
            Convert.ToString(number, 2));
    }
}
