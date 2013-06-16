using System;
using System.Collections.Generic;
using System.IO;

internal class StudentSorter
{
    private static void Main()
    {
        SortedDictionary<string, List<Student>> courses = new SortedDictionary<string, List<Student>>();
        string studentsFilePath = "../../Resources/students.txt";

        using (StreamReader reader = new StreamReader(studentsFilePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] recordData = line.Split('|');
                string firstName = recordData[0].Trim();
                string lastName = recordData[1].Trim();
                string course = recordData[2].Trim();

                List<Student> students;

                if (!courses.TryGetValue(course, out students))
                {
                    students = new List<Student>();
                    courses.Add(course, students);
                }

                Student student = new Student(firstName, lastName);
                students.Add(student);
            }
        }

        foreach (var pair in courses)
        {
            Console.WriteLine("{0,15}:\n\t\t{1}", pair.Key, string.Join("\n\t\t", pair.Value));
        }
    }
}
