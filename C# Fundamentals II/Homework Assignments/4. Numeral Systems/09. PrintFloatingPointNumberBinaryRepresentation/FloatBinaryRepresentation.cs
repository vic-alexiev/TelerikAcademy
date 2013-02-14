using NumeralSystems;
using System;
using System.Text;

public class FloatBinaryRepresentation
{
    private char sign;
    private string exponent;
    private string mantissa;

    public char Sign
    {
        get { return sign; }
    }

    public string Exponent
    {
        get { return exponent; }
    }

    public string Mantissa
    {
        get { return mantissa; }
    }

    /// <summary>
    /// <see cref="http://stackoverflow.com/questions/397692/how-do-i-display-the-binary-representation-of-a-float-or-double"/>
    /// </summary>
    /// <param name="value"></param>
    public FloatBinaryRepresentation(float value)
    {
        // unsafe
        //Initialize(value);

        // safe
        Initialize(BitConverter.GetBytes(value));
    }

    /// <summary>
    /// Unsafe initialization - uses pointers to access the memory (4 consecutive bytes) occupied by the
    /// single-precision floating-point number.
    /// <seealso cref="http://en.wikipedia.org/wiki/Single_precision"/>
    /// </summary>
    /// <param name="value"></param>
    private unsafe void Initialize(float value)
    {
        int valueAsInteger = *(int*)&value;

        StringBuilder mantissaBuilder = new StringBuilder();
        StringBuilder exponentBuilder = new StringBuilder();

        if (valueAsInteger < 0)
        {
            sign = '1';
        }
        else
        {
            sign = '0';
        }

        for (int i = 0; i < 31; i++)
        {
            int bitValue = valueAsInteger & (1 << i);

            if (i < 23)
            {
                mantissaBuilder.Insert(0, bitValue == 0 ? '0' : '1');
            }
            else
            {
                exponentBuilder.Insert(0, bitValue == 0 ? '0' : '1');
            }
        }

        exponent = exponentBuilder.ToString();
        mantissa = mantissaBuilder.ToString();
    }

    /// <summary>
    /// Safe initialization of the binary representation,
    /// the number was first converted to an array of bytes.
    /// </summary>
    /// <param name="value"></param>
    private void Initialize(byte[] value)
    {
        StringBuilder binaryBuilder = new StringBuilder();

        foreach(byte item in value)
        {
            binaryBuilder.Insert(0, Converter.FromDecimal(item, 2).PadLeft(8, '0'));
        }

        string binaryRepresentation = binaryBuilder.ToString();

        sign = binaryRepresentation[0];
        exponent = binaryRepresentation.Substring(1, 8);
        mantissa = binaryRepresentation.Substring(9);
    }
}
