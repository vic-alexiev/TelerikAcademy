using System.Collections;
using System.Collections.Generic;

public class Path : IEnumerable<Point3D>
{
    private List<Point3D> pointsList;

    public Path()
    {
        pointsList = new List<Point3D>();
    }

    public void Add(Point3D point)
    {
        pointsList.Add(point);
    }

    public IEnumerator<Point3D> GetEnumerator()
    {
        foreach (Point3D point in pointsList)
            yield return point;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        foreach (Point3D point in pointsList)
            yield return point;
    }
}
