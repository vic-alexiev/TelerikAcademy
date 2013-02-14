using NumeralSystems;
using System;

class ConvertDecimalToBinary
{
    static void Main()
    {
        try
        {
            long decimalNumber = 8753;
            Console.WriteLine(Converter.FromDecimal(decimalNumber, 2));
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
