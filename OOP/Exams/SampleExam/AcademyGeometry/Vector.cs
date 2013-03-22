using System;

namespace AcademyGeometry
{
    public abstract class Vector
    {
        double[] components;
        double magnitude;

        public double Magnitude
        {
            get
            {
                return this.magnitude;
            }
        }

        public double this[int index]
        {
            get { return this.GetComponent(index); }
            set { this.SetComponent(index, value); }
        }

        public int Dimensions { get; private set; }

        protected Vector(params double[] components)
        {
            this.Dimensions = components.Length;

            this.components = new double[components.Length];

            for (int i = 0; i < components.Length; i++)
            {
                this.components[i] = components[i];
            }

            this.magnitude = this.CalculateMagnitude();
        }

        private double GetComponent(int index)
        {
            return this.components[index];
        }

        private void SetComponent(int index, double value)
        {
            this.components[index] = value;
            this.magnitude = this.CalculateMagnitude();
        }

        private double CalculateMagnitude()
        {
            double sumOfSquaredComponents = 0;
            foreach (var component in this.components)
            {
                sumOfSquaredComponents += component * component;
            }

            return Math.Sqrt(sumOfSquaredComponents);
        }

        public bool IsZero()
        {
            foreach (var component in this.components)
            {
                if (component != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void Normalize()
        {
            for (int i = 0; i < this.components.Length; i++)
            {
                this.components[i] = this.components[i] / this.Magnitude;
            }
        }
    }
}
