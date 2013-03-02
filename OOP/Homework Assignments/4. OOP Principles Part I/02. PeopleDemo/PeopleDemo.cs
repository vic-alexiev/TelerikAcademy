using System;
using System.Collections.Generic;
using System.Linq;

class PeopleDemo
{
    private static List<Student> InitializeStudents()
    {
        List<Student> source = new List<Student>();

        source.Add(new Student("Kiril", "Nikolov", 23.4));
        source.Add(new Student("Stamo", "Petkov", 12.9));
        source.Add(new Student("Yordan", "Yordanov", 89.12));
        source.Add(new Student("Boris", "Gutsev", 35.229));
        source.Add(new Student("Martin", "Yankov", 72.124));
        source.Add(new Student("Vladimir", "Georgiev", 19.2));
        source.Add(new Student("Lina", "Ivanova", 78.93));
        source.Add(new Student("Mihail", "Petrov", 19.75));
        source.Add(new Student("Lyubomir", "Yanchev", 27.01));
        source.Add(new Student("Nikolay", "Alexiev", 34.12));

        return source;
    }

    private static List<Worker> InitializeWorkers()
    {
        List<Worker> source = new List<Worker>();

        source.Add(new Worker("Kiril", "Donchev", 200));
        source.Add(new Worker("Stamo", "Dimitrov", 300));
        source.Add(new Worker("Yordan", "Nikolov", 500));
        source.Add(new Worker("Boris", "Kovachev", 350));
        source.Add(new Worker("Martin", "Ivanov", 280));
        source.Add(new Worker("Vladimir", "Georgiev", 400));
        source.Add(new Worker("Lina", "Petrova", 380));
        source.Add(new Worker("Mihail", "Petrov", 275));
        source.Add(new Worker("Lyubomir", "Yanchev", 350));
        source.Add(new Worker("Nikolay", "Mihaylov", 295));

        return source;
    }

    static void Main()
    {
        #region Task: Initialize a list of 10 students and sort them by grade in ascending order.

        List<Student> students = InitializeStudents();

        // I solution
        students.Sort(new Comparison<Student>((s1, s2) => s1.Grade.CompareTo(s2.Grade)));
        // II solution
        students = students.OrderBy(s => s.Grade).ToList();
        // III solution
        students =
            (from student in students
             orderby student.Grade
             select student).ToList();

        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }

        #endregion

        #region Task: Initialize a list of 10 workers and sort them by money per hour in descending order.

        List<Worker> workers = InitializeWorkers();

        // I solution
        workers.Sort(new Comparison<Worker>((w1, w2) => w2.MoneyPerHour.CompareTo(w1.MoneyPerHour)));
        // II solution
        workers = workers.OrderByDescending(w => w.MoneyPerHour).ToList();
        // III solution
        workers =
            (from worker in workers
             orderby worker.MoneyPerHour descending
             select worker).ToList();

        foreach (Worker worker in workers)
        {
            Console.WriteLine(worker);
        }

        #endregion

        #region Task: Merge the lists and sort them by first name and last name.

        List<Human> humans = new List<Human>(students);
        List<Human> humanWorkers = new List<Human>(workers);

        humans = humans.Concat(humanWorkers).ToList();

        // I solution
        humans = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToList();
        // II solution
        humans.Sort(); // uses CompareTo() method in Human
        // III solution
        humans =
            (from human in humans
             orderby human.FirstName, human.LastName
             select human).ToList();

        foreach (var human in humans)
        {
            Console.WriteLine(human);
        }

        #endregion
    }
}
