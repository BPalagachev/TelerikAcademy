using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Models
{
    public class Album
    {
        private ICollection<Song> songs;

        public Album()
        {
            this.songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Year { get; set; }

        public string Producer { get; set; }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual Artist Artist { get; set; }

    }
}
