using System;

class SwapBitSequencesInAnInteger
{
    static void Main()
    {
        string numberFromConsole;
        string firstIndexFromConsole;
        string secondIndexFromConsole;
        string sequenceLengthFromConsole;

        // bits to swap reside in number
        uint number;
        // position of the first bit sequence to swap
        byte firstIndex;
        // position of the second bit sequence to swap
        byte secondIndex;
        // number of consecutive bits in each sequence
        byte sequenceLength;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();
        }
        while (!UInt32.TryParse(numberFromConsole, out number));

        Console.WriteLine("Your number in binary representation is {0}.",
            Convert.ToString(number, 2).PadLeft(32, '0'));

        do
        {
            Console.WriteLine("First index:");
            firstIndexFromConsole = Console.ReadLine();
        }
        while (!Byte.TryParse(firstIndexFromConsole, out firstIndex));

        do
        {
            Console.WriteLine("Second index:");
            secondIndexFromConsole = Console.ReadLine();
        }
        while (!Byte.TryParse(secondIndexFromConsole, out secondIndex));

        do
        {
            Console.WriteLine("Number of consecutive bits in each sequence:");
            sequenceLengthFromConsole = Console.ReadLine();
        }
        while (!Byte.TryParse(sequenceLengthFromConsole, out sequenceLength));

        // XOR temporary
        uint temp = ((number >> firstIndex) ^ (number >> secondIndex)) & ((1U << sequenceLength) - 1);
        // bit-swapped result goes here
        uint result = number ^ ((temp << firstIndex) | (temp << secondIndex));

        Console.WriteLine("Your new number ({0}) in binary representation is {1}.",
            result,
            Convert.ToString(result, 2).PadLeft(32, '0'));
    }
}
