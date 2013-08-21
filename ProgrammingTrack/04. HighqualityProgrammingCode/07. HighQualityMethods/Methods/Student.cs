using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AdditionalInformation { get; set; }

        public Student(string firstname, string lastName, string dateOfBirth, string additionalInfo = null)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            this.DateOfBirth = DateTime.Parse(dateOfBirth);
            this.AdditionalInformation = additionalInfo;
        }


        public bool IsOlderThan(Student other)
        {
            bool isOlder = (this.DateOfBirth < other.DateOfBirth);
            return isOlder;
        }
    }
}
