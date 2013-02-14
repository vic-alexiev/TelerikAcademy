using System;
using System.Drawing;

class CheckIsPointInCircle
{
    static void Main()
    {
        string xCoordFromConsole;
        string yCoordFromConsole;

        int centerXCoord = 0;
        int centerYCoord = 0;
        int radius = 5;

        int xCoord;
        int yCoord;

        do
        {
            Console.WriteLine("Point x coordinate:");
            xCoordFromConsole = Console.ReadLine();
        }
        while (!Int32.TryParse(xCoordFromConsole, out xCoord));

        do
        {
            Console.WriteLine("Point y coordinate:");
            yCoordFromConsole = Console.ReadLine();
        }
        while (!Int32.TryParse(yCoordFromConsole, out yCoord));

        bool isInCircle = IsInCircle(new Point(xCoord, yCoord), new Point(centerXCoord, centerYCoord), radius);

        Console.WriteLine("The point is{0} in the circle K(C({1}, {2}), {3}).",
            isInCircle ? String.Empty : " not",
            centerXCoord,
            centerYCoord,
            radius);
    }

    private static bool IsInCircle(Point point, Point center, int radius)
    {
        bool isInCircle =
            (point.X - center.X) * (point.X - center.X) + (point.Y - center.Y) * (point.Y - center.Y) <= radius * radius;

        return isInCircle;
    }
}
