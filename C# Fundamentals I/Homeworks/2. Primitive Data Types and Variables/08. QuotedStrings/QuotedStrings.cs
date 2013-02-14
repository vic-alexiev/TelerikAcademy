using System;

class QuotedStrings
{
    static void Main()
    {
        string a = "The \"use\" of quotations causes difficulties.";
        string b = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}
