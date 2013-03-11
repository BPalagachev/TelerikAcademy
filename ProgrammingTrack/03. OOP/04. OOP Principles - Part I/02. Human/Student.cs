using System;

namespace _02.Human
{
    public class Student : Human, IStudent
    {
        private byte grade;

        public Student(string aFirstName, string aLastName, byte aGrade)
            : base(aFirstName, aLastName)
        {
            this.Grade = aGrade;
        }

        public byte Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Grades must not be higher that 6 or lower then 2!");
                }

                this.grade = value;
            }
        }
    }
}
