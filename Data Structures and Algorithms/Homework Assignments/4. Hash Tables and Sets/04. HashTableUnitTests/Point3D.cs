namespace HashTableUnitTests
{
    internal class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            Point3D other = obj as Point3D;

            if (other == null)
                return false;

            if (!this.X.Equals(other.X))
                return false;

            if (!this.Y.Equals(other.Y))
                return false;

            if (!this.Z.Equals(other.Z))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;
            unchecked
            {
                result = result * prime + X.GetHashCode();
                result = result * prime + Y.GetHashCode();
                result = result * prime + Z.GetHashCode();
            }

            return result;
        }
    }
}
