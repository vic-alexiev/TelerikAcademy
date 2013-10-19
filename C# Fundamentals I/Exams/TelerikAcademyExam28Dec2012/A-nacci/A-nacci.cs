using System;

class A_nacci
{
    static void Main()
    {
        string firstLetter = Console.ReadLine();

        string secondLetter = Console.ReadLine();

        string numberL = Console.ReadLine();
        int lines = Int32.Parse(numberL);

        int[] abonacciNumbers = new int[lines > 1 ? 2 * lines - 1 : 2];
        int totalCount = 2 * lines - 1;

        abonacciNumbers[0] = firstLetter[0] - 'A' + 1;
        abonacciNumbers[1] = secondLetter[0] - 'A' + 1;

        int a = abonacciNumbers[0];
        int b = abonacciNumbers[1];
        int sum;

        for (int i = 2; i < totalCount; i++)
        {
            sum = (a + b) > 26 ? (a + b) % 26 : a + b;
            a = b;
            b = sum;
            abonacciNumbers[i] = sum;
        }

        Console.WriteLine((char)(abonacciNumbers[0] + 'A' - 1));

        int index = 1;
        for (int i = 1; i < lines; i++)
        {
            Console.WriteLine("{0}{1}{2}",
                (char)(abonacciNumbers[index] + 'A' - 1),
                new String((char)32, i - 1),
                (char)(abonacciNumbers[index + 1] + 'A' - 1));

            index += 2;
        }
    }
}
