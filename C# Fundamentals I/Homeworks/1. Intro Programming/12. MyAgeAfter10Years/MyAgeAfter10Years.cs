using System;

class MyAgeAfter10Years
{
    static void Main()
    {
        byte age;
        string inputAge;

        do
        {
            Console.WriteLine("Your current age:");
            inputAge = Console.ReadLine();
        }
        while (!Byte.TryParse(inputAge, out age));

        Console.WriteLine("In 10 years' time you will be {0} years old.", age + 10);
    }
}

