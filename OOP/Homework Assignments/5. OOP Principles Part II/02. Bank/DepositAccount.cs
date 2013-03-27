using System;

namespace Bank
{
    public class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(
            Customer owner,
            decimal balance,
            decimal monthlyInterestRate,
            int periodInMonths)
            : base(owner, balance, monthlyInterestRate)
        {
            this.interestCalculator = new DepositAccountInterestCalculator(
                balance, monthlyInterestRate, periodInMonths);
        }

        public void Withdraw(decimal amount)
        {
            if (this.balance < amount)
            {
                throw new ArgumentException("Balance too low.");
            }
            this.balance -= amount;
        }
    }
}
