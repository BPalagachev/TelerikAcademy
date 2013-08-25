using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BloggingSystem.Services.DataTransferObjects
{
    [DataContract]
    public class PostCreateDto
    {
        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name="text")]
        public string Text { get; set; }

        [DataMember(Name="tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}