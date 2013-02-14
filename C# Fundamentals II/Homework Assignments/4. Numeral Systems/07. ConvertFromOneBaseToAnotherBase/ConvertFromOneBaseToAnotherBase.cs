using NumeralSystems;
using System;

class ConvertFromOneBaseToAnotherBase
{
    static void Main()
    {
        try
        {
            string octValue = "05326";
            string binValue = Converter.FromArbitraryBaseToAnother(octValue, 8, 2);

            Console.WriteLine(binValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
