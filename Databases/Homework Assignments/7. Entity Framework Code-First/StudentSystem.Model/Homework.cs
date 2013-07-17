using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Model
{
    public class Homework
    {
        [Key(), Column("HomeworkId")]
        public int Id { get; set; }

        [Column("Content")]
        public string Content { get; set; }

        [Column("TimeSent")]
        public DateTime? TimeSent { get; set; }
    }
}
