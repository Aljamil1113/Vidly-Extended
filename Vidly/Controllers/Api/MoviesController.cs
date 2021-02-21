using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using System.Data.Entity;
using Vidly.Models;
using System.Web.Http.Cors;
using System.Web;
using Newtonsoft.Json;
using Vidly.SqlViews;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Vidly.Controllers.Api
{
    [Authorize]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext context;
        private VidlyViews viewContext;

        public MoviesController()
        {
            context = new ApplicationDbContext();
            viewContext = new VidlyViews();
        }

        public async Task<IHttpActionResult> GetMovies(string query = null)
        {
            var movies = await viewContext.MovieGenres.ToListAsync();

            if (!String.IsNullOrWhiteSpace(query))
            {
                var movieName = await context.Database.SqlQuery<MovieGenre>("exec spShowMoviesWithName {0}", query).ToListAsync();
                return Ok(movieName);
            }

            return Ok(movies);

        }

        public async Task<IHttpActionResult> GetMovie(int id)
        {
            var movie = await context.Movies.Where(m => m.Id == id).Include(g => g.Genre).SingleOrDefaultAsync(); ;

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public async Task<IHttpActionResult> CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            context.Movies.Add(movie);
            await context.SaveChangesAsync();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public async void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = context.Movies.Where(m => m.Id == id).SingleOrDefault();

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            try
            {
                Mapper.Map(movieDto, movieInDb);
            }
            catch(AutoMapperMappingException e)
            {
                Console.WriteLine(e);
            }       

            await context.SaveChangesAsync();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public async void DeleteMovie(int id)
        {
            var movieInDb = context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Movies.Remove(movieInDb);
            await context.SaveChangesAsync();
        }
    }
}
