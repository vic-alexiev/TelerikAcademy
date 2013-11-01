using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public string Lab
        {
            get 
            { 
                return lab; 
            }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                lab = value; 
            }
        }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public override string ToString()
        {
            return String.Format("{0} Lab={1}", base.ToString(), this.Lab);
        }
    }
}
