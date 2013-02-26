// Write a method that from a given array of students finds all students whose first 
// name is before its last name alphabetically. Use LINQ query operators.

using System;
using System.Collections.Generic;
using System.Linq;

class StudentsNameLINQ
{
    static void Main(string[] args)
    {
        string[] names = { "Asia Bratanova", "Bratan Sotivov", "Sotir Bratanov" };
        List<Student> eightGrade = new List<Student>();
        foreach (var name in names)
        {
            string[] splited = name.Split(' ');
            eightGrade.Add( new Student(splited[0], splited[1]));
        }

        var firstNameBeforeLast =
            from student in eightGrade
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;

        foreach (var student in firstNameBeforeLast)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }
}

public class Student
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Student(string aFirstName, string aLastName)
    {
        this.FirstName = aFirstName;
        this.LastName = aLastName;
    }
}
