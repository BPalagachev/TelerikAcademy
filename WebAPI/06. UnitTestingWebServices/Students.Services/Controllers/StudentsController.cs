using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Repositories;
using Students.Data;
using Students.Models;
using Students.Services.DataTransferObjects;
using System.Data.Entity;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository DataSource;

        public StudentsController(IRepository repository)
        {
            this.DataSource = repository;
        }

        public StudentsController()
        {
        }

        public IEnumerable<StudentDto> Get(string subject, int value)
        {
            var students = this.DataSource.All<Student>("Marks");
            var studentDtos = students
                .Where(x => x.Marks.Any(y => y.Value == value && y.Subject == subject))
                .Select(StudentDto.FromStudent).ToList();

            return studentDtos;
        }

        public IEnumerable<StudentDto> Get()
        {
            var a = this.DataSource.All<Student>();
            var allStudents = a.Select(StudentDto.FromStudent);
            return allStudents;
        }

        // GET api/students/5
        public StudentDto Get(int id)
        {
            var student = this.DataSource.Get<Student>(id);
            var studentDto = StudentDto.FromStudent.Compile()(student);
            return studentDto;
        }
        
        // POST api/students
        public void Post([FromBody]StudentDto value)
        {
            var newStudent = new Student()
            {
                Age = value.Age,
                FirstName = value.FirstName,
                Grade = value.Grade,
                LastName = value.LastName,
            };

            foreach (var mark in value.Marks)
            {
                var newMark = MarksByStudentDto.ToMark.Compile()(mark);
                newStudent.Marks.Add(newMark);
            }

            var school = RepositoryUtils.GetOrCreateItem<School>(
                x => x.Name == value.School.Name && x.Location  == value.School.Location,
                x => { x.Name = value.School.Name; x.Location  = value.School.Location;},
                this.DataSource);

            newStudent.School = school;

            this.DataSource.Add(newStudent);
            this.DataSource.SaveChanges();            
        }
    }

}
