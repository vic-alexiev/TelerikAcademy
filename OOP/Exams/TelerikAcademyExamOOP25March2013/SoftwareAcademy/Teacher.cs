using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private IList<ICourse> courses;

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                name = value;
            }
        }

        public Teacher(string name)
        {
            this.Name = name;

            courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.courses.Count > 0)
            {
                StringBuilder coursesBuilder = new StringBuilder();

                foreach (ICourse course in courses)
                {
                    coursesBuilder.AppendFormat("{0}, ", course.Name);
                }

                coursesBuilder.Length -= 2;

                result.AppendFormat("; Courses=[{0}]", coursesBuilder);
            }

            return result.ToString();
        }
    }
}
