using System;
using System.Collections.Generic;
using System.Text;

namespace DataSources
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }

        public Album(int albumId, string title)
        {
            AlbumId = albumId;
            Title = title;
        }
    }
}
