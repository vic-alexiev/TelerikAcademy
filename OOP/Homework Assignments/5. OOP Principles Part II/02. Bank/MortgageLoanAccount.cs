namespace Bank
{
    public class MortgageLoanAccount : Account
    {
        public MortgageLoanAccount(
            Customer owner,
            decimal balance,
            decimal monthlyInterestRate,
            int periodInMonths)
            : base(owner, balance, monthlyInterestRate)
        {
            this.interestCalculator = new MortgageLoanAccountInterestCalculator(
                owner, balance, monthlyInterestRate, periodInMonths);
        }
    }
}
