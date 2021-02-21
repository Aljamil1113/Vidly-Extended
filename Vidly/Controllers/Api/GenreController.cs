using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class GenreController : ApiController
    {
        private ApplicationDbContext context;

        public GenreController()
        {
            context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMembershiTypes()
        {
            var genres = context.Genres.ToList();

            return Ok(genres);
        }

        public IHttpActionResult GetMembershipType(int id)
        {
            var genre = context.Genres.Where(m => m.Id == id).FirstOrDefault();

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }
    }
}
