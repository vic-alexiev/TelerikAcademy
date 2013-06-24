using System;

namespace ShoppingCenter
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

            int firstSpaceIndex = value.IndexOf(" ");
            string name = value.Substring(0, firstSpaceIndex);

            string argumentsList = value.Substring(firstSpaceIndex + 1).Trim();
            string[] arguments = argumentsList.Split(new char[] { ';' });

            Command command = new Command(name, arguments);
            return command;
        }
    }
}
