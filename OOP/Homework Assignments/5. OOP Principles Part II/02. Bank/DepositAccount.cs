using Bank.Enums;
using System;

namespace Bank
{
    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(
            string ownerId,
            string ownerName,
            string ownerLastName,
            string ownerAddress,
            string ownerPhone,
            CustomerType customerType,
            decimal balance,
            decimal monthlyInterestRate,
            int periodInMonths)
            : base(ownerId, ownerName, ownerLastName, ownerAddress, ownerPhone, customerType, balance, monthlyInterestRate)
        {
            this.interestCalculator = new DepositAccountInterestCalculator(
                balance, monthlyInterestRate, periodInMonths);
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (this.balance < amount)
            {
                throw new ArgumentException("Not enough money.");
            }
            this.balance -= amount;
        }
    }
}
