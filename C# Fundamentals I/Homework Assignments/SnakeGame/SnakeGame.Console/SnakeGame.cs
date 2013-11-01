using SnakeGame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp
{
    internal class SnakeGame
    {
        private static void FixConsole()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
        }

        private static void Main()
        {
            // The snake speed
            double sleepTime = 100;

            ConsoleAppleGenerator appleGenerator = new ConsoleAppleGenerator(Console.WindowWidth, Console.WindowHeight);

            ConsoleSnake snake = new ConsoleSnake(5, '#', ConsoleColor.Green, Direction.Right);
            ConsoleApple apple;

            do
            {
                apple = appleGenerator.CreateApple();
            }
            while (snake.IsOn(apple));

            FixConsole();

            apple.Draw();

            while (true)
            {
                // Read user input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    snake.ChangeDirection(pressedKey);
                }

                MovementResult movementResult = snake.Move(Console.WindowWidth, Console.WindowHeight, apple);

                if (movementResult == MovementResult.Wall ||
                    movementResult == MovementResult.SelfBite)
                {
                    // Game is over
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Game over!!! Your points: {0}", snake.Length);
                    return;
                }

                if (movementResult == MovementResult.OnApple)
                {
                    do
                    {
                        apple = appleGenerator.CreateApple();
                    }
                    while (snake.IsOn(apple));

                    apple.Draw();
                }

                snake.Draw();

                // Slow the motion
                Thread.Sleep((int)sleepTime);

                // Change the speed
                sleepTime -= 0.05;
            }
        }
    }
}
