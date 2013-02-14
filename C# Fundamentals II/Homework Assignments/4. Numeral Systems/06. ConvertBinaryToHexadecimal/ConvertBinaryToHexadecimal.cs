using NumeralSystems;
using System;

class ConvertBinaryToHexadecimal
{
    static void Main()
    {
        try
        {
            string binValue = "0000111101101";
            string hexValue = Converter.FromBinaryToHexadecimal(binValue);
            Console.WriteLine(hexValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
