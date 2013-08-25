using System.Runtime.Serialization;

namespace BloggingSystem.Services.DataTransferObjects
{
    [DataContract]
    public class PostLeaveCommentDto
    {
        [DataMember(Name="text")]
        public string Text { get; set; }
    }
}