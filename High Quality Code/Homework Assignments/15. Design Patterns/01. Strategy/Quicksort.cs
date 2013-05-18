using System;
using System.Collections.Generic;

namespace Strategy
{
    // "ConcreteStrategy"

    public class Quicksort : SortingStrategy
    {
        public override void Sort<T>(List<T> list)
        {
            // Default is Quicksort
            list.Sort();

            Console.WriteLine("Quicksort used.");
        }
    }
}
