using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Column("MovieId")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd,yyyy}")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name= "Date Added")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime DateAdded { get; set; }

        [Range(1, 20, ErrorMessage = "It must be between 1 to 20")]
        [Display(Name = "Stocks")]
        public byte NumberInStock { get; set; }

        [Display(Name = "Available")]
        public byte NumberAvailable { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        public Genre Genre { get; set; }


        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public virtual ICollection<RentalMovie> RentalMovies { get; set; }

    }
}