using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Students.Services.DataTransferObjects
{
    [DataContract]
    public class SchoolByStudentsDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Location { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
    }
}
