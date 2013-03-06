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
        Console.WriteLine("Deposit account interest: {0:C2}", depositInterest);

        (depositAccount as IDepositable).Deposit(459.76M);
        (depositAccount as IWithdrawable).Withdraw(400.76M);

        Console.WriteLine("Deposit account balance: {0:C2}", depositAccount.Balance);

        decimal loanInterest = loanAccount.CalculateInterest(10);
        Console.WriteLine("Loan account interest: {0:C2}", loanInterest);

        decimal mortgageLoanInterest = mortgageLoanAccount.CalculateInterest(10);
        Console.WriteLine("Mortgage loan account interest: {0:C2}", mortgageLoanInterest);
    }
}
