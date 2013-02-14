using System;

class Swap3SpecifiedBitsInAnInteger
{
    static void Main()
    {
        string numberFromConsole;

        // bits to swap reside in number
        uint number;
        // position of the first bit sequence to swap
        byte firstIndex = 3;
        // position of the second bit sequence to swap
        byte secondIndex = 24;
        // number of consecutive bits in each sequence
        byte sequenceLength = 3;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();
        }
        while (!UInt32.TryParse(numberFromConsole, out number));

        Console.WriteLine("Your number in binary representation is {0}.",
            Convert.ToString(number, 2).PadLeft(32, '0'));

        // XOR temporary
        uint temp = ((number >> firstIndex) ^ (number >> secondIndex)) & ((1U << sequenceLength) - 1);
        // bit-swapped result goes here
        uint result = number ^ ((temp << firstIndex) | (temp << secondIndex));

        Console.WriteLine("Your new number ({0}) in binary representation is {1}.",
            result,
            Convert.ToString(result, 2).PadLeft(32, '0'));
    }
}
