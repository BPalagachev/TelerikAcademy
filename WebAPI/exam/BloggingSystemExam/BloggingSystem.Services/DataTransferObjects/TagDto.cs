using BloggingSystem.Models;
using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace BloggingSystem.Services.DataTransferObjects
{
    [DataContract]
    public class TagDto
    {
        public static Expression<Func<Tag, TagDto>> FromTag
        {
            get
            {
                return tag =>
                   new TagDto()
                   {
                       Id = tag.Id,
                       Name = tag.TagName,
                       NumberOfPosts = tag.Posts.Count
                   };
            }
        }

        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="posts")]
        public int NumberOfPosts { get; set; }
    }
}