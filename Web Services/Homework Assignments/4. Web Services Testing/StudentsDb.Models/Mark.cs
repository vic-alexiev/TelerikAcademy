using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsDb.Models
{
    public class Mark : IIdentifier
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public int Value { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
