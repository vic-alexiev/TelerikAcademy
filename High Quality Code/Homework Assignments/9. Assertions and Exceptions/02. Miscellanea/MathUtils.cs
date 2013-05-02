// ********************************
// <copyright file="MathUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Miscellanea
{
    using System;

    /// <summary>
    /// Contains methods that perform various mathematical operations.
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Checks if the specified number is prime.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is prime, otherwise - false.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
        /// <paramref name="number"/> is less than 2.</exception>
        public static bool IsPrime(int number)
        {
            if (number < 2)
            {
                throw new ArgumentOutOfRangeException("number", "Only natural numbers greater than 1 can be primes.");
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
