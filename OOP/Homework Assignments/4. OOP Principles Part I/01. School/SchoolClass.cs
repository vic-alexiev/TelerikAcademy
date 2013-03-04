using System.Collections.Generic;
using System.Text;

public class SchoolClass : IAnnotation
{
    public string Id { get; private set; }

    public List<Student> Students { get; private set; }

    public List<Teacher> Teachers { get; private set; }

    public string Tag { get; set; }

    public SchoolClass(string id, Student[] students, Teacher[] teachers)
    {
        this.Id = id;

        this.Students = new List<Student>(students);

        this.Teachers = new List<Teacher>(teachers);
    }

    public override string ToString()
    {
        StringBuilder schoolClassInfoBuilder = new StringBuilder();

        schoolClassInfoBuilder.AppendFormat("Class {0}:", this.Id);

        schoolClassInfoBuilder.Append("\r\nStudents:");

        foreach (Student student in this.Students)
        {
            schoolClassInfoBuilder.AppendFormat("\r\n{0}", student);
        }

        schoolClassInfoBuilder.Append("\r\nTeachers:");

        foreach (Teacher teacher in this.Teachers)
        {
            schoolClassInfoBuilder.AppendFormat("\r\n{0}", teacher);
        }

        return schoolClassInfoBuilder.ToString();
    }
}
