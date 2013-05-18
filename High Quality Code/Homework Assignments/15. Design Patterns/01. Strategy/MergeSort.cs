using System;
using System.Collections.Generic;

namespace Strategy
{
    // "ConcreteStrategy"

    public class MergeSort : SortingStrategy
    {
        public override void Sort<T>(List<T> list)
        {
            // this.MergeSort(list); not-implemented

            Console.WriteLine("Merge sort used.");
        }
    }
}
