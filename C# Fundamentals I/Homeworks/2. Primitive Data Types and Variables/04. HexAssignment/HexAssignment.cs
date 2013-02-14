using System;
using System.Globalization;

class HexAssignment
{
    static void Main(string[] args)
    {
        int number = 254;

        //string hex = String.Format("{0:X}", number);
        string hex = Convert.ToString(number, 16);

        //int numberFromHex = 0xFE;
        int numberFromHex = Int32.Parse(hex, NumberStyles.HexNumber);

        Console.WriteLine(numberFromHex);
    }
}
