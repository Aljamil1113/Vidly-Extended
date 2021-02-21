using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize]
    // GET: Customers
    public class CustomersController : Controller
    {
        
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult Index()
        {

            //var customers = context.Customers.Include(m => m.MembershipType).ToList();

            //return View(customers);
            return View();
        }

        public ActionResult Details(int? id)
        {
            var customer = context.Customers.SingleOrDefault(i => i.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
                
            return View(customer);
        }


        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult New()
        {
            var membershipTypes = context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            ViewBag.CustomerPage = "New Customer";
            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };

            ViewBag.CustomerPage = "Update Customer";

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies + "," + RoleName.SuperAdmin)]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.RentLimit = customer.RentLimit;
                customerInDb.IsDelinquent = customer.IsDelinquent;
                customerInDb.DiscountRate = customer.DiscountRate;

            }
            
            context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}