using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class Student
    {
        private ICollection<Mark> marks;

        public Student()
        {
            this.marks = new HashSet<Mark>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Required]
        public int Grade { get; set; }

        public virtual School School { get; set; }

        // Set of marks
        public ICollection<Mark> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }
    }
}
