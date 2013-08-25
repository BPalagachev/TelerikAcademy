using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class School
    {
        private ICollection<Student> students;

        public School()
        {
            this.students = new HashSet<Student>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
