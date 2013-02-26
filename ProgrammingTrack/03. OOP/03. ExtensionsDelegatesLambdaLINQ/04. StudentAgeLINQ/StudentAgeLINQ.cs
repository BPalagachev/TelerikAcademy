// Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

using System;
using System.Collections.Generic;
using System.Linq;

class StudentAgeLINQ
{
    static void Main(string[] args)
    {
        string[] names = { "Asia Bratanova 18", "Bratan Sotivov 20", "Sotir Bratanov 24", "Diado Ioco 169" };
        List<Student> eightGrade = new List<Student>();
        foreach (var name in names)
        {
            string[] splited = name.Split(' ');
            eightGrade.Add(new Student(splited[0], splited[1], byte.Parse(splited[2])));
        }

        var ageInRange =
            from student in eightGrade
            where student.Age>=18 && student.Age <=24
            select student;

        foreach (var student in ageInRange)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }
}

public class Student
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public byte Age { get; private set; }

    public Student(string aFirstName, string aLastName, byte aAge)
    {
        this.FirstName = aFirstName;
        this.LastName = aLastName;
        this.Age = aAge;
    }
}