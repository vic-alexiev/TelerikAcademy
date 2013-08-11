using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;
using System.IO;
using System.Text;

namespace KingSurvivalUnitTests
{
    /// <summary>
    /// Used to test the <see cref="Game"/> class functionality.
    /// </summary>
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestRunWithIORedirected()
        {
            string inputFilePath = "../../Resources/SampleInput.in";
            string outputFilePath = "../../Resources/SampleOutput.out";
            string expectedOutputFilePath = "../../Resources/ExpectedOutput.out";

            Game.RunWithIORedirected(inputFilePath, outputFilePath);

            string actualOutput = File.ReadAllText(outputFilePath, Encoding.ASCII);
            string expectedOutput = File.ReadAllText(expectedOutputFilePath, Encoding.ASCII);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
