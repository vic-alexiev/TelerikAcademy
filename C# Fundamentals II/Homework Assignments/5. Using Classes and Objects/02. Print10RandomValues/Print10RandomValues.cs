using System;

class Print10RandomValues
{
    private static Random randomGenerator = new Random();

    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            // the upper bound is exclusive
            int randomValue = randomGenerator.Next(100, 201);

            Console.WriteLine(randomValue);
        }
    }
}
