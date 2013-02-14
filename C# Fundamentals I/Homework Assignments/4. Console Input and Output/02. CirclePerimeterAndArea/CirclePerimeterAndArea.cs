using System;
using System.Globalization;

class CirclePerimeterAndArea
{
    static void Main()
    {
        string radiusAsString;
        double radius;

        do
        {
            Console.Write("Enter the radius of the circle: ");
            radiusAsString = Console.ReadLine();
        }
        while (!Double.TryParse(radiusAsString, NumberStyles.Number, CultureInfo.InvariantCulture, out radius)
            || radius < 0.0);

        double perimeter = 2.0 * Math.PI * radius;
        double area = Math.PI * radius * radius;

        Console.WriteLine("\nPerimeter . . . . . . . : {0:F6}\n" +
            "Area. . . . . . . . . . : {1:F6}\n", perimeter, area);

    }
}
