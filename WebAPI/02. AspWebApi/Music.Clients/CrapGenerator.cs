using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Clients
{
    public static class CrapGenerator
    {
        public static Album GenerateTestAlbum(string identifier)
        {
            Album testAlbum = new Album()
            {
                Name = identifier + " Album Name",
                Producer = identifier + " Producer",
                Year = 2011
            };

            return testAlbum;
        }

        public static Artist GenerateTestArtist(string identifier)
        {
            var testArtist = new Artist()
            {
                BirthDate = DateTime.Now,
                Country = identifier + " Country",
                Name = identifier + " Artist Name",
            };

            return testArtist;
        }

        public static Song GenerateTestSong(string identifier)
        {
            var testSong = new Song()
            {
                Genre = identifier + " Song Genre",
                Name = identifier + " Song Name", 
                Year = 2011,
            };

            return testSong;
        }

    }
}
