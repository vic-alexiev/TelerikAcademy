using ATM.DataAccess;
using ATM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Client
{
    internal class ATMDemo
    {
        private static void Main()
        {
            var dataManager = new DataManager(new ATMEntities());

            ATMOperationResult withdrawResult = dataManager.WithdrawMoney("9273412345", "8356", 200);

            if (withdrawResult == ATMOperationResult.Success)
            {
                decimal cardCash;
                ATMOperationResult retrieveResult = dataManager.GetCardCash("9273412345", "8356", out cardCash);

                if (retrieveResult == ATMOperationResult.Success)
                {
                    Console.WriteLine("Remaining cash: {0:N2}", cardCash);
                }
            }
        }
    }
}
