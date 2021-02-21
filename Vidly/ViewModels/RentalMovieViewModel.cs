using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RentalMovieViewModel
    {
        public Rental Rental { get; set; }

        public IEnumerable<RentalMovie> RentalMovies { get; set; }

    }

}