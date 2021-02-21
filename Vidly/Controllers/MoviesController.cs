using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Net;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext context;

        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Random()
        {
            var random = new Movie()
            {
                Name = "Shrek!"
            };

            var customers = new List<Customer>()
            {
                new Customer{ Name = "Customer 1" },
                new Customer{ Name = "Customer 2" },
                new Customer{ Name = "Customer 3" },
                new Customer{ Name = "Customer 4" },
                new Customer{ Name = "Customer 5" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = random,
                Customers = customers
            };

            return View(viewModel);

            //ViewData["Movie"] = random;
            //ViewBag.Movie = random;

            //return View();

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}

        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if(!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        public ActionResult Index()
        {
            //var movies = context.Movies.Include(g => g.Genre).ToList();
            //return View(movies);

            //if (User.IsInRole(RoleName.CanManageMovies) || User.IsInRole(RoleName.SuperAdmin))
            //{
            //    return View("List");
            //}
            //return View("ReadOnlyList");

            return View("List");
        }

        public ActionResult Details(int id)
        {
            var movie = context.Movies.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult New()
        {
            var genres = context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie()
                {
                    DateAdded = DateTime.Now,
                    ReleaseDate = DateTime.Now
                },
                Genres = genres
            };

            ViewBag.MoviePage = "New Movie";

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = new Movie(),
                    Genres = context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Amount = movie.Amount;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.NumberAvailable = movie.NumberAvailable;

                if(movie.NumberInStock != movie.NumberAvailable)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult Edit(int id)
        {
            var movie = context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = context.Genres.ToList()
            };

            ViewBag.MoviePage = "Edit Movie";

            return View("MovieForm", viewModel);
        }

    }
}