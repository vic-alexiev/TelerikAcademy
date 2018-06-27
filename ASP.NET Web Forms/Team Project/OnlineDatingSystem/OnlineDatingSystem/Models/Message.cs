using System;

namespace OnlineDatingSystem.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public bool Read { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
    }
}