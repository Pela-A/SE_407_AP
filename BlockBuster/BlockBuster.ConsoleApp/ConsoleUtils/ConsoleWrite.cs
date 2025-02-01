using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.ConsoleApp.ConsoleUtils
{
    public class ConsoleWrite : IConsoleUtils
    {
        public void ConsoleFunction(IEnumerable<Movie> movies)
        {
            Console.WriteLine("List of Movies:");

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"Movie Title: {movie.Title},  Genre: {movie.Genre?.GenreDescr ?? "N/A"},  Release Year: {movie.ReleaseYear}");
            }
        }
    }
}
