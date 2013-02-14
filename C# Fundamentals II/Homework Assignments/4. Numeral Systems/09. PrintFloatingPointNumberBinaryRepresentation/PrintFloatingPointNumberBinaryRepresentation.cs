using NumeralSystems;
using System;
using System.Globalization;
using System.Text;

class PrintFloatingPointNumberBinaryRepresentation
{
    static void Main()
    {
        while (true)
        {
            string number;
            float n;

            do
            {
                Console.Write("Enter a single-precision floating-point number: ");
                number = Console.ReadLine();
            }
            while (!Single.TryParse(number, NumberStyles.Number, CultureInfo.InvariantCulture, out n));

            FloatBinaryRepresentation binRepresentation = new FloatBinaryRepresentation(n);

            Console.WriteLine("Your number's binary representation:\n\t"+
                "Sign: {0}\n\tExponent: {1}\n\tSignificand (Mantissa): {2}",
                binRepresentation.Sign, binRepresentation.Exponent, binRepresentation.Mantissa);    
        }
    }
}
