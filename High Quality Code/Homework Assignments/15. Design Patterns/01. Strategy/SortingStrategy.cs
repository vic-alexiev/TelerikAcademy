using System;
using System.Collections.Generic;

namespace Strategy
{
    // "Strategy"

    public abstract class SortingStrategy
    {
        public abstract void Sort<T>(List<T> list)
            where T : IComparable<T>;
    }
}
