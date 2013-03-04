using System.Collections.Generic;
using System.Text;

public class Teacher : Person, IAnnotation
{
    public List<Course> Courses { get; private set; }

    public string Tag { get; set; }

    public Teacher(string firstName, string lastName, Course[] courses)
        : base(firstName, lastName)
    {
        this.Courses = new List<Course>(courses);
    }

    public override string ToString()
    {
        StringBuilder teacherInfoBuilder = new StringBuilder();

        teacherInfoBuilder.AppendFormat("Teacher: {0}", base.ToString());

        teacherInfoBuilder.Append("\r\nCourses:");

        foreach (Course course in this.Courses)
        {
            teacherInfoBuilder.AppendFormat("\r\n{0}", course);
        }

        return teacherInfoBuilder.ToString();
    }
}
