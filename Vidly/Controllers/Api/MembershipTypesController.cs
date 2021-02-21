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
    public class MembershipTypesController : ApiController
    {
        private ApplicationDbContext context;

        public MembershipTypesController()
        {
            context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMembershiTypes()
        {
            var membershipTypes = context.MembershipTypes.ToList();

            return Ok(membershipTypes);
        }

        public IHttpActionResult GetMembershipType(int id)
        {
            var membershipType = context.MembershipTypes.Where(m => m.Id == id).FirstOrDefault();

            if (membershipType == null)
                return NotFound();

            return Ok(membershipType);
        }
    }
}
