using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Vidly.SqlViews;

namespace Vidly.Controllers.Api
{
    [Authorize]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        public async Task<IHttpActionResult> GetCustomers(string query = null)
        {
            var customers = await context.Database.SqlQuery<CustomerMembershipType>("exec spShowCustomers").ToListAsync();

            if(!String.IsNullOrWhiteSpace(query))
            {
                var customerQuery = await context.Database.
                    SqlQuery<CustomerMembershipType>("exec spShowCustomersWithName {0}", query).ToListAsync();

                return Ok(customerQuery);
            }

            return Ok(customers);
        }

        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            var customer = await context.Customers.Where(c => c.Id == id).Include(m => m.MembershipType).SingleOrDefaultAsync();

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public async Task<IHttpActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1   
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public async void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = context.Customers.Where(c => c.Id == id).SingleOrDefault();

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            try
            {
                await context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public async void DeleteCustomer(int id)
        {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Customers.Remove(customerInDb);
            await context.SaveChangesAsync();

            await context.Customers.LoadAsync();
        }
    }
}
