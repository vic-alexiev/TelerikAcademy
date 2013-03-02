namespace Bank
{
    public interface IInterestCalculator
    {
        int PeriodInMonths { get; }

        decimal CalculateInterest();
    }
}
