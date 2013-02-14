using System;
using System.Linq;
using System.Numerics;

public class CalculateNFactorialUsingIntArrays
{
    /// <summary>
    /// http://stackoverflow.com/questions/1489830/efficient-way-to-determine-number-of-digits-in-an-integer
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private static int GetDigitsCount(int x)
    {
        if (x == Int32.MinValue) return 10 + 1;
        if (x < 0) return GetDigitsCount(-x) + 1;

        if (x >= 10000)
        {
            if (x >= 10000000)
            {
                if (x >= 100000000)
                {
                    if (x >= 1000000000)
                        return 10;
                    return 9;
                }
                return 8;
            }
            if (x >= 100000)
            {
                if (x >= 1000000)
                    return 7;
                return 6;
            }
            return 5;
        }
        if (x >= 100)
        {
            if (x >= 1000)
                return 4;
            return 3;
        }
        if (x >= 10)
            return 2;
        return 1;
    }

    private static int[] ConvertPositiveIntegerToArrayOfDigits(int number)
    {
        int[] array = new int[GetDigitsCount(number)];

        int i = 0;
        while (number > 0)
        {
            int remainder = number % 10;

            array[i++] = remainder;

            number /= 10;
        }

        return array;
    }

    public static int[] MultiplyPositiveIntegers(int[] a, int[] b)
    {
        int n = a.Length;
        int m = b.Length;

        // LEN(c) = LEN(a) + LEN(b)
        int[] c = new int[n + m];
        int temp;
        int carry = 0;

        for (int i = 0; i < n; i++)
        {
            carry = 0;

            for (int j = 0; j < m; j++)
            {
                temp = c[i + j] + a[i] * b[j] + carry;
                c[i + j] = temp % 10;
                carry = temp / 10;
            }

            if (carry > 0)
            {
                c[i + m] = carry;
            }
        }

        if (carry > 0)
        {
            c[n + m - 1] = carry;
        }

        // if the last element is zero (a leading zero in the result) - remove it
        if (c[n + m - 1] == 0)
        {
            Array.Resize(ref c, n + m - 1);
        }

        return c;
    }

    /// <summary>
    /// An iterative version.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int[] Factorial1(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("The argument cannot be negative.");
        }

        if (n == 0 || n == 1)
        {
            return new int[] { 1 };
        }

        if (n == 2)
        {

            return new int[] { 2 };
        }

        if (n == 3)
        {

            return new int[] { 6 };
        }

        int[] factorial = new int[] { 4, 2 };

        for (int i = 5; i <= n; i++)
        {
            factorial = MultiplyPositiveIntegers(factorial, ConvertPositiveIntegerToArrayOfDigits(i));
        }

        return factorial;
    }

    /// <summary>
    /// A recursive version.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int[] Factorial2(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("The argument cannot be negative.");
        }

        if (n == 0 || n == 1)
        {
            return new int[] { 1 };
        }

        if (n == 2)
        {

            return new int[] { 2 };
        }

        if (n == 3)
        {

            return new int[] { 6 };
        }

        return MultiplyPositiveIntegers(
            Factorial2(n - 1),
            ConvertPositiveIntegerToArrayOfDigits(n));
    }

    public static BigInteger Factorial3(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("The argument cannot be negative.");
        }

        if (n == 0 || n == 1)
        {
            return 1;
        }

        BigInteger factorial = 2;

        for (int i = 3; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }

    static void Main()
    {
        while (true)
        {
            Console.Write("Enter N: ");
            string number = Console.ReadLine();
            int n = Int32.Parse(number);

            // I solution
            int[] factorial = Factorial1(n);

            Console.WriteLine(String.Join(String.Empty, factorial.Reverse()));

            // II solution (using BigInteger)
            //BigInteger result = Factorial3(n);

            //Console.WriteLine(result);
        }
    }
}
