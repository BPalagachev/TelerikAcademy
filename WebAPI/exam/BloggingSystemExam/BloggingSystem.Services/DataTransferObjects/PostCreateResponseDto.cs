using System.Runtime.Serialization;

namespace BloggingSystem.Services.DataTransferObjects
{
    [DataContract]
    public class PostCreateResponseDto
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="title")]
        public string Title { get; set; }
    }
}