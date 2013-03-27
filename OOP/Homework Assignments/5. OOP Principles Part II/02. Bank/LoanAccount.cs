namespace Bank
{
    public class LoanAccount : Account
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
    }
}
