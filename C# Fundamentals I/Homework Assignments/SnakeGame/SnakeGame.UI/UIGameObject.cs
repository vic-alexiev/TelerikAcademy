using SnakeGame.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.UI
{
    public class UIGameObject : GameObject
    {
        public UIGameObject(int x, int y, int width, int height, Pen pen)
            : base(x, y, width, height)
        {
            this.Pen = pen;
        }

        public Pen Pen { get; set; }

        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(this.Pen, this.X, this.Y, this.Width, this.Height);
        }
    }
}
