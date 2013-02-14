using System;
using System.Text;

class CopyrightTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        char c = '\u00A9';
        string line = String.Empty;
        int linesCount = 3;

        for (int i = 0; i < linesCount; i++)
        {
            line = new String(c, 2 * i + 1);
            Console.WriteLine(line.PadLeft(linesCount + i));
        }
    }
}
