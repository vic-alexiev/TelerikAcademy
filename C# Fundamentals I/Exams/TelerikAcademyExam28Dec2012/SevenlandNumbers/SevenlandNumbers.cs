using System;

class SevenlandNumbers
{
    private static int ConvertSeptenaryToDecimal(string septenaryNumber)
    {
        int decimalNumber = 0;
        int digits = septenaryNumber.Length;

        for (int i = 0; i < digits; i++)
        {
            decimalNumber += (septenaryNumber[i] - '0') * (int)Math.Pow(7, digits - 1 - i);
        }

        return decimalNumber;
    }

    private static string ConvertDecimalToSeptenary(int decimalNumber)
    {
        if (decimalNumber == 0)
        {
            return "0";
        }

        int index = 31; // 0 ... 31 - bits in the binary representation of an int
        char[] charArray = new char[32];

        while (decimalNumber != 0)
        {
            int remainder = (int)(decimalNumber % 7);
            charArray[index--] = Convert.ToChar(remainder + '0');
            decimalNumber = decimalNumber / 7;
        }

        string septenaryNumber = new String(charArray, index + 1, 32 - index - 1);

        return septenaryNumber;
    }

    static void Main()
    {
        string kSeptenary = Console.ReadLine();
        int kDecimal = ConvertSeptenaryToDecimal(kSeptenary);
        Console.WriteLine(ConvertDecimalToSeptenary(kDecimal + 1));
    }
}
