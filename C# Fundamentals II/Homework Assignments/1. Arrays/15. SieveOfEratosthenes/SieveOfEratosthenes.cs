using System;
using System.Collections.Generic;
using System.Linq;

public static class SieveOfEratosthenes
{
    /// <summary>
    /// Returns an IList containing the primes in the segment [2, upperLimit].
    /// </summary>
    /// <remarks>
    /// The numbers are sifted via the LINQ implementation of the
    /// Sieve of Eratosthenes.
    /// <see cref="http://codereview.stackexchange.com/questions/6115/sieve-of-eratosthenes-in-c-with-linq"/>    
    /// <seealso cref="http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes"/>
    /// </remarks>
    /// <param name="upperLimit"></param>
    /// <returns></returns>
    private static IList<int> GetPrimesLinq(int upperLimit)
    {
        int current = 1;
        double sqrtOfUpperLimit = Math.Sqrt(upperLimit);
        var segment = Enumerable.Range(2, upperLimit - 1).ToList();

        while (current <= sqrtOfUpperLimit)
        {
            current = segment.First(i => i > current);
            segment.RemoveAll(i => i != current && i % current == 0);
        }

        return segment;
    }

    /// <summary>
    /// An extension method used to initialize the elements of an array 
    /// with a specified value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <param name="value"></param>
    public static void Populate<T>(this T[] arr, T value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }
    }

    /// <summary>
    /// Returns an array of Booleans showing whether the index is prime or not.
    /// Uses the Sieve of Eratosthenes.
    /// </summary>
    /// <param name="upperLimit"></param>
    /// <returns></returns>
    private static bool[] GetPrimes(int upperLimit)
    {
        bool[] prime = new bool[upperLimit + 1];
        prime.Populate(true);

        double sqrtOfUpperLimit = Math.Sqrt(upperLimit);
        for (int i = 2; i <= sqrtOfUpperLimit; i++)
        {
            if (prime[i] == true)
            {
                for (int j = i * i; j <= upperLimit; j += i)
                {
                    prime[j] = false;
                }
            }
        }

        return prime;
    }

    static void Main()
    {
        string numberN;
        int n;

        do
        {
            Console.Write("Enter the range size: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        // I solution
        //IList<int> primes = GetPrimesLinq(n);
        //string primesAsString = String.Join(", ", primes);
        //Console.WriteLine(primesAsString);

        // II solution
        bool[] prime = GetPrimes(n);

        int i = 2;
        Console.Write(i++);
        while (i <= n)
        {
            if (prime[i])
            {
                Console.Write(", {0}", i);
            }
            i++;
        }

        Console.WriteLine();
    }
}
