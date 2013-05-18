using System;
using System.Collections.Generic;

namespace Strategy
{
    // "Context"

    public class SortedList
    {
        private List<string> list = new List<string>();
        private SortingStrategy sortingStrategy;

        public void SetSortingStrategy(SortingStrategy sortingStrategy)
        {
            this.sortingStrategy = sortingStrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            sortingStrategy.Sort(list);

            // Display results
            foreach (string name in list)
            {
                Console.WriteLine(" " + name);
            }

            Console.WriteLine();
        }
    }
}
