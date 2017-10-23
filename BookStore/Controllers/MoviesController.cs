using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookStore.Models;
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

            var movies = _context.movies.ToList<Movie>();

            return View(movies);
        }
        [Route("movies/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);

            return View(movie);
        }
    }
}