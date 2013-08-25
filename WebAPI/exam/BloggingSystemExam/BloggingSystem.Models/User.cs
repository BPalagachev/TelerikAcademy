using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloggingSystem.Models
{
    public class User
    {
       private ICollection<Post> posts;
       private ICollection<Comment> comments;

       public User()
       {
           this.posts = new HashSet<Post>();
           this.comments = new HashSet<Comment>();
       }

        public int Id { get; set; }

        [Required,MinLength(6), MaxLength(30)] // Unique key contraints are defined in the Initial Migration class
        public string UserName { get; set; }

        [Required, MinLength(6), MaxLength(30)]
        public string NickName { get; set; }

        [Required, StringLength(40)]
        public string AuthCode { get; set; }

        public string SessionKey { get; set; }
        
        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }
            set
            {
                this.posts = value;
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
