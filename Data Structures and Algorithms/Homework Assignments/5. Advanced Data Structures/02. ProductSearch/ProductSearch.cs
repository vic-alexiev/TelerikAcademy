using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Wintellect.PowerCollections;

internal class ProductSearch
{
    private static Random randomNumberGenerator = new Random();
    private const string chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()-_=+[{]};:'\",<.>/? ";

    private static string GetRandomString(int size)
    {
        char[] buffer = new char[size];
        int length = chars.Length;

        for (int i = 0; i < size; i++)
        {
            buffer[i] = chars[randomNumberGenerator.Next(length)];
        }

        return new string(buffer);
    }

    private static string[] GetRandomStringArray(int length, int stringMaxSize)
    {
        string[] value = new string[length];

        for (int i = 0; i < value.Length; i++)
        {
            value[i] = GetRandomString(randomNumberGenerator.Next(1, stringMaxSize + 1));
        }

        return value;
    }

    private static double[] GetRandomDoubleArray(int length, double maxValue)
    {
        double[] value = new double[length];

        for (int i = 0; i < value.Length; i++)
        {
            value[i] = randomNumberGenerator.NextDouble() * maxValue;
        }

        return value;
    }

    private static void GetRangeBounds(double maxValue, out double lowerBound, out double upperBound)
    {
        double midValue = randomNumberGenerator.NextDouble() * maxValue;

        lowerBound = randomNumberGenerator.NextDouble() * midValue;
        upperBound = midValue + randomNumberGenerator.NextDouble() * (maxValue - midValue);
    }

    private static void CreateProductsFile(string path, int productsCount, double maxPrice, int nameMaxLength)
    {
        double[] pricesArray = GetRandomDoubleArray(productsCount, maxPrice);
        string[] namesArray = GetRandomStringArray(productsCount, nameMaxLength);

        using (StreamWriter writer = new StreamWriter(path, false))
        {
            for (int i = 0; i < productsCount; i++)
            {
                writer.WriteLine("{0} | {1:F2}", namesArray[i], pricesArray[i]);
            }
        }
    }

    private static OrderedMultiDictionary<double, string> ReadProducts(string path)
    {
        OrderedMultiDictionary<double, string> products = new OrderedMultiDictionary<double, string>(true);

        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                products.Add(double.Parse(data[1]), data[0].Trim());
            }
        }

        return products;
    }

    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string productsFilePath = "../../Resources/Products.txt";
        string resultsFilePath = "../../Resources/Results.txt";

        int productsCount = 500000;
        int searchesCount = 10000;
        double priceMaxValue = 100000.0;
        int nameMaxLength = 50;
        int extractSize = 20;

        CreateProductsFile(productsFilePath, productsCount, priceMaxValue, nameMaxLength);

        OrderedMultiDictionary<double, string> products = ReadProducts(productsFilePath);

        // Another solution would be to use OrderedBag<Product> (Product implements IComparable<Product>
        // by comparing product prices). In this case the Range() method would be something like
        // products.Range(new Product("xxx", lowerPrice), true, new Product("xxx", upperPrice), true).

        double lowerPrice;
        double upperPrice;

        using (StreamWriter writer = new StreamWriter(resultsFilePath, false))
        {
            for (int i = 0; i < searchesCount; i++)
            {
                GetRangeBounds(priceMaxValue, out lowerPrice, out upperPrice);
                var extract = products.Range(lowerPrice, true, upperPrice, true).Take(extractSize);

                writer.WriteLine(Environment.NewLine + "====================================");
                writer.WriteLine(
                    "{0}. First {1} products in the price range from {2:F2} to {3:F2}:",
                    i + 1,
                    extractSize,
                    lowerPrice,
                    upperPrice);

                int index = 0;

                foreach (var pair in extract)
                {
                    foreach (var name in pair.Value)
                    {
                        index++;
                        if (index > extractSize)
                        {
                            break;
                        }

                        writer.WriteLine("{0,3}. {1} | {2:F2}", index, name, pair.Key);
                    }

                    if (index > extractSize)
                    {
                        break;
                    }
                }
            }
        }
    }
}
