using Music.Data;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Music.DataTransferObjects
{
    [DataContract(Name = "Album", Namespace = "")]
    public class AlbumDto
    {
        [XmlIgnore]
        static public Func<Album, AlbumDto> AlbumToAlbumDto
        {
            get { return x => new AlbumDto(x); }
        }

        public AlbumDto()
        {
        }

        public AlbumDto(Album album)
        {
            this.Id = album.Id;
            this.Name = album.Name;
            this.Year = album.Year;
            this.Producer = album.Producer;
            if (album.Artist != null)
            {
                this.ArtistName = album.Artist.Name;
            }
            if (album.Songs != null)
            {
                this.Songs = string.Join(", ", album.Songs.Select(x => x.Name).ToList());

            }
        }

        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? Year { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public string Songs { get; set; }

        [DataMember]
        public string ArtistName { get; set; }

        public static void UpdateOrCreateAlbumFromDto(Album album, MusicContext albumContext, AlbumDto albumDto)
        {
            if (album == null)
            {
                album = new Album();
            }

            album.Name = albumDto.Name ?? album.Name;
            album.Year = albumDto.Year ?? album.Year;
            album.Producer = albumDto.Producer ?? album.Producer;

            var artist = MusicDal.GetOrCreateItem<Artist>(
                x => x.Name == albumDto.Name,
                x => x.Name = albumDto.Name,
                albumContext);

            album.Artist = artist;
            artist.Albums.Add(album);

            album.Songs.Clear();

            var newSongsList = albumDto.Songs
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>x.Trim());

            foreach (var songName in newSongsList)
            {
                var song = MusicDal.GetOrCreateItem<Song>(
                    x => x.Name == songName,
                    x => x.Name = songName,
                    albumContext);

                album.Songs.Add(song);
                song.Albums.Add(album);
            }
        }
    }

}