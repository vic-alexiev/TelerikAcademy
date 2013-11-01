using System;

namespace MarsRover
{
    public class InvalidCommandsException : ApplicationException
    {
        private string commands;
        public string Commands
        {
            get
            {
                return commands;
            }
        }

        public InvalidCommandsException()
            : base()
        {
        }

        public InvalidCommandsException(string message, string commands, Exception innerException)
            : base(message, innerException)
        {
            this.commands = commands;
        }

        public InvalidCommandsException(string message, string commands)
            : this(message, commands, null)
        {
        }
    }
}
