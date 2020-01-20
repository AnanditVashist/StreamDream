using System;
using System.ComponentModel.DataAnnotations;

namespace StreamDream.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public DateTime ReleasedOn { get; set; }

        public Genre Genre { get; set; }
    }
}