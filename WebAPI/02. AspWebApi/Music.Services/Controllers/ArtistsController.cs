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
    public class ArtistsController : ApiController
    {
        private MusicContext db = new MusicContext();

        // GET api/Artists
        public HttpResponseMessage GetArtists()
        {
           var artists = db.Artists
                .Include("Songs")
                .Include("Albums")
                .Select(ArtistDto.ArtistToArtistDtoExpression)
                .ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, artists);
        }

        // GET api/Artists/5
        public HttpResponseMessage GetArtist(int id)
        {
            Artist artist = db.Artists.Where(x => x.Id == id).FirstOrDefault();

            if (artist == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            var albumDto = new ArtistDto(artist);
            return this.Request.CreateResponse(HttpStatusCode.OK, albumDto);
        }

        // PUT api/Artists/5
        public HttpResponseMessage PutArtist(int id, ArtistDto artistDto)
        {
            var artistToEdit = db.Artists.Where(x => x.Id == id).FirstOrDefault();

            if (artistToEdit == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            ArtistDto.UpdateOrCreateArtistFromDto(artistToEdit, db, artistDto);

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

        // POST api/Artists
        public HttpResponseMessage PostArtist(ArtistDto artistDto)
        {
            ArtistDto.UpdateOrCreateArtistFromDto(null, db, artistDto);

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

        // DELETE api/Artists/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
