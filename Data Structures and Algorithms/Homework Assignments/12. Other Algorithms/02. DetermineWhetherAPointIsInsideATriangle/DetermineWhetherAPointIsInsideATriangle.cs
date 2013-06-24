using System;

/// <summary>
/// For more info, see http://en.wikipedia.org/wiki/Barycentric_coordinate_system
/// </summary>
internal class DetermineWhetherAPointIsInsideATriangle
{
    private struct Point
    {
        public Point(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }

    private static bool AreCollinear(Point p1, Point p2, Point p3)
    {
        double slope1 = (p2.Y - p1.Y) / (p2.X - p1.X);

        double slope2 = (p3.Y - p2.Y) / (p3.X - p2.X);

        return slope1 == slope2;
    }

    private static bool PointIsInsideTriangle(Point p, Point p1, Point p2, Point p3)
    {
        if (AreCollinear(p1, p2, p3))
        {
            throw new ArgumentException(string.Format("The points {0}, {1} and {2} are collinear.", p1, p2, p3));
        }

        double lambda1 = ((p2.Y - p3.Y) * (p.X - p3.X) + (p3.X - p2.X) * (p.Y - p3.Y)) /
        ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));

        double lambda2 = ((p3.Y - p1.Y) * (p.X - p3.X) + (p1.X - p3.X) * (p.Y - p3.Y)) /
               ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));

        double lambda3 = 1.0 - lambda1 - lambda2;

        return 0.0 <= lambda1 && lambda1 <= 1.0 &&
            0.0 <= lambda2 && lambda2 <= 1.0 &&
            0.0 <= lambda3 && lambda3 <= 1.0;
    }

    private static void Main(string[] args)
    {
        Point p = new Point(10, 1);
        Point p1 = new Point(0, 0);
        Point p2 = new Point(5.7, 0);
        Point p3 = new Point(0, 4.91);

        //Point p1 = new Point(0, 0);
        //Point p2 = new Point(1, 1);
        //Point p3 = new Point(5, 5);

        bool inside = PointIsInsideTriangle(p, p1, p2, p3);
        Console.WriteLine("The point lies inside the triangle: " + inside);
    }
}
