using System;

namespace Bank
{
    public class DepositAccountInterestCalculator : IInterestCalculator
    {
        #region Private Fields

        private decimal principal;
        private decimal minInterestPrincipal;
        private decimal monthlyInterestRate;
        private int periodInMonths;

        #endregion

        #region Properties

        public decimal Principal
        {
            get
            {
                return principal;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Principal must be positive.");
                }
                principal = value;
            }
        }

        public decimal MinInterestPrincipal
        {
            get
            {
                return minInterestPrincipal;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Minimum interest principal must be positive.");
                }
                minInterestPrincipal = value;
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
                if (value <= 0)
                {
                    throw new ArgumentException("Interest rate must be positive.");
                }
                monthlyInterestRate = value;
            }
        }

        public int PeriodInMonths
        {
            get
            {
                return periodInMonths;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Period in months must be positive.");
                }
                periodInMonths = value;
            }
        }

        #endregion

        #region Constructors

        public DepositAccountInterestCalculator(
            decimal principal, decimal monthlyInterestRate, int periodInMonths)
        {
            this.Principal = principal;
            this.MinInterestPrincipal = 1000;
            this.MonthlyInterestRate = monthlyInterestRate;
            this.PeriodInMonths = periodInMonths;
        }

        #endregion

        #region Public Methods

        public decimal CalculateInterest()
        {
            if (this.principal < this.MinInterestPrincipal)
            {
                return 0;
            }

            return (this.monthlyInterestRate / 100) * this.principal * this.periodInMonths;
        }

        #endregion
    }
}
