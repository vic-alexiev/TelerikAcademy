using System;
using System.Collections;
using System.Collections.Generic;

internal class PrintNumbersInReversedOrder
{
    private static void Main()
    {
        int number;
        int numbersCount;
        string countAsString;
        string numberAsString;

        do
        {
            Console.WriteLine("Enter the number of integers which will be printed in reversed order:");
            countAsString = Console.ReadLine();
        }
        while (!int.TryParse(countAsString, out numbersCount) || numbersCount <= 0);

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < numbersCount; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                numberAsString = Console.ReadLine();
            }
            while (!int.TryParse(numberAsString, out number));

            stack.Push(number);
        }

        Console.WriteLine("Your numbers in reversed order:");

        while (stack.Count != 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}
