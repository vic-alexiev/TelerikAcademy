using DocumentSystem;
using System;
using System.Collections.Generic;

public class DocumentSystemDemo
{
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(commandLine))
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        DocumentOrganizer docManager = new DocumentOrganizer();

        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");

            string command = commandLine.Substring(0, paramsStartIndex);

            int paramsEndIndex = commandLine.IndexOf("]");

            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);

            string[] attributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string commandResult = docManager.ExecuteCommand(command, attributes);
            Console.WriteLine(commandResult);
        }
    }
}