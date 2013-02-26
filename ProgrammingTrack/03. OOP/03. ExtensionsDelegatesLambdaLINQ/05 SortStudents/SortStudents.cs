// Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
// the students by first name and last name in descending order. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;

class SortStudents
{
    static void Main()
    {
        string[] names = { "Bratan Sotivov 20", "Asia Bratanova 18", "Sotir Bratanov 24", "Diado Ioco 169" };
        List<Student> eightGrade = new List<Student>();
        foreach (var name in names)
        {
            string[] splited = name.Split(' ');
            eightGrade.Add(new Student(splited[0], splited[1], byte.Parse(splited[2])));
        }

        var sortedWithLINQ =
            from student in eightGrade
            orderby student.LastName + student.FirstName
            select student;

        Console.WriteLine("Sorted by last name, then by first name with LINQ: ");
        foreach (var student in sortedWithLINQ)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }

        IEnumerable<Student> sortedWithOrderBy = 
        eightGrade.OrderBy(student => student.LastName).ThenBy(student => student.FirstName);
        Console.WriteLine("Sorted by last name, then by first name with OrderBy and ThenBy");
        foreach (var student in sortedWithOrderBy)
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