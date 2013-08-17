using System.Collections.Generic;

namespace StudentsDb.Services.Models
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public int Grade { get; set; }

        public int SchoolId { get; set; }

        public IEnumerable<MarkDto> Marks;
    }
}