using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public string Town
        {
            get
            {
                return town;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                town = value;
            }
        }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public override string ToString()
        {
            return String.Format("{0} Town={1}", base.ToString(), this.Town);
        }
    }
}
