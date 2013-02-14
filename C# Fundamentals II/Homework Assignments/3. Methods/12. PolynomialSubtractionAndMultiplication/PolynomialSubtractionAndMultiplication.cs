using System;

public class PolynomialSubtractionAndMultiplication
{
    public static void MultiplyPolynomialByConstant(int[] array, int c)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= c;
        }
    }

    public static int[] SubtractPolynomials(int[] a, int[] b)
    {
        MultiplyPolynomialByConstant(b, -1);
        return PolynomialAddition.AddPolynomials(a, b);
    }

    public static int[] MultiplyPolynomials(int[] a, int[] b)
    {
        int n = a.Length;
        int m = b.Length;
        int[] c = new int[n + m - 1];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                c[i + j] = c[i + j] + a[i] * b[j];
            }
        }

        return c;
    }

    static void Main()
    {
        //int[] a = new int[] { 1, 1, 0, 1 };
        //int[] b = new int[] { 1, 0, -1 };

        int[] a = new int[] { 2, 1 };
        int[] b = new int[] { -17, 4, 3, 1 };

        int[] result = MultiplyPolynomials(a, b);

        Console.WriteLine(String.Join(" ", result));
    }
}
