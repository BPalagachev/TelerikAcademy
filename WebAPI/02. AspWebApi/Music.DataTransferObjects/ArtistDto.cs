using Music.Data;
using Music.Models;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Music.DataTransferObjects
{
    [DataContract(Name = "Artist", Namespace = "")]
    public class ArtistDto
    {
        [XmlIgnore]
        static public Func<Artist, ArtistDto> ArtistToArtistDtoExpression
        {
            get { return x => new ArtistDto(x); }
        }

        public ArtistDto()
        {
        }

        public ArtistDto(Artist artist)
        {
            this.Id = artist.Id;
            this.Name = artist.Name;
            this.BirthDate = artist.BirthDate;
            this.Country = artist.Country;
            if (artist.Songs != null)
            {
                this.Songs = string.Join(", ", artist.Songs.Select(x => x.Name).ToList());
            }
            if (artist.Albums != null)
            {
                this.Albums = string.Join(", ", artist.Albums.Select(x => x.Name).ToList());
            }
        }

        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Songs { get; set; }

        [DataMember]
        public string Albums { get; set; }

        public static void UpdateOrCreateArtistFromDto(Artist artist, MusicContext albumContext, ArtistDto artistDto)
        {
            if (artist == null)
            {
                artist = new Artist();
            }

            artist.Name = artistDto.Name ?? artist.Name;
            artist.BirthDate = artistDto.BirthDate?? artist.BirthDate;
            artist.Country = artistDto.Country ?? artist.Country;

            artist.Songs.Clear();
            var newSongsList = artistDto.Songs
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());

            foreach (var songName in newSongsList)
            {
                var song = MusicDal.GetOrCreateItem<Song>(
                    x => x.Name == songName,
                    x => x.Name = songName,
                    albumContext);

                artist.Songs.Add(song);
                song.Artists.Add(artist);
            }

            artist.Albums .Clear();
            var newAlbumsList = artistDto.Albums
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());

            foreach (var albumName in newAlbumsList)
            {
                var album = MusicDal.GetOrCreateItem<Album>(
                    x => x.Name == albumName,
                    x => x.Name = albumName,
                    albumContext);

                artist.Albums.Add(album);
                album.Artist = artist;
            }
        }
    }
}