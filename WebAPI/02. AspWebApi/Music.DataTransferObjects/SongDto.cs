using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Music.DataTransferObjects
{
    [DataContract(Name = "Song", Namespace = "")]
    public class SongDto
    {
        [XmlIgnore]
        static public Func<Song, SongDto> ArtistToArtistDtoExpression
        {
            get { return x => new SongDto(x); }
        }

        public SongDto()
        {
        }

        public SongDto(Song song)
        {
            this.Id = song.Id;
            this.Name = song.Name;
            this.Year = song.Year;
            this.Genre = song.Genre;

            if (song.Artists != null)
            {
                this.Artists = string.Join(", ", song.Artists.Select(x => x.Name).ToList());
            }
            if (song.Albums != null)
            {
                this.Albums = string.Join(", ", song.Albums.Select(x => x.Name).ToList());
            }
        }

        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? Year { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public string Artists { get; set; }

        [DataMember]
        public string Albums { get; set; }

        public static void UpdateOrCreateSongFromDto(Song song, MusicContext albumContext, SongDto songDto)
        {
            if (song == null)
            {
                song = new Song();
            }

            song.Name = songDto.Name ?? song.Name;
            song.Year = songDto.Year ?? song.Year;
            song.Genre = songDto.Genre ?? song.Genre;

            song.Artists.Clear();
            var newArtistsList = songDto.Artists
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());

            foreach (var artistName in newArtistsList)
            {
                var artist = MusicDal.GetOrCreateItem<Artist>(
                    x => x.Name == artistName,
                    x => x.Name = artistName,
                    albumContext);

                song.Artists.Add(artist);
                artist.Songs.Add(song);
            }

            song.Albums.Clear();
            var newAlbumsList = songDto.Albums
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());

            foreach (var albumName in newAlbumsList)
            {
                var album = MusicDal.GetOrCreateItem<Album>(
                    x => x.Name == albumName,
                    x => x.Name = albumName,
                    albumContext);

                song.Albums.Add(album);
                album.Songs.Add(song);
            }
        }
    }
}
