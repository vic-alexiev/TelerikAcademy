using MusicStoreModels;
using MusicStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

internal class MusicStoreClient
{
    private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:12392/") };

    #region Print Methods

    private static void PrintSongs(int songId)
    {
        string requestUri = "api/Songs/";

        if (songId > 0)
        {
            requestUri += songId;
        }

        HttpResponseMessage response = Client.GetAsync(requestUri).Result; // Blocking call!
        if (response.IsSuccessStatusCode)
        {
            if (songId > 0)
            {
                var song = response.Content.ReadAsAsync<SongDto>().Result;

                Console.WriteLine(
                    "{0,4} {1,-25} {2}",
                    song.SongYear, song.SongTitle, song.Genre);
            }
            else
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SongDto>>().Result;
                foreach (var song in songs)
                {
                    Console.WriteLine(
                        "{0,4} {1,-25} {2}",
                        song.SongYear, song.SongTitle, song.Genre);
                }
            }
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }

    private static void PrintAlbums(int albumId)
    {
        string requestUri = "api/Albums/";

        if (albumId > 0)
        {
            requestUri += albumId;
        }

        HttpResponseMessage response = Client.GetAsync(requestUri).Result; // Blocking call!
        if (response.IsSuccessStatusCode)
        {
            if (albumId > 0)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;

                Console.WriteLine(
                    "{0,4} {1,-25} {2}",
                    album.AlbumYear, album.AlbumTitle, album.Producer);
            }
            else
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var album in albums)
                {
                    Console.WriteLine(
                        "{0,4} {1,-25} {2}",
                        album.AlbumYear, album.AlbumTitle, album.Producer);
                }
            }
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }

    private static void PrintArtists(int artistId)
    {
        string requestUri = "api/Artists/";

        if (artistId > 0)
        {
            requestUri += artistId;
        }

        HttpResponseMessage response = Client.GetAsync(requestUri).Result; // Blocking call!
        if (response.IsSuccessStatusCode)
        {
            if (artistId > 0)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                Console.WriteLine(
                    "{0,10} {1,-25} {2:MMMM d, yyyy}",
                    artist.Country, artist.ArtistName, artist.DateOfBirth);
            }
            else
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var artist in artists)
                {
                    Console.WriteLine(
                        "{0,10} {1,-25} {2:MMMM d, yyyy}",
                        artist.Country, artist.ArtistName, artist.DateOfBirth);
                }
            }
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }

    #endregion

    #region Add Methods

    private static void AddSong(string title, int? year, string genre, string artistName, string albumTitle)
    {
        // Create a new song
        var newSong = new Song
        {
            SongTitle = title,
            SongYear = year,
            Genre = genre
        };

        Uri newSongUri = null;

        HttpResponseMessage response = Client.PostAsXmlAsync(
            string.Format("api/Songs?artistName={0}&albumTitle={1}",
            artistName,
            albumTitle),
            newSong).Result;

        if (response.IsSuccessStatusCode)
        {
            newSongUri = response.Headers.Location;
            Console.WriteLine("SongId: " + newSongUri.Segments[3]);
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }

    private static void AddAlbum(string title, int? year, string producer, string artistName)
    {
        // Create a new album
        var newAlbum = new Album
        {
            AlbumTitle = title,
            AlbumYear = year,
            Producer = producer
        };

        Uri newAlbumUri = null;

        HttpResponseMessage response = Client.PostAsJsonAsync(
            string.Format("api/Albums?artistName={0}",
            artistName),
            newAlbum).Result;

        if (response.IsSuccessStatusCode)
        {
            newAlbumUri = response.Headers.Location;
            Console.WriteLine("AlbumId: " + newAlbumUri.Segments[3]);
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }

    private static void AddArtist(string name, string country, DateTime? dateOfBirth)
    {
        // Create a new artist
        var newArtist = new Artist
        {
            ArtistName = name,
            Country = country,
            DateOfBirth = dateOfBirth
        };

        Uri newArtistUri = null;

        HttpResponseMessage response = Client.PostAsJsonAsync("api/Artists", newArtist).Result;
        if (response.IsSuccessStatusCode)
        {
            newArtistUri = response.Headers.Location;
            Console.WriteLine("ArtistId: " + newArtistUri.Segments[3]);
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }

    #endregion

    #region Update Methods

    private static void UpdateSong(int id, string title, int? year, string genre)
    {
        var modelSong = new Song
        {
            SongTitle = title,
            SongYear = year,
            Genre = genre
        };

        HttpResponseMessage response = Client.PutAsXmlAsync(
            string.Format("api/Songs/{0}", id),
            modelSong).Result;

        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
    }

    private static void UpdateAlbum(int id, string title, int? year, string producer)
    {
        var modelAlbum = new Album
        {
            AlbumTitle = title,
            AlbumYear = year,
            Producer = producer
        };

        HttpResponseMessage response = Client.PutAsJsonAsync(
            string.Format("api/Albums/{0}", id),
            modelAlbum).Result;

        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
    }

    private static void UpdateArtist(int id, string name, string country, DateTime? dateOfBirth)
    {
        var modelArtist = new Artist
        {
            ArtistName = name,
            Country = country,
            DateOfBirth = dateOfBirth
        };

        HttpResponseMessage response = Client.PutAsJsonAsync(
            string.Format("api/Artists/{0}", id),
            modelArtist).Result;

        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
    }

    #endregion

    #region Delete Methods

    private static void DeleteSong(int id)
    {
        HttpResponseMessage response = Client.DeleteAsync(string.Format("api/Songs/{0}", id)).Result;
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
    }

    private static void DeleteAlbum(int id)
    {
        HttpResponseMessage response = Client.DeleteAsync(string.Format("api/Albums/{0}", id)).Result;
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
    }

    private static void DeleteArtist(int id)
    {
        HttpResponseMessage response = Client.DeleteAsync(string.Format("api/Artists/{0}", id)).Result;
        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
    }

    #endregion

    private static void Main()
    {
        // The database script is in the \Resources folder (MusicStore.sql).

        // Add an Accept header for JSON format.
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/xml"));

        PrintSongs(0);

        //PrintAlbums(0);

        //PrintArtists(1);

        //AddSong("Con te partirò", 1996, "Pop", "Andrea Bocelli", "Romanza");
        //AddSong("Vivere", 1996, "Pop", "Andrea Bocelli", "Romanza");
        //AddSong("Per Amore", 1996, "Pop", "Andrea Bocelli", "Romanza");

        //UpdateSong(15, "A Woman Loves a Man", 1987, "Pop");

        //AddAlbum("Romanza", 1996, "Polydor", "Andrea Bocelli");

        //UpdateAlbum(1, "Eros", 1997, "BMG");

        //AddArtist("Andrea Bocelli", "Italy", new DateTime(1958, 9, 22));

        //UpdateArtist(6, null, "Italy", null);

        //DeleteSong(16);

        //DeleteAlbum(6);

        //DeleteArtist(6);
    }
}
