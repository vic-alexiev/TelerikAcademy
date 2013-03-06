using System;

public class InvalidRangeException<T> : ApplicationException
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    #region Private Fields

    private T start;
    private T end;

    #endregion

    #region Properties

    public T Start
    {
        get
        {
            return start;
        }
    }

    public T End
    {
        get
        {
            return end;
        }
    }

    #endregion

    #region Constructors

    public InvalidRangeException(T start, T end)
        : this(null, start, end, null)
    {
    }

    public InvalidRangeException(string message, T start, T end, Exception innerException)
        : base(message, innerException)
    {
        this.start = start;
        this.end = end;
    }

    public InvalidRangeException(string message, T start, T end)
        : this(message, start, end, null)
    {
    }

    #endregion
}
