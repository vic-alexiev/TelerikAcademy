using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Model
{
    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        [Key(), Column("CourseId")]
        public int Id { get; set; }

        [Column("CourseName")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Materials")]
        public string Materials { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
