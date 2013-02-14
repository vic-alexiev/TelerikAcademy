using NumeralSystems;
using System;

class ConvertDecimalToHexadecimal
{
    static void Main()
    {
        try
        {
            long decimalNumber = 3402288846;
            Console.WriteLine(Converter.FromDecimal(decimalNumber, 16));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
