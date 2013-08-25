using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloggingSystem.Models
{
    public class Tag
    {
        private ICollection<Post> posts;

        public Tag()
        {
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [MinLength(3), MaxLength(50)]
        public string TagName { get; set; }

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
    }
}
