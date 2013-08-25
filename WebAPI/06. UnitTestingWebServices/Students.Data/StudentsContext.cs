using Students.Models;
using System.Data.Entity;

namespace Students.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext()
            :base("StudentsTestsDb")
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<School> Schools { get; set; }
    }
}
