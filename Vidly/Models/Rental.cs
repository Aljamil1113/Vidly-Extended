using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        [Column("RentalId")]
        public int Id { get; set; }

        [Display(Name = "Total Amount")]
        public decimal Price { get; set; }


        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        [Required]
        public Customer Customer { get; set; }


        public virtual ICollection<RentalMovie> RentalMovies { get; set; }

    }
}