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
        [Required]
        public int GenreId { get; set; }
        [Range(1, 20, ErrorMessage = "The field number in stock should be between 1 to 20")]
        public int NumberInStock { get; set; }
    }
}