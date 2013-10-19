using System;

class ExcelColumns
{
    static void Main()
    {
        string numberN = Console.ReadLine();
        int n = Int32.Parse(numberN);

        long index = 0;

        for (int i = 0; i < n; i++)
        {
            string letter = Console.ReadLine();

            index *= 26;
            index += (letter[0] - 'A' + 1);
        }

        Console.WriteLine(index);
    }
}
