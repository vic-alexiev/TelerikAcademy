using System;

class SquareRoot
{
    public static double Sqrt(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("Square root for negative numbers is undefined.");
        }

        return Math.Sqrt(value);
    }


    static void Main()
    {
        Console.Write("Enter an integer to calculate its square root: ");
        string number = Console.ReadLine();

        try
        {
            int n = Int32.Parse(number);

            double sqrt = Sqrt(n);

            Console.WriteLine("The square root of {0} is {1:N4}.", n, sqrt);
        }
        catch (FormatException fex)
        {
            Console.WriteLine(fex.Message);
        }
        catch (OverflowException oex)
        {
            Console.WriteLine(oex.Message);
        }
        catch (ArgumentOutOfRangeException aex)
        {
            Console.WriteLine(aex.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye.");
        }
    }
}
