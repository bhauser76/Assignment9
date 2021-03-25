using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment9.Models;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesDbContext _context;
        public HomeController(ILogger<HomeController> logger, MoviesDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //displays the home page view
        public IActionResult Index()
        {
            return View();
        }

        //displays the poscasts page view
        public IActionResult Podcasts()
        {
            return View();
        }

        //displats the Movielist View
        [HttpGet]
        public IActionResult ViewMovies(Movie movie)
        {
            return View(_context.Movies);
        }

        //displays the addmovie view
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        //This will run when the user hits the submit button to enter a movie
        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(newMovie);
                _context.SaveChanges();
                return RedirectToAction("ViewMovies");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult ViewMovies(Movie movie, string test)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
