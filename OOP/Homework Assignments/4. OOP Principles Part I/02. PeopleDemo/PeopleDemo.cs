using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PeopleDemo
{
    static void Main()
    {
        // Task: Initialize an array of 10 students and sort them by grade in ascending order.

        //Student[] students = new Student[]
        //{
        //    new Student("Kiril", "Nikolov", 23.4),
        //    new Student("Stamo", "Petkov", 12.9),
        //    new Student("Yordan", "Yordanov", 89.12),
        //    new Student("Boris", "Gutsev", 35.229),
        //    new Student("Martin", "Yankov", 72.124),
        //    new Student("Vladimir", "Georgiev", 19.2),
        //    new Student("Lina", "Ivanova", 78.93),
        //    new Student("Mihail", "Petrov", 19.75),
        //    new Student("Lyubomir", "Yanchev", 27.01),
        //    new Student("Nikolay", "Alexiev", 34.12),
        //};

        //Array.Sort(students);

        //foreach (Student student in students)
        //{
        //    Console.WriteLine(student);
        //}

        // Task: Initialize an array of 10 workers and sort them by money per hour in descending order.

        Worker[] workers = new Worker[]
        {
            new Worker("Kiril", "Nikolov", 200),
            new Worker("Stamo", "Petkov", 300),
            new Worker("Yordan", "Yordanov", 500),
            new Worker("Boris", "Gutsev", 350),
            new Worker("Martin", "Yankov", 280),
            new Worker("Vladimir", "Georgiev", 400),
            new Worker("Lina", "Ivanova", 380),
            new Worker("Mihail", "Petrov", 275),
            new Worker("Lyubomir", "Yanchev", 350),
            new Worker("Nikolay", "Alexiev", 295),
        };

        //// I solution
        //var sortedWorkers =
        //    from worker in workers
        //    orderby worker.MoneyPerHour descending
        //    select worker;

        //foreach (Worker worker in sortedWorkers)
        //{
        //    Console.WriteLine(worker);
        //}

        //// II solution
        //workers = workers.OrderByDescending(w => w.MoneyPerHour).ToArray();

        //foreach (Worker worker in workers)
        //{
        //    Console.WriteLine(worker);
        //}

        // III solution
        //Array.Sort(workers, new Comparison<Worker>((w1, w2) => w2.MoneyPerHour.CompareTo(w1.MoneyPerHour)));        
        Array.Sort(workers, new Comparison<Worker>((w1, w2) => w2.CompareTo(w1)));

        foreach (Worker worker in workers)
        {
            Console.WriteLine(worker);
        }
    }
}
