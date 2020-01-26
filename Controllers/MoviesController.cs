using StreamDream.Models;
using StreamDream.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StreamDream.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult New()
        {
            var viewModel = new MovieViewModel
            {
                Genre = _context.Genre,
                Movie = new Movie()
            };
            return View("MoviesForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).Single(m => m.Id == id);
            var viewModel = new MovieViewModel
            {
                Movie = movie,
                Genre = _context.Genre
            };
            return View("MoviesForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre
                };
                return View("MoviesForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleasedOn = movie.ReleasedOn;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}