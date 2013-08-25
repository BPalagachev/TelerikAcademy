namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Homework> homeworks;
        private ICollection<Course> courses;

        public Student()
        {
            this.homeworks = new HashSet<Homework>();
            this.courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string FacultyNumber { get; set; }

        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }

        
        public virtual ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }
    }
}
