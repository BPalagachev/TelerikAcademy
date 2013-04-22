using System;
using System.Text;

namespace _04.Person
{
    // Task 4 - Create a class Person with two fields – name and age. Age can be left 
    // unspecified (may contain null value. Override ToString() to display the information
    // of a person and if age is not specified – to say so. Write a program to test this 
    // functionality.

    public class Person
    {
        public Person(string aName, uint? aAge = null)
        {
            this.Name = aName;
            this.Age = aAge;
        }

        public string Name { get; private set; }
        public uint? Age { get; private set; }

        public override string ToString()
        {
            StringBuilder personinfo = new StringBuilder();

            personinfo.AppendLine("Person's Information");

            personinfo.AppendLine("Name: " + this.Name);
            if (this.Age != null)
            {
                personinfo.AppendLine("Age: " + this.Age.ToString());
            }
            else
            {
                personinfo.AppendLine("Age: Unknown");
            }

            return personinfo.ToString();
        }

    }
}
