using System;

class FiveVariablesDeclaration
{
    static void Main()
    {
        ushort firstVar = 52130;
        Console.WriteLine("The type of firstVar is {0} since [{1}; {2}] is\n"
            + "the smallest primitive type range that includes {3}.\n",
            typeof(ushort), UInt16.MinValue, UInt16.MaxValue, firstVar);

        sbyte secondVar = -115;
        Console.WriteLine("The type of secondVar is {0} since [{1}; {2}] is\n"
            + "the smallest primitive type range that includes {3}.\n",
            typeof(sbyte), SByte.MinValue, SByte.MaxValue, secondVar);

        int thirdVar = 4825932;
        Console.WriteLine("The type of thirdVar is {0} since [{1}; {2}] is\n"
            + "the smallest primitive type range that includes {3}.\n",
            typeof(int), Int32.MinValue, Int32.MaxValue, thirdVar);

        byte fourthVar = 97;
        Console.WriteLine("The type of fourthVar is {0} since [{1}; {2}] is\n"
            + "the smallest primitive type range that includes {3}.\n",
            typeof(byte), Byte.MinValue, Byte.MaxValue, fourthVar);

        short fifthVar = -10000;
        Console.WriteLine("The type of fifthVar is {0} since [{1}; {2}] is\n"
            + "the smallest primitive type range that includes {3}.\n",
            typeof(short), Int16.MinValue, Int16.MaxValue, fifthVar);
    }
}
