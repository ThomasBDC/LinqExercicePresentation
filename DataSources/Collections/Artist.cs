using System;
using System.Collections.Generic;
using System.Text;

namespace DataSources
{
    public class Artist
    {
        public Artist(int artistId, string name)
        {
            ArtistId = artistId;
            Name = name;
        }
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public List<Album> TousSesAlbums { get; set; }
    }
}
