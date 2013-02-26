using Points3D;
using System;
using System.Globalization;
using System.Threading;

class Points3DDemo
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Path points = PathStorage.LoadPath("..\\..\\TestFiles\\Input.txt");

        foreach (Point3D point in points)
        {
            Console.WriteLine(point);
        }

        Console.WriteLine(Point3D.Origin);

        double shortestDistance = Double.MaxValue;

        // find the distance between the closest points
        for (int i = 0; i < points.Count - 1; i++)
        {
            for (int j = i + 1; j < points.Count; j++)
            {
                double distance = DistanceFinder.CalcDistance(points[i], points[j]);

                if (shortestDistance > distance)
                {
                    shortestDistance = distance;
                }
            }
        }

        Console.WriteLine("The distance between the closest points is {0:F2}.", shortestDistance);

        //Path resultPath = new Path();

        //foreach (Point3D point in points)
        //{
        //    resultPath.Add(point);
        //}

        //PathStorage.SavePath(resultPath, "..\\..\\TestFiles\\Output.txt");
    }
}
