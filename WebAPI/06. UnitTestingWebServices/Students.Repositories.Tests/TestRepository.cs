using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Data;
using System.Transactions;
using System.Linq;
using Students.Models;

namespace Students.Repositories.Tests
{
    [TestClass]
    public class TestRepository
    {
        public StudentsContext StudentsContext { get; set; }

        public IRepositoty repository { get; set; }

        public TransactionScope tranScope { get; set; }

        public TestRepository()
        {
            this.StudentsContext = new StudentsContext();
            this.repository = new EFRepository(StudentsContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_Null_ShouldAddNothis()
        {
            var countBefore = this.repository.All<Student>().Count();
            this.repository.Add<Student>(null);
        }

        [TestMethod]
        public void Add_ValidStudent_ShouldBeAddedInDb()
        {
            var validStudent = new Student()
            {
                LastName = "ValidLastName",
                Grade = 5,
            };

            this.repository.Add(validStudent);
            this.repository.SaveChanges();

            var foundStudent = this.StudentsContext.Students.Find(validStudent.Id);
            Assert.IsNotNull(foundStudent);
            Assert.AreEqual(validStudent.LastName, foundStudent.LastName);
        }

        [TestMethod]
        public void Update_UpdateStudent_StudentShouldBeChangedInDb()
        {
            var student = new Student()
            {
                LastName = "OldName",
                Grade = 10,
            };
            var school = new School()
            {
                Name = "118 SOU",
                Location = "Mladost"
            };

            school.Students.Add(student);
            this.StudentsContext.Students.Add(student);
            this.StudentsContext.SaveChanges();
            var studentId = student.Id;

            student.FirstName = "New First Name";
            student.LastName = "New Last Name";
            student.School = new School()
            {
                Name = "New School",
                Location = "New Location"
            };

            this.repository.Update(student);
            this.repository.SaveChanges();

            var updatedStudent = this.StudentsContext.Students.Find(studentId);
            Assert.AreEqual("New First Name", updatedStudent.FirstName);
            Assert.AreEqual("New Last Name", updatedStudent.LastName);
            Assert.AreEqual("New School", updatedStudent.School.Name);
        }

        [TestMethod]
        public void GetById_GetExsistingStudent_ShouldBeEqual()
        {
            var student = new Student()
            {
                LastName = "student",
                Grade = 10,
            };
            this.StudentsContext.Students.Add(student);
            this.StudentsContext.SaveChanges();

            var id = student.Id;

            var studentFromDb = this.repository.Get<Student>(id);
            Assert.AreEqual(student.Id, studentFromDb.Id);
        }

        [TestMethod]
        public void GetById_GetNotExistingStundet_ShouldReturnNull()
        {
            var id = 0;
            var nullStundet = this.repository.Get<Student>(id);
            Assert.IsNull(nullStundet);
        }

        [TestMethod]
        public void DeleteById_DeleteStudentFromDb_ShouldNotBePresentInDb()
        {
            var student = new Student()
            {
                LastName = "student",
                Grade = 10,
            };
            this.StudentsContext.Students.Add(student);
            this.StudentsContext.SaveChanges();

            var id = student.Id;

            this.repository.Delete<Student>(id);
            this.repository.SaveChanges();

            var deleteStudent = this.StudentsContext.Students.Find(id);
            Assert.IsNull(deleteStudent);
        }

        [TestMethod]
        public void DeleteEntity_DeleteStudentFromDb_ShouldNotBePresentInDb()
        {
            var student = new Student()
            {
                LastName = "student",
                Grade = 10,
            };
            this.StudentsContext.Students.Add(student);
            this.StudentsContext.SaveChanges();

            var id = student.Id;

            this.repository.Delete(student);
            this.repository.SaveChanges();

            var deleteStudent = this.StudentsContext.Students.Find(id);
            Assert.IsNull(deleteStudent);
        }

        [TestMethod]
        public void All_GetAllStundetsIncluingMarks_ShouldNotCauseNPlusOne()
        {
            for (int i = 0; i < 10; i++)
            {
                var student = new Student()
                {
                    LastName = "TestStudent",
                    Grade = 5
                };
                for (int j = 0; j < 10; j++)
                {
                    var mark = new Mark()
                    {
                        Subject = "Subject" + i,
                        Value = i
                    };

                    student.Marks.Add(mark);
                }
                
                this.StudentsContext.Students.Add(student);
            }

            this.StudentsContext.SaveChanges();

            var allStundets = this.repository.All<Student>("Marks");

            foreach (var st in allStundets)
            {
                var m = st.Marks.ToList();
            }

            int allStundetsCount = allStundets.Count();

            Assert.IsTrue(allStundetsCount >= 10); 
        }
    }
}
