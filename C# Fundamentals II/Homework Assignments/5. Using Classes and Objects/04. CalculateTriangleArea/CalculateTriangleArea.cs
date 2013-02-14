using System;
using System.Globalization;

class CalculateTriangleArea
{
    private enum TriangleAreaOption : byte
    {
        SideAndAltitude = 1,
        ThreeSides = 2,
        TwoSidesAndAngle = 3
    }

    /// <summary>
    /// Calculates triangle's area, given two sides and the angle between them (in degrees).
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="degrees"></param>
    /// <returns></returns>
    private static double CalculateArea(double a, double b, int degrees)
    {
        double radians = degrees * Math.PI / 180;

        return 0.5 * a * b * Math.Sin(radians);
    }

    private static void CalculateTriangleAreaByTwoSidesAndAngle()
    {
        string inputSideA;
        string inputSideB;
        string inputDegrees;
        double a;
        double b;
        int degrees;

        do
        {
            Console.Write("Enter the length of the first side (a positive real number): ");
            inputSideA = Console.ReadLine();
        }
        while (!Double.TryParse(inputSideA, NumberStyles.Number, CultureInfo.InvariantCulture, out a) || a <= 0.0);

        do
        {
            Console.Write("Enter the length of the second side (a positive real number): ");
            inputSideB = Console.ReadLine();
        }
        while (!Double.TryParse(inputSideB, NumberStyles.Number, CultureInfo.InvariantCulture, out b) || b <= 0.0);

        do
        {
            Console.Write("Enter the angle (in degrees) between the sides: ");
            inputDegrees = Console.ReadLine();
        }
        while (!Int32.TryParse(inputDegrees, NumberStyles.Number, CultureInfo.InvariantCulture, out degrees)
            || degrees <= 0 || degrees >= 180);

        double area = CalculateArea(a, b, degrees);
        Console.WriteLine("The area of the triangle is {0:N4}.", area);
    }

    /// <summary>
    /// Calculates triangle's area, given its three sides.
    /// Uses Heron's formula.
    /// <seealso cref="http://en.wikipedia.org/wiki/Heron's_formula"/>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private static double CalculateArea(double a, double b, double c)
    {
        double s = 0.5 * (a + b + c);

        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    private static bool IsTrianglePossible(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    private static void CalculateTriangleAreaByThreeSides()
    {
        string inputSideA;
        string inputSideB;
        string inputSideC;
        double a;
        double b;
        double c;

        do
        {
            Console.Write("Enter the length of the first side (a positive real number): ");
            inputSideA = Console.ReadLine();
        }
        while (!Double.TryParse(inputSideA, NumberStyles.Number, CultureInfo.InvariantCulture, out a) || a <= 0.0);

        do
        {
            Console.Write("Enter the length of the second side (a positive real number): ");
            inputSideB = Console.ReadLine();
        }
        while (!Double.TryParse(inputSideB, NumberStyles.Number, CultureInfo.InvariantCulture, out b) || b <= 0.0);

        do
        {
            Console.Write("Enter the length of the second side (a positive real number): ");
            inputSideC = Console.ReadLine();
        }
        while (!Double.TryParse(inputSideC, NumberStyles.Number, CultureInfo.InvariantCulture, out c) || c <= 0.0);

        if (!IsTrianglePossible(a, b, c))
        {
            Console.WriteLine("These cannot be the lengths of the sides of a triangle.\n" +
                "The conditions for the sides are:\n\t| a + b > c\n\t| a + c > b\n\t| b + c > a");
        }
        else
        {
            double area = CalculateArea(a, b, c);
            Console.WriteLine("The area of the triangle is {0:N4}.", area);
        }
    }

    /// <summary>
    /// Calculates triangle's area by a side and the altitude 
    /// perpendicular to the side.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="ha"></param>
    /// <returns></returns>
    private static double CalculateArea(double a, double ha)
    {
        return 0.5 * a * ha;
    }

    private static void CalculateTriangleAreaBySideAndAltitude()
    {
        string inputSide;
        string inputAltitude;
        double a;
        double ha;

        do
        {
            Console.Write("Enter the length of the side (a positive real number): ");
            inputSide = Console.ReadLine();
        }
        while (!Double.TryParse(inputSide, NumberStyles.Number, CultureInfo.InvariantCulture, out a) || a <= 0.0);

        do
        {
            Console.Write("Enter the length of the altitude (a positive real number): ");
            inputAltitude = Console.ReadLine();
        }
        while (!Double.TryParse(inputAltitude, NumberStyles.Number, CultureInfo.InvariantCulture, out ha) || ha <= 0.0);

        double area = CalculateArea(a, ha);

        Console.WriteLine("The area of the triangle is {0:N4}.", area);
    }

    static void Main()
    {
        string userInput;
        TriangleAreaOption chosenOption;

        do
        {
            Console.WriteLine("Calculate the area of a triangle:");
            Console.WriteLine("\tPress [1] if you are given a side and an altitude perpendicular to it.");
            Console.WriteLine("\tPress [2] if you are given three sides.");
            Console.WriteLine("\tPress [3] if you are given two sides and the angle (in degrees) between them.");
            userInput = Console.ReadLine();
        }
        while (!Enum.TryParse(userInput, out chosenOption)
            || chosenOption < TriangleAreaOption.SideAndAltitude
            || chosenOption > TriangleAreaOption.TwoSidesAndAngle);

        switch (chosenOption)
        {
            case TriangleAreaOption.SideAndAltitude:
                {
                    CalculateTriangleAreaBySideAndAltitude();
                    break;
                }
            case TriangleAreaOption.ThreeSides:
                {
                    CalculateTriangleAreaByThreeSides();
                    break;
                }
            case TriangleAreaOption.TwoSidesAndAngle:
                {
                    CalculateTriangleAreaByTwoSidesAndAngle();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
