namespace StudentSystem.Models
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public Homework()
        {
        }

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateSent { get; set; }

        public int? StudentId { get; set; }

        public int CourseId { get; set; }
    }
}
