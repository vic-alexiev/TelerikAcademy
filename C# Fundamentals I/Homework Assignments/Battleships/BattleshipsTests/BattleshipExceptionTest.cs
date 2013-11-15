// ********************************
// <copyright file="BattleshipExceptionTest.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace BattleshipsTests
{
    using System;
    using Battleships;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="BattleshipException"/> class functionality.
    /// </summary>
    [TestClass]
    public class BattleshipExceptionTest
    {
        [TestMethod]
        public void TestConstructor_NoParameters()
        {
            BattleshipException battleshipEx = new BattleshipException();

            Assert.AreEqual("Error in the application.", battleshipEx.Message);
            Assert.AreEqual(null, battleshipEx.InnerException);
        }

        [TestMethod]
        public void TestConstructor_MessageProvided()
        {
            BattleshipException battleshipEx = new BattleshipException("Test");

            Assert.AreEqual("Test", battleshipEx.Message);
            Assert.AreEqual(null, battleshipEx.InnerException);
        }

        [TestMethod]
        public void TestConstructor_MessageAndInnerExceptionProvided()
        {
            Exception innerEx = new InvalidOperationException();
            BattleshipException battleshipEx =
                new BattleshipException("Test", innerEx);

            Assert.AreEqual("Test", battleshipEx.Message);
            Assert.AreSame(innerEx, battleshipEx.InnerException);
        }
    }
}
