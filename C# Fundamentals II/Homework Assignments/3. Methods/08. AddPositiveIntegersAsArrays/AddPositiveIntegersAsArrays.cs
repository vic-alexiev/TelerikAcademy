using System;
using System.Text.RegularExpressions;

public class AddPositiveIntegersAsArrays
{
    private const int MAX_LENGTH = 10000;

    /// <summary>
    /// Checks if the string represents a valid integer (leading zeros are allowed),
    /// no "+" sign in front.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static bool IsPositiveInteger(string value)
    {
        string pattern = @"^0*[1-9]+$";
        Match match = Regex.Match(value, pattern);
        if (match.Success)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Works for positive integers (no "+" sign in front).
    /// </summary>
    /// <param name="numberString"></param>
    /// <returns></returns>
    private static int[] ConvertStringToArrayOfDigits(string numberString)
    {
        string trimmedNumber = numberString.TrimStart('0');

        int n = trimmedNumber.Length;

        int[] array = new int[n];

        // put the digits in the integer array in reversed order
        for (int i = n - 1; i >= 0; i--)
        {
            array[n - i - 1] = trimmedNumber[i] - '0';
        }

        return array;
    }

    /// <summary>
    /// Adds two integers represented as arrays of their digits.
    /// The ones digit is kept in array[0], the tens digit - in array[1]
    /// and so on. Works if both arguments are positive or one is zero and
    /// the other positive.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private static int[] AddPositiveIntegers(int[] a, int[] b)
    {
        if (a.Length > MAX_LENGTH || b.Length > MAX_LENGTH)
        {
            throw new ArgumentException("Argument too large.");
        }

        int maxLength = Math.Max(a.Length, b.Length);
        int minLength = Math.Min(a.Length, b.Length);

        // LEN(result) := MAX(LEN(a), LEN(b)) + 1 
        int[] result = new int[maxLength + 1];

        int i;
        int temp;
        int carry = 0;
        for (i = 0; i < minLength; i++)
        {
            temp = a[i] + b[i] + carry;
            result[i] = temp % 10;
            carry = temp / 10;
        }

        if (minLength == maxLength)
        {
            if (carry > 0)
            {
                result[minLength] = carry;
            }
        }
        else
        {
            int[] c = (a.Length == maxLength) ? a : b;

            for (i = minLength; i < maxLength; i++)
            {
                temp = c[i] + carry;
                result[i] = temp % 10;
                carry = temp / 10;
            }

            if (carry > 0)
            {
                result[maxLength] = carry;
            }
        }

        // the result may have a leading zero (the last element in the array of its digits),
        // so we remove it
        if (result[maxLength] == 0)
        {
            Array.Resize(ref result, maxLength);
        }

        return result;
    }

    public static string AddPositiveIntegers(string value1, string value2)
    {
        if (!IsPositiveInteger(value1) || !IsPositiveInteger(value2))
        {
            throw new ArgumentException("Value is not a positive integer.");
        }

        int[] number1 = ConvertStringToArrayOfDigits(value1);
        int[] number2 = ConvertStringToArrayOfDigits(value2);

        int[] sum = AddPositiveIntegers(number1, number2);

        Array.Reverse(sum);

        string result = String.Join(String.Empty, sum);

        return result;
    }

    static void Main()
    {
        string number1String;
        string number2String;

        do
        {
            Console.Write("Enter first positive integer: ");
            number1String = Console.ReadLine();
        }
        while (!IsPositiveInteger(number1String));

        do
        {
            Console.Write("Enter second positive integer: ");
            number2String = Console.ReadLine();
        }
        while (!IsPositiveInteger(number2String));

        string result = AddPositiveIntegers(number1String, number2String);

        Console.WriteLine("{0} + {1} = {2}.", number1String.TrimStart('0'), number2String.TrimStart('0'), result);
    }
}
