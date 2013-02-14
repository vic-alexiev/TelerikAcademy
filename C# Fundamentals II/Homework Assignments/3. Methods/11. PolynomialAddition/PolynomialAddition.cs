using System;

public class PolynomialAddition
{
    public static int[] AddPolynomials(int[] a, int[] b)
    {
        int maxLength = Math.Max(a.Length, b.Length);
        int minLength = Math.Min(a.Length, b.Length);
        int[] result = new int[maxLength];

        int i;
        for (i = 0; i < minLength; i++)
        {
            result[i] = a[i] + b[i];
        }

        if (minLength < maxLength)
        {
            int[] c = (a.Length == maxLength) ? a : b;

            for (i = minLength; i < maxLength; i++)
            {
                result[i] = c[i];
            }
        }

        i = maxLength - 1;

        while (i > 0 && result[i] == 0)
        {
            i--;
        }

        if (i != maxLength - 1)
        {
            Array.Resize(ref result, i + 1);
        }

        return result;
    }

    static void Main()
    {
        int[] a = new int[] { -5, 6 };
        int[] b = new int[] { 5, -6 };

        int[] result = AddPolynomials(a, b);

        Console.WriteLine(String.Join(" ", result));
    }
}
