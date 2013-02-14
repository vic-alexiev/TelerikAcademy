using System;

public class ValueOutOfRangeException : ApplicationException
{
    public ValueOutOfRangeException()
        : base()
    {
    }

    public ValueOutOfRangeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ValueOutOfRangeException(string message)
        : this(message, null)
    {
    }
}

