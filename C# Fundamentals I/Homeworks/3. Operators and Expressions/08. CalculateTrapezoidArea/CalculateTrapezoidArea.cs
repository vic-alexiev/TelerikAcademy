using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CalculateTrapezoidArea
{
    static void Main()
    {
        string baseAFromConsole;
        string baseBFromConsole;
        string heightFromConsole;

        double baseA;
        double baseB;
        double height;

        do
        {
            Console.WriteLine("Base a:");
            baseAFromConsole = Console.ReadLine();
        }
        while (!Double.TryParse(baseAFromConsole, out baseA) || baseA < 0);

        do
        {
            Console.WriteLine("Base b:");
            baseBFromConsole = Console.ReadLine();
        }
        while (!Double.TryParse(baseBFromConsole, out baseB) || baseB < 0);

        do
        {
            Console.WriteLine("Height:");
            heightFromConsole = Console.ReadLine();
        }
        while (!Double.TryParse(heightFromConsole, out height) || height < 0);

        double area = 0.5 * (baseA + baseB) * height;

        Console.WriteLine("The trapezoid's area is {0}.", area);
    }
}
