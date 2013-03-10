using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitArray64Demo
{
    static void Main()
    {
        BitArray64 bitArray = new BitArray64();

        bitArray[63] = 1;
        bitArray[62] = 1;

        int index = 0;
        foreach (int bit in bitArray)
        {
            Console.WriteLine("Bit {0,2}: {1}", index, bit);
            index++;
        }

        Console.WriteLine(bitArray);
    }
}
