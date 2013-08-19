using MusicStoreModels;
using MusicStoreServices.Models;
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
    public class SongsController : ApiController
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public SongsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Songs
        public IEnumerable<SongDto> GetSongs()
        {
            var songs =
                from song in db.Songs.Include(s => s.Album).Include(s => s.Artist)
                select new SongDto
                {
                    SongId = song.SongId,
                    ArtistId = song.ArtistId,
                    AlbumId = song.AlbumId,
                    SongTitle = song.SongTitle,
                    SongYear = song.SongYear,
                    Genre = song.Genre
                };

            return songs.AsEnumerable();
        }

        // GET api/Songs/5
        public SongDto GetSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new SongDto
            {
                SongId = song.SongId,
                ArtistId = song.ArtistId,
                AlbumId = song.AlbumId,
                SongTitle = song.SongTitle,
                SongYear = song.SongYear,
                Genre = song.Genre
            };
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, SongDto song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var songToUpdate = db.Songs.FirstOrDefault(s => s.SongId == id);

            if (songToUpdate != null && song != null)
            {
                songToUpdate.UpdateWith(new Song
                {
                    SongTitle = song.SongTitle,
                    SongYear = song.SongYear,
                    Genre = song.Genre
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(songToUpdate).State = EntityState.Modified;

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
        public HttpResponseMessage PostSong(string artistName, string albumTitle, [FromBody]SongDto song)
        {
            if (string.IsNullOrWhiteSpace(artistName) ||
                string.IsNullOrWhiteSpace(albumTitle))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var artist = db.Artists.Include(a => a.Albums).SingleOrDefault(a => a.ArtistName == artistName);
            if (artist == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var album = artist.Albums.SingleOrDefault(a => a.AlbumTitle == albumTitle);
            if (album == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (album.Songs.Any(s => s.SongTitle == song.SongTitle))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (ModelState.IsValid)
            {
                var newSong = new Song
                {
                    SongTitle = song.SongTitle,
                    SongYear = song.SongYear,
                    Genre = song.Genre,
                    Artist = artist,
                    Album = album
                };

                db.Songs.Add(newSong);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, newSong);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newSong.SongId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteSong(int id)
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