using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace StringExtensionUnitTests
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void TestCapitalizeFirstLetters()
        {
            string markTwain = "College is a place where a professor's lecture notes go straight to the students' lecture notes, without passing through the brains of either.";
            string markTwainCapitalized = markTwain.CapitalizeFirstLetters(new CultureInfo("en-US"));

            Assert.AreEqual("College Is A Place Where A Professor's Lecture Notes Go Straight To The Students' Lecture Notes, Without Passing Through The Brains Of Either.", markTwainCapitalized);
        }
    }
}
