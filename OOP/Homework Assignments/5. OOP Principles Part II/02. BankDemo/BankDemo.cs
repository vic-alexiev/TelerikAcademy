using Bank;
using System;
using System.Globalization;
using System.Threading;

class BankDemo
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        Customer depositAccountCustomer = new IndividualCustomer(
            "2343PJ34752",
            "William",
            "Harris",
            "1 Microsoft Way, Redmond, WA",
            "1-888-553-6562");

        DepositAccount depositAccount = new DepositAccount(
            depositAccountCustomer,
            2500,
            1.0825M,
            12);

        Customer loanAccountCustomer = new CorporateCustomer(
            "89BPQ123YJ0",
            "Oracle Corporation",
            "500 Oracle Parkway, Redwood Shores, Redwood City, California, United States",
            "1-981-717-9366");

        Account loanAccount = new LoanAccount(
            loanAccountCustomer,
            1000000000,
            1.0931M,
            24);

        Customer mortgageLoanAccountCustomer = new IndividualCustomer(
            "97A20LX3YJU",
            "Ginni",
            "Rometty",
            "Armonk, New York, U.S.",
            "1-129-342-3817");

        Account mortgageLoanAccount = new MortgageLoanAccount(
            mortgageLoanAccountCustomer,
            300000,
            1.0875M,
            36);

        decimal depositInterest = depositAccount.CalculateInterest(3);
        Console.WriteLine("Deposit account interest: {0:C2}", depositInterest);

        depositAccount.Deposit(459.76M);
        depositAccount.Withdraw(400.76M);

        Console.WriteLine("Deposit account balance: {0:C2}", depositAccount.Balance);

        decimal loanInterest = loanAccount.CalculateInterest(10);
        Console.WriteLine("Loan account interest: {0:C2}", loanInterest);

        decimal mortgageLoanInterest = mortgageLoanAccount.CalculateInterest(10);
        Console.WriteLine("Mortgage loan account interest: {0:C2}", mortgageLoanInterest);
    }
}
