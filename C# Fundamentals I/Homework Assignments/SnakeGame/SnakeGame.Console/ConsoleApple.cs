using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp
{
    public class ConsoleApple : ConsoleGameObject
    {
        public ConsoleApple(int x, int y, char appleChar, ConsoleColor color)
            : base(x, y, appleChar, color)
        {
        }
    }
}
