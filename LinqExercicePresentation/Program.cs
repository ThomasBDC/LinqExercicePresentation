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
            Exercice3OrderMethod();
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
                select $"Album n°{album.AlbumId} : {album.Title}";

            foreach (var alb in rechercheQuery)
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
