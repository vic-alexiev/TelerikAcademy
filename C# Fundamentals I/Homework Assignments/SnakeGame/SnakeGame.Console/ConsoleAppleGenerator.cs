using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp
{
    public class ConsoleAppleGenerator
    {
        private Random randomGenerator = new Random();
        private int fieldWidth;
        private int fieldHeight;

        public ConsoleAppleGenerator(int fieldWidth, int fieldHeight)
        {
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;
        }

        public ConsoleApple CreateApple()
        {
            ConsoleApple apple = new ConsoleApple(
                randomGenerator.Next(1, this.fieldWidth - 1),
                randomGenerator.Next(1, this.fieldHeight - 1),
                '@',
                ConsoleColor.Red);

            return apple;
        }
    }
}
