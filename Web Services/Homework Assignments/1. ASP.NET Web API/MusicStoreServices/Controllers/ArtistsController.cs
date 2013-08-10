using MusicStoreModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStoreServices.Controllers
{
    public class ArtistsController : ApiController
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public ArtistsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Artists
        public IEnumerable<ArtistDto> GetArtists()
        {
            var artists =
                from artist in db.Artists.Include(a => a.Songs)
                select new ArtistDto
                {
                    ArtistId = artist.ArtistId,
                    ArtistName = artist.ArtistName,
                    Country = artist.Country,
                    DateOfBirth = artist.DateOfBirth,
                    Songs =
                    (from song in artist.Songs
                     select new SongDto
                     {
                         SongId = song.SongId,
                         ArtistId = song.ArtistId,
                         AlbumId = song.AlbumId,
                         SongTitle = song.SongTitle,
                         SongYear = song.SongYear,
                         Genre = song.Genre
                     }).AsEnumerable()
                };

            return artists.AsEnumerable();
        }

        // GET api/Artists/5
        public Artist GetArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artist;
        }

        // PUT api/Artists/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var artistToUpdate = db.Artists.FirstOrDefault(a => a.ArtistId == id);

            if (artistToUpdate != null && artist != null)
            {
                artistToUpdate.UpdateWith(artist);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(artistToUpdate).State = EntityState.Modified;

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
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artists/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Include(a => a.Albums).Include(a => a.Songs).FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            List<int> songIds = new List<int>();

            foreach (var song in artist.Songs)
            {
                songIds.Add(song.SongId);
            }

            foreach (var songId in songIds)
            {
                db.Songs.Remove(db.Songs.Single(s => s.SongId == songId));
            }

            List<int> albumIds = new List<int>();

            foreach (var album in artist.Albums)
            {
                albumIds.Add(album.AlbumId);
            }

            foreach (var albumId in albumIds)
            {
                db.Albums.Remove(db.Albums.Single(a => a.AlbumId == albumId));
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