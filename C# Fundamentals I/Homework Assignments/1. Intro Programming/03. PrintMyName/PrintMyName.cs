using System;

class PrintMyName
{
    static void Main()
    {
        Console.WriteLine("What's your name?");
        
        string userName = Console.ReadLine();
        
        if (String.IsNullOrWhiteSpace(userName))
        {
            userName = Environment.MachineName;
        }

        Console.WriteLine("Hi, {0}!", userName);
    }
}

