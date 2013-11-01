using SnakeGame.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame.UI
{
    public partial class FormSnakeGame : Form
    {
        private UISnake snake;
        private UIApple apple;
        private UIAppleGenerator appleGenerator;
        private int snakeLength = 5;
        private int segmentSize = 10;
        private int appleSize = 10;

        public FormSnakeGame()
        {
            InitializeComponent();

            this.snake = new UISnake(snakeLength, segmentSize, segmentSize, Direction.Right, Pens.Green);

            this.appleGenerator = new UIAppleGenerator(
                this.pictureBoxSnakeGame.Width,
                this.pictureBoxSnakeGame.Height,
                this.appleSize,
                this.appleSize);

            do
            {
                this.apple = this.appleGenerator.CreateApple();
            }
            while (this.snake.IsOn(apple));

            this.timerSnakeGame.Start();
        }

        private void pictureBoxSnakeGame_Paint(object sender, PaintEventArgs e)
        {
            this.apple.Draw(e.Graphics);
            this.snake.Draw(e.Graphics);
        }

        private void timerSnakeGame_Tick(object sender, EventArgs e)
        {
            MovementResult movementResult = this.snake.Move(
                this.pictureBoxSnakeGame.Width,
                this.pictureBoxSnakeGame.Height,
                this.apple);

            if (movementResult == MovementResult.Wall ||
                movementResult == MovementResult.SelfBite)
            {
                timerSnakeGame.Stop();

                // Game is over
                MessageBox.Show(string.Format("Game over!!! Your points: {0}", snake.Length));
                this.Close();
            }

            if (movementResult == MovementResult.OnApple)
            {
                do
                {
                    this.apple = this.appleGenerator.CreateApple();
                }
                while (this.snake.IsOn(apple));
            }

            this.Invalidate(true);
        }

        private void FormSnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            this.snake.ChangeDirection(e.KeyCode);
        }
    }
}
