using Music.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext()
            : base("MusicDb")
        {
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}
