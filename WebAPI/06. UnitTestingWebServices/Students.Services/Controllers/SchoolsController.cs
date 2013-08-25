using Students.Data;
using Students.Models;
using Students.Repositories;
using Students.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class SchoolsController : ApiController
    {
        private IRepository DataSource;

        public SchoolsController()
        {
            var context = new StudentsContext();
            this.DataSource = new EFRepository(context);
        }

        // GET api/schools
        public IEnumerable<SchoolDto> Get()
        {
            var schools = this.DataSource.All<School>().Select(SchoolDto.FromStudent);
            return schools;
        }

        // GET api/schools/5
        public SchoolDto Get(int id)
        {
            var school = this.DataSource.Find<School>(x => x.Id == id)
                .Select(SchoolDto.FromStudent)
                .FirstOrDefault();

            return school;
        }

        // POST api/schools
        public void Post([FromBody]SchoolDto value)
        {
            var newSchool = new School()
            {
                Location = value.Location,
                Name = value.Name
            };

            foreach (var st in value.Students)
	        {
                var newStudent = new Student()
                {
                    FirstName = st.FirstName,
                    LastName = st.LastName,
                    Grade = st.Grade,
                    Age = st.Age
                };
                newSchool.Students.Add(newStudent);
	        }

            this.DataSource.SaveChanges();
        }
    }
}
