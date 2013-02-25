using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.Enums;

namespace MobilePhoneUnitTests
{
    [TestClass]
    public class GsmTest
    {
        [TestMethod]
        public void TestGsmConstructor1()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(MobilePhoneManufacturer.Nokia, mobilePhone.Manufacturer);
        }

        [TestMethod]
        public void TestGsmConstructor2()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(BatteryType.LiIon, mobilePhone.Battery.Type);
        }

        [TestMethod]
        public void TestGsmConstructor3()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual("BL-4U", mobilePhone.Battery.Brand);
        }

        [TestMethod]
        public void TestGsmConstructor4()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(600, mobilePhone.Battery.StandByTime.Hours);
        }

        [TestMethod]
        public void TestGsmConstructor5()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(17, mobilePhone.Battery.TalkTime.Hours);
        }

        [TestMethod]
        public void TestGsmConstructor6()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(240, mobilePhone.Display.Size.ResolutionWidth);
        }

        [TestMethod]
        public void TestGsmConstructor7()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(400, mobilePhone.Display.Size.ResolutionHeight);
        }

        [TestMethod]
        public void TestGsmConstructor8()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(3.0, mobilePhone.Display.Size.Diagonal);
        }

        [TestMethod]
        public void TestGsmConstructor9()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(ColorDepth.Colors65K, mobilePhone.Display.Colors);
        }

        [TestMethod]
        public void TestGsmConstructor10()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual("Nokia Asha 310", mobilePhone.Brand);
        }

        [TestMethod]
        public void TestGsmConstructor11()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual(90, mobilePhone.Price);
        }

        [TestMethod]
        public void TestGsmConstructor12()
        {
            Gsm mobilePhone = new Gsm(MobilePhoneManufacturer.Nokia,
                new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                new Display(240, 400, 3.0, ColorDepth.Colors65K),
                "Nokia Asha 310",
                90,
                "Dustin Hoffman");

            Assert.AreEqual("Dustin Hoffman", mobilePhone.Owner);
        }

        [TestMethod]
        public void TestGsmConstructor13()
        {
            Gsm mobilePhone = new Gsm(
                MobilePhoneManufacturer.Motorola,
                new Battery(),
                new Display(),
                "Motorola ATRIX HD MB886");

            Assert.AreEqual(null, mobilePhone.Battery.StandByTime.Hours);
        }

        [TestMethod]
        public void TestGsmConstructor14()
        {
            Gsm mobilePhone = new Gsm(
                MobilePhoneManufacturer.Motorola,
                null,
                new Display(),
                "Motorola ATRIX HD MB886");

            Assert.AreEqual(null, mobilePhone.Battery.TalkTime.Minutes);
        }

        [TestMethod]
        public void TestGsmConstructor15()
        {
            Gsm mobilePhone = new Gsm(
                MobilePhoneManufacturer.Motorola,
                null,
                null,
                "Motorola ATRIX HD MB886");

            Assert.AreEqual(null, mobilePhone.Display.Size.ResolutionWidth);
        }

        [TestMethod]
        [ExpectedException(typeof(MobilePhoneException))]
        public void TestGsmConstructor16_ThrowsException()
        {
            Gsm mobilePhone = new Gsm(
                MobilePhoneManufacturer.Unknown,
                null,
                null,
                "Motorola ATRIX HD MB886");
        }

        [TestMethod]
        [ExpectedException(typeof(MobilePhoneException))]
        public void TestGsmConstructor17_ThrowsException()
        {
            Gsm mobilePhone = new Gsm(
                MobilePhoneManufacturer.SonyEricsson,
                null,
                null,
                "");
        }

        [TestMethod]
        public void TestStaticPropertyIPhone4S()
        {
            Assert.AreEqual(BatteryType.LiPoly, Gsm.IPhone4S.Battery.Type);
        }
    }
}
