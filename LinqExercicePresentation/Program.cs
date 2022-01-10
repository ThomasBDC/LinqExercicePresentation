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
            Exercice2Where();
        }

        static void Exercice2Where()
        {

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
