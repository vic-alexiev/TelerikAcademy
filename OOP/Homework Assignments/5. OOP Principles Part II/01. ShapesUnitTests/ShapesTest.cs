using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
using System;

namespace ShapesUnitTests
{
    [TestClass]
    public class ShapesTest
    {
        [TestMethod]
        public void TestShapeConstructor1()
        {
            Rectangle r = new Rectangle(20, 30);

            Assert.AreEqual(20, r.Width);
        }

        [TestMethod]
        public void TestShapeConstructor2()
        {
            Rectangle r = new Rectangle(7, 19.25);

            Assert.AreEqual(19.25, r.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestShapeConstructor3_ThrowsException()
        {
            Shape r = new Rectangle(0, 19.25);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestShapeConstructor4_ThrowsException()
        {
            Shape r = new Rectangle(8.102, -10.3);
        }

        [TestMethod]
        public void TestRectangleCalculateArea()
        {
            Rectangle r = new Rectangle(2.1, 39);

            Assert.AreEqual(81.9, r.CalculateArea());
        }

        [TestMethod]
        public void TestTriangleCalculateArea()
        {
            Triangle r = new Triangle(2.1, 39);

            Assert.AreEqual(40.95, r.CalculateArea());
        }

        [TestMethod]
        public void TestCircleCalculateArea()
        {
            Circle r = new Circle(12);

            Assert.AreEqual(452.389342, Math.Round(r.CalculateArea(), 6));
        }
    }
}
