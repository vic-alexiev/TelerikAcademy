using System;

class GetBitValueFromAnInteger
{
    static void Main()
    {
        string numberFromConsole;
        string bitIndexFromConsole;

        uint number;
        byte bitIndex;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();
        }
        while (!UInt32.TryParse(numberFromConsole, out number));

        do
        {
            Console.WriteLine("Bit index (starting from 0, right to left):");
            bitIndexFromConsole = Console.ReadLine();
        }
        while (!Byte.TryParse(bitIndexFromConsole, out bitIndex));

        uint mask = 1U << bitIndex;

        uint numberWithMaskApplied = number & mask;

        Console.WriteLine("Your number in binary representation is {0}.\n"
            + "The bit at index {1} (starting from 0, right to left) is {2}.",
            Convert.ToString(number, 2),
            bitIndex,
            numberWithMaskApplied == 0 ? "0" : "1");
    }
}
