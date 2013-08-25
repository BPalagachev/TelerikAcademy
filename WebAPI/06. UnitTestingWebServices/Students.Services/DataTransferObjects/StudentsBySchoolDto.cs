using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.DataTransferObjects
{
    [DataContract]
    public class StudentsBySchoolDto
    {
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
    }
}