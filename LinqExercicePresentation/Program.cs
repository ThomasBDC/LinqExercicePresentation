using System;
using DataSources;
using System.Linq;

namespace LinqExercicePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Définir ma source de données
            var malist = ListAlbumsData.ListAlbums;
        }
    }
}
