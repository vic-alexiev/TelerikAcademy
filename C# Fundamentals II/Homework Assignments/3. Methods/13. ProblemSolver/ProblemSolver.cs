using Nakov.IO;
using System;
using System.Globalization;
using System.Linq;

class ProblemSolver
{
    private enum UserChoice : byte
    {
        ReverseNumber = 1,
        CalculateAverage = 2,
        SolveLinearEquation = 3
    }

    private static void HandleCalculateAverage()
    {
        string sequenceLength;
        int n;
        do
        {
            Console.Write("Enter the length of the sequence (an integer > 1): ");
            sequenceLength = Console.ReadLine();
        }
        while (!Int32.TryParse(sequenceLength, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n < 2);

        int[] numbers = new int[n];

        Console.Write("Enter {0} integers separated with spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        double average = numbers.Average();

        Console.WriteLine("The average: {0:N4}", average);
    }

    private static void HandleReverseNumber()
    {
        string input;
        int number;
        do
        {
            Console.Write("Enter a non-negative integer: ");
            input = Console.ReadLine();
        }
        while (!Int32.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out number) || number < 0);

        try
        {
            int numberReversed = ReverseNumberDigits.ReverseInteger(number);
            Console.WriteLine("Your integer with its digits reversed: {0}.", numberReversed);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void HandleSolveLinearEquation()
    {
        string linearCoefficient;
        double a;
        string freeTerm;
        double b;

        do
        {
            Console.Write("Enter the linear coefficient (a real number, shouldn't be zero): ");
            linearCoefficient = Console.ReadLine();
        }
        while (!Double.TryParse(linearCoefficient, NumberStyles.Number, CultureInfo.InvariantCulture, out a) || a == 0.0);

        do
        {
            Console.Write("Enter the free term (a real number): ");
            freeTerm = Console.ReadLine();
        }
        while (!Double.TryParse(freeTerm, NumberStyles.Number, CultureInfo.InvariantCulture, out b));

        double root = GetLinearEquationRoot(a, b);

        Console.WriteLine("The root: {0:N4}", root);
    }

    private static double GetLinearEquationRoot(double linearCoefficient, double freeTerm)
    {
        if (linearCoefficient == 0.0)
        {
            throw new ArgumentException("Linear coefficient cannot be zero.");
        }

        return -freeTerm / linearCoefficient;
    }

    static void Main()
    {
        string userInput;
        UserChoice userChoice;
        do
        {
            Console.WriteLine("Your options:");
            Console.WriteLine("\t\tPress [1] to reverse the digits of a number.");
            Console.WriteLine("\t\tPress [2] to calculate the average of an integer series.");
            Console.WriteLine("\t\tPress [3] to solve a linear equation.");
            userInput = Console.ReadLine();
        }
        while (!Enum.TryParse(userInput, out userChoice)
            || userChoice < UserChoice.ReverseNumber
            || userChoice > UserChoice.SolveLinearEquation);

        switch (userChoice)
        {
            case UserChoice.ReverseNumber:
                {
                    HandleReverseNumber();
                    break;
                }
            case UserChoice.CalculateAverage:
                {
                    HandleCalculateAverage();
                    break;
                }
            case UserChoice.SolveLinearEquation:
                {
                    HandleSolveLinearEquation();
                    break;
                }
            default:
                break;
        }
    }
}
