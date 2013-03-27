using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankUnitTests
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void TestCustomerConstructor1()
        {
            Customer customer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Assert.AreEqual("2343PJ34752", customer.Id);
        }

        [TestMethod]
        public void TestCustomerConstructor2()
        {
            Customer customer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Assert.AreEqual("William", customer.Name);
        }

        [TestMethod]
        public void TestCustomerConstructor3()
        {
            Customer customer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Assert.AreEqual("Harris", customer.LastName);
        }

        [TestMethod]
        public void TestCustomerConstructor4()
        {
            Customer customer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Assert.AreEqual("1 Microsoft Way, Redmond, WA", customer.Address);
        }

        [TestMethod]
        public void TestCustomerConstructor5()
        {
            Customer customer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Assert.AreEqual("1-888-553-6562", customer.Phone);
        }

        [TestMethod]
        public void TestAccountConstructor1()
        {
            Customer accountCustomer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Account account = new DepositAccount(
                accountCustomer,
                2500,
                1.0825M,
                12);

            Assert.AreEqual(2500, account.Balance);
        }

        [TestMethod]
        public void TestAccountConstructor2()
        {
            Customer accountCustomer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Account account = new DepositAccount(
                accountCustomer,
                2500,
                1.0825M,
                12);

            Assert.AreEqual(1.0825M, account.MonthlyInterestRate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAccountConstructor3_ThrowsException()
        {
            Customer accountCustomer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Account account = new DepositAccount(
                accountCustomer,
                -2500,
                1.0825M,
                12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAccountConstructor4_ThrowsException()
        {
            Customer accountCustomer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Account account = new DepositAccount(
                accountCustomer,
                2500,
                -1.0825M,
                12);
        }

        [TestMethod]
        public void TestWithdrawMethod()
        {
            Customer accountCustomer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            DepositAccount account = new DepositAccount(
                accountCustomer,
                2500,
                1.0825M,
                12);

            account.Withdraw(400M);

            Assert.AreEqual(2100M, account.Balance);
        }

        [TestMethod]
        public void TestDepositMethod()
        {
            Customer accountCustomer = new IndividualCustomer(
                "2343PJ34752",
                "William",
                "Harris",
                "1 Microsoft Way, Redmond, WA",
                "1-888-553-6562");

            Account account = new DepositAccount(
                accountCustomer,
                32500,
                1.0825M,
                12);

            account.Deposit(459M);

            Assert.AreEqual(32959M, account.Balance);
        }
    }
}
