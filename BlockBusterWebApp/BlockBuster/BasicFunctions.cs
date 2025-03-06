using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster
{
    public static class BasicFunctions
    {
        // Constructors not allowed in static classes
        // All methods and members need to be static inside static classes

        // Get a single movie by id
        public static Movie? GetMovieById(int movieId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies.Find(movieId);
            }

        }

        public static Movie? GetMovieWithDetailsById(int movieId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Movies
                        .Include(movie => movie.Director)
                        .Include(movie => movie.Genre)
                        .FirstOrDefault(movie => movie.MovieId == movieId);
            }
        }

        // Get all movies
        public static List<Movie> GetAllMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies.ToList();
            }
        }

        public static List<Movie> GetAllMoviesWithDetails()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Movies
                        .Include(movie => movie.Director)
                        .Include(Movie => Movie.Genre)
                        .ToList();

            }
        }

        public static List<Movie> GetCheckedOutMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return

                    context
                        .Transactions
                        .Where(t => t.CheckedIn.Equals("N"))
                        .Join
                        (
                            context.Movies,
                            t => t.MovieId,
                            m => m.MovieId,
                            (t, m) => m
                        )
                        .ToList();
            }
        }

        // W3 Assignment

        // Get all Movies by Genre Description.
        public static List<Movie> GetMoviesByGenreDescription(string genreDesc)
        {

            using (var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Genres
                        .Where(g => g.GenreDescr.Equals(genreDesc.ToLower()))
                        .Join
                        (
                            context.Movies,
                            g => g.GenreId,
                            m => m.GenreId,
                            (g, m) => m
                        )
                        .ToList();
            }
        }

        // Get all Movies by Genre Description.
        public static List<Movie> GetMoviesByDirectorLastName(string lastName)
        {

            using (var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Directors
                        .Where(d => d.LastName.Equals(lastName.ToLower()))
                        .Join
                        (
                            context.Movies,
                            d => d.DirectorId,
                            m => m.DirectorId,
                            (d, m) => m
                        )
                        .ToList();
            }
        }



        #region Director Functions
        public static List<Director> GetAllDirectors()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Directors.ToList();
            }
        }

        public static Director? GetDirectorById(int directorId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Directors.FirstOrDefault(dir => dir.DirectorId == directorId);
            }
        }
        #endregion

        #region Genre Functions
        public static List<Genre> GetAllGenres()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Genres.ToList();
            }
        }
        public static Genre? GetGenreById(int genreId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Genres.FirstOrDefault(genre => genre.GenreId == genreId);
            }
        }
        #endregion

    }
}
