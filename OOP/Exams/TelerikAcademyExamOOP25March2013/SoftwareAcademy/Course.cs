using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        // a list of topics
        private IList<string> program;

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

        public ITeacher Teacher { get; set; }

        protected Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;

            program = new List<string>();
        }

        public void AddTopic(string topic)
        {
            this.program.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}: Name={1};", this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                result.AppendFormat(" Teacher={0};", this.Teacher.Name);
            }

            if (this.program.Count > 0)
            {
                StringBuilder topicsBuilder = new StringBuilder();

                foreach (string topic in program)
                {
                    topicsBuilder.AppendFormat("{0}, ", topic);
                }

                topicsBuilder.Length -= 2;

                result.AppendFormat(" Topics=[{0}];", topicsBuilder);
            }

            return result.ToString();
        }
    }
}