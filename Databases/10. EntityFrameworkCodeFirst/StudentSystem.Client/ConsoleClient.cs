namespace StudentSystem.Client
{
    using System;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Data.Entity;
    using StudentSystem.Data.Migrations;

    public class ConsoleClient
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            var dbContext = new StudentSystemContext();

            using (dbContext)
            {

                var kolio = new Student()
                {
                    Name = "Kolio Piandeto",
                    FacultyNumber = "15486251"
                };

                var homework = new Homework()
                {
                    Content = "AaaAaaaAaaaAaaa",
                    DateSent = new DateTime(2011, 03, 05)
                };

                var music = new Course()
                {
                    Name = "Advanced music"
                };

                var material = new Material()
                {
                    Title = "Old songs",
                    Url = "http://dir.bg/music/1920"
                };

                kolio.Courses.Add(music);
                music.Studensts.Add(kolio);
                kolio.Homeworks.Add(homework);
                music.Homeworks.Add(homework);
                music.Materials.Add(material);

                dbContext.Students.Add(kolio);
                dbContext.Courses.Add(music);
                dbContext.Homeworks.Add(homework);
                dbContext.Materials.Add(material);

                dbContext.SaveChanges();
            }

        }
    }
}
