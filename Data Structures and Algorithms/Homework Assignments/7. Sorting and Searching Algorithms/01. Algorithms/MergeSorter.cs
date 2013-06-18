namespace Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
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
            if (left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;

            this.Sort(items, left, mid);
            this.Sort(items, mid + 1, right);

            int endLeft = mid;
            int startRight = mid + 1;
            while ((left <= endLeft) && (startRight <= right))
            {
                if (items[left].CompareTo(items[startRight]) < 0)
                {
                    left++;
                }
                else
                {
                    T temp = items[startRight];
                    for (int k = startRight - 1; k >= left; k--)
                    {
                        items[k + 1] = items[k];
                    }
                    items[left] = temp;
                    left++;
                    endLeft++;
                    startRight++;
                }
            }
        }
    }
}
