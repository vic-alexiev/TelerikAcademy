using System;

class AstrologicalDigits
{
    static void Main()
    {
        string numberAsString = Console.ReadLine();
        numberAsString = numberAsString.Replace(".", "").Replace("-", "");

        int astrologicalSum = 0;

        foreach (char c in numberAsString)
        {
            astrologicalSum += (c - '0');
        }

        int sum = astrologicalSum;

        while (sum > 9)
        {
            astrologicalSum = sum;
            sum = 0;

            while (astrologicalSum > 0)
            {
                sum += astrologicalSum % 10;
                astrologicalSum /= 10;
            }
        }

        astrologicalSum = sum;

        Console.WriteLine(astrologicalSum);
    }
}
