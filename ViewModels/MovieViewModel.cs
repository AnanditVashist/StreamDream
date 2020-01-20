using StreamDream.Models;
using System.Collections.Generic;

namespace StreamDream.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}