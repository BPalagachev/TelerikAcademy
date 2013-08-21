using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeContentCatalog;
using System.Collections.Generic;
using System.Linq;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class CatalogTests
    {
        #region Test Add
        [TestMethod]
        public void TestAdd_AllItems()
        {
            Catalog catalog = new Catalog();
            catalog.Add(
                new Content(ContentType.Application,
                    new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" }));

            catalog.Add(
                new Content(ContentType.Book,
                    new string[] { "Book", "Writer", "6546151", "http://www.book.url" }));

            catalog.Add(
                new Content(ContentType.Movie,
                    new string[] { "Movie", "Director", "8435135", "http://www.movie.url" }));

            catalog.Add(
                new Content(ContentType.Music,
                    new string[] { "Song", "Singer", "6515313", "http://www.song.url" }));


            Assert.AreEqual(4, catalog.Count);
        }

        [TestMethod]
        public void TestAdd_DuplicateItem()
        {
            Catalog catalog = new Catalog();
            catalog.Add(
                new Content(ContentType.Application,
                    new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" }));

            catalog.Add(
                new Content(ContentType.Book,
                    new string[] { "Book", "Writer", "6546151", "http://www.book.url" }));

            catalog.Add(
                new Content(ContentType.Movie,
                    new string[] { "Movie", "Director", "8435135", "http://www.movie.url" }));

            catalog.Add(
                new Content(ContentType.Music,
                    new string[] { "Song", "Singer", "6515313", "http://www.song.url" }));

            catalog.Add(
               new Content(ContentType.Application,
                   new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" }));

            Assert.AreEqual(5, catalog.Count);
        }
        #endregion

        #region Test GetListContent
        [TestMethod]
        public void TestGetListContent_GetOneOfTwo()
        {
            Catalog catalog = new Catalog();

            Content expexedItem = new Content(ContentType.Application,
                    new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(expexedItem);

            catalog.Add(
                new Content(ContentType.Book,
                    new string[] { "Book", "Writer", "6546151", "http://www.book.url" }));

            catalog.Add(
                new Content(ContentType.Movie,
                    new string[] { "Movie", "Director", "8435135", "http://www.movie.url" }));

            catalog.Add(
                new Content(ContentType.Music,
                    new string[] { "Song", "Singer", "6515313", "http://www.song.url" }));

            catalog.Add(
               new Content(ContentType.Application,
                   new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" }));

            var searchResult = catalog.GetListContent("Firefox v.11.0", 1);

            Assert.AreEqual(1, searchResult.Count());
            Assert.AreSame(expexedItem, searchResult.First());
        }

        [TestMethod]
        public void TestGetListContent_GetFiveOfTwo()
        {
            Catalog catalog = new Catalog();

            Content firstElement = new Content(ContentType.Application,
                    new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(firstElement);

            catalog.Add(
                new Content(ContentType.Book,
                    new string[] { "Book", "Writer", "6546151", "http://www.book.url" }));

            catalog.Add(
                new Content(ContentType.Movie,
                    new string[] { "Movie", "Director", "8435135", "http://www.movie.url" }));

            catalog.Add(
                new Content(ContentType.Music,
                    new string[] { "Song", "Singer", "6515313", "http://www.song.url" }));

            Content secondElement = new Content(ContentType.Application,
                   new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(secondElement);

            var searchResult = catalog.GetListContent("Firefox v.11.0", 5);

            Assert.AreEqual(2, searchResult.Count());
            Assert.AreSame(firstElement, searchResult.First());
            Assert.AreSame(secondElement, searchResult.Skip(1).Take(1).First());
        }

        [TestMethod]
        public void TestGetListContent_NotFound()
        {
            Catalog catalog = new Catalog();

            Content firstElement = new Content(ContentType.Application,
                    new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(firstElement);

            catalog.Add(
                new Content(ContentType.Book,
                    new string[] { "Book", "Writer", "6546151", "http://www.book.url" }));

            catalog.Add(
                new Content(ContentType.Movie,
                    new string[] { "Movie", "Director", "8435135", "http://www.movie.url" }));

            catalog.Add(
                new Content(ContentType.Music,
                    new string[] { "Song", "Singer", "6515313", "http://www.song.url" }));

            Content secondElement = new Content(ContentType.Application,
                   new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(secondElement);

            var searchResult = catalog.GetListContent("Bira", 5);

            Assert.AreEqual(0, searchResult.Count());
        }
        #endregion

        #region Test UpdateContent
        [TestMethod]
        public void TestUpdateContent_updateTwoUrls()
        {
            Catalog catalog = new Catalog();

            Content firstElement = new Content(ContentType.Application,
                    new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(firstElement);

            catalog.Add(
                new Content(ContentType.Book,
                    new string[] { "Book", "Writer", "6546151", "http://www.book.url" }));

            catalog.Add(
                new Content(ContentType.Movie,
                    new string[] { "Movie", "Director", "8435135", "http://www.movie.url" }));

            catalog.Add(
                new Content(ContentType.Music,
                    new string[] { "Song", "Singer", "6515313", "http://www.song.url" }));

            Content secondElement = new Content(ContentType.Application,
                   new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(secondElement);

            var numberOfItemsUpdateOnce = catalog.UpdateContent("http://www.mozilla.org", "once-updated Mozilla");
            var numberOfItemUpdatedAgain = catalog.UpdateContent("http://www.mozilla.org", "updated again Mozilla");


            Assert.AreEqual(2, numberOfItemsUpdateOnce);
            Assert.AreEqual(0, numberOfItemUpdatedAgain);
        }

        [TestMethod]
        public void TestUpdateContent_updateNonExistingUrl()
        {
            Catalog catalog = new Catalog();

            Content firstElement = new Content(ContentType.Application,
                    new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(firstElement);

            catalog.Add(
                new Content(ContentType.Book,
                    new string[] { "Book", "Writer", "6546151", "http://www.book.url" }));

            catalog.Add(
                new Content(ContentType.Movie,
                    new string[] { "Movie", "Director", "8435135", "http://www.movie.url" }));

            catalog.Add(
                new Content(ContentType.Music,
                    new string[] { "Song", "Singer", "6515313", "http://www.song.url" }));

            Content secondElement = new Content(ContentType.Application,
                   new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            catalog.Add(secondElement);

            var itemsUpdated = catalog.UpdateContent("http://Not-found", "once-updated Mozilla");
          
            Assert.AreEqual(0, itemsUpdated);
        }
        #endregion
    }
}
