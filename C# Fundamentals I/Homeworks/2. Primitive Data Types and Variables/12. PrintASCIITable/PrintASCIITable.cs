using System;

class PrintASCIITable
{
    static void Main()
    {
        char c;

        Console.WriteLine("ASCII Table\n{0}", new String('-', 34));
        
        Console.WriteLine("{0} | {1} | {2} | {3} | {4}\n{5}",
            " Binary", "Oct", "Dec", "Hex", "Symbol", new String('-', 34));

        for (int i = 0; i < 128; i++)
        {
            c = (char)i;

            Console.WriteLine("{0} | {1} | {2} | {3} | {4}", 
                Convert.ToString(i, 2).PadLeft(7, '0'),
                Convert.ToString(i, 8).PadLeft(3, '0'),
                Convert.ToString(i).PadLeft(3),
                Convert.ToString(i, 16).PadLeft(3, '0').ToUpper(),
                c == '\n' ? new String(' ', 6) : c.ToString().PadLeft(6));
        }
    }
}
  