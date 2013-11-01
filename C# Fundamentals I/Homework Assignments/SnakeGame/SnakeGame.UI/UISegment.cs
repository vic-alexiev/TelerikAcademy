using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.UI
{
    public class UISegment : UIGameObject
    {
        public UISegment(int x, int y, int width, int height, Pen pen)
            : base(x, y, width, height, pen)
        {
        }
    }
}
