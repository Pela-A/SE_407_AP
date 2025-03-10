using BookStore.Models;
using BookStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWepApp.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            var authors = AdvancedRepositoryFunctions.GetAll<Author>();
            return View(authors);
        }

        // GET: 
        public ActionResult Create()
        {
            
            return View();
        }



        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                AdvancedRepositoryFunctions.Create<Author>(author);
                return RedirectToAction("Index", "Author");
            }
            catch
            {
                return View();
            }
        }









        // (Navigates to Edit Page)
        public ActionResult EditAuthor(int id)
        {
            var author = AdvancedRepositoryFunctions.GetById<Author>(id);
            return View(author);
        }



        // (Updates the Author)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuthor(int id, IFormCollection collection)
        {
            try
            {
            

                var propsToUpdate = new List<(string propName, object? propValue)>
                {
                    (nameof(Author.AuthorFirst), (string)collection[nameof(Author.AuthorFirst)]),
                    (nameof(Author.AuthorLast), (string)(collection[nameof(Author.AuthorLast)]))
                };


                AdvancedRepositoryFunctions
                    .Update<Author>
                    (
                        id,
                        propsToUpdate
                    );

                return RedirectToAction("Index", "Author");
            }
            catch
            {
                return View();
            }
        }


        // GET: 
        public ActionResult Delete(int id)
        {
            var author = AdvancedRepositoryFunctions.GetById<Author>( id );
            return View(author);
        }


        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                AdvancedRepositoryFunctions.Delete<Author>(id);
                return RedirectToAction("Index", "Author");
            }
            catch
            {
                return View();
            }
        }
    }
}
