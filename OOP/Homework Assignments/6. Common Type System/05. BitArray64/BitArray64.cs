using System;
using System.Collections;
using System.Collections.Generic;

public class BitArray64 : IEnumerable<int>
{
    #region Private Fields

    public const int BITS_COUNT = 64;
    private ulong bitsValue;

    #endregion

    #region Properties

    public ulong BitsValue
    {
        get
        {
            return this.bitsValue;
        }
        private set
        {
            this.bitsValue = value;
        }
    }

    #region Indexer

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < BITS_COUNT)
            {
                ulong mask = (ulong)1 << index;

                // Check the bit at position index
                if ((bitsValue & mask) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
            }
        }

        set
        {
            if (index < 0 || index >= BITS_COUNT)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
            }

            if (value != 0 && value != 1)
            {
                throw new ArgumentOutOfRangeException("Value must be 0 or 1.");
            }

            ulong mask = (ulong)1 << index;

            if (value == 1)
            {
                bitsValue |= mask;
            }
            else
            {
                bitsValue &= ~mask;
            }
        }
    }

    #endregion

    #endregion

    #region Constructors

    public BitArray64()
    {
        this.bitsValue = (ulong)0;
    }

    public BitArray64(ulong bitsValue)
    {
        this.BitsValue = bitsValue;
    }

    #endregion

    #region Overrides

    public override string ToString()
    {
        return Convert.ToString((long)this.bitsValue, 2).PadLeft(64, '0');
    }

    public override bool Equals(object obj)
    {
        // If the cast is invalid, the result will be null
        BitArray64 other = obj as BitArray64;

        // Check if we have valid not null BitArray64 object
        if (other == null)
        {
            return false;
        }

        return this.bitsValue == other.bitsValue;
    }

    public static bool operator ==(BitArray64 arrayA, BitArray64 arrayB)
    {
        return BitArray64.Equals(arrayA, arrayB);
    }

    public static bool operator !=(BitArray64 arrayA, BitArray64 arrayB)
    {
        return !(BitArray64.Equals(arrayA, arrayB));
    }

    public override int GetHashCode()
    {
        return this.bitsValue.GetHashCode();
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        for (int i = 0; i < BITS_COUNT; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (this as IEnumerable<int>).GetEnumerator();
    }

    #endregion
}
