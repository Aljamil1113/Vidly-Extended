using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace Vidly.Controllers.Api
{
    [Authorize]
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext context;

        public NewRentalsController()
        {
            context = new ApplicationDbContext();
        }

        
        public IHttpActionResult GetRentals()
        {
            var rentals = context.Rentals.Include(c => c.Customer).ToList();

            var rentalDto = new List<RentalDto>();

            foreach (var rental in rentals)
            {
                rentalDto.Add(new RentalDto
                {
                    Id = rental.Id,
                    Price = rental.Price,
                    DateRented = rental.DateRented,
                    Customer = rental.Customer
                
            });
            }
            return Ok(rentalDto);
        }


        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No Movies have been given.");

            var customer = context.Customers.Where(c => c.Id == newRentalDto.CustomerId).SingleOrDefault();

            if (customer == null)
                return BadRequest("Customer ID is not valid");

            if (customer.IsDelinquent)
                return BadRequest("Customer is not valid to rent. Please ask the staff about this...");

            var movies = context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or more movies are invalid");

            if (movies.Count > customer.RentLimit)
                return BadRequest("Your rent exceed the limit...");

            decimal disc = 0.00M;
            decimal movieTotal = 0.00M;

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                movie.NumberInStock--;

                movieTotal += movie.Amount;
            }

            disc = movieTotal - (movieTotal * (Convert.ToDecimal(customer.DiscountRate) / 100));

            var rental = new Rental
            {
                Customer = customer,
                DateRented = DateTime.Now,
                Price = disc,
            };
            context.Rentals.Add(rental);

           
            foreach (var movie in movies)
            {
                var rentalMovie = new RentalMovie()
                {
                    Movie = movie,
                    Rental = rental
                };
               
                context.RentalMovies.Add(rentalMovie);
                context.SaveChanges();

            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //catch (DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);
            //}

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public void Delete(int id)
        {
            var rentalInDb = context.Rentals.SingleOrDefault(r => r.Id == id);

            if(rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Rentals.Remove(rentalInDb); ;
            context.SaveChanges();
        }
    }
}
