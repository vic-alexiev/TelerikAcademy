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
    /// Used to test the functionality of the <see cref="FileUtils"/> and
    /// <see cref="GeometryUtils"/> classes.
    /// </summary>
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetExtension1_ThrowsException()
        {
            string extension = FileUtils.GetExtension(null);
        }

        [TestMethod]
        public void TestGetExtension2()
        {
            string extension = FileUtils.GetExtension(string.Empty);
            Assert.AreEqual(string.Empty, extension);
        }

        [TestMethod]
        public void TestGetExtension3()
        {
            string extension = FileUtils.GetExtension("Microsoft.VisualStudio.TestTools.UnitTesting");
            Assert.AreEqual("UnitTesting", extension);
        }

        [TestMethod]
        public void TestGetExtension4()
        {
            string extension = FileUtils.GetExtension("jquery-1.9.1.js");
            Assert.AreEqual("js", extension);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetFileNameWithoutExtension1_ThrowsException()
        {
            string fileNameWithoutExtension = FileUtils.GetFileNameWithoutExtension(null);
        }

        [TestMethod]
        public void TestGetFileNameWithoutExtension2()
        {
            string fileNameWithoutExtension = FileUtils.GetFileNameWithoutExtension(string.Empty);
            Assert.AreEqual(string.Empty, fileNameWithoutExtension);
        }

        [TestMethod]
        public void TestGetFileNameWithoutExtension3()
        {
            string fileNameWithoutExtension = FileUtils.GetFileNameWithoutExtension("Microsoft.VisualStudio.TestTools.UnitTesting");
            Assert.AreEqual("Microsoft.VisualStudio.TestTools", fileNameWithoutExtension);
        }

        [TestMethod]
        public void TestGetFileNameWithoutExtension4()
        {
            string fileNameWithoutExtension = FileUtils.GetFileNameWithoutExtension("jquery-1.9.1.js");
            Assert.AreEqual("jquery-1.9.1", fileNameWithoutExtension);
        }

        [TestMethod]
        public void TestCalcDistance2D()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, 1, 1);
            Assert.AreEqual(Math.Sqrt(2), distance);
        }

        [TestMethod]
        public void TestCalcDistance3D()
        {
            double distance = GeometryUtils.CalcDistance3D(0, 0, 0, 1, 1, 1);
            Assert.AreEqual(Math.Sqrt(3), distance);
        }
    }
}
