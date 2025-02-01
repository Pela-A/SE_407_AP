using Azure;
using BlockBuster.ConsoleApp.ConsoleUtils;
using BlockBuster.Models;
using System;

namespace BlockBuster.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ConsoleUtils.ListMovies(BasicFunctions.GetAllMovies());
            //ConsoleUtils.ListObjects(BasicFunctions.GetAllMovies());
            //OldConsoleUtils.ListMovies(BasicFunctions.GetAllMovies());

            //return;

            try
            {
                string consoleUtil, basicFunction, paramFilter;
                int movieId;

                ValidateArguments(args, out consoleUtil, out basicFunction, out movieId, out paramFilter);

                // If valid arguments we perform our basicFunction. We then perform our consoleUtil with the data from there.
                List<Movie> movies = new List<Movie>();
                switch (basicFunction)
                {
                    case "GetAllMovies":
                        {
                            movies = BasicFunctions.GetAllMovies();
                            break;
                        }
                    case "GetCheckedOutMovies":
                        {
                            movies = BasicFunctions.GetCheckedOutMovies();
                            break;
                        }
                    case "GetMovieById":
                        {
                            Movie? movie = BasicFunctions.GetMovieById(movieId);
                            if (movie != null)
                            {
                                movies = new List<Movie> { movie };
                            }
                            break;
                        }
                    case "GetMoviesByGenreDescription":
                        {
                            movies = BasicFunctions.GetMoviesByGenreDescription(paramFilter);
                            break;
                        }
                    case "GetMoviesByDirectorLastName":
                        {
                            movies = BasicFunctions.GetMoviesByDirectorLastName(paramFilter);
                            break;
                        }
                    default:
                        {
                            movies = BasicFunctions.GetAllMovies();
                            break;
                        }
                }

                /*
                 * Determine our console function
                 * Too lazy to do something like this for BasicFunctions.
                 * Use the strategy design pattern to define family of algorithms that are interchangeable at run time. Thanks Dr.Saban
                 */

                IConsoleUtils consoleFunction;

                switch (consoleUtil)
                {
                    case "CSV":
                        {
                            consoleFunction = new ConsoleCSV();
                            break;
                        }
                    case "Console":
                        {
                            consoleFunction = new ConsoleWrite();
                            break;
                        }
                    default:
                        {
                            // If somehow validation didn't work
                            consoleFunction = new ConsoleCSV();
                            break;
                        }
                }

                // Use our console function with our list of movies

                if(movies.Count > 0)
                {
                    consoleFunction.ConsoleFunction(movies);
                }
                else
                {
                    Console.WriteLine("No movies found");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Something went wrong: {ex.ToString()} ");
            }
            
        }

        /*
         * 
         * 
         *  Console CSV
         *  
         *  GetAllMovies GetCheckedOutMovies
         * 
         *  GetMovieById (10)
         *  
         *  GetMoviesByGenreDescription (Drama) GetMoviesByDirectorLastName (Lucas)
         * 
         * 
         * 
         */




                // Command ling args to perform functions
                // arg[0] the output format (console util)
                // arg[1] the data we want (basic function we want)
                // arg[2] the filter for data we want (param)

        private static void ValidateArguments(string[] args, out string consoleUtil, out string basicFunction, out int movieId, out string paramFilter)
        {
            string[] consoleUtils = { "CSV", "Console" };
            string util = args[0];
            bool isConsoleUtil = consoleUtils.Contains(util);
            // If the first argument is invalid we want to immediately throw exception

            if (!isConsoleUtil)
            {
                throw new ArgumentException("First argument must be a valid console utility.");
            }
            else
            {
                consoleUtil = args[0];
            }

            // Now that we know the consoleUtil is valid we want to see whether the basicFunction is valid
            string basicFunctionArg = args[1];

            string[] basicFunctionNoParams = { "GetAllMovies", "GetCheckedOutMovies" };
            string[] basicFunctionById = { "GetMovieById" };
            string[] basicFunctionOneParams = { "GetMoviesByGenreDescription", "GetMoviesByDirectorLastName" };

            bool isNoParam = basicFunctionNoParams.Contains(basicFunctionArg);
            bool isIdParam = basicFunctionById.Contains(basicFunctionArg);
            bool isOneParam = basicFunctionOneParams.Contains(basicFunctionArg);
            if (isNoParam)
            {
                basicFunction = basicFunctionArg;
                paramFilter = "";
                movieId = -1;
            }
            else if (isOneParam)
            {
                basicFunction = basicFunctionArg;
                paramFilter = args[2];
                movieId = -1;
            }
            else if (isIdParam)
            {
                basicFunction = basicFunctionArg;

                if (!int.TryParse(args[2], out movieId))
                {
                    throw new ArgumentException("Third argument must be a valid integer");
                }
                paramFilter = "";
            }
            else
            {
                throw new ArgumentException("Second argument must be a valid function.");
            }

        }
    }
}
