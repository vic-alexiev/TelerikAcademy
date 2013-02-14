using System;

class CompanyInformation
{
    static void Main()
    {
        Console.Write("Enter the name of the company: ");
        string companyName = Console.ReadLine();

        Console.Write("Enter the address of the company: ");
        string companyAddress = Console.ReadLine();

        string companyPhone;
        int companyPhoneNumber;

        do
        {
            Console.Write("Enter the phone number of the company: ");
            companyPhone = Console.ReadLine();
        }
        while (!Int32.TryParse(companyPhone, out companyPhoneNumber) || companyPhoneNumber <= 0);

        Console.Write("Enter the fax number of the company: ");
        string companyFaxNumber = Console.ReadLine();

        Console.Write("Enter the web site of the company: ");
        string companyWebSite = Console.ReadLine();

        Console.Write("Enter the data about the manager.\nFirst name: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Last name: ");
        string managerLastName = Console.ReadLine();

        string managerAge;
        byte age;

        do
        {
            Console.Write("Age: ");
            managerAge = Console.ReadLine();
        }
        while (!Byte.TryParse(managerAge, out age));

        string managerPhone;
        int managerPhoneNumber;

        do
        {
            Console.Write("Phone number: ");
            managerPhone = Console.ReadLine();
        }
        while (!Int32.TryParse(managerPhone, out managerPhoneNumber) || managerPhoneNumber <= 0);

        Manager theManager = new Manager(managerFirstName, managerLastName, age, managerPhoneNumber);

        Company ourCompany = new Company(theManager, companyName, companyAddress, companyPhoneNumber, companyFaxNumber, companyWebSite);

        Console.WriteLine(new string('-', 40));
        Console.WriteLine(ourCompany);
    }
}
