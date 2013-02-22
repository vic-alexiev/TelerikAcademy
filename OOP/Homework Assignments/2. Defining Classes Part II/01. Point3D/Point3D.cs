using System;

public struct Point3D
{
    #region Fields

    private double x;
    private double y;
    private double z;
    private static readonly Point3D origin;

    #endregion

    #region Properties

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double Z
    {
        get { return z; }
        set { z = value; }
    }

    public static Point3D Origin
    {
        get
        {
            return origin;
        }
    }

    #endregion

    #region Constructors

    static Point3D()
    {
        origin = new Point3D(0, 0, 0);
    }

    public Point3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    #endregion

    #region Operators

    public static bool operator ==(Point3D p1, Point3D p2)
    {
        return p1.Equals(p2);
    }

    public static bool operator !=(Point3D p1, Point3D p2)
    {
        return !p1.Equals(p2);
    }

    #endregion

    #region Public Methods

    public override int GetHashCode()
    {
        byte[] xBytes = BitConverter.GetBytes(x);
        byte[] yBytes = BitConverter.GetBytes(y);
        byte[] zBytes = BitConverter.GetBytes(z);

        int result = 0;

        for (int i = 0; i < sizeof(double); i++)
        {
            result ^= (xBytes[i] ^ yBytes[i] ^ zBytes[i]);
        }

        return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Point3D))
        {
            return false;
        }

        Point3D p = (Point3D)obj;

        return this.X == p.X && this.Y == p.Y && this.Z == p.Z;
    }

    public override string ToString()
    {
        return String.Format("({0:F2}, {1:F2}, {2:F2})", x, y, z);
    }

    #endregion
}
