using System;

class ReadNumbers
{
    private static int ReadNumber(int start, int end)
    {
        if (start >= end)
        {
            throw new ArgumentException("Specified values do not represent a valid range.");
        }

        Console.Write("Enter an integer in the range ({0}, {1}): ", start, end);
        string inputValue = Console.ReadLine();

        int number = Int32.Parse(inputValue);

        if (number <= start || number >= end)
        {
            throw new ValueOutOfRangeException("Input value was out of the range of valid values.");
        }

        return number;
    }

    static void Main()
    {
        int start = 1;
        int end = 100;
        int numbersCount = 10;

        for (int i = 0; i < numbersCount; i++)
        {
            try
            {
                int number = ReadNumber(start, end);
                start = number;
            }
            catch (ArgumentException aex)
            {
                i--;
                Console.WriteLine(aex.Message);
            }
            catch (FormatException fex)
            {
                i--;
                Console.WriteLine(fex.Message);
            }
            catch (OverflowException oex)
            {
                i--;
                Console.WriteLine(oex.Message);
            }
            catch (ValueOutOfRangeException vex)
            {
                i--;
                Console.WriteLine(vex.Message);
            }
        }
    }
}
