using System;
using System.Collections.Generic;

namespace MusicStoreServices.Models
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Country { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public IEnumerable<SongDto> Songs { get; set; }
    }
}
