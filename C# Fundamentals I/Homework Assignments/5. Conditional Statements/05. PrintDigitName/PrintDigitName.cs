using System;

class PrintDigitName
{
    static void Main()
    {
        string digitAsString;
        byte digit;

        do
        {
            Console.Write("Enter a digit (0, ..., 9): ");
            digitAsString = Console.ReadLine();
        }
        while (!Byte.TryParse(digitAsString, out digit));

        switch (digit)
        {
            case 1:
                {
                    Console.WriteLine("One");
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Two");
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Three");
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Four");
                    break;
                }
            case 5:
                {
                    Console.WriteLine("Five");
                    break;
                }
            case 6:
                {
                    Console.WriteLine("Six");
                    break;
                }
            case 7:
                {
                    Console.WriteLine("Seven");
                    break;
                }
            case 8:
                {
                    Console.WriteLine("Eight");
                    break;
                }
            case 9:
                {
                    Console.WriteLine("Nine");
                    break;
                }
            case 0:
                {
                    Console.WriteLine("Zero");
                    break;
                }
            default:
                {
                    Console.WriteLine("This is not a digit!");
                    break;
                }
        }
    }
}
