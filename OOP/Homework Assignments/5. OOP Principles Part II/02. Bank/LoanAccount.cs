using Bank.Enums;

namespace Bank
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(
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
            this.interestCalculator = new LoanAccountInterestCalculator(
                customerType, balance, monthlyInterestRate, periodInMonths);
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
    }
}
