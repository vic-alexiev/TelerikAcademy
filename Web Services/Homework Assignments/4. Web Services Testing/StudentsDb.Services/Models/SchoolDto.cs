using System.Collections.Generic;

namespace StudentsDb.Services.Models
{
    public class SchoolDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public IEnumerable<StudentDto> Students;
    }
}