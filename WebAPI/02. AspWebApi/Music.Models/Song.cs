using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Song
    {
        private ICollection<Artist> artists;
        private ICollection<Album> albums;

        public Song()
        {
            this.artists = new HashSet<Artist>();
            this.albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
