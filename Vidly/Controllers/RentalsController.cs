using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;
using System.Net;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    //[Authorize]
    public class RentalsController : Controller
    {
        // GET: Rentals

        private ApplicationDbContext context;

        public RentalMovieViewModel rentalMovieVM { get; set; }

        public RentalsController()
        {
            context = new ApplicationDbContext();
            rentalMovieVM = new RentalMovieViewModel()
            {
                Rental = new Rental(),
                RentalMovies = new List<RentalMovie>()
            };
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult Edit(int id)
        {
            var rental = context.Rentals.Where(r => r.Id == id).Include(c => c.Customer).SingleOrDefault();

            if (rental == null)
                return HttpNotFound();

            var rentalMovies = context.RentalMovies.Where(rm => rm.RentalId == id).Include(m => m.Movie)
               .Include(g => g.Movie.Genre).ToList();
           
           
            rentalMovieVM.Rental = rental;
            rentalMovieVM.RentalMovies = rentalMovies;

            return View(rentalMovieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult Save(int? id, RentalMovieViewModel rentalViews)
        {

            var rentalMovieDb = context.RentalMovies.Where(rm => rm.RentalId == rentalViews.Rental.Id).Include(m => m.Movie).ToList();

            if (rentalMovieDb == null)
                return HttpNotFound();

            var rentalMovie = new List<RentalMovie>();
    
            context.SaveChanges();
            
            
            return RedirectToAction("Index", "Rentals");
        }

        //To Update RentalMovie
        [HttpPost]
        public ActionResult UpdateRentalMovie(RentalMovie rentalMovie)
        {
            var rentalMovieDb = context.RentalMovies.Where(rm => rm.RentalId == rentalMovie.RentalId &&
            rm.MovieId == rentalMovie.MovieId).FirstOrDefault();

            if (rentalMovieDb == null)
                return HttpNotFound();

            rentalMovieDb.DateReturned = rentalMovie.DateReturned;

            if(rentalMovie.DateReturned != null)
            {
                var movie = context.Movies.Where(m => m.Id == rentalMovie.MovieId).FirstOrDefault();

                movie.NumberAvailable++;
                movie.NumberInStock++;
            }

            context.SaveChanges();

            return new EmptyResult();
        }
    }
}