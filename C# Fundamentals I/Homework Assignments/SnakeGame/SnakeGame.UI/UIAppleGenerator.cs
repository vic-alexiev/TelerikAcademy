using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.UI
{
    public class UIAppleGenerator
    {
        private Random randomGenerator = new Random();
        private int fieldWidth;
        private int fieldHeight;
        private int appleWidth;
        private int appleHeight;

        public UIAppleGenerator(int fieldWidth, int fieldHeight, int appleWidth, int appleHeight)
        {
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;
            this.appleWidth = appleWidth;
            this.appleHeight = appleHeight;
        }

        public UIApple CreateApple()
        {
            UIApple apple = new UIApple(
                randomGenerator.Next(1, this.fieldWidth / this.appleWidth) * this.appleWidth,
                randomGenerator.Next(1, this.fieldHeight / this.appleHeight) * this.appleHeight,
                this.appleWidth,
                this.appleHeight,
                Pens.Red);

            return apple;
        }
    }
}
