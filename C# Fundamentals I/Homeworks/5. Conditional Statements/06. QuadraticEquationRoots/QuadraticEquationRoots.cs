using System;
using System.Globalization;

class QuadraticEquationRoots
{
    static void Main()
    {
        string quadraticCoefficient;
        string linearCoefficient;
        string freeTerm;
        double a;
        double b;
        double c;
        double discriminant;
        double sqrtOfDiscriminant;
        double x1;
        double rez1;
        double imz1;
        double x2;
        double rez2;
        double imz2;
        int precision = 8;

        do
        {
            Console.Write("Enter the quadratic coefficient (a): ");
            quadraticCoefficient = Console.ReadLine();
        }
        while (!Double.TryParse(quadraticCoefficient, NumberStyles.Number, CultureInfo.InvariantCulture, out a)
            || Math.Round(a, precision) == 0.0);

        do
        {
            Console.Write("Enter the linear coefficient (b): ");
            linearCoefficient = Console.ReadLine();
        }
        while (!Double.TryParse(linearCoefficient, NumberStyles.Number, CultureInfo.InvariantCulture, out b));

        do
        {
            Console.Write("Enter the free term (c): ");
            freeTerm = Console.ReadLine();
        }
        while (!Double.TryParse(freeTerm, NumberStyles.Number, CultureInfo.InvariantCulture, out c));

        // calculate the discriminant
        discriminant = b * b - 4 * a * c;

        // If the discriminant is zero, then there is exactly one distinct real root.
        if (Math.Round(discriminant, precision / 2) == 0.0)
        {
            x1 = x2 = -b / (2 * a);
            Console.WriteLine("The quadratic equation has a double real root: {0:F4}.", x1);
        }

        // If the discriminant is negative, then there are no real roots. 
        // Rather, there are two distinct (non-real) complex roots, which are complex conjugates of each other.
        else if (discriminant < 0.0)
        {
            sqrtOfDiscriminant = Math.Sqrt(-discriminant);
            rez1 = rez2 = -b / (2 * a);
            imz1 = sqrtOfDiscriminant / (2 * a);
            imz2 = -imz1;

            Console.WriteLine("The quadratic equation has two complex roots: ({0:F4}, {1:F4}) and ({2:F4}, {3:F4}).", rez1, imz1, rez2, imz2);
        }

        // If the discriminant is positive, then there are two distinct roots, both of which are real numbers.
        else
        {
            sqrtOfDiscriminant = Math.Sqrt(discriminant);
            x1 = (-b + sqrtOfDiscriminant) / (2 * a);
            x2 = (-b - sqrtOfDiscriminant) / (2 * a);

            Console.WriteLine("The quadratic equation has two distinct real roots: {0:F4} and {1:F4}.", x1, x2);
        }
    }
}