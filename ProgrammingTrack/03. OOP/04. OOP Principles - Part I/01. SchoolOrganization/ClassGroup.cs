using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolOrganization
{
    public class ClassGroup
    {
        private IList<Teacher> setOfTeachers;
        private IList<Student> setOfStudents;

        public ClassGroup(char aUniqueTextIdentifier)
        {
            this.setOfTeachers = new List<Teacher>();
            this.setOfStudents = new List<Student>();
            this.UniqueTextIdentifier = aUniqueTextIdentifier;
        }

        public char UniqueTextIdentifier { get; private set; }

        public IEnumerable GetTeachers
        {
            get
            {
                IList<Teacher> set = new List<Teacher>();
                foreach (var teacher in this.setOfTeachers)
                {
                    set.Add(teacher);
                }

                return set;
            }
        }

        public IEnumerable GetStudents
        {
            get
            {
                IList<Student> set = new List<Student>();
                foreach (var student in this.setOfStudents)
                {
                    set.Add(student);
                }

                return set;
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            this.setOfTeachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            this.setOfStudents.Add(student);
        }
    }
}
