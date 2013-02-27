using System;

class IEnumerableExtensionDemo
{
    static void Main()
    {
        float[] floatArray = new float[] { 3.141592f, -90.12f, 4.789f, 0.177f };
        float minFloat = floatArray.Min();
        Console.WriteLine(minFloat);

        double[] doubleArray = new double[] { 9.23423, 2.718281828, -18.39, 7.61, -10.11 };
        double maxDouble = doubleArray.Max();
        Console.WriteLine(maxDouble);

        string[] stringsArray = new string[] { "ala", "bala", "porto", "kala", "aaalaaa" };
        string minString = stringsArray.Min();
        Console.WriteLine(minString);

        decimal[] decimalArray = new decimal[] { 23, 8.14M, 0.1023M, -13 };
        decimal sum = decimalArray.Sum();
        Console.WriteLine(sum);

        long[] longArray = new long[] { 13, 90, -10, 4, 76 };
        long product = longArray.Product();
        Console.WriteLine(product);

        int[] intArray = new int[] { 1, 2, 3, 4, 5, 6 };
        decimal average = intArray.Average();
        Console.WriteLine(average);
    }
}
