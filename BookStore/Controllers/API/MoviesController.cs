using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BookStore.Models;

namespace BookStore.Controllers.API
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET ALL MOVIES:
        [Route("")]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.movies.ToList().Select( Mapper.Map<Movie,MovieDto>));
        }
        // GET MOVIES BY ID 
        [Route("{id}")]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movie.DateAdded = DateTime.Today;
            _context.movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            var movie = _context.movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map<MovieDto, Movie>(movieDto, movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            _context.movies.Remove(movie);
            _context.SaveChanges();
            return Ok();

        }
    }
}
