using System;
using System.Collections;
using System.Collections.Generic;

namespace Points3D
{
    public class Path : IEnumerable<Point3D>
    {
        private List<Point3D> pointsList;

        public int Count
        {
            get
            {
                return pointsList.Count;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                if (index < 0 || index >= pointsList.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return pointsList[index];
            }
        }

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
            return ((IEnumerable<Point3D>)this).GetEnumerator();
        }
    }
}
