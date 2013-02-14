using System;

class GetThirdBitOfAnInteger
{
    static void Main()
    {
        byte bitIndex = 3;

        string numberFromConsole;
        uint number;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();
        }
        while (!UInt32.TryParse(numberFromConsole, out number));

        uint mask = 1u << bitIndex;

        uint numberWithMaskApplied = number & mask;

        Console.WriteLine("Your number in binary representation is {0}.\n"
            + "The bit at index {1} (counting from 0, right to left) is {2}.",
            Convert.ToString(number, 2),
            bitIndex,
            numberWithMaskApplied == 0 ? "0" : "1");
    }
}
