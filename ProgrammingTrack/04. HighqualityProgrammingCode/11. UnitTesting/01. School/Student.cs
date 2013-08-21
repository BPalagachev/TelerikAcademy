namespace _01.School
{
    using System;

    public class Student
    {
        public Student(string name, School studentSchool)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Students name cannot be empty or null!");
            }

            this.Name = name;
            this.UniqueNumber = studentSchool.GetUniqueStudentNumber();
        }

        public string Name { get; set; }

        public int UniqueNumber { get; private set; }
    }
}
