using AutoMapper;
using StreamDream.Dtos;
using StreamDream.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StreamDream.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            var _context = new ApplicationDbContext();
        }
        //for /api/GetMovies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
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
            return Created(new Uri(Request.RequestUri))
        } 

    }
}
