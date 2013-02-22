using System;
using System.Globalization;
using System.Threading;

class Point3DTest
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
        foreach (Point3D pointA in points)
        {
            foreach (Point3D pointB in points)
            {
                if (pointA != pointB)
                {
                    double distance = DistanceFinder.CalcDistance(pointA, pointB);

                    if (shortestDistance > distance)
                    {
                        shortestDistance = distance;
                    }
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
