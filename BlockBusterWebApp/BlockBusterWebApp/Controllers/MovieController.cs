using BlockBuster.Models;
using BlockBuster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlockBusterWebApp.Helpers;

namespace BlockBusterWebApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.DirectorId = DropDownFormatter.FormatDirectors();
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movieToCreate)
        {
            try
            {
                BlockBusterAdminFunctions.AddMovie(movieToCreate);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.DirectorId = DropDownFormatter.FormatDirectors();
            return View(movie);
        }


        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movieToEdit)
        {
            try
            {
                BlockBusterAdminFunctions.EditMovie(movieToEdit);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }


        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
            try
            {
                BlockBusterAdminFunctions.DeleteMovie(movie.MovieId);
                return RedirectToAction("Movies", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
