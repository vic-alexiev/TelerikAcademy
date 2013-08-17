using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsDb.Models
{
    public class Student : IIdentifier
    {
        private ICollection<Mark> marks;

        public Student()
        {
            this.marks = new HashSet<Mark>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public int Grade { get; set; }

        public virtual ICollection<Mark> Marks
        {
            get { return this.marks; }
            internal set { this.marks = value; }
        }

        [ForeignKey("School")]
        public int SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
