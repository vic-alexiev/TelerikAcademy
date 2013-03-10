namespace Bank
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(
            Customer owner,
            decimal balance,
            decimal monthlyInterestRate,
            int periodInMonths)
            : base(owner, balance, monthlyInterestRate)
        {
            this.interestCalculator = new LoanAccountInterestCalculator(
                owner, balance, monthlyInterestRate, periodInMonths);
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
    }
}
