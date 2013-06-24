using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ShoppingCenter
{
    internal class ShoppingCenterDemo
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int commandsCount = int.Parse(Console.ReadLine());

            ShoppingCenterManager shoppingCenterManager = new ShoppingCenterManager();
            CommandProcessor commandProcessor = new CommandProcessor(shoppingCenterManager);

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                Command command = Command.Parse(Console.ReadLine());
                commandProcessor.Process(command, resultBuilder);
            }

            Console.Write(resultBuilder);
        }
    }
}
