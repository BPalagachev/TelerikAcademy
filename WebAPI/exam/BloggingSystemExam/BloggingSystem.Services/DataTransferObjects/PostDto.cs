using BloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace BloggingSystem.Services.DataTransferObjects
{
    [DataContract]
    public class PostDto
    {
        public static Expression<Func<Post, PostDto>> FromPost
        {
            get
            {
                return post =>
                   new PostDto()
                   {
                       Id = post.Id,
                       Title = post.Title,
                       PostedBy = post.User.NickName,
                       Text = post.Text,
                       PostDate = post.PostDate,
                       Tags = post.Tags.Select(tag=>tag.TagName), 
                       Comments = post.Comments.Select( com => new CommentsByPostsDto()
                       {
                            User = com.User.NickName,
                            Text = com.Text, 
                            CommentDate = com.CommentDate
                       })
                   };
            }
        }

        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name="postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name="postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name="text")]
        public string Text { get; set; }

        [DataMember(Name="tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name="comments")]
        public IEnumerable<CommentsByPostsDto> Comments { get; set; }
    }
}