using System.Collections.Generic;

namespace HashedSetUnitTests
{
    /// <summary>
    /// Strange comparer that uses modulo arithmetic.
    /// </summary>
    internal class ModularComparer : IEqualityComparer<int>
    {
        private int modulus;

        public ModularComparer(int modulus)
        {
            this.modulus = modulus;
        }

        public bool Equals(int x, int y)
        {
            return (x % modulus) == (y % modulus);
        }

        public int GetHashCode(int obj)
        {
            return (obj % modulus).GetHashCode();
        }
    }
}
