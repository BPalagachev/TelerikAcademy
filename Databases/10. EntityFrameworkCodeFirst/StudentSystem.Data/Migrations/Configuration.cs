namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var spiro = new Student()
            {
                Name = "Spiro Spirta",
                FacultyNumber = "123Spirooo"
            };

            var homework = new Homework()
            {
                Content = "Spiros thoughts",
                DateSent = new DateTime(2013, 7, 16)
            };

            var cookingForDummies = new Course()
            {
                Name = "Cooking For Dummies"
            };

            var material = new Material()
            {
                Title = "Lutenica ot qgodi",
                Url = "http://uti.uti/cooking/recepies/strawberries"
            };

            spiro.Courses.Add(cookingForDummies);
            cookingForDummies.Studensts.Add(spiro);
            spiro.Homeworks.Add(homework);
            cookingForDummies.Homeworks.Add(homework);
            cookingForDummies.Materials.Add(material);

            context.Students.AddOrUpdate(spiro);
            context.Courses.AddOrUpdate(cookingForDummies);
            context.Homeworks.AddOrUpdate(homework);
            context.Materials.AddOrUpdate(material);
        }
    }
}
