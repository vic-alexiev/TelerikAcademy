using System;
using System.Text.RegularExpressions;

public class ReverseNumberDigits
{
    /// <summary>
    /// Checks if the input string starts with a +/- sign
    /// (optionally) and contains only decimal digits (0-9).
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsInteger(string value)
    {
        string pattern = @"^[+-]*[0-9]+$";
        Match match = Regex.Match(value, pattern);
        if (match.Success)
        {
            return true;
        }

        return false;
    }

    public static string ReverseInteger(string value)
    {
        string trimmedValue = value.TrimStart('0');

        int n = trimmedValue.Length;
        char[] reversed = new char[n];

        for (int i = n - 1; i >= 0; i--)
        {
            reversed[n - i - 1] = trimmedValue[i];
        }

        // the input string may contain +/- in front, so we prepend 
        // the sign in the result
        if (reversed[n - 1] == '+' || reversed[n - 1] == '-')
        {
            return String.Format("{0}{1}", reversed[n - 1], new String(reversed, 0, n - 1));
        }

        return new String(reversed);
    }

    public static int ReverseInteger(int value)
    {
        if (value == 0)
        {
            return 0;
        }

        int number = Math.Abs(value);
        int numberReversed = 0;

        while (number > 0)
        {
            int remainder = number % 10;

            checked
            {
                numberReversed = 10 * numberReversed + remainder;
            }

            number /= 10;
        }

        if (value < 0)
        {
            numberReversed = -numberReversed;
        }

        return numberReversed;
    }

    static void Main()
    {
        // I solution
        //int number;
        //string numberAsString;

        //do
        //{
        //    Console.Write("Enter an integer: ");
        //    numberAsString = Console.ReadLine();
        //}
        //while (!Int32.TryParse(numberAsString, out number));

        //int numberReversed = ReverseNumber(number);
        //Console.WriteLine(numberReversed);

        // II solution
        string numberAsString;

        do
        {
            Console.Write("Enter an integer: ");
            numberAsString = Console.ReadLine();
        }
        while (!IsInteger(numberAsString));


        string reversedInteger = ReverseInteger(numberAsString);
        Console.WriteLine(reversedInteger);
    }
}
