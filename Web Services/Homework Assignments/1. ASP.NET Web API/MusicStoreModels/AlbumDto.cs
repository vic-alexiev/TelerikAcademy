using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreModels
{
    public class AlbumDto
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public Nullable<int> AlbumYear { get; set; }
        public string Producer { get; set; }
        public IEnumerable<SongDto> Songs { get; set; }
    }
}
