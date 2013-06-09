using System;
using System.IO;
using System.Text;

namespace PhoneBook
{
    internal class PhoneBookDemo
    {
        private static void Main()
        {
            string phoneBookFilePath = "../../Resources/phones.txt";
            string commandsFilePath = "../../Resources/commands.txt";

            IEntriesManager entriesManager = new PhoneBookManager(phoneBookFilePath);
            CommandProcessor commandProcessor = new CommandProcessor(entriesManager);

            using (StreamReader reader = new StreamReader(commandsFilePath))
            {
                string line;

                StringBuilder result = new StringBuilder();

                while ((line = reader.ReadLine()) != null)
                {
                    Command command = Command.Parse(line);
                    string output = commandProcessor.Process(command);
                    result.Append(output);
                }

                Console.Write(result);
            }
        }
    }
}
