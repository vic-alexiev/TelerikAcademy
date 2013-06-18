namespace Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
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

            this.Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> items, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = (left + right) / 2;
            T x = items[pivot];

            while (i <= j)
            {
                while (items[i].CompareTo(x) < 0)
                {
                    i++;
                }

                while (x.CompareTo(items[j]) < 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                this.Sort(items, left, j);
            }

            if (i < right)
            {
                this.Sort(items, i, right);
            }
        }
    }
}
