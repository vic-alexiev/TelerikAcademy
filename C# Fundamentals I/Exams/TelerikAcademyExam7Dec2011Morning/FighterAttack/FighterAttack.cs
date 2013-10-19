using System;
using System.Drawing;

class FighterAttack
{

    private static bool IsInsideThePlant(Point point, Point plantCorner1, Point plantCorner2)
    {
        return Math.Min(plantCorner1.X, plantCorner2.X) <= point.X
            && point.X <= Math.Max(plantCorner1.X, plantCorner2.X)
            && Math.Min(plantCorner1.Y, plantCorner2.Y) <= point.Y
            && point.Y <= Math.Max(plantCorner1.Y, plantCorner2.Y);
    }

    private static int GetTotalDamage(Point missile, Point plantCorner1, Point plantCorner2)
    {
        int totalDamage = 0;

        if (IsInsideThePlant(missile, plantCorner1, plantCorner2))
        {
            totalDamage += 100;
        }

        Point leftSidePoint = new Point(missile.X, missile.Y + 1);
        Point rightSidePoint = new Point(missile.X, missile.Y - 1);
        Point frontPoint = new Point(missile.X + 1, missile.Y);

        if (IsInsideThePlant(leftSidePoint, plantCorner1, plantCorner2))
        {
            totalDamage += 50;
        }

        if (IsInsideThePlant(rightSidePoint, plantCorner1, plantCorner2))
        {
            totalDamage += 50;
        }

        if (IsInsideThePlant(frontPoint, plantCorner1, plantCorner2))
        {
            totalDamage += 75;
        }

        return totalDamage;
    }

    private static Point GetMissileLocation(Point fighter, int range)
    {
        return new Point(fighter.X + range, fighter.Y);
    }

    static void Main()
    {
        string plantCorner1XCoord = Console.ReadLine();
        int plantCorner1X = Int32.Parse(plantCorner1XCoord);

        string plantCorner1YCoord = Console.ReadLine();
        int plantCorner1Y = Int32.Parse(plantCorner1YCoord);

        string plantCorner2XCoord = Console.ReadLine();
        int plantCorner2X = Int32.Parse(plantCorner2XCoord);

        string plantCorner2YCoord = Console.ReadLine();
        int plantCorner2Y = Int32.Parse(plantCorner2YCoord);

        string fighterXCoord = Console.ReadLine();
        int fighterX = Int32.Parse(fighterXCoord);

        string fighterYCoord = Console.ReadLine();
        int fighterY = Int32.Parse(fighterYCoord);

        string distance = Console.ReadLine();
        int range = Int32.Parse(distance);

        Point plantCorner1 = new Point(plantCorner1X, plantCorner1Y);
        Point plantCorner2 = new Point(plantCorner2X, plantCorner2Y);

        Point fighter = new Point(fighterX, fighterY);

        Point missile = GetMissileLocation(fighter, range);

        int totalDamage = GetTotalDamage(missile, plantCorner1, plantCorner2);

        Console.WriteLine("{0}%", totalDamage);
    }
}
