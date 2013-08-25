using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.DataTransferObjects
{
    [DataContract]
    public class SchoolDto
    {
        static public Expression<Func<School, SchoolDto>> FromStudent
        {
            get
            {
                return x => new SchoolDto()
                {
                    Id = x.Id,
                    Location = x.Location,
                    Name = x.Location,
                    Students = x.Students.Select(y => new StudentsBySchoolDto()
                    {
                        Age = y.Age,
                        FirstName = y.FirstName,
                        Grade = y.Grade,
                        Id = y.Id,
                        LastName = y.LastName
                    })
                };
            }
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public IEnumerable<StudentsBySchoolDto> Students { get; set; }
    }
}