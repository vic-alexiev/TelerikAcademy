namespace StudentsDb.Services.Models
{
    public class MarkDto
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public int Value { get; set; }

        public int StudentId { get; set; }
    }
}