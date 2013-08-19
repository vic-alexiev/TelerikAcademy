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
    public class AlbumsController : ApiController
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public AlbumsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Albums
        public IEnumerable<AlbumDto> GetAlbums()
        {
            var albums =
                from album in db.Albums.Include(a => a.Songs)
                select new AlbumDto
                {
                    AlbumId = album.AlbumId,
                    AlbumTitle = album.AlbumTitle,
                    AlbumYear = album.AlbumYear,
                    Producer = album.Producer,
                    Songs =
                    (from song in album.Songs
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

            return albums.AsEnumerable();
        }

        // GET api/Albums/5
        public AlbumDto GetAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new AlbumDto
            {
                AlbumId = album.AlbumId,
                AlbumTitle = album.AlbumTitle,
                AlbumYear = album.AlbumYear,
                Producer = album.Producer
            };
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, AlbumDto album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var albumToUpdate = db.Albums.FirstOrDefault(a => a.AlbumId == id);

            if (albumToUpdate != null && album != null)
            {
                albumToUpdate.UpdateWith(new Album
                {
                    AlbumTitle = album.AlbumTitle,
                    AlbumYear = album.AlbumYear,
                    Producer = album.Producer
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(albumToUpdate).State = EntityState.Modified;

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
        public HttpResponseMessage PostAlbum(string artistName, [FromBody]AlbumDto album)
        {
            if (string.IsNullOrWhiteSpace(artistName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var artist = db.Artists.Include(a => a.Albums).SingleOrDefault(a => a.ArtistName == artistName);
            if (artist == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (artist.Albums.Any(a => a.AlbumTitle == album.AlbumTitle))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (ModelState.IsValid)
            {
                var newAlbum = new Album
                {
                    AlbumTitle = album.AlbumTitle,
                    AlbumYear = album.AlbumYear,
                    Producer = album.Producer
                };

                db.Albums.Add(newAlbum);
                artist.Albums.Add(newAlbum);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, newAlbum);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newAlbum.AlbumId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Include(a => a.Artists).Include(a => a.Songs).FirstOrDefault(a => a.AlbumId == id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            List<int> songIds = new List<int>();

            foreach (var song in album.Songs)
            {
                songIds.Add(song.SongId);
            }

            foreach (var songId in songIds)
            {
                db.Songs.Remove(db.Songs.Single(s => s.SongId == songId));
            }

            album.Artists.Clear();

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