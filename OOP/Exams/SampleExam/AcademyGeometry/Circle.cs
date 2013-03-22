using System;

namespace AcademyGeometry
{
    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        public double Radius { get; private set; }

        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.Radius = radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public Vector3D GetNormal()
        {
            return new Vector3D(0, 0, 1);
        }
    }
}
