using BookStore.Models;
using BookStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWepApp.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            var genres = AdvancedRepositoryFunctions.GetAll<Genre>();
            return View(genres);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }



        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            try
            {
                AdvancedRepositoryFunctions.Create<Genre>(genre);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }


        // (Navigates to Edit Page)
        public ActionResult EditGenre(int id)
        {
            var genre = AdvancedRepositoryFunctions.GetById<Genre>(id);
            return View(genre);
        }



        // (Updates the Genre)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGenre(int id, IFormCollection collection)
        {
            try
            {
            

                var propsToUpdate = new List<(string propName, object? propValue)>
                {
                    (nameof(Genre.GenreType), (string)collection[nameof(Genre.GenreType)])
                    
                };


                AdvancedRepositoryFunctions
                    .Update<Genre>
                    (
                        id,
                        propsToUpdate
                    );

                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }


        // GET: 
        public ActionResult Delete(int id)
        {
            var genre = AdvancedRepositoryFunctions.GetById<Genre>( id );
            return View(genre);
        }


        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                AdvancedRepositoryFunctions.Delete<Genre>(id);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }
    }
}
