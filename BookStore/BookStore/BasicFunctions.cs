using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public static class BasicFunctions
    {
        public static List<Book> GetAllBooks()
        {
            using (var context = new Se407BookstoreContext())
            {
                return context.Books.ToList();
            }
        }

        public static Book? GetBookByTitle(string bookTitle)
        {

            using (var context = new Se407BookstoreContext())
            {
                return context.Books.FirstOrDefault(b => b.BookTitle == bookTitle);

            }
 
        }

        public static List<Book> GetBooksByLastName(string lastName)
        {
            using (var context = new Se407BookstoreContext())
            {
                return
                    context
                        .Authors
                        .Where(b => b.AuthorLast.Equals(lastName))
                        .Join
                        (
                            context.Books,
                            b => b.AuthorId,
                            m => m.AuthorId,
                            (t, m) => m
                        )
                        .ToList();
            }
        }


    }
}
