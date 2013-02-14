using NumeralSystems;
using System;

class ConvertBinaryToDecimal
{
    static void Main()
    {
        try
        {
            string binaryNumber = "1010100111";
            Console.WriteLine(Converter.ToDecimal(binaryNumber, 2));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
