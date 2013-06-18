namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Value cannot be null.");
            }

            if (collection.Count == 0 || collection.Count == 1)
            {
                return;
            }

            int size = collection.Count;
            int min;
            for (int i = 0; i < size - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }

                T temp = collection[i];
                collection[i] = collection[min];
                collection[min] = temp;
            }
        }
    }
}
