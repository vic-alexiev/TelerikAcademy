using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyGeometry
{
    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public double Radius { get; private set; }

        public Cylinder(Vector3D top, Vector3D bottom, double radius)
            : base(top, bottom)
        {
            this.Radius = radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        /// <summary>
        /// Calculates the surface area of a cylinder:
        /// 2 pi r^2 + 2 pi r h = 2 pi r (r + h)
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            double height = this.GetHeight();

            return 2 * Math.PI * this.Radius * (this.Radius + height);
        }

        public double GetVolume()
        {
            double height = this.GetHeight();

            return Math.PI * this.Radius * this.Radius * height;
        }

        private double GetHeight()
        {
            return (this.vertices[0] - this.vertices[1]).Magnitude;
        }
    }
}
