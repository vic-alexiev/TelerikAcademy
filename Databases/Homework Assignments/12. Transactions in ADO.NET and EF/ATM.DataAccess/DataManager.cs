using ATM.Model;
using System.Transactions;
using System.Linq;
using System;

namespace ATM.DataAccess
{
    public class DataManager
    {
        #region Private Fields

        private ATMEntities atmContext;

        #endregion

        #region Constructor

        public DataManager(ATMEntities atmContext)
        {
            this.atmContext = atmContext;
        }

        #endregion

        #region Public Methods

        public ATMOperationResult WithdrawMoney(string cardNumber, string cardPIN, decimal amount)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                var matches = this.atmContext.CardAccounts.Where(a => a.CardNumber == cardNumber).ToList();

                if (matches.Count == 0)
                {
                    return ATMOperationResult.CardNumberInvalid;
                }

                var account = matches[0];

                if (account.CardPIN != cardPIN)
                {
                    return ATMOperationResult.CardPINInvalid;
                }

                if (account.CardCash <= amount)
                {
                    return ATMOperationResult.CashInsufficient;
                }

                account.CardCash -= amount;
                this.atmContext.SaveChanges();

                this.SaveTransactionHistory(cardNumber, amount);

                scope.Complete();

                return ATMOperationResult.Success;
            }
        }

        public ATMOperationResult GetCardCash(string cardNumber, string cardPIN, out decimal cash)
        {
            cash = 0.0M;

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                var matches = this.atmContext.CardAccounts.Where(a => a.CardNumber == cardNumber).ToList();

                if (matches.Count == 0)
                {
                    return ATMOperationResult.CardNumberInvalid;
                }

                var account = matches[0];

                if (account.CardPIN != cardPIN)
                {
                    return ATMOperationResult.CardPINInvalid;
                }

                cash = account.CardCash;

                scope.Complete();

                return ATMOperationResult.Success;
            }
        }

        public void InsertCardAccount(string cardNumber, string cardPIN, decimal cash)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                CardAccount account = new CardAccount
                {
                    CardNumber = cardNumber,
                    CardPIN = cardPIN,
                    CardCash = cash
                };

                this.atmContext.CardAccounts.Add(account);
                this.atmContext.SaveChanges();

                scope.Complete();
            }
        }

        #endregion

        #region Private Methods

        private void SaveTransactionHistory(string cardNumber, decimal amount)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                TransactionsHistory transactionInfo = new TransactionsHistory
                {
                    CardNumber = cardNumber,
                    TransactionDate = DateTime.Now,
                    Amount = amount
                };

                this.atmContext.TransactionsHistories.Add(transactionInfo);
                this.atmContext.SaveChanges();

                scope.Complete();
            }
        }

        #endregion
    }
}
