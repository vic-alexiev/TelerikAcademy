using System;

class PrintMyFirstAndLastName
{
    static void Main()
    {
        Console.WriteLine("Your first name:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Your last name:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Hi, {0} {1}!", firstName, lastName);
    }
}

