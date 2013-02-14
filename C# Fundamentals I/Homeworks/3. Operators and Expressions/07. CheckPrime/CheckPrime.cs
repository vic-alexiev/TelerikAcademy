using System;
using System.Collections.Generic;
using System.Linq;

public static class CheckPrime
{
    static void Main()
    {
        string numberFromConsole;
        int number;
        int upperLimit = 100;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();
        }
        while (!Int32.TryParse(numberFromConsole, out number) || number < 0 || number > upperLimit);

        bool isPrime = IsPrime(number);
        Console.WriteLine("This number is{0} prime.", isPrime ? String.Empty : " not");

        IList<int> primes = GetPrimesLinq(upperLimit);
        bool belongsToPrimes = primes.Contains(number);
        Console.WriteLine("This number is{0} prime.", belongsToPrimes ? String.Empty : " not");

        bool[] prime = GetPrimes(upperLimit);
        Console.WriteLine("This number is{0} prime.", prime[number] ? String.Empty : " not");
    }

    private static bool IsPrime(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentException("The number must be a positive integer.");
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

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
    /// Returns an array of Booleans showing whether the index is prime or not.
    /// Uses the Sieve of Eratosthenes.
    /// </summary>
    /// <param name="upperLimit"></param>
    /// <returns></returns>
    private static bool[] GetPrimes(int upperLimit)
    {
        bool[] prime = new bool[upperLimit + 1];
        prime.Populate(true);
        prime[0] = false;
        prime[1] = false;

        double sqrtOfUpperLimit = Math.Sqrt(upperLimit);
        for (int i = 2; i <= sqrtOfUpperLimit; i++)
        {
            if (prime[i] == true)
            {
                for (int j = i * 2; j < prime.Length; j += i)
                {
                    prime[j] = false;
                }
            }
        }

        return prime;
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
}
