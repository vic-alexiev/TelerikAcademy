using System;

class FloatAndDoubleVariables
{
    static void Main()
    {
        double firstVar = 34.567839023;
        Console.WriteLine("The type of firstVar is {0} since {0} keeps the precision of {1}.",
            typeof(double), firstVar);

        float secondVar = 12.345f;
        Console.WriteLine("The type of secondVar is {0} since {0} is enough to keep the precision of {1}.",
            typeof(float), secondVar);

        double thirdVar = 8923.1234857;
        Console.WriteLine("The type of thirdVar is {0} since {0} keeps the precision of {1}.",
            typeof(double), thirdVar);

        float fourthVar = 3456.091f;
        Console.WriteLine("The type of fourthVar is {0} since {0} is enough to keep the precision of {1}.",
            typeof(float), fourthVar);
    }
}
