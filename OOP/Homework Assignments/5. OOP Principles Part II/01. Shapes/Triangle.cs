namespace Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double side, double altitude)
            : base(side, altitude)
        {
        }

        public override double CalculateArea()
        {
            return 0.5 * this.width * this.height;
        }
    }
}
