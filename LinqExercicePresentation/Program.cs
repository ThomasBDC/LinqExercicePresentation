using System;
using DataSources;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace LinqExercicePresentation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Quel est votre recherche ?");
            string recherche = Console.ReadLine();

            #region XML
            //var newXMLFile = new XElement("Root",
            //    from album in ListAlbumsData.ListAlbums
            //    select new XElement("Album",
            //        new XElement("AlbumId", album.AlbumId),
            //        new XElement("Title", album.Title)
            //        )
            //    );

            //Console.WriteLine(newXMLFile);
            #endregion XML

            #region JSON

            //var myJsonFile = 
            //    new JObject(
            //        new JProperty("une propriété", 
            //            "Valeur propriété"),
            //        new JProperty("un tableau",
            //            new JArray(new JValue("val1"), new JValue("val2"), new JValue("val3"))),
            //        new JProperty("un objet", 
            //            new JObject(
            //                new JProperty("PropObject1", "Valeur propriété"),
            //                new JProperty("PropObject2", "Valeur propriété")))
            //    );

            //Console.WriteLine(myJsonFile);


            //var myJsonAlbums = JObject.Parse(File.ReadAllText(@$"{Directory.GetCurrentDirectory()}/Json/Albums.json"));

            //var searchResult = from album in myJsonAlbums["AllAlbums"]
            //                   where ((string)album["Title"]).Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
            //                   select album;

            //foreach (var album in searchResult)
            //{
            //    Console.WriteLine($"{album["AlbumId"]}:{album["Title"]}");
            //}

            #endregion JSON


            ////Définir ma source de données
            //var malist = ListAlbumsData.ListAlbums;
            //var listArtists = ListArtistsData.ListArtists;


            ////requête avec la syntaxe méthodes
            //var toShow = from album in malist
            //             where album.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)   
            //             join artist in listArtists on album.ArtistId equals artist.ArtistId
            //             select new { 
            //                artist = artist,
            //                album = album
            //             }
            //             into allInformations
            //             orderby allInformations.artist.Name, allInformations.album.Title
            //             group allInformations by allInformations.artist;


            //var requeteAvecJointure = from album in ListAlbumsData.ListAlbums
            //                          join artist in ListArtistsData.ListArtists on album.ArtistId equals artist.ArtistId
            //                          select new
            //                          {
            //                              artist = artist,
            //                              album = album
            //                          };


            ////requête avec la syntaxe méthodes
            //var requestMethod = malist.Where(alb => alb.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase))
            //                    .Join(listArtists, alb => alb.ArtistId, art => art.ArtistId, 
            //                    (alb, art)=> new {
            //                        artist = art,
            //                        album = alb
            //                    })
            //                    .GroupBy(item => item.artist).OrderBy(w => w.Key.Name);


            ////return true
            //var allRequest = ListAlbumsData.ListAlbums.All(alb => !string.IsNullOrWhiteSpace(alb.Title));

            ////return false
            //var anyRequest = ListAlbumsData.ListAlbums.Any(alb => !string.IsNullOrWhiteSpace(alb.Title));

            ////return true
            //var anyEmptyRequest = ListAlbumsData.ListAlbums.Any();

            //int[] tableauAvecDesEntiers = new int[] { 15, 5, 32, 2, 8 };

            //var plusQueSix = from nombre in tableauAvecDesEntiers
            //                 where nombre > 6
            //                 select nombre;

            ////Appel de la requête
            //foreach (var artiste in requestMethod)
            //{
            //    Console.WriteLine($"Artiste : {artiste.Key.Name} ({artiste.Key.ArtistId})");
            //    foreach (var album in artiste)
            //    {
            //        Console.WriteLine($"Album n°{album.album.AlbumId} : {album.album.Title}");
            //    }
            //    Console.WriteLine("");
            //}


            var allAlbumsText = from line in File.ReadAllLines(@$"{Directory.GetCurrentDirectory()}/Text/Albums.txt")
                                where line.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
                                select line;
            
            foreach (var line in allAlbumsText)
            {
                Console.WriteLine(line);
            }

            //var XMLFile = XElement.Load(@$"{Directory.GetCurrentDirectory()}/XML/Albums.xml");
            //var allAlbums = from element in XMLFile.Descendants("Album")
            //                where element.Element("Title").Value.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
            //                select element;

            //foreach (var album in allAlbums)
            //{
            //    Console.WriteLine(album.Value);
            //}
        }
    }
}
