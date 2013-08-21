namespace _02.TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _01.School;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestCreatingStudentTrivial()
        {
            // This test fails when all tests are runned. 
            // But It PASSES when it is debugged or runned individually. I have no explanation for this.
            School testSchool = new School();

            Student testStudent = new Student("test student", testSchool);

            Assert.AreEqual("test student", testStudent.Name, "Students Name differs");
            Assert.AreEqual(100000, testStudent.UniqueNumber, "Students Unique Number differs");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreatingNullNamedStudent()
        {
            School testSchool = new School();
            Student testStudent = new Student(null, testSchool);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreatingStundetWithEmptyName()
        {
            School testSchool = new School();
            Student testStudent = new Student(string.Empty, testSchool);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCreatingTooManyStudents()
        {
            // this test indirectly Schools internal int GetUniqueStudentNumber()
            School testSchool = new School();
            
            for (int i = 0; i < 900000; i++)
            {
                Student testStudent = new Student("test student", testSchool);
            }
        }

        [TestMethod]
        public void TestUniqueStudentsNumberSequence()
        {
            // This test fails when all tests are runned. 
            // But it PASSES when it is debugged or runned individually. I have no explanation for this.

            // this test indirectly Schools internal int GetUniqueStudentNumber()
            School testSchool = new School();

            for (int i = 100000; i <= 999999; i++)
            {
                Student testStudent = new Student("test student", testSchool);
                Assert.AreEqual(i, testStudent.UniqueNumber, "Unique numbers differs from: " + i);
            }
        }
    }
}
