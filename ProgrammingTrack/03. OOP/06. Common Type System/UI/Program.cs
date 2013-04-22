using System;
using System.Collections.Generic;
using _04.Person;
using _05.BitArray64;
using Task1To3;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Task 1 - 
            Student newKid = new Student("Manol", "Karamanolow", "123456789");
            newKid.MiddleName = "Fictional Character";
            newKid.Specialty = Specialty.MasterTypist;

            Student oldKid = new Student("Manol", "Karamanolow", "987654321");
            newKid.MobilePhone = "0888 888 888";
            newKid.Specialty = Specialty.Gardening;

            // Test Equals()

            // if (newKid.Equals(newKid))
            if (newKid.Equals(oldKid))
            {
                Console.WriteLine("Same Student - only one SSN");
            }
            else
            {
                Console.WriteLine("Different students as they have different SSN");
            }

            // Test ToString()
            Console.WriteLine(newKid);

            // Test GetHashCode
            Console.WriteLine(oldKid.GetHashCode());
            Console.WriteLine(newKid.GetHashCode());

            // Testing == and !=
            Console.WriteLine("newKid is NOT oldKid: {0}", newKid != oldKid);
            Console.WriteLine("newKid is newKid: {0}", newKid == newKid);

            // Task 2 - 

            // Testing deep copying
            oldKid = newKid.Clone() as Student;
            oldKid.MiddleName = "Test if this field will be changed in newKid as well";
            Console.WriteLine(newKid);

            // Task 3 -
            List<Student> group = new List<Student>();
            group.Add(new Student("aaa", "aaa", "9999"));
            group.Add(new Student("bbb", "bbb", "1239"));
            group.Add(new Student("bbb", "bbb", "1236"));

            group.Sort();
            foreach (var student in group)
            {
                Console.WriteLine(student.FirstName + " " + student.SSN);
            }

            // Task 4 - 
            // Testing ToString() with specified Age property
            Person firstPerson = new Person("Manol", 17);
            Console.WriteLine(firstPerson);

            // Testing ToString() with unspecified Age property
            Person secondPersn = new Person("Manol2");
            Console.WriteLine(secondPersn);

            // Task 5 -
            BitArray64 binary = BitArray64.Parse("101"); // 5
            binary[1] = 1; // 7
            binary[2] = 0; // 3

            // testing ToString()
            Console.WriteLine(binary);

            // test Ienumerable
            Console.WriteLine();
            foreach (int item in binary)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            // test equals
            Console.WriteLine("11 is equal to 11: {0}", binary.Equals(BitArray64.Parse("11")));
            Console.WriteLine("11 is equal to 101: {0}", binary.Equals(BitArray64.Parse("101")));

            // tesint != and ==
            Console.WriteLine("11 is equal to 11: {0}", binary == BitArray64.Parse("11"));
            Console.WriteLine("11 is NOT equal to 101: {0}", binary != BitArray64.Parse("101"));
        }
    }
}
