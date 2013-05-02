// ********************************
// <copyright file="MiscellaneaDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Miscellanea;

/// <summary>
/// Used to demonstrate the use of various utility methods.
/// </summary>
internal class MiscellaneaDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        try
        {
            var subsequence1 = ArrayUtils.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(subsequence1);

            var subsequence2 = ArrayUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subsequence2));

            var subsequence3 = ArrayUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", subsequence3));

            var subsequence4 = ArrayUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", subsequence4));

            Console.WriteLine(StringUtils.ExtractEnding("I love C#", 2));
            Console.WriteLine(StringUtils.ExtractEnding("Nakov", 4));
            Console.WriteLine(StringUtils.ExtractEnding("beer", 4));
            Console.WriteLine(StringUtils.ExtractEnding("Hi", 100));

            bool is23Prime = MathUtils.IsPrime(23);
            if (is23Prime)
            {
                Console.WriteLine("23 is prime.");
            }
            else
            {
                Console.WriteLine("23 is not prime.");
            }
        }
        catch (ArgumentOutOfRangeException aoorex)
        {
            Console.WriteLine(aoorex.Message);
        }
        catch (ArgumentNullException anex)
        {
            Console.WriteLine(anex.Message);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine(aex.Message);
        }
    }
}
