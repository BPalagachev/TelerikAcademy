using Students.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.DataTransferObjects
{
    [DataContract]
    public class StudentDto
    {
        static public Expression<Func<Student, StudentDto>> FromStudent
        {
            get
            {
                return student => new StudentDto()
                    {
                        Age = student.Age,
                        FirstName = student.FirstName ?? "Unknown",
                        Grade = student.Grade,
                        Id = student.Id,
                        LastName = student.LastName,
                        Marks = student.Marks.Select(x => new MarksByStudentDto()
                        {
                            Value = x.Value,
                            Subject = x.Subject
                        }),
                        School = new SchoolByStudentsDto()
                        {
                            Id = student.School.Id,
                            Location = student.School.Location,
                            Name = student.School.Name
                        }
                    };
            }
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public int Grade { get; set; }

        [DataMember]
        public SchoolByStudentsDto School { get; set; }

        [DataMember]
        public IEnumerable<MarksByStudentDto> Marks { get; set; }
    }
}