using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleApp.ConsoleUtils
{
    public class ConsoleWrite : IConsoleUtils
    {
        public void ConsoleFunction(IEnumerable<Book> books)
        {
            Console.WriteLine("List of Books:");

            foreach (Book book in books)
            {
                Console.WriteLine($"Book Title: {book.BookTitle},  Genre: {book.Genre?.GenreType ?? "N/A"},  Release Year: {book.YearOfRelease}");
            }
        }
    }
}
