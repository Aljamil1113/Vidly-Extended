using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Stocks")]
        public int NumberInStock { get; set; }

        [Display(Name = "Available")]
        public byte NumberAvailable { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }

    }
}