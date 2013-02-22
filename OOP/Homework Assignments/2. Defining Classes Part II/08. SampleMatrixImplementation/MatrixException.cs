using System;

public class MatrixException : ApplicationException
{
    public MatrixException()
        : base()
    {
    }

    public MatrixException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public MatrixException(string message)
        : this(message, null)
    {
    }
}