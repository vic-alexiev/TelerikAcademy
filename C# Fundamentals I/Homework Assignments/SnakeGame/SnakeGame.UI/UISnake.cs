using SnakeGame.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame.UI
{
    public class UISnake
    {
        private Dictionary<Direction, Point> deltas;
        private Queue<UISegment> body;
        private Direction direction;
        private UISegment removedSegment;

        public UISnake(int length, int segmentWidth, int segmentHeight, Direction direction, Pen pen)
        {
            this.InitDeltas();
            this.body = new Queue<UISegment>(length);

            for (int i = 0; i < length; i++)
            {
                this.body.Enqueue(new UISegment(i * segmentWidth, 0, segmentWidth, segmentHeight, pen));
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

        public void Draw(Graphics graphics)
        {
            foreach (var segment in this.body)
            {
                segment.Draw(graphics);
            }
        }

        public bool IsOn(UIGameObject uiGameObject)
        {
            foreach (var segment in this.body)
            {
                if (segment.X == uiGameObject.X && segment.Y == uiGameObject.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public void ChangeDirection(Keys key)
        {
            if (key == Keys.Right)
                if (this.direction != Direction.Left) this.direction = Direction.Right;
            if (key == Keys.Down)
                if (this.direction != Direction.Up) this.direction = Direction.Down;
            if (key == Keys.Left)
                if (this.direction != Direction.Right) this.direction = Direction.Left;
            if (key == Keys.Up)
                if (this.direction != Direction.Down) this.direction = Direction.Up;
        }

        public MovementResult Move(int fieldWidth, int fieldHeight, UIApple apple)
        {
            UISegment oldHead = this.body.Last();
            UISegment newHead = new UISegment(
                oldHead.X + this.deltas[this.direction].X * oldHead.Width,
                oldHead.Y + this.deltas[this.direction].Y * oldHead.Height,
                oldHead.Width,
                oldHead.Height,
                oldHead.Pen);

            if (newHead.X >= fieldWidth || newHead.X < 0 ||
                newHead.Y >= fieldHeight || newHead.Y < 0)
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
    }
}
