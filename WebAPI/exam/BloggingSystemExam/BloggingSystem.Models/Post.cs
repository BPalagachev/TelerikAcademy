using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingSystem.Models
{
    public class Post
    {
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;

        public Post()
        {
            this.PostDate = DateTime.Now;
            this.tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags;
            }
            set
            {
                this.tags = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
