using NumeralSystems;
using System;

class ConvertHexadecimalToDecimal
{
    static void Main()
    {
        try
        {
            string hexadecimalNumber = "14ff";
            Console.WriteLine(Converter.ToDecimal(hexadecimalNumber, 16));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
