// ********************************
// <copyright file="TelerikStringExtensionsTest.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace TelerikStringExtensionsUnitTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TelerikStringExtensions;

    /// <summary>
    /// Contains methods which test the extension methods for the <see cref="System.String"/> class.
    /// </summary>
    [TestClass]
    public class TelerikStringExtensionsTest
    {
        [TestMethod]
        public void TestToMD5Hash()
        {
            string value = "The quick brown fox jumps over the lazy dog";
            Assert.AreEqual("9e107d9d372bb6826bd81d3542a419d6", value.ToMD5Hash());
        }

        [TestMethod]
        public void TestToBoolean1()
        {
            string value = "yes";
            Assert.AreEqual(true, value.ToBoolean());
        }

        [TestMethod]
        public void TestToBoolean2()
        {
            string value = "false";
            Assert.AreEqual(false, value.ToBoolean());
        }

        [TestMethod]
        public void TestToShort1()
        {
            string value = "-32768";
            Assert.AreEqual(-32768, value.ToShort());
        }

        [TestMethod]
        public void TestToShort2()
        {
            string value = "65535";
            Assert.AreEqual(0, value.ToShort());
        }

        [TestMethod]
        public void TestToShort3()
        {
            string value = string.Empty;
            Assert.AreEqual(0, value.ToShort());
        }

        [TestMethod]
        public void TestToShort4()
        {
            string value = null;
            Assert.AreEqual(0, value.ToShort());
        }

        [TestMethod]
        public void TestToShort5()
        {
            string value = "test value";
            Assert.AreEqual(0, value.ToShort());
        }

        [TestMethod]
        public void TestToShort6()
        {
            string value = "3.141592";
            Assert.AreEqual(0, value.ToShort());
        }

        [TestMethod]
        public void TestToInteger1()
        {
            string value = "1234567890";
            Assert.AreEqual(1234567890, value.ToInteger());
        }

        [TestMethod]
        public void TestToInteger2()
        {
            string value = "2147483648";
            Assert.AreEqual(0, value.ToInteger());
        }

        [TestMethod]
        public void TestToInteger3()
        {
            string value = string.Empty;
            Assert.AreEqual(0, value.ToInteger());
        }

        [TestMethod]
        public void TestToInteger4()
        {
            string value = null;
            Assert.AreEqual(0, value.ToInteger());
        }

        [TestMethod]
        public void TestToInteger5()
        {
            string value = "some string";
            Assert.AreEqual(0, value.ToInteger());
        }

        [TestMethod]
        public void TestToInteger6()
        {
            string value = "2.718281828";
            Assert.AreEqual(0, value.ToInteger());
        }

        [TestMethod]
        public void TestToLong1()
        {
            string value = "9223372036854775807";
            Assert.AreEqual(9223372036854775807, value.ToLong());
        }

        [TestMethod]
        public void TestToLong2()
        {
            string value = "9223372036854775808";
            Assert.AreEqual(0, value.ToLong());
        }

        [TestMethod]
        public void TestToLong3()
        {
            string value = string.Empty;
            Assert.AreEqual(0, value.ToLong());
        }

        [TestMethod]
        public void TestToLong4()
        {
            string value = null;
            Assert.AreEqual(0, value.ToLong());
        }

        [TestMethod]
        public void TestToLong5()
        {
            string value = "some string";
            Assert.AreEqual(0, value.ToLong());
        }

        [TestMethod]
        public void TestToLong6()
        {
            string value = "-2.718281828";
            Assert.AreEqual(0, value.ToLong());
        }

        [TestMethod]
        public void TestToDateTime1()
        {
            string value = "2013/4/30 15:31:00";
            Assert.AreEqual(new DateTime(2013, 4, 30, 15, 31, 0), value.ToDateTime());
        }

        [TestMethod]
        public void TestToDateTime2()
        {
            string value = "20013/4/30 15:31:00";
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 0, 0), value.ToDateTime());
        }

        [TestMethod]
        public void TestToDateTime3()
        {
            string value = string.Empty;
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 0, 0), value.ToDateTime());
        }

        [TestMethod]
        public void TestToDateTime4()
        {
            string value = null;
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 0, 0), value.ToDateTime());
        }

        [TestMethod]
        public void TestCapitalizeFirstLetter1()
        {
            string value = null;
            Assert.AreEqual(null, value.CapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestCapitalizeFirstLetter2()
        {
            string value = string.Empty;
            Assert.AreEqual(string.Empty, value.CapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestCapitalizeFirstLetter3()
        {
            string value = "   ";
            Assert.AreEqual("   ", value.CapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestCapitalizeFirstLetter4()
        {
            string value = "telerik";
            Assert.AreEqual("Telerik", value.CapitalizeFirstLetter());
        }

        [TestMethod]
        public void TestGetStringBetween1()
        {
            string value = "The quick brown fox jumps over the lazy dog";
            Assert.AreEqual(" jumps over the lazy ", value.GetStringBetween("fox", "dog"));
        }

        [TestMethod]
        public void TestGetStringBetween2()
        {
            string value = "The quick brown fox jumps over the lazy dog";
            Assert.AreEqual(string.Empty, value.GetStringBetween("rabbit", "dog"));
        }

        [TestMethod]
        public void TestGetStringBetween3()
        {
            string value = "The quick brown fox jumps over the lazy dog";
            Assert.AreEqual(string.Empty, value.GetStringBetween("fox", "tortoise"));
        }

        [TestMethod]
        public void TestGetStringBetween4()
        {
            string value = "The quick brown fox jumps over the lazy dog";
            Assert.AreEqual(string.Empty, value.GetStringBetween("fox", "dog", 20));
        }

        [TestMethod]
        public void TestConvertCyrillicToLatinLetters1()
        {
            string value = "Стани, стани, юнак балкански";
            Assert.AreEqual("Stani, stani, yunak balkanski", value.ConvertCyrillicToLatinLetters());
        }

        [TestMethod]
        public void TestConvertCyrillicToLatinLetters2()
        {
            string value = "Stand up, stand up, Balkan Superman";
            Assert.AreEqual("Stand up, stand up, Balkan Superman", value.ConvertCyrillicToLatinLetters());
        }

        [TestMethod]
        public void TestConvertCyrillicToLatinLetters3()
        {
            string value = string.Empty;
            Assert.AreEqual(string.Empty, value.ConvertCyrillicToLatinLetters());
        }

        [TestMethod]
        public void TestConvertLatinToCyrillicKeyboard1()
        {
            string value = "It is a truth universally acknowledged";
            Assert.AreEqual("Ит ис а трутх унижерсаллъ ацкновледгед", value.ConvertLatinToCyrillicKeyboard());
        }

        [TestMethod]
        public void TestConvertLatinToCyrillicKeyboard2()
        {
            string value = "Благодаря!";
            Assert.AreEqual("Благодаря!", value.ConvertLatinToCyrillicKeyboard());
        }

        [TestMethod]
        public void TestConvertLatinToCyrillicKeyboard3()
        {
            string value = string.Empty;
            Assert.AreEqual(string.Empty, value.ConvertLatinToCyrillicKeyboard());
        }

        [TestMethod]
        public void TestToValidUsername1()
        {
            string value = "петър.иванов";
            Assert.AreEqual("petur.ivanov", value.ToValidUsername());
        }

        [TestMethod]
        public void TestToValidUsername2()
        {
            string value = "георги йорданов";
            Assert.AreEqual("georgiyordanov", value.ToValidUsername());
        }

        [TestMethod]
        public void TestToValidUsername3()
        {
            string value = string.Empty;
            Assert.AreEqual(string.Empty, value.ToValidUsername());
        }

        [TestMethod]
        public void TestToValidLatinFileName1()
        {
            string value = "протокол от изборите.pdf";
            Assert.AreEqual("protokol-ot-izborite.pdf", value.ToValidLatinFileName());
        }

        [TestMethod]
        public void TestToValidLatinFileName2()
        {
            string value = "Doc1.docx";
            Assert.AreEqual("Doc1.docx", value.ToValidLatinFileName());
        }

        [TestMethod]
        public void TestToValidLatinFileName3()
        {
            string value = string.Empty;
            Assert.AreEqual(string.Empty, value.ToValidLatinFileName());
        }

        [TestMethod]
        public void TestGetFirstCharacters1()
        {
            string value = string.Empty;
            Assert.AreEqual(string.Empty, value.GetFirstCharacters(10));
        }

        [TestMethod]
        public void TestGetFirstCharacters2()
        {
            string value = "The quick brown fox jumps over the lazy dog";
            Assert.AreEqual("The qui", value.GetFirstCharacters(7));
        }

        [TestMethod]
        public void TestGetFirstCharacters3()
        {
            string value = "Telerik Academy";
            Assert.AreEqual("Telerik Academy", value.GetFirstCharacters(20));
        }

        [TestMethod]
        public void TestGetFileExtension1()
        {
            string value = "4. Code Documentation and Comments Homework.zip";
            Assert.AreEqual("zip", value.GetFileExtension());
        }

        [TestMethod]
        public void TestGetFileExtension2()
        {
            string value = "homework-high-quality-programming-code.tar.gz";
            Assert.AreEqual("gz", value.GetFileExtension());
        }

        [TestMethod]
        public void TestGetFileExtension3()
        {
            string value = string.Empty;
            Assert.AreEqual(string.Empty, value.GetFileExtension());
        }

        [TestMethod]
        public void TestToContentType1()
        {
            string value = "doc";
            Assert.AreEqual("application/msword", value.ToContentType());
        }

        [TestMethod]
        public void TestToContentType2()
        {
            string value = "gif";
            Assert.AreEqual("application/octet-stream", value.ToContentType());
        }

        [TestMethod]
        public void TestToContentType3()
        {
            string value = string.Empty;
            Assert.AreEqual("application/octet-stream", value.ToContentType());
        }
    }
}
