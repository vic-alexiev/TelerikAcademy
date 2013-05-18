using System;
using System.Collections.Generic;

namespace Strategy
{
    // "ConcreteStrategy"

    public class Shellsort : SortingStrategy
    {
        public override void Sort<T>(List<T> list)
        {
            // this.Shellsort(list); not-implemented

            Console.WriteLine("Shellsort used.");
        }
    }
}
