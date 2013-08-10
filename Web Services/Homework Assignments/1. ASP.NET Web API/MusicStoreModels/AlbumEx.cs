using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreModels
{
    public partial class Album
    {
        public void UpdateWith(Album album)
        {
            if (!string.IsNullOrWhiteSpace(album.AlbumTitle))
            {
                this.AlbumTitle = album.AlbumTitle;
            }

            if (album.AlbumYear.HasValue)
            {
                this.AlbumYear = album.AlbumYear;
            }

            if (!string.IsNullOrWhiteSpace(album.Producer))
            {
                this.Producer = album.Producer;
            }
        }
    }
}
