using Bank.Enums;
using System;

namespace Bank
{
    public abstract class Account
    {
        protected Customer owner;
        protected decimal balance;
        private decimal monthlyInterestRate; // percent
        protected IInterestCalculator interestCalculator;

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Balance must be positive.");
                }
            }
        }

        protected decimal MonthlyInterestRate
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
                monthlyInterestRate = value;
            }
        }

        public Account(
            string ownerId,
            string ownerName,
            string ownerLastName,
            string ownerAddress,
            string ownerPhone,
            CustomerType customerType,
            decimal balance,
            decimal monthlyInterestRate)
        {
            if (customerType == CustomerType.Individual)
            {
                this.owner = new IndividualCustomer(ownerId, ownerName, ownerLastName, ownerAddress, ownerPhone);
            }
            else
            {
                this.owner = new CorporateCustomer(ownerId, ownerName, ownerAddress, ownerPhone);
            }

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
    }
}
