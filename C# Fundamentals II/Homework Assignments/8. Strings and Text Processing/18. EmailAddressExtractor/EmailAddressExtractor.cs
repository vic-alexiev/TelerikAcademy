using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class EmailAddressExtractor
{
    private static List<string> GetEmailAddresses(string input)
    {
        string pattern = @"\b\w+[\w\-]*(\.\w+[\w\-]*)*@[a-z0-9]+[a-z0-9-]*(\.[a-z0-9]+[a-z0-9-]*)*(\.[a-z]{2,6})\b";

        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

        List<string> emails = new List<string>();

        foreach (Match match in matches)
        {
            emails.Add(match.Value);
        }

        return emails;
    }

    static void Main()
    {
        string text = "Examples of valid emails: diado@kaval.com, kalitko@duduk.net, 123--@usa.net, " +
            "test.test123@en.some-host.12345.com. Examples of invalid emails: .ala.@bala.com, test@-host.com, user@.test.ru, " +
            "alabala@, user@host, @eu.net, test%mail.bg.";

        List<string> emailsList = GetEmailAddresses(text);

        Console.WriteLine("Email addresses:");

        foreach (string email in emailsList)
        {
            Console.WriteLine(email);
        }
    }
}
