using System;

class PrintHelloUserName
{
    private static void PrintHello()
    {
        Console.Write("Your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Hello, {0}", userName);
    }

    static void Main()
    {
        PrintHello();
    }
}
