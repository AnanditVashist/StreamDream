using AutoMapper;
using StreamDream.Dtos;
using StreamDream.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace StreamDream.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //for /api/GetMovies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.Include(c => c.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }
        //for /api/GetMovies/id
        public MovieDto GetMovie(int id)
        {
            var movieIndb = _context.Movies.Single(m => m.Id == id);
            return Mapper.Map<Movie, MovieDto>(movieIndb);
        }
        //for post /api/getMovies
        [HttpPost]
        public IHttpActionResult GetMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [HttpPut]
        public void updateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }
    }
}
