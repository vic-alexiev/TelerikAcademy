using SnakeGame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp
{
    public class ConsoleGameObject : GameObject
    {
        private char character;
        private ConsoleColor color;

        public ConsoleGameObject(int x, int y, char objectChar, ConsoleColor color)
            : base(x, y, 1, 1)
        {
            this.character = objectChar;
            this.color = color;
        }

        public char Character
        {
            get
            {
                return this.character;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.color;
            Console.Write(this.character);
        }

        public void Hide(char emptySpace)
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(emptySpace);
        }
    }
}
