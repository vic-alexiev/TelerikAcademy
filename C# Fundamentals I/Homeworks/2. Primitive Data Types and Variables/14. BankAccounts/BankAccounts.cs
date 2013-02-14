using System;

class BankAccounts
{
    static void Main(string[] args)
    {
        string firstName = "Georgi";
        string middleName = "Georgiev";
        string lastName = "Yordanov";
        decimal balance = 523.87M;
        string bankName = "BNP Paribas";
        string iban = "CH93 0076 2011 6238 5295 7";
        string bic = "DABADKKK";
        string[] cardNumbers = new string[] { "1234-5678-9000-0000", "5678-1234-6500-0000", "4321-9876-6540-0000" };

        Holder holder = new Holder(firstName, middleName, lastName);

        BankAccount bankAccount = new BankAccount(holder, balance, bankName, iban, bic, cardNumbers);

        Console.WriteLine(bankAccount);
    }
}
