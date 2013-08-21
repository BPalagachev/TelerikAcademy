namespace _02.TestSchool
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _01.School;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCreatingCourse()
        {
            Course testCourse = new Course();
            Assert.AreNotEqual(null, testCourse);
        }

        [TestMethod]
        public void TestAddingStudentToCourse()
        {
            School testSchool = new School();
            Student testStudent = new Student("test student", testSchool);
            Course testCourse = new Course();

            testCourse.AddStudent(testStudent);
            IList<Student> enlistedStudents = testCourse.EnrolledStudents;

            Assert.AreEqual(1, enlistedStudents.Count);
            Assert.AreSame(testStudent, enlistedStudents[0]);
        }

        [TestMethod]
        public void TestAdding30Students()
        {
            School testSchool = new School();
            Course testCourse = new Course();

            for (int i = 0; i < 30; i++)
            {
                Student testStudent = new Student("test student", testSchool);
                testCourse.AddStudent(testStudent);
            }

            Assert.AreEqual(30, testCourse.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddingTooManyStudents()
        {
            School testSchool = new School();
            Course testCourse = new Course();

            for (int i = 0; i < 31; i++)
            {
                Student testStudent = new Student("test student", testSchool);
                testCourse.AddStudent(testStudent);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddingSameStudentTwice()
        {
            School testSchool = new School();
            Student testStudent = new Student("test student", testSchool);
            Course testCourse = new Course();

            for (int i = 0; i < 2; i++)
            {                
                testCourse.AddStudent(testStudent);
            }
        }

        [TestMethod]
        public void TestRemovingStudents()
        {
            School testSchool = new School();
            Student firstTestStudent = new Student("first test student", testSchool);
            Student secondTestStudent = new Student("second test student", testSchool);
            Course testCourse = new Course();

            testCourse.AddStudent(firstTestStudent);
            testCourse.AddStudent(secondTestStudent);

            testCourse.RemoveStudent(firstTestStudent);
            IList<Student> enrolledStudents = testCourse.EnrolledStudents;

            Assert.AreEqual(1, testCourse.Count);
            Assert.AreSame(secondTestStudent, enrolledStudents[0]);
            Assert.IsFalse(enrolledStudents.Contains(firstTestStudent));            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullStudent()
        {
            School testSchool = new School();
            Student firstTestStudent = new Student("first test student", testSchool);
            Student secondTestStudent = new Student("second test student", testSchool);
            Course testCourse = new Course();

            testCourse.AddStudent(firstTestStudent);
            testCourse.AddStudent(secondTestStudent);

            testCourse.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemovingNotEnrolledStudent()
        {
            School testSchool = new School();
            Student firstTestStudent = new Student("first test student", testSchool);
            Student secondTestStudent = new Student("second test student", testSchool);
            Course testCourse = new Course();

            testCourse.AddStudent(firstTestStudent);

            testCourse.RemoveStudent(secondTestStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemvingStudentFromEmptyCourse()
        {
            School testSchool = new School();
            Student firstTestStudent = new Student("first test student", testSchool);
            Course testCourse = new Course();

            testCourse.RemoveStudent(firstTestStudent);
        }
    }
}
