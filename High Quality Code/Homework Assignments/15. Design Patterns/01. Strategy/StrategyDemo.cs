using System;

namespace Strategy
{
    internal class StrategyDemo
    {
        private static void Main()
        {
            // Two contexts following different strategies
            SortedList studentRecords = new SortedList();

            studentRecords.Add("John");
            studentRecords.Add("Peter");
            studentRecords.Add("George");
            studentRecords.Add("Paul");
            studentRecords.Add("Martin");

            studentRecords.SetSortingStrategy(new Quicksort());
            studentRecords.Sort();

            studentRecords.SetSortingStrategy(new Shellsort());
            studentRecords.Sort();

            studentRecords.SetSortingStrategy(new MergeSort());
            studentRecords.Sort();

            // Wait for user
            Console.Read();
        }
    }
}
