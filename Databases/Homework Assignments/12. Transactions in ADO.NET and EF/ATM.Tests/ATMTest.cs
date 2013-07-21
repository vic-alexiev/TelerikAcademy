using ATM.DataAccess;
using ATM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Tests
{
    [TestClass]
    public class ATMTest
    {
        [TestMethod]
        public void TestWithdraw_CashInsufficient()
        {
            var dataManager = new DataManager(new ATMEntities());

            dataManager.InsertCardAccount("1113335559", "9871", 200.0M);

            ATMOperationResult withdrawResult = dataManager.WithdrawMoney("1113335557", "9871", 200.0M);

            Assert.AreEqual(ATMOperationResult.CashInsufficient, withdrawResult);
        }
    }
}
