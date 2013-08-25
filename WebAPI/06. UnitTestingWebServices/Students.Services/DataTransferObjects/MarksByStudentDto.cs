using Students.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Students.Services.DataTransferObjects
{
    [DataContract]
    public class MarksByStudentDto
    {
        public static Expression<Func<MarksByStudentDto, Mark>> ToMark
        {
            get
            {
                return mark => new Mark()
                {
                    Subject = mark.Subject,
                    Value = mark.Value,
                };
            }
        }

        [Required]
        [DataMember(IsRequired = true)]
        public int Value { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string Subject { get; set; }
    }
}
