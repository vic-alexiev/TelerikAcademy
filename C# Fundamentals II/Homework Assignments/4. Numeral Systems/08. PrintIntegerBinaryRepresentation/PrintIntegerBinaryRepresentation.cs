using System;
using System.Text;

public class PrintIntegerBinaryRepresentation
{
    public static string GetBinaryRepresentation(short value)
    {
        StringBuilder binaryBuilder = new StringBuilder();

        for (int i = 0; i < 16; i++)
        {
            int bitValue = value & (1 << i);
            binaryBuilder.Insert(0, bitValue == 0 ? '0' : '1');
        }

        return binaryBuilder.ToString();
    }

    static void Main()
    {
        while (true)
        {
            string number;
            short n;
            do
            {
                Console.Write("Enter a 16-bit signed integer: ");
                number = Console.ReadLine();
            }
            while (!Int16.TryParse(number, out n));

            // check
            Console.WriteLine("Your number's binary representation: {0}", Convert.ToString(n, 2).PadLeft(16, '0'));

            string binary = GetBinaryRepresentation(n);

            Console.WriteLine("Your number's binary representation: {0}", binary);
        }
    }
}
