using System;
using System.Collections.Generic;
using System.Text;

namespace DataSources
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        public Album(int albumId, string title, int artistId)
        {
            AlbumId = albumId;
            Title = title;
            ArtistId = artistId;
        }
    }
}
