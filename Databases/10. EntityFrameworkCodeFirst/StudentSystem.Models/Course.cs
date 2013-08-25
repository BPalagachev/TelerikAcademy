namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Homework> homeworks;
        private ICollection<Material> materials;
        private ICollection<Student> studensts;

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.materials = new HashSet<Material>();
            this.studensts = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        
        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }

        public virtual ICollection<Material> Materials
        {
            get { return materials; }
            set { materials = value; }
        }

        public virtual ICollection<Student> Studensts
        {
            get { return studensts; }
            set { studensts = value; }
        }

    }
}
