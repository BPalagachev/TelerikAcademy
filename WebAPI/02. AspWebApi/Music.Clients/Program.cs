using Music.DataTransferObjects;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Music.Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            // Json Client
            Console.WriteLine("Json CLient");
            var testArtist = CrapGenerator.GenerateTestArtist("JSon Test 1");
            var firstTestAlbum = CrapGenerator.GenerateTestAlbum("JSon Test 1");
            var secondTestAlbum = CrapGenerator.GenerateTestAlbum("JSon Test 2");
            Song firstTestSong = CrapGenerator.GenerateTestSong("JSon Test 1");
            var secondTestSong = CrapGenerator.GenerateTestSong("JSon Test 2");

            testArtist.Albums.Add(firstTestAlbum);
            testArtist.Albums.Add(secondTestAlbum);
            testArtist.Songs.Add(firstTestSong);
            testArtist.Songs.Add(secondTestSong);

            // AlbumDto is a Data Transfer class that provides communication between the client ant the services
            var jsonClient = new JsonClient<ArtistDto>("http://localhost:31168/api/");
            jsonClient.Post("Artists", new ArtistDto(testArtist));

            var allArtists = jsonClient.Get("Artists");
            DisplayListOfArtists(allArtists);

            // Xml Client
            Console.WriteLine("Xml CLient");
            var testAlbum = CrapGenerator.GenerateTestAlbum("Xml Test 1");
            var xmlArtist = CrapGenerator.GenerateTestArtist("Xml Test 1");
            var xmlSong1 = CrapGenerator.GenerateTestSong("Xml Test 1");
            var xmlSong2 = CrapGenerator.GenerateTestSong("Xml Test 2");

            testAlbum.Artist = xmlArtist;
            testAlbum.Songs.Add(xmlSong1);
            testAlbum.Songs.Add(xmlSong2);

            var xmlClient = new XmlClient<AlbumDto>("http://localhost:31168/api/");
            xmlClient.Post("Albums", new AlbumDto(testAlbum));

            var allAlbums = xmlClient.Get("Albums");
            DisplayListOfAlbums(allAlbums);
        }

        public static void DisplayListOfArtists(IEnumerable<ArtistDto> allArtists)
        {
            foreach (var artist in allArtists)
            {
                Console.WriteLine("Artist Name: {0}", artist.Name);
                Console.WriteLine("Artist Country{0}", artist.Country);
                Console.WriteLine("Artist BirthDate {0}", artist.BirthDate);

                Console.WriteLine("Songs: {0}", artist.Songs);
                Console.WriteLine("Albums: {0}", artist.Albums);
            }
        }

        public static void DisplayListOfAlbums(IEnumerable<AlbumDto> allAlbums)
        {
            foreach (var album in allAlbums)
            {
                Console.WriteLine("Artist Name: {0}", album.Name);
                Console.WriteLine("Artist Producer{0}", album.Producer);
                Console.WriteLine("Artist BirtYearhDate {0}", album.Year);

                Console.WriteLine("Songs: {0}", album.Songs);
                Console.WriteLine("ArtistName: {0}", album.ArtistName);
            }
        }
    }
}