using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Points3D;

namespace Points3DUnitTests
{
    [TestClass]
    public class Points3DTest
    {
        [TestMethod]
        public void TestOrigin()
        {
            Point3D origin = Point3D.Origin;

            Assert.AreEqual(0, origin.X);
            Assert.AreEqual(0, origin.Y);
            Assert.AreEqual(0, origin.Z);
        }

        [TestMethod]
        public void TestPath()
        {
            Path points = new Path();

            Point3D point = new Point3D(2, -5, 7);
            points.Add(point);

            Assert.AreEqual(2, point.X);
            Assert.AreEqual(-5, point.Y);
            Assert.AreEqual(7, point.Z);
        }

        [TestMethod]
        public void TestCalcDistance()
        {
            Path points = new Path();

            Point3D point1 = new Point3D(0, 0, 0);
            points.Add(point1);
            Point3D point2 = new Point3D(1, 1, 0);
            points.Add(point2);

            double distance = DistanceFinder.CalcDistance(points[1], points[0]);

            Assert.AreEqual(1.41, Math.Round(distance, 2));
        }
    }
}
