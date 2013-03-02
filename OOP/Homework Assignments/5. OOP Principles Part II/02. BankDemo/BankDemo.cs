using Bank;
using Bank.Enums;
using System;
using System.Globalization;
using System.Threading;

class BankDemo
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        Account depositAccount = new DepositAccount(
            "2343PJ34752",
            "William",
            "Harris",
            "1 Microsoft Way, Redmond, WA",
            "1-888-553-6562",
            CustomerType.Individual,
            2500,
            1.0825M,
            12);

        Account loanAccount = new LoanAccount(
            "89BPQ123YJ0",
            "Oracle Corporation",
            String.Empty,
            "500 Oracle Parkway, Redwood Shores, Redwood City, California, United States",
            "1-981-717-9366",
            CustomerType.Corporate,
            1000000000,
            1.0931M,
            24);

        Account mortgageLoanAccount = new MortgageLoanAccount(
            "97A20LX3YJU",
            "Ginni",
            "Rometty",
            "Armonk, New York, U.S.",
            "1-129-342-3817",
            CustomerType.Individual,
            300000,
            1.0875M,
            36);

        decimal depositInterest = depositAccount.CalculateInterest(3);
        Console.WriteLine(depositInterest.ToString("C2"));

        decimal loanInterest = loanAccount.CalculateInterest(10);
        Console.WriteLine(loanInterest.ToString("C2"));

        decimal mortgageLoanInterest = mortgageLoanAccount.CalculateInterest(10);
        Console.WriteLine(mortgageLoanInterest.ToString("C2"));
    }
}
