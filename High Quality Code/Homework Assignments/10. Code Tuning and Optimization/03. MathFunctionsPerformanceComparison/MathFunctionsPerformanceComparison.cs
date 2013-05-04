using System;
using System.Diagnostics;

internal class MathFunctionsPerformanceComparison
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

    private static void DisplaySquareRootPerformance()
    {
        int iterationsCount = 10000000;

        double doubleValue = 0;
        string doubleMessage = "Square root of a Double value".PadRight(45, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue = Math.Sqrt(6.1);
            }
        }, doubleMessage);
    }

    private static void DisplayNaturalLogarithmPerformance()
    {
        int iterationsCount = 10000000;

        double doubleValue = 0;
        string doubleMessage = "Natural logarithm of a Double value".PadRight(45, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue = Math.Log(6.1);
            }
        }, doubleMessage);
    }

    private static void DisplaySinePerformance()
    {
        int iterationsCount = 10000000;

        double doubleValue = 0;
        string doubleMessage = "Sine of a Double value".PadRight(45, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                doubleValue = Math.Sin(6.1);
            }
        }, doubleMessage);
    }

    private static void Main()
    {
        DisplaySquareRootPerformance();

        DisplayNaturalLogarithmPerformance();

        DisplaySinePerformance();
    }
}
