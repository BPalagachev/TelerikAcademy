using System;

namespace BloggingSystem.Services.DataTransferObjects
{
    public class CommentsByPostsDto
    {
        public string Text { get; set; }

        public string User { get; set; }

        public DateTime CommentDate { get; set; }
    }
}