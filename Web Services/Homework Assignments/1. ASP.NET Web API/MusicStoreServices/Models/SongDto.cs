using System;

namespace MusicStoreServices.Models
{
    public class SongDto
    {
        public int SongId { get; set; }
        public Nullable<int> ArtistId { get; set; }
        public Nullable<int> AlbumId { get; set; }
        public string SongTitle { get; set; }
        public Nullable<int> SongYear { get; set; }
        public string Genre { get; set; }
    }
}