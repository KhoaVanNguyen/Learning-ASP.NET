using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookStore.Models;
using BookStore.ViewModels;
namespace BookStore.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movie
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {

            var movies = _context.movies.Include(m => m.Genre).ToList<Movie>();

            return View(movies);
        }

        public ActionResult New()
        {
            var movieViewModel = new MovieFormViewModel
            {
                Genres = _context.genres.ToList()
            };
            return View("MovieForm",movieViewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.movies.Add(movie);
            } else
            {
                var movieInDb = _context.movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        [Route("movies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);

            var movieViewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.genres.ToList()
            };
            return View("MovieForm", movieViewModel);
        }



    }
}