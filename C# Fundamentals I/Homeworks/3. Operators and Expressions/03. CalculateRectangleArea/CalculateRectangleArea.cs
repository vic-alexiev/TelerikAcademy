using System;

class CalculateRectangleArea
{
    static void Main()
    {
        string widthFromConsole;
        string heightFromConsole;

        double width;
        double height;

        do
        {
            Console.WriteLine("Width:");
            widthFromConsole = Console.ReadLine();
        }
        while (!Double.TryParse(widthFromConsole, out width) || width < 0);

        do
        {
            Console.WriteLine("Height:");
            heightFromConsole = Console.ReadLine();
        }
        while (!Double.TryParse(heightFromConsole, out height) || height < 0);

        double area = width * height;

        Console.WriteLine("The rectangle area is {0} square units.", area);
    }
}
