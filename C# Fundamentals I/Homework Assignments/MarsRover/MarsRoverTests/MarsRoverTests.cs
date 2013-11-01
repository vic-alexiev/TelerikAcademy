using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRoverTests
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandsException))]
        public void RunMarsRoverWithNoCommands1()
        {
            int x;
            int y;
            int lastSuccessIndex;
            bool success = MarsRover.MarsRover.Run(null, out x, out y, out lastSuccessIndex);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandsException))]
        public void RunMarsRoverWithNoCommands2()
        {
            int x;
            int y;
            int lastSuccessIndex;
            bool success = MarsRover.MarsRover.Run(String.Empty, out x, out y, out lastSuccessIndex);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandsException))]
        public void RunMarsRoverWithInvalidCommands()
        {
            int x;
            int y;
            int lastSuccessIndex;
            bool success = MarsRover.MarsRover.Run("RRFFLFTYZ12374", out x, out y, out lastSuccessIndex);

            Assert.Fail();
        }

        [TestMethod]
        public void RunMarsRoverInsideTheGrid1()
        {
            int x;
            int y;
            int lastSuccessIndex;
            bool success = MarsRover.MarsRover.Run("RFLFFRF", out x, out y, out lastSuccessIndex);

            Assert.AreEqual(2, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual(7, lastSuccessIndex);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void RunMarsRoverInsideTheGrid2()
        {
            int x;
            int y;
            int lastSuccessIndex;
            bool success = MarsRover.MarsRover.Run("FRFFBLF", out x, out y, out lastSuccessIndex);

            Assert.AreEqual(1, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual(7, lastSuccessIndex);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void RunMarsRoverInsideTheGrid3()
        {
            int x;
            int y;
            int lastSuccessIndex;
            bool success = MarsRover.MarsRover.Run("RFLLLBRF", out x, out y, out lastSuccessIndex);

            Assert.AreEqual(0, x);
            Assert.AreEqual(1, y);
            Assert.AreEqual(8, lastSuccessIndex);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void RunMarsRoverOutsideTheGrid()
        {
            int x;
            int y;
            int lastSuccessIndex;
            bool success = MarsRover.MarsRover.Run("RFLFFRFLFFRFFLF", out x, out y, out lastSuccessIndex);

            Assert.AreEqual(4, x);
            Assert.AreEqual(4, y);
            Assert.AreEqual(14, lastSuccessIndex);
            Assert.AreEqual(false, success);
        }
    }
}
