using System;

class NullableTypes
{
    static void Main()
    {
        int? intVar = null;
        double? doubleVar = null;

        Console.WriteLine("intVar: {0}, doubleVar: {1}", intVar, doubleVar);

        intVar += 10;
        doubleVar += 6.2397;

        Console.WriteLine("intVar: {0}, doubleVar: {1}", intVar, doubleVar);

        intVar = intVar.GetValueOrDefault() + 10;
        doubleVar = doubleVar.GetValueOrDefault() + 6.2397;

        Console.WriteLine("intVar: {0}, doubleVar: {1}", intVar, doubleVar);
    }
}
