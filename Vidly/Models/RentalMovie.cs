using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class RentalMovie
    {
        [Key, Column(Order = 0)]
        public int RentalId { get; set; }
        public Rental Rental { get; set; }


        [Key, Column(Order = 1)]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }


        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }
    }
}