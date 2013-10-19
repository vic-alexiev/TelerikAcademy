using System;
using System.Drawing;

class ShipDamage
{
    private enum HitLocation
    {
        Outside = 0,
        Corner = 25,
        Side = 50,
        Inside = 100
    }

    private static HitLocation GetHitLocation(Point projectile, Point shipCorner1, Point shipCorner2)
    {
        if (projectile.X < Math.Min(shipCorner1.X, shipCorner2.X)
            || projectile.X > Math.Max(shipCorner1.X, shipCorner2.X)
            || projectile.Y < Math.Min(shipCorner1.Y, shipCorner2.Y)
            || projectile.Y > Math.Max(shipCorner1.Y, shipCorner2.Y))
        {
            return HitLocation.Outside;
        }
        else if ((projectile.X == shipCorner1.X || projectile.X == shipCorner2.X)
            && (projectile.Y == shipCorner1.Y || projectile.Y == shipCorner2.Y))
        {
            return HitLocation.Corner;
        }
        else if ((projectile.X == shipCorner1.X || projectile.X == shipCorner2.X)
            || (projectile.Y == shipCorner1.Y || projectile.Y == shipCorner2.Y))
        {
            return HitLocation.Side;
        }
        else
        {
            return HitLocation.Inside;
        }
    }

    /// <summary>
    /// The point P(x, y) and its reflection P'(x', y') on the other side of the horizon y = h (const)
    /// (a line parallel to the X-axis) satisfy the conditions:
    /// | x = x'
    /// | (y + y') / 2 = h, i.e. y' = 2h - y
    /// </summary>
    /// <param name="catapult"></param>
    /// <param name="horizon"></param>
    /// <returns></returns>
    private static Point GetProjectileLocation(Point catapult, int horizon)
    {
        return new Point(catapult.X, 2 * horizon - catapult.Y);
    }

    static void Main()
    {
        string shipCorner1XCoord = Console.ReadLine();
        int shipCorner1X = Int32.Parse(shipCorner1XCoord);

        string shipCorner1YCoord = Console.ReadLine();
        int shipCorner1Y = Int32.Parse(shipCorner1YCoord);

        string shipCorner2XCoord = Console.ReadLine();
        int shipCorner2X = Int32.Parse(shipCorner2XCoord);

        string shipCorner2YCoord = Console.ReadLine();
        int shipCorner2Y = Int32.Parse(shipCorner2YCoord);

        string hAxis = Console.ReadLine();
        int horizon = Int32.Parse(hAxis);

        string c1XCoord = Console.ReadLine();
        int c1X = Int32.Parse(c1XCoord);

        string c1YCoord = Console.ReadLine();
        int c1Y = Int32.Parse(c1YCoord);

        string c2XCoord = Console.ReadLine();
        int c2X = Int32.Parse(c2XCoord);

        string c2YCoord = Console.ReadLine();
        int c2Y = Int32.Parse(c2YCoord);

        string c3XCoord = Console.ReadLine();
        int c3X = Int32.Parse(c3XCoord);

        string c3YCoord = Console.ReadLine();
        int c3Y = Int32.Parse(c3YCoord);

        Point shipCorner1 = new Point(shipCorner1X, shipCorner1Y);
        Point shipCorner2 = new Point(shipCorner2X, shipCorner2Y);

        int totalDamage = 0;

        Point catapult1 = new Point(c1X, c1Y);
        Point projectile1 = GetProjectileLocation(catapult1, horizon);
        totalDamage += (int)GetHitLocation(projectile1, shipCorner1, shipCorner2);

        Point catapult2 = new Point(c2X, c2Y);
        Point projectile2 = GetProjectileLocation(catapult2, horizon);
        totalDamage += (int)GetHitLocation(projectile2, shipCorner1, shipCorner2);

        Point catapult3 = new Point(c3X, c3Y);
        Point projectile3 = GetProjectileLocation(catapult3, horizon);
        totalDamage += (int)GetHitLocation(projectile3, shipCorner1, shipCorner2);

        Console.WriteLine("{0}%", totalDamage);
    }
}
