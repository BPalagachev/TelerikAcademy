using System;

namespace SchoolOrganization
{
    public class UI
    {
       public static void Main(string[] args)
        {
            Teacher[] lectors = new Teacher[]
            {
                new Teacher("Joro Bekama"),
                new Teacher("Dafinka"),
            };

            lectors[0].AddDiscipline(new Discipline("Biology", 15, 15));
            lectors[0].AddDiscipline(new Discipline("German", 45, 70));
            lectors[1].AddDiscipline(new Discipline("Кампютери", 100, 1000));
            lectors[1].Comments = "Да отваш при бай Стоядин!";

            ClassGroup classA = new ClassGroup('A');
            classA.AddStudent(new Student("Sedefcho", 'A'));
            classA.AddStudent(new Student("Margaret", 'A') { Comments = "Huligan" });
            foreach (var teacher in lectors)
            {
                classA.AddTeacher(teacher);
            }

            ClassGroup classB = new ClassGroup('B');
            classB.AddStudent(new Student("Strahil", 'B'));
            classB.AddTeacher(lectors[1]);

            School babaitskoto = new School();
            babaitskoto.AddClass(classA);
            babaitskoto.AddClass(classB);

            foreach (ClassGroup group in babaitskoto.GetClasses)
            {
                Console.WriteLine("-----New Class-----");
                Console.WriteLine("This is {0} class!", group.UniqueTextIdentifier);
                Console.WriteLine("Stundet List:");
                foreach (Student student in group.GetStudents)
                {
                    Console.WriteLine("Name: {0}", student.Name);
                    Console.WriteLine("This student is a part of {0} class!", student.UniqueClassNumber);
                    Console.WriteLine("Comments: {0}", student.Comments);
                }

                Console.WriteLine("Teacher List:");
                foreach (Teacher teacher in group.GetTeachers)
                {
                    Console.WriteLine("Name: " + teacher.Name);
                    Console.WriteLine("Comments: " + teacher.Comments);
                    Console.WriteLine("Disciplines:");
                    foreach (Discipline subject in teacher.GetSetOfDisciplines)
                    {
                        Console.WriteLine("Discipline Name: " + subject.Name);
                        Console.WriteLine("Number of Lectures: " + subject.NumberOfLectures);
                        Console.WriteLine("Number of Exercises: " + subject.NumberOfExercises);
                    }
                }
            }
        }
    }
}
