namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Material
    {
        public Material()
        {
        }
        
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public int CourseId { get; set; }
    }
}
