

using BookStore.Models;
using BookStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace BookStoreWepApp.Controllers
{
    public class BookController : Controller
    {
        // GET: 
        public ActionResult Index()
        {
            return View();
        }



        // GET: 
        public ActionResult BookDetails(int id)
        {
            var book = BasicFunctions.GetBookWithDetailsById(id);
            return View(book);
        }



        // GET: 
        public ActionResult Create()
        {
            ViewBag.GenreId =
                new SelectList
                (
                    AdvancedRepositoryFunctions.GetAll<Genre>(),
                    "GenreId",
                    "GenreType"
            );
            ViewBag.AuthorId =
                   new SelectList
                    (
                        AdvancedRepositoryFunctions.GetAll<Author>(),
                        "AuthorId",
                        "FullName"
                    );

            return View();
        }



        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                AdvancedRepositoryFunctions.Create<Book>(book);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }








   
        // (Navigates to Edit Page)
        public ActionResult EditBook(int id)
        {
            var book = AdvancedRepositoryFunctions.GetById<Book>(id);

            ViewBag.GenreId =
                new SelectList
                (
                    AdvancedRepositoryFunctions.GetAll<Genre>(),
                    "GenreId",
                    "GenreType"
            );
            ViewBag.AuthorId =
                   new SelectList
                    (
                        AdvancedRepositoryFunctions.GetAll<Author>(),
                        "AuthorId",
                        "FullName"
                    );

            return View(book);
        }


 
        // (Updates the Book)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, IFormCollection collection)
        {
            try
            {
                var targetGenre =
                    AdvancedRepositoryFunctions
                        .GetById<Genre>
                        (
                            int.Parse(collection["GenreId"])
                        );

                var targetAuthor =
                    AdvancedRepositoryFunctions
                        .GetById<Author>
                        (
                            int.Parse(collection["AuthorId"])
                        );

                var propsToUpdate = new List<(string propName, object? propValue)>
                {
                    (nameof(Book.BookTitle), (string)collection[nameof(Book.BookTitle)]),
                    (nameof(Book.YearOfRelease), short.Parse(collection[nameof(Book.YearOfRelease)])),
                    (nameof(Book.Genre), targetGenre),
                    (nameof(Book.Author), targetAuthor)
                };


                AdvancedRepositoryFunctions
                    .Update<Book>
                    (
                        id,
                        propsToUpdate
                    );

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }


        // GET: 
        public ActionResult Delete(int id)
        {
            var book = BasicFunctions.GetBookWithDetailsById(id);
            return View(book);
        }


        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                AdvancedRepositoryFunctions.Delete<Book>(id);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
