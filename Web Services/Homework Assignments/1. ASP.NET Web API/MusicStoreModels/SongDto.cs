using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreModels
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
