using System;
using System.Text;

namespace Task1To3
{
    // Task 1 - Define a class Student, which contains data about a student – first, middle and last name, 
    // SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an 
    // enumeration for the specialties, universities and faculties. Override the standard methods, 
    // inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string aFirstName, string aLastName, string aSSN)
        {
            this.FirstName = aFirstName;
            this.LastName = aLastName;
            this.SSN = aSSN;

            this.MiddleName = null;
            this.Address = null;
            this.MobilePhone = null;
            this.Email = null;
            this.Course = null;
            this.Specialty = Specialty.Unknown;
            this.University = University.Unknown;
            this.Faculty = Faculty.Unknown;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string SSN { get; private set; }

        public string MiddleName { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string Course { get; set; }

        public Specialty Specialty { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        // Two students are the same person if they have same SSN (ЕГН?)
        public override bool Equals(object obj)
        {
            if (!(obj is Student))
            {
                throw new ArgumentException("You can only compare students to other students");
            }

            Student student = obj as Student;

            if (this.SSN == student.SSN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder studentInfo = new StringBuilder();

            studentInfo.AppendLine("Student Info:");

            studentInfo.AppendLine("First Name: " + this.FirstName);
            studentInfo.AppendLine("Last Name: " + this.LastName);
            studentInfo.AppendLine("Social Security Number: " + this.SSN);

            studentInfo.AppendLine("Middle Name: " + (this.MiddleName ?? "Unknown"));
            studentInfo.AppendLine("Address: " + (this.Address ?? "Unknown"));
            studentInfo.AppendLine("Mobile Phone: " + (this.MobilePhone ?? "Unknown"));
            studentInfo.AppendLine("Course: " + (this.Course ?? "Unknown"));
            studentInfo.AppendLine("Speciality: " + this.Specialty);
            studentInfo.AppendLine("University: " + this.University);
            studentInfo.AppendLine("Faculty: " + this.Faculty);

            return studentInfo.ToString();
        }

        public override int GetHashCode()
        {
            int hasCode = this.SSN[0];

            for (int i = 1; i < this.SSN.Length; i++)
            {
                if (i % 2 == 0)
                {
                    hasCode *= this.SSN[i];
                }
                else
                {
                    hasCode ^= this.SSN[i];
                }
            }

            return hasCode;
        }

        public static bool operator ==(Student st1, Student st2)
        {
            return st1.Equals(st2);
        }

        public static bool operator !=(Student st1, Student st2)
        {
            return !st1.Equals(st2);
        }

        // Task 2 - Add implementations of the ICloneable interface. The Clone() method should 
        // deeply copy all object's fields into a new object of type Student.
        public object Clone()
        {
            Student copiedStudent = new Student(this.FirstName, this.LastName, this.SSN);

            copiedStudent.MiddleName = this.MiddleName != null ? string.Copy(this.MiddleName) : null; 
            copiedStudent.Address = this.Address != null ? string.Copy(this.Address) : null;
            copiedStudent.MobilePhone = this.MobilePhone != null ? string.Copy(this.MobilePhone) : null;
            copiedStudent.Email = this.Email != null ? string.Copy(this.Email) : null;
            copiedStudent.Course = this.Course != null ? string.Copy(this.Course) : null;
            copiedStudent.Specialty = this.Specialty;
            copiedStudent.University = this.University;
            copiedStudent.Faculty = this.Faculty;

            return copiedStudent;
        }

        // Task 3 - Implement the  IComparable<Student> interface to compare students by names (as first criteria, 
        // in lexicographic order) and by social security number (as second criteria, in increasing order).
        public int CompareTo(Student other)
        {
            int firstNameComparison = this.FirstName.CompareTo(other.FirstName);

            if (firstNameComparison == 0)
            {
                return this.SSN.CompareTo(other.SSN);
            }
            else
            {
                return firstNameComparison;
            }
        }
    }
}
