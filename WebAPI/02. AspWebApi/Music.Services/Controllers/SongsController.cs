using Music.Data;
using Music.DataTransferObjects;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Music.Services.Controllers
{
    public class SongsController : ApiController
    {
        private MusicContext db = new MusicContext();

        // GET api/Songs
        public HttpResponseMessage GetSongs()
        {
            var artists = db.Songs
                .Include("Artists")
                .Include("Albums")
                .Select(SongDto.ArtistToArtistDtoExpression)
                .ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, artists);
        }

        // GET api/Songs/5
        public HttpResponseMessage GetSong(int id)
        {
            Song song = db.Songs.Where(x => x.Id == id).FirstOrDefault();

            if (song == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            var songDto = new SongDto(song);
            return this.Request.CreateResponse(HttpStatusCode.OK, songDto);
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, SongDto songDto)
        {
            var songToEdit = db.Songs.Where(x => x.Id == id).FirstOrDefault();

            if (songToEdit == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            SongDto.UpdateOrCreateSongFromDto(songToEdit, db, songDto);

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

        // POST api/Songs
        public HttpResponseMessage PostSong(SongDto songDto)
        {
            SongDto.UpdateOrCreateSongFromDto(null, db, songDto);

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

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Songs.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
