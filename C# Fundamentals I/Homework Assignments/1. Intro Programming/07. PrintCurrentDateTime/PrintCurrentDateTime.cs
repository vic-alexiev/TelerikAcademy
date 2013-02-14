using System;
using System.Globalization;

class PrintCurrentDateTime
{
    static void Main()
    {
        // by default, format is taken from Windows settings
        Console.WriteLine(DateTime.Now);

        // using custom format
        Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyyг. HH:mm:ss"));

        // using a culture
        Console.WriteLine(DateTime.Now.ToString(new CultureInfo("es-ES")));
    }
}

