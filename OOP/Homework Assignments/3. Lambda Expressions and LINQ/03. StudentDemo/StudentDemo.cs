using System;
using System.Linq;

class StudentDemo
{
    static void Main()
    {
        Student[] students = new Student[]
        {
            new Student("Robert", "De Niro", new DateTime(1943, 8, 17)),
            new Student("Danny", "DeVito", new DateTime(1944, 10, 17)),
            new Student("George", "Clooney", new DateTime(1961, 5, 6)),
            new Student("Dustin", "Hoffman", new DateTime(1937, 8, 8)),
            new Student("Pierce", "Brosnan", new DateTime(1953, 5, 16)),
            new Student("Daniel", "Craig", new DateTime(1968, 3, 2)),
            new Student("Al", "Pacino", new DateTime(1940, 4, 25)),
            new Student("Meryl", "Streep", new DateTime(1949, 6, 22)),
            new Student("Julia", "Roberts", new DateTime(1967, 10, 28)),
            new Student("Sean", "Penn", new DateTime(1960, 8, 17)),
            new Student("Brad", "Pitt", new DateTime(1963, 12, 18)),
            new Student("Matt", "Damon", new DateTime(1970, 10, 8)),
            new Student("Robert", "Redford", new DateTime(1936, 8, 18)),
            new Student("Andy", "Garcia", new DateTime(1956, 4, 12)),
            new Student("Anthony", "Hopkins", new DateTime(1937, 12, 31)),
            new Student("Justin", "Bieber", new DateTime(1994, 3, 1)),
            new Student("Josh", "Hutcherson", new DateTime(1992, 10, 12)),
            new Student("Nina", "Dobrev", new DateTime(1989, 1, 9)),  
            new Student("Taylor", "Lautner", new DateTime(1992, 2, 11)),
            new Student("Sean", "Connery", new DateTime(1930, 8, 25)),
            new Student("Daniel", "Radcliffe", new DateTime(1989, 7, 23)),
            new Student("Danny", "Glover", new DateTime(1946, 7, 22)),
            new Student("Matt", "LeBlanc", new DateTime(1967, 7, 25)),
        };

        #region Problem 3

        // Find all students whose first name is lexicographically before their last name.

        //var studentsWithFirstNameLexicallyBeforeLastName =
        //    from student in students
        //    where student.FirstName.CompareTo(student.LastName) < 0
        //    select student;

        //foreach (Student student in studentsWithFirstNameLexicallyBeforeLastName)
        //{
        //    Console.WriteLine(student);
        //}

        #endregion

        #region Problem 4

        // Find the first and last name of all students from 18 to 24 years old.

        //var firstAndLastNames =
        //    from student in students
        //    where student.GetAge() >= 18 && student.GetAge() <= 24
        //    select new { FirstName = student.FirstName, LastName = student.LastName };

        //foreach (var fullName in firstAndLastNames)
        //{
        //    Console.WriteLine("{0} {1}", fullName.FirstName, fullName.LastName);
        //}

        #endregion

        #region Problem 5

        // Sort the students by first name and last name in descending order.

        //IOrderedEnumerable<Student> sortedStudents1 = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);

        //foreach (Student student in sortedStudents1)
        //{
        //    Console.WriteLine(student);
        //}

        var sortedStudents2 =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;

        foreach (Student student in sortedStudents2)
        {
            Console.WriteLine(student);
        }

        #endregion
    }
}
