using System;
using DataSources;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
//Vous avez déjà toutes les dépendances pour les exercices :)

namespace LinqExercicePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercice5Join();
        }



        static void Exercice5Join()
        {
            //sources de données 
            var listAlbums = ListAlbumsData.ListAlbums;
            var listArtists = ListArtistsData.ListArtists;

            Console.WriteLine("Ecrire votre recherche ...");
            var recherche = Console.ReadLine();

            var maRequete =
                from album in listAlbums
                where album.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
                join artist in listArtists on album.ArtistId equals artist.ArtistId
                select new
                {
                    artist = artist,
                    album = album
                }
                into allInformations
                orderby allInformations.album.Title ascending, allInformations.artist.Name
                group allInformations by allInformations.artist;

            foreach (var artiste in maRequete)
            {
                Console.WriteLine($"Artiste n°{artiste.Key.ArtistId} : {artiste.Key.Name}");
                foreach (var objetArtisteAlbum in artiste)
                {
                    Console.WriteLine($"Album n°{objetArtisteAlbum.album.AlbumId} : {objetArtisteAlbum.album.Title}");
                }
                Console.WriteLine("");
            }
        }

        static void Exercice4GroupBy()
        {
            var malist = ListAlbumsData.ListAlbums;

            Console.WriteLine("Ecrire votre recherche ...");
            var recherche = Console.ReadLine();

            var request = from album in malist
                          where album.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
                          orderby album.Title ascending, album.AlbumId descending
                          group album by album.ArtistId;

            foreach (var artiste in request)
            {
                Console.WriteLine(artiste.Key);
                foreach (var alb in artiste)
                {
                    Console.WriteLine($"Album n°{alb.AlbumId} : {alb.Title}");
                }
                Console.WriteLine();
            }
        }

        static void Exercice3OrderMethod()
        {
            var maliste = ListAlbumsData.ListAlbums;

            Console.WriteLine("Ecrire votre recherche ...");
            var recherche = Console.ReadLine();

            var marequeteMethode =maliste
                    .Where(alb => alb.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase))
                    .OrderBy(alb => alb.Title)
                    .ThenByDescending(alb => alb.AlbumId)
                    .Select(alb => $"Album n°{alb.AlbumId} : {alb.Title}");

            foreach (var alb in marequeteMethode)
            {
                Console.WriteLine(alb);
            }
        }

        static void Exercice3OrderRequete()
        {
            var maliste = ListAlbumsData.ListAlbums;

            Console.WriteLine("Ecrire votre recherche ...");
            var recherche = Console.ReadLine();

            var rechercheQuery =
                from album in maliste
                where album.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
                orderby album.Title ascending, album.AlbumId descending 
                select $"Album n°{album.AlbumId} : {album.Title}"
                    into affichagealbum
                where affichagealbum.Length < 30
                select affichagealbum;

            foreach (var alb in rechercheQuery.DefaultIfEmpty("Pas de résultat"))
            {
                Console.WriteLine(alb);
            }
        }
        
        static void Exercice2Where()
        {
            var maliste = ListAlbumsData.ListAlbums;

            Console.WriteLine("Ecrire votre recherche ...");
            var recherche = Console.ReadLine();

            var rechercheQuery =
                from album in maliste
                where album.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
                select $"Album n°{album.AlbumId} : {album.Title}";

            foreach (var alb in rechercheQuery)
            {
                Console.WriteLine(alb);
            }
        }

        static void Exercice1Select()
        {

            //DataSource
            var maliste = ListAlbumsData.ListAlbums;

            //Definir notre requête
            //Syntaxe requête
            var AlbumsDefinitionQuery =
                from album in maliste
                select $"Album n°{album.AlbumId} : {album.Title}";

            //Syntaxe méthode
            var AlbumsDefinitionQueryMethod = maliste
                .Select(album => $"Album n°{album.AlbumId} : {album.Title}");

            //Executer
            foreach (var alb in AlbumsDefinitionQueryMethod)
            {
                Console.WriteLine(alb);
            }
        }
    }
}
