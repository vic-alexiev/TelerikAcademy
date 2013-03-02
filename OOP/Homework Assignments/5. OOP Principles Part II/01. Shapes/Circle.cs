using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, radius)
        {
        }

        public override double CalculateArea()
        {
            return Math.PI * this.width * this.height;
        }
    }
}
