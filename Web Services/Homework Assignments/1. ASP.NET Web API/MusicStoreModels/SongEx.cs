using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreModels
{
    public partial class Song
    {
        public void UpdateWith(Song song)
        {
            if (!string.IsNullOrWhiteSpace(song.SongTitle))
            {
                this.SongTitle = song.SongTitle;
            }

            if (song.SongYear.HasValue)
            {
                this.SongYear = song.SongYear;
            }

            if (!string.IsNullOrWhiteSpace(song.Genre))
            {
                this.Genre = song.Genre;
            }
        }
    }
}
