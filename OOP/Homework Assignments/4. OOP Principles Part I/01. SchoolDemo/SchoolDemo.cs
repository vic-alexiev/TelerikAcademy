using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SchoolDemo
{
    static void Main()
    {
        Student[] students1 = new Student[]
        {
            new Student("Kiril", "Nikolov", 1),
            new Student("Stamo", "Petkov", 2),
            new Student("Yordan", "Yordanov", 3),
            new Student("Boris", "Gutsev", 4),
            new Student("Martin", "Yankov", 5),
            new Student("Vladimir", "Georgiev", 6),
            new Student("Lina", "Ivanova", 7)
        };

        Student[] students2 = new Student[]
        {
            new Student("Mihail", "Petrov", 1),
            new Student("Lyubomir", "Yanchev", 2),
            new Student("Nikolay", "Alexiev", 3),
            new Student("Konstantin", "Dikov", 4),
            new Student("Dimitar", "Todorov", 5),
            new Student("Tsvetan", "Ivanov", 6),
            new Student("Victor", "Ivanov", 7)
        };

        Course[] donchoMinkovCourses = new Course[]
        {
            new Course("C# Fundamentals Part I", 8, 8),
            new Course("C# Fundamentals Part II", 8, 8),
            new Course("Object-Oriented Programming", 8, 8),
            new Course("JavaScript Part I", 8, 8)
        };

        Course[] nikolayKostovCourses = new Course[]
        {
            new Course("C# Fundamentals Part I", 10, 0),
            new Course("C# Fundamentals Part II", 5, 5),
            new Course("Object-Oriented Programming", 9, 9),
            new Course("ASP.NET MVC", 8, 8)
        };

        Course[] georgeGeorgievCourses = new Course[]
        {
            new Course("C# Fundamentals Part I", 10, 0),
            new Course("C# Fundamentals Part II", 5, 5),
            new Course("HTML5", 9, 9),
            new Course("CSS3", 8, 8)
        };

        Course[] svetlinNakovCourses = new Course[]
        {
            new Course("C# Fundamentals Part I", 10, 10),
            new Course("C# Fundamentals Part II", 18, 3),
            new Course("Object-Oriented Programming", 8, 1),
            new Course("Knowledge Sharing and Teamwork", 10, 0)
        };

        Teacher[] teachers1 = new Teacher[]
        {
            new Teacher("Doncho", "Minkov", donchoMinkovCourses),
            new Teacher("Nikolay", "Kostov", nikolayKostovCourses)
        };

        Teacher[] teachers2 = new Teacher[]
        {
            new Teacher("George", "Georgiev", georgeGeorgievCourses),
            new Teacher("Svetlin", "Nakov", svetlinNakovCourses)
        };

        SchoolClass[] schoolClasses = new SchoolClass[]
        {
            new SchoolClass("Ia", students1, teachers1),
            new SchoolClass("Ib", students2, teachers2)
        };

        School telerikAcademy = new School("Telerik Academy", schoolClasses);

        Console.WriteLine(telerikAcademy);
    }
}
