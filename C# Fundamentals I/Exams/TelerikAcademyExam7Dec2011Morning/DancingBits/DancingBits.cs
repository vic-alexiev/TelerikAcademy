using System;
using System.Text;

class DancingBits
{
    static void Main()
    {
        string numberK = Console.ReadLine();
        int k = Int32.Parse(numberK);

        string numberN = Console.ReadLine();
        int n = Int32.Parse(numberN);

        StringBuilder concatBuilder = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string number = Console.ReadLine();
            concatBuilder.Append(Convert.ToString(Int32.Parse(number), 2));
        }

        string concatenation = concatBuilder.ToString();

        int dancingBitsCount = 1;
        int dancingBitGroupsWithLengthK = 0;

        int length = concatenation.Length;

        for (int i = 1; i < length; i++)
        {
            if (concatenation[i] == concatenation[i - 1])
            {
                dancingBitsCount++;
            }
            else
            {
                if (dancingBitsCount == k)
                {
                    dancingBitGroupsWithLengthK++;
                }

                // a new group of dancing bits begins
                dancingBitsCount = 1;
            }
        }

        // the last group of dancing bits should also be checked
        if (dancingBitsCount == k)
        {
            dancingBitGroupsWithLengthK++;
        }

        Console.WriteLine(dancingBitGroupsWithLengthK);
    }
}
