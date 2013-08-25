using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Models
{
    public class Artist
    {
        private ICollection<Song> songs;
        private ICollection<Album> albums;

        public Artist()
        {
            this.BirthDate = null;
            this.songs = new HashSet<Song>();
            this.albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual string Country { get; set; }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
