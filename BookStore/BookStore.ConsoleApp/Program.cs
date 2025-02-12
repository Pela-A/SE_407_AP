using BookStore.ConsoleApp.ConsoleUtils;
using BookStore.Models;

namespace BookStore.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {






            try
            {
                string consoleUtil, basicFunction, paramFilter;
                

                ValidateArguments(args, out consoleUtil, out basicFunction, out paramFilter);

                // If valid arguments we perform our basicFunction. We then perform our consoleUtil with the data from there.
                List<Book> books = new List<Book>();
                switch (basicFunction)
                {
                    case "GetAllBooks":
                        {
                            books = BasicFunctions.GetAllBooks();
                            break;
                        }
                    case "GetBookByTitle":
                        {
                            Book? book = BasicFunctions.GetBookByTitle(paramFilter);
                            if (book != null)
                            {
                                books = new List<Book> { book };
                            }
                            break;
                        }
                    case "GetBooksByLastName":
                        {
                            books = BasicFunctions.GetBooksByLastName(paramFilter);
                            break;
                        }
                    default:
                        {
                            books = BasicFunctions.GetAllBooks();
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

                if (books.Count > 0)
                {
                    consoleFunction.ConsoleFunction(books);
                }
                else
                {
                    Console.WriteLine("No books found");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Something went wrong: {ex.ToString()} ");
            }


        } // end main



        private static void ValidateArguments(string[] args, out string consoleUtil, out string basicFunction, out string paramFilter)
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

            string[] basicFunctionNoParams = {"GetAllBooks"};
            
            string[] basicFunctionOneParams = { "GetBookByTitle", "GetBooksByLastName" };

            bool isNoParam = basicFunctionNoParams.Contains(basicFunctionArg);
            bool isOneParam = basicFunctionOneParams.Contains(basicFunctionArg);

            if (isNoParam)
            {
                basicFunction = basicFunctionArg;
                paramFilter = "";
            }
            else if (isOneParam)
            {
                basicFunction = basicFunctionArg;
                paramFilter = args[2];
            }
            else
            {
                throw new ArgumentException("Second argument must be a valid function.");
            }

        } // end validate function
    
    } // end class

} // end name space
