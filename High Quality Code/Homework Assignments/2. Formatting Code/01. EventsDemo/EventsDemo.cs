using Events;
using System;

class EventsDemo
{
    private static EventHolder events = new EventHolder();

    /// <summary>
    /// Executes commands from the command line.
    /// <example>
    /// AddEvent 2013-04-09 13:00:00 | High quality code lecture | Telerik Academy
    /// AddEvent 2013-04-09 09:00:00 | JS lecture | Telerik Academy
    /// AddEvent 2013-04-09 10:00:00 | CMS lecture | Telerik Academy
    /// DeleteEvents CMS lecture
    /// ListEvents 2013-04-09 12:54:00 | 10
    /// End
    /// </example>
    /// </summary>
    static void Main()
    {
        while (ExecuteNextCommand()) { }
        Console.WriteLine(Messages.Output);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        switch (command[0])
        {
            case 'A':
                {
                    AddEvent(command);
                    return true;
                }
            case 'D':
                {
                    DeleteEvents(command);
                    return true;
                }
            case 'L':
                {
                    ListEvents(command);
                    return true;
                }
            default:
                {
                    return false;
                }
        }
    }

    private static void ListEvents(string command)
    {
        DateTime dateAndTime = GetDateAndTime(command, "ListEvents");

        int pipeIndex = command.IndexOf('|');
        string countAsString = command.Substring(pipeIndex + 1);

        int count = Int32.Parse(countAsString);

        events.ListEvents(dateAndTime, count);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        events.DeleteEvents(title);
    }

    private static void AddEvent(string command)
    {
        DateTime dateAndTime;
        string title;
        string location;
        GetParameters(command, "AddEvent", out dateAndTime, out title, out location);

        events.AddEvent(dateAndTime, title, location);
    }

    private static void GetParameters(string commandForExecution, string commandType,
        out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDateAndTime(commandForExecution, commandType);

        int firstPipeIndex = commandForExecution.IndexOf('|');

        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = String.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDateAndTime(string command, string commandType)
    {
        DateTime dateAndTime = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        return dateAndTime;
    }
}
