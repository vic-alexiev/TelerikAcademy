using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreModels
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public IEnumerable<SongDto> Songs { get; set; }
    }
}
