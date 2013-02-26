using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace VersionsUnitTests
{
    [TestClass]
    [Version("1.0", "This is a test class.")]
    public class VersionsTest
    {
        [TestMethod]
        [Version("12.6")]
        public void TestClassVersionNumber()
        {
            Type type = typeof(VersionsTest);

            object[] customAttributes = type.GetCustomAttributes(false);

            Assert.AreEqual("1.0", (customAttributes[0] as VersionAttribute).Version);
        }

        [TestMethod]
        [Version("8.19", "Yet another test method.")]
        public void TestClassVersionComment()
        {
            Type type = typeof(VersionsTest);

            object[] customAttributes = type.GetCustomAttributes(false);

            Assert.AreEqual("This is a test class.", (customAttributes[0] as VersionAttribute).Comment);
        }

        [TestMethod]
        [Version("12.7")]
        public void TestMethodVersionNumber()
        {
            Type type = typeof(VersionsTest);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            object[] methodAttributes = methods[0].GetCustomAttributes(false);

            Assert.AreEqual("12.6", (methodAttributes[0] as VersionAttribute).Version);
        }

        [TestMethod]
        [Version("12.7")]
        public void TestMethodVersionComment()
        {
            Type type = typeof(VersionsTest);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            object[] methodAttributes = methods[1].GetCustomAttributes(false);

            Assert.AreEqual("Yet another test method.", (methodAttributes[0] as VersionAttribute).Comment);
        }
    }
}
