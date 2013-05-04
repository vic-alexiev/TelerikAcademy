using System;
using System.Diagnostics;

internal class OperatorsPerformanceComparison
{
    private static void DisplayExecutionTime(Action action, string message = "")
    {
        Console.Write(message);
        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + "\n");
    }

    private static void DisplayAdditionComparison()
    {
        int iterationsCount = 10000000;

        int intValue = 0;
        string intMessage = "Adding Int32 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                intValue = 1 + 6;
            }
        }, intMessage);

        long longValue = 0;
        string longMessage = "Adding Int64 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                longValue = 1L + 6L;
            }
        }, longMessage);

        float floatValue = 0;
        string floatMessage = "Adding Single values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                floatValue = 1.1f + 6.1f;
            }
        }, floatMessage);

        double doubleValue = 0;
        string doubleMessage = "Adding Double values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue = 1.1 + 6.1;
            }
        }, doubleMessage);

        decimal decimalValue = 0m;
        string decimalMessage = "Adding Decimal values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                decimalValue = 1.1m + 6.1m;
            }
        }, decimalMessage);
    }

    private static void DisplaySubtractionComparison()
    {
        int iterationsCount = 10000000;

        int intValue = 0;
        string intMessage = "Subtracting Int32 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                intValue = 6 - 3;
            }
        }, intMessage);

        long longValue = 0;
        string longMessage = "Subtracting Int64 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                longValue = 6L - 3L;
            }
        }, longMessage);

        float floatValue = 0;
        string floatMessage = "Subtracting Single values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                floatValue = 6.1f - 3.1f;
            }
        }, floatMessage);

        double doubleValue = 0;
        string doubleMessage = "Subtracting Double values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue = 6.1 - 3.1;
            }
        }, doubleMessage);

        decimal decimalValue = 0m;
        string decimalMessage = "Subtracting Decimal values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                decimalValue = 6.1m - 3.1m;
            }
        }, decimalMessage);
    }

    private static void DisplayIncrementComparison()
    {
        int iterationsCount = 10000000;

        int intValue = 6;
        string intMessage = "Incrementing a Int32 value".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                intValue++;
            }
        }, intMessage);

        long longValue = 6L;
        string longMessage = "Incrementing a Int64 value".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                longValue++;
            }
        }, longMessage);

        float floatValue = 6.1f;
        string floatMessage = "Incrementing a Single value".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                floatValue++;
            }
        }, floatMessage);

        double doubleValue = 6.1;
        string doubleMessage = "Incrementing a Double value".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue++;
            }
        }, doubleMessage);

        decimal decimalValue = 6.1m;
        string decimalMessage = "Incrementing a Decimal value".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                decimalValue++;
            }
        }, decimalMessage);
    }

    private static void DisplayMultiplicationComparison()
    {
        int iterationsCount = 10000000;

        int intValue = 0;
        string intMessage = "Multiplying Int32 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                intValue = 6 * 13;
            }
        }, intMessage);

        long longValue = 0;
        string longMessage = "Multiplying Int64 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                longValue = 6L * 13L;
            }
        }, longMessage);

        float floatValue = 0;
        string floatMessage = "Multiplying Single values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                floatValue = 6.1f * 13.1f;
            }
        }, floatMessage);

        double doubleValue = 0;
        string doubleMessage = "Multiplying Double values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue = 6.1 * 13.1;
            }
        }, doubleMessage);

        decimal decimalValue = 0m;
        string decimalMessage = "Multiplying Decimal values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                decimalValue = 6.1m * 13.1m;
            }
        }, decimalMessage);
    }

    private static void DisplayDivisionComparison()
    {
        int iterationsCount = 10000000;

        int intValue = 0;
        string intMessage = "Dividing Int32 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                intValue = 6 / 3;
            }
        }, intMessage);

        long longValue = 0;
        string longMessage = "Dividing Int64 values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                longValue = 6L / 3L;
            }
        }, longMessage);

        float floatValue = 0;
        string floatMessage = "Dividing Single values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                floatValue = 6.1f / 3.1f;
            }
        }, floatMessage);

        double doubleValue = 0;
        string doubleMessage = "Dividing Double values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue = 6.1 / 3.1;
            }
        }, doubleMessage);

        decimal decimalValue = 0m;
        string decimalMessage = "Dividing Decimal values".PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                decimalValue = 6.1m / 3.1m;
            }
        }, decimalMessage);
    }

    private static void Main()
    {
        DisplayAdditionComparison();

        DisplaySubtractionComparison();

        DisplayIncrementComparison();

        DisplayMultiplicationComparison();

        DisplayDivisionComparison();
    }
}
