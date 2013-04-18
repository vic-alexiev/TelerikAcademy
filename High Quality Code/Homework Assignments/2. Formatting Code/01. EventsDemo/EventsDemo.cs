// ********************************
// <copyright file="EventsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using System.Globalization;
using Events;

/// <summary>
/// A class which demonstrates the use of events - adding an event 
/// to the event holder, deleting an event and displaying all 
/// events which are in the event holder.
/// </summary>
internal class EventsDemo
{
    /// <summary>
    /// The permissible formats for the date and time part of the commands.
    /// </summary>
    private static readonly string[] DateAndTimeFormats = new string[] 
    {
        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-dd HH:mm",
        "yyyy-MM-dd"
    };

    /// <summary>
    /// An event holder which keeps the events.
    /// </summary>
    private static EventHolder events = new EventHolder();

    /// <summary>
    /// Executes commands from the command line.
    /// <example>
    /// AddEvent 2013-04-09 13:00:00 | High quality code lecture | Enterprise Hall
    /// AddEvent 2013-04-09 09:00:00 | JS lecture | Ultimate Hall
    /// AddEvent 2013-04-09 10:00:00 | CMS lecture | Enterprise Hall
    /// DeleteEvents CMS lecture
    /// ListEvents 2013-04-09 12:54:00 | 10
    /// End
    /// </example>
    /// </summary>
    private static void Main()
    {
        bool validCommand;

        do
        {
            validCommand = ExecuteNextCommand();
        }
        while (validCommand);

        Console.WriteLine(events.Log);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(command))
        {
            return false;
        }

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

        int count = int.Parse(countAsString);

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

    private static void GetParameters(
        string commandForExecution,
        string commandType,
        out DateTime dateAndTime,
        out string eventTitle,
        out string eventLocation)
    {
        dateAndTime = GetDateAndTime(commandForExecution, commandType);

        int firstPipeIndex = commandForExecution.IndexOf('|');

        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = string.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    /// <summary>
    /// Extracts the date and time from the command specified.
    /// </summary>
    /// <param name="command">The command text.</param>
    /// <param name="commandType">The command type.</param>
    /// <returns>The date and time as a single <see cref="System.DateTime"/> object.</returns>
    private static DateTime GetDateAndTime(string command, string commandType)
    {
        int firstPipeIndex = command.IndexOf('|');
        int dateAndTimePartLength = firstPipeIndex - commandType.Length - 1;

        string dateAndTimePart = command.Substring(commandType.Length + 1, dateAndTimePartLength).Trim();
        DateTime dateAndTime = DateTime.ParseExact(
            dateAndTimePart, DateAndTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
        return dateAndTime;
    }
}
