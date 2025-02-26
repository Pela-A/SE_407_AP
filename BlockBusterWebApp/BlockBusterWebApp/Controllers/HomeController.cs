using BlockBuster;
using BlockBusterWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlockBusterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string[] _myColors;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _myColors = ["red", "green", "blue"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colors()
        {
            string[] colors = { "Red", "Blue", "Yellow" };
            ViewBag.Colors = colors;
            return View();
        }

        public IActionResult Cities()
        {
            string[] cities = { "Tokyo", "New York", "Los Angeles", "Paris", "London" };
            ViewBag.Cities = cities;
            return View();
        }
        public IActionResult Hobbies()
        {
            string[] hobbies = { "Eating food", "Video Games", "Traveling", "Learning", "Puzzles" };
            ViewBag.Hobbies = hobbies;
            return View();
        }

        public IActionResult Movies()
        {
            var movies = BasicFunctions.GetAllMoviesWithDetails();
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
