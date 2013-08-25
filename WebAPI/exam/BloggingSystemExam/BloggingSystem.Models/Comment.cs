using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        public virtual User User { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
