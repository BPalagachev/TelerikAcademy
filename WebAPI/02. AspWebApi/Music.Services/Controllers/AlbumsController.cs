using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Music.Models;
using Music.Data;
using Music.DataTransferObjects;

namespace Music.Services.Controllers
{
    public class AlbumsController : ApiController
    {
        private MusicContext db = new MusicContext();

        // GET api/Albums
        public HttpResponseMessage GetAlbums()
        {
            var albums = db.Albums
                .Include("Artist")
                .Include("Songs")
                .Select(AlbumDto.AlbumToAlbumDto)
                .ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, albums);
        }

        // GET api/Albums/5
        public HttpResponseMessage GetAlbum(int id)
        {
            Album album = db.Albums.Where(x => x.Id == id).FirstOrDefault();

            if (album == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            var albumDto = new AlbumDto(album);
            return this.Request.CreateResponse(HttpStatusCode.OK, albumDto);
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, AlbumDto albumDto)
        {
            var albumToEdit = db.Albums.Where(x => x.Id == id).FirstOrDefault();

            if (albumToEdit == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            AlbumDto.UpdateOrCreateAlbumFromDto(albumToEdit, db, albumDto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Albums
        public HttpResponseMessage PostAlbum(AlbumDto albumDto)
        {
            AlbumDto.UpdateOrCreateAlbumFromDto(null, db, albumDto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}