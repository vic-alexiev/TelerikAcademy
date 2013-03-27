using System;

namespace Bank
{
    public abstract class Account : IDepositable
    {
        private Customer owner;
        protected decimal balance;
        private decimal monthlyInterestRate; // percent
        protected IInterestCalculator interestCalculator;

        public Customer Owner
        {
            get
            {
                return this.owner;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                this.balance = value;
            }
        }

        public decimal MonthlyInterestRate
        {
            get
            {
                return monthlyInterestRate;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be negative.");
                }
                this.monthlyInterestRate = value;
            }
        }

        protected Account(Customer owner, decimal balance, decimal monthlyInterestRate)
        {
            this.owner = owner;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public decimal CalculateInterest(int months)
        {
            if (months <= 0)
            {
                throw new ArgumentException("The interest period should be a positive integer.");
            }

            return (this.interestCalculator.CalculateInterest() / this.interestCalculator.PeriodInMonths) * months;
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
    }
}
