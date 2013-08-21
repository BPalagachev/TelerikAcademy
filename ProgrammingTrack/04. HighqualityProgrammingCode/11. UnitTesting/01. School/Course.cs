namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int AllAvailablePlaces = 30;

        private IList<Student> enrolledStundents;

        public Course()
        {
            this.enrolledStundents = new List<Student>();
        }

        public string Name { get; private set; }

        public int Count
        {
            get { return this.enrolledStundents.Count; }
        }

        public IList<Student> EnrolledStudents
        {
            get
            {
                return new List<Student>(this.enrolledStundents);
            }
        }

        public void AddStudent(Student newStudent)
        {
            if (this.enrolledStundents.Count >= AllAvailablePlaces)
            {
                throw new InvalidOperationException("All places for this course has already been taken!");
            }
            else if (this.enrolledStundents.Contains(newStudent))
            {
                throw new ArgumentException("This student is already enrolled for the course. Cannot be added twice!");
            }

            this.enrolledStundents.Add(newStudent);
        }

        public void RemoveStudent(Student droppedStudent)
        {
            if (droppedStudent == null)
            {
                throw new ArgumentNullException("Students cannot be null!");
            }
            else if (this.enrolledStundents.Count <= 0)
            {
                throw new InvalidOperationException("Cannot remove student from empty coure!");
            }
            else if (!this.enrolledStundents.Contains(droppedStudent))
            {
                throw new ArgumentException("The student: " + droppedStudent.Name + " was now found in the participants of this course!");
            }

            this.enrolledStundents.Remove(droppedStudent);
        }
    }
}
