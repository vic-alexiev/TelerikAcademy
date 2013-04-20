// ********************************
// <copyright file="UtilsTest.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace UtilsUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utils;

    /// <summary>
    /// Tests the methods in the <see cref="Utils.GeometryUtils"/> class.
    /// </summary>
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void TestCalcTriangleArea1()
        {
            double area = GeometryUtils.CalcTriangleArea(3, 4, 5);
            Assert.AreEqual(6, area);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcTriangleArea2_ThrowsException()
        {
            double area = GeometryUtils.CalcTriangleArea(0, 40, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcTriangleArea3_ThrowsException()
        {
            double area = GeometryUtils.CalcTriangleArea(10, 0, 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcTriangleArea4_ThrowsException()
        {
            double area = GeometryUtils.CalcTriangleArea(10, 30, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcTriangleArea5_ThrowsException()
        {
            double area = GeometryUtils.CalcTriangleArea(-5, 12, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcTriangleArea6_ThrowsException()
        {
            double area = GeometryUtils.CalcTriangleArea(5, -12, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcTriangleArea7_ThrowsException()
        {
            double area = GeometryUtils.CalcTriangleArea(5, 12, -13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcTriangleArea8_ThrowsException()
        {
            double area = GeometryUtils.CalcTriangleArea(18.24, 100, 31.0057);
        }

        [TestMethod]
        public void TestCalcTriangleArea9()
        {
            double area = GeometryUtils.CalcTriangleArea(60, 91, 109);
            Assert.AreEqual(2730, area);
        }

        [TestMethod]
        public void TestDigitToText1()
        {
            string[] digits = new string[10]
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };

            for (int i = 0; i < 10; i++)
            {
                string word = LanguageUtils.DigitToText(i);
                Assert.AreEqual(digits[i], word);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDigitToText2_ThrowsException()
        {
            string word = LanguageUtils.DigitToText(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDigitToText3_ThrowsException()
        {
            string word = LanguageUtils.DigitToText(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMax1_ThrowsException()
        {
            int max = StatisticalUtils.Max(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMax2_ThrowsException()
        {
            int max = StatisticalUtils.Max();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMax3_ThrowsException()
        {
            int max = StatisticalUtils.Max(new int[0]);
        }

        [TestMethod]
        public void TestMax4()
        {
            int max = StatisticalUtils.Max(new int[1]);
            Assert.AreEqual(0, max);
        }

        [TestMethod]
        public void TestMax5()
        {
            int max = StatisticalUtils.Max(1, 9, 17, 3, 6, 999, 66);
            Assert.AreEqual(999, max);
        }

        [TestMethod]
        public void TestCalcDistance1()
        {
            double distance = GeometryUtils.CalcDistance(0, 0, 1, 1);
            Assert.AreEqual(Math.Sqrt(2), distance);
        }

        [TestMethod]
        public void TestCalcDistance2()
        {
            double distance = GeometryUtils.CalcDistance(1, 1, 5, 4);
            Assert.AreEqual(5, distance);
        }

        [TestMethod]
        public void TestCalcDistance3()
        {
            double distance = GeometryUtils.CalcDistance(12.8, 9.73, 12.8, 9.73);
            Assert.AreEqual(0, distance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsLineHorizontal1_ThrowsException()
        {
            bool horizontal = GeometryUtils.IsLineHorizontal(12.8, 9.73, 12.8, 9.73);
        }

        [TestMethod]
        public void TestIsLineHorizontal2()
        {
            bool horizontal = GeometryUtils.IsLineHorizontal(12.8, 9.73, -12.8, 9.73);
            Assert.AreEqual(true, horizontal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsLineVertical1_ThrowsException()
        {
            bool vertical = GeometryUtils.IsLineVertical(12.8, 9.73, 12.8, 9.73);
        }

        [TestMethod]
        public void TestIsLineVertical2()
        {
            bool vertical = GeometryUtils.IsLineVertical(12.8, -9.73, 12.8, 9.73);
            Assert.AreEqual(true, vertical);
        }
    }
}
