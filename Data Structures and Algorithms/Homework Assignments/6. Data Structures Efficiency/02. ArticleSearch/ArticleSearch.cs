using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Wintellect.PowerCollections;

internal class ArticleSearch
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

    private static void CreateArticlesFile(string path, int articlesCount, double maxPrice, int stringMaxSize)
    {
        double[] pricesArray = GetRandomDoubleArray(articlesCount, maxPrice);
        string[] barcodesArray = GetRandomStringArray(articlesCount, stringMaxSize);
        string[] vendorsArray = GetRandomStringArray(articlesCount, stringMaxSize);
        string[] titlesArray = GetRandomStringArray(articlesCount, stringMaxSize);

        using (StreamWriter writer = new StreamWriter(path, false))
        {
            for (int i = 0; i < articlesCount; i++)
            {
                writer.WriteLine(
                    "{0,10:F2} | {1} | {2} | {3}",
                    pricesArray[i],
                    barcodesArray[i],
                    vendorsArray[i],
                    titlesArray[i]);
            }
        }
    }

    private static OrderedBag<Article> ReadArticles(string path)
    {
        OrderedBag<Article> articles = new OrderedBag<Article>();

        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');

                double price = double.Parse(data[0]);

                Article article = new Article(
                    price,
                    data[1].Trim(),
                    data[2].Trim(),
                    data[3].Trim());

                articles.Add(article);
            }
        }

        return articles;
    }

    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string articlesFilePath = "../../Resources/Articles.txt";
        string resultsFilePath = "../../Resources/Results.txt";

        int articlesCount = 500000;
        int searchesCount = 10000;
        double priceMaxValue = 100000.0;
        int stringMaxSize = 50;
        int extractSize = 20;

        Stopwatch stopwatch = Stopwatch.StartNew();

        CreateArticlesFile(articlesFilePath, articlesCount, priceMaxValue, stringMaxSize);

        stopwatch.Stop();
        Console.WriteLine("Articles file created for {0} second(s).", stopwatch.ElapsedMilliseconds / 1000);
        stopwatch.Restart();

        OrderedBag<Article> articles = ReadArticles(articlesFilePath);

        // Another solution would be to use OrderedMultiDictionary<double, Article>
        // (The keys are the article prices). In this case the Range() method would be
        // articles.Range(lowerPrice, true, upperPrice, true).

        double lowerPrice;
        double upperPrice;

        using (StreamWriter writer = new StreamWriter(resultsFilePath, false))
        {
            for (int i = 0; i < searchesCount; i++)
            {
                GetRangeBounds(priceMaxValue, out lowerPrice, out upperPrice);
                var extract = articles.Range(
                    new Article(lowerPrice, "N/A", "N/A", "N/A"),
                    true,
                    new Article(upperPrice, "N/A", "N/A", "N/A"),
                    true).Take(extractSize);

                writer.WriteLine(Environment.NewLine + "====================================");
                writer.WriteLine(
                    "{0}. First {1} articles in the price range from {2:F2} to {3:F2}:",
                    i + 1,
                    extractSize,
                    lowerPrice,
                    upperPrice);

                int index = 0;
                foreach (var article in extract)
                {
                    writer.WriteLine("{0,4}. {1}", ++index, article);
                }
            }
        }

        stopwatch.Stop();

        Console.WriteLine("Time elapsed: {0} minutes", stopwatch.ElapsedMilliseconds / 60000);
    }
}
