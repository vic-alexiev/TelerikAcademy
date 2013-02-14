using System;

class PrintLastDigit
{
    private static string GetDigitAsWord(int digit)
    {
        switch (digit)
        {
            case 0:
                {
                    return "zero";
                }
            case 1:
                {
                    return "one";
                }
            case 2:
                {
                    return "two";
                }
            case 3:
                {
                    return "three";
                }
            case 4:
                {
                    return "four";
                }
            case 5:
                {
                    return "five";
                }
            case 6:
                {
                    return "six";
                }
            case 7:
                {
                    return "seven";
                }
            case 8:
                {
                    return "eight";
                }
            case 9:
                {
                    return "nine";
                }
            default:
                {
                    return "Unknown digit";
                }
        }
    }

    static void Main()
    {
        int number;
        string numberAsString;
        do
        {
            Console.Write("Enter an integer: ");
            numberAsString = Console.ReadLine();
        }
        while (!Int32.TryParse(numberAsString, out number));

        int lastDigit = Math.Abs(number) % 10;

        string lastDigitAsWord = GetDigitAsWord(lastDigit);

        Console.WriteLine("Your number's last digit is {0}.", lastDigitAsWord);
    }
}
