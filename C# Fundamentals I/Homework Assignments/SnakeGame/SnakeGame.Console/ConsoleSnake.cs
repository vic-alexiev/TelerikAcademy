using SnakeGame.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp
{
    public class ConsoleSnake
    {
        private Dictionary<Direction, Point> deltas;
        private Queue<ConsoleSegment> body;
        private Direction direction;
        private ConsoleSegment removedSegment;

        public ConsoleSnake(int length, char segmentChar, ConsoleColor color, Direction direction)
        {
            this.InitDeltas();
            this.body = new Queue<ConsoleSegment>(length);

            for (int i = 0; i < length; i++)
            {
                this.body.Enqueue(new ConsoleSegment(i, 0, segmentChar, color));
            }

            this.direction = direction;
        }

        public int Length
        {
            get
            {
                return this.body.Count;
            }
        }

        public void Draw()
        {
            if (this.removedSegment != null)
            {
                this.removedSegment.Hide(' ');
            }

            foreach (var segment in this.body)
            {
                segment.Draw();
            }
        }

        public bool IsOn(ConsoleGameObject gameObject)
        {
            foreach (var segment in this.body)
            {
                if (segment.X == gameObject.X && segment.Y == gameObject.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public void ChangeDirection(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.RightArrow)
                if (this.direction != Direction.Left) this.direction = Direction.Right;
            if (pressedKey.Key == ConsoleKey.DownArrow)
                if (this.direction != Direction.Up) this.direction = Direction.Down;
            if (pressedKey.Key == ConsoleKey.LeftArrow)
                if (this.direction != Direction.Right) this.direction = Direction.Left;
            if (pressedKey.Key == ConsoleKey.UpArrow)
                if (this.direction != Direction.Down) this.direction = Direction.Up;
        }

        public MovementResult Move(int width, int height, ConsoleApple apple)
        {
            ConsoleSegment oldHead = this.body.Last();
            ConsoleSegment newHead = new ConsoleSegment(
                oldHead.X + this.deltas[this.direction].X,
                oldHead.Y + this.deltas[this.direction].Y,
                oldHead.Character,
                oldHead.Color);

            if (newHead.X >= width || newHead.X < 0 ||
                newHead.Y >= height || newHead.Y < 0)
            {
                return MovementResult.Wall;
            }

            if (this.IsOn(newHead))
            {
                return MovementResult.SelfBite;
            }

            // the following two operations create the effect of motion:
            // 1. add the new head in front of the old one
            this.body.Enqueue(newHead);

            // if the snake is on the apple
            if (this.IsOn(apple))
            {
                // increase the length by 1, i.e. don't remove the last segment
                this.removedSegment = null;
                return MovementResult.OnApple;
            }
            else
            {
                // 2. remove the last segment
                this.removedSegment = this.body.Dequeue();
            }

            return MovementResult.OK;
        }

        private void InitDeltas()
        {
            this.deltas = new Dictionary<Direction, Point>();
            this.deltas[Direction.Right] = new Point(1, 0);
            this.deltas[Direction.Down] = new Point(0, 1);
            this.deltas[Direction.Left] = new Point(-1, 0);
            this.deltas[Direction.Up] = new Point(0, -1);
        }

        private class ConsoleSegment : ConsoleGameObject
        {
            public ConsoleSegment(int x, int y, char segmentChar, ConsoleColor color)
                : base(x, y, segmentChar, color)
            {
            }
        }
    }
}
