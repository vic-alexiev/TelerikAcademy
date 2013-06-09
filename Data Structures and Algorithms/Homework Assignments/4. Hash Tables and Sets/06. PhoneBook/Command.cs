using System;

namespace PhoneBook
{
    public class Command
    {
        public Command(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; private set; }

        public string[] Arguments { get; private set; }

        public static Command Parse(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "value cannot be null.");
            }

            int openingParenthesisIndex = value.IndexOf('(');

            if (openingParenthesisIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + value, "value");
            }

            string name = value.Substring(0, openingParenthesisIndex).Trim();

            int closingParenthesisIndex = value.IndexOf(')');

            if (closingParenthesisIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + value, "value");
            }

            string argumentsList = value.Substring(
                openingParenthesisIndex + 1,
                closingParenthesisIndex - openingParenthesisIndex - 1).Trim();

            string[] arguments = argumentsList.Split(new char[] { ',' });

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            Command command = new Command(name, arguments);
            return command;
        }
    }
}
