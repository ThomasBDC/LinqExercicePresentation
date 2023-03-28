using System;
using DataSources;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
//Vous avez déjà toutes les dépendances pour les exercices :)

namespace LinqExercicePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var allData = ListAlbumsData.ListAlbums;

            Console.WriteLine("En quoi voulez-vous transformer votre src de données ?");
            Console.WriteLine("1 - JSON");
            Console.WriteLine("2 - XML");
            Console.WriteLine("3 - TXT");

            string reponse = Console.ReadLine();

            switch(reponse) {
                case "1":
                    PrintJson(allData);
                    break;
                case "2":
                    PrintXml(allData);
                    break;
                case "3":
                    PrintTxt(allData);
                    break;
            }
        }

        static void PrintTxt(List<Album> allData)
        {
            var albumTxt = from alb in allData
                           select $"{alb.AlbumId} : {alb.Title}";
            string allAlbums = "";
            foreach(var album in albumTxt) {
                allAlbums += album + "\n";
            }
            Console.WriteLine(allAlbums);
            File.WriteAllText(@"albums.txt", allAlbums);
        }

        static void PrintXml(List<Album> allData)
        {
            var XML = new XElement("allAlbums", from alb in allData
                           select new XElement("Album", 
                                new XElement("AlbumId", alb.AlbumId),
                                new XElement("Title", alb.Title)
                                )
                           );
            File.WriteAllText(@"albums.xml", XML.ToString());
            Console.Write(XML.ToString());
        }

        static void PrintJson(List<Album> allData)
        {
            var Json = new JObject(new JProperty("allAlbums", 
                                    from alb in allData
                                    select new JObject(
                                            new JProperty("AlbumId", alb.AlbumId),
                                            new JProperty("Title", alb.Title)
                                        )
                           ));
            File.WriteAllText(@"albums.json", Json.ToString());
            Console.Write(Json.ToString()); 
        }
    }
}
