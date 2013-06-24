using System;

/// <summary>
/// For more info, see http://www.8bitavenue.com/2010/08/make-change/
/// </summary>
internal class ChangeMaker
{
    //Make change method
    private static void MakeChange(float money)
    {
        //Those are simply counters
        int nickel = 0;
        int twopence = 0;
        int penny = 0;

        //Convert amount to cents
        int m = (int)(money * 100);

        //Sum must not exceed amount
        int sum = 0;

        //Keep adding to the sum selecting the largest
        //coin until we exceed the amount needed
        while (sum != m)
        {
            if (sum + 5 <= m)
            {
                nickel++;
                sum += 5;
            }
            else if (sum + 2 <= m)
            {
                twopence++;
                sum += 2;
            }
            else if (sum + 1 <= m)
            {
                penny++;
                sum += 1;
            }
            else
            {
                //Do nothing
            }
        }

        //Write output
        Console.WriteLine(money + " =");
        Console.WriteLine(nickel + " nickels");
        Console.WriteLine(penny + " twopence");
        Console.WriteLine(penny + " pennies");
    }

    private static void Main()
    {
        float money = 0.33f;
        MakeChange(money);
    }
}
