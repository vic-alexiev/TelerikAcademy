using System;
using System.Drawing;

class CheckIsPointInCircleAndNotInRectangle
{
    static void Main()
    {
        string xCoordFromConsole;
        string yCoordFromConsole;

        int centerXCoord = 1;
        int centerYCoord = 1;
        int radius = 3;

        int top = 1;
        int left = -1;
        int width = 6;
        int height = 2;

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

        Point point = new Point(xCoord, yCoord);

        bool isInCircle = IsInCircle(point, new Point(centerXCoord, centerYCoord), radius);
        bool isInRectangle = IsInRectangle(point, left, top, width, height);

        Console.WriteLine("The point is{0} in the region defined by the interior of the circle K(C({1}, {2}), {3}) " +
            "and the exterior of the rectangle R(top: {4}, left: {5}, width: {6}, height: {7}).",
            isInCircle && !isInRectangle ? String.Empty:" not",
            centerXCoord,
            centerYCoord,
            radius,
            top,
            left,
            width,
            height);
    }

    private static bool IsInCircle(Point point, Point center, int radius)
    {
        bool isInCircle =
            (point.X - center.X) * (point.X - center.X) + (point.Y - center.Y) * (point.Y - center.Y) <= radius * radius;

        return isInCircle;
    }

    private static bool IsInRectangle(Point point, int left, int top, int width, int height)
    {
        bool isInRectangle =
            ((point.X >= left) && (point.X <= left + width)) && ((point.Y <= top) && (point.Y >= top - height));

        return isInRectangle;
    }
}
