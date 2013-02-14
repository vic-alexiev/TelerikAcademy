using NumeralSystems;
using System;

class ConvertHexadecimalToBinary
{
    static void Main()
    {
        // I solution
        //string hexValue = "ABC";
        //string binValue = Convert.ToString(Convert.ToInt32(hexValue, 16), 2);
        //Console.WriteLine(binValue);

        // II solution
        string hexValue = "2c3d4e";
        string binValue = Converter.FromHexadecimalToBinary(hexValue);
        Console.WriteLine(binValue);
    }
}
