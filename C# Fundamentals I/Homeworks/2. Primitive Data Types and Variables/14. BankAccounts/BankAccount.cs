using System;
using System.Text;

public class BankAccount
{
    private Holder accountHolder;
    private decimal balance;
    private string bankName;
    private string iban;
    private string bic;
    private string[] cardNumbers;

    public BankAccount(Holder accountHolder, decimal balance, string bankName, string iban, string bic, string[] cardNumbers)
    {
        this.accountHolder = accountHolder;

        this.balance = balance;
        this.bankName = bankName;
        this.iban = iban;
        this.bic = bic;

        this.cardNumbers = new string[cardNumbers.Length];
        cardNumbers.CopyTo(this.cardNumbers, 0);
    }

    public override string ToString()
    {
        StringBuilder cards = new StringBuilder();

        foreach (var cardNumber in cardNumbers)
        {
            cards.AppendFormat("\t{0}\n", cardNumber);
        }

        return String.Format("{0}\nBalance: {1}\nBank name: {2}\nIBAN: {3}\nBIC: {4}\nCard numbers\n{5}", 
            accountHolder, balance, bankName, iban, bic, cards);
    }
}
