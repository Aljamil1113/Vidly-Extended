using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        
        public UserRolesViewModel userRolesViewModel = new UserRolesViewModel();
        public UsersController()
        {
            context = new ApplicationDbContext();
            userRolesViewModel = new UserRolesViewModel()
            {
                ApplicationUsers = new ApplicationUser(),
                RoleName = "",
                Roles = new List<string>()
            };
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        // GET: Users
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        [HttpGet]
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult Edit(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (id == null)
            {
                return HttpNotFound();
            }

            
            userRolesViewModel.ApplicationUsers = context.Users.Find(id);

            var roles = roleManager.Roles.ToList();

            List<string> listRoles = new List<string>();

            foreach(var item in roles)
            {
                listRoles.Add(item.Name);
            }

            if(userRolesViewModel.ApplicationUsers == null)
            {
                return HttpNotFound();
            }

            userRolesViewModel.RoleName = userManager.GetRoles(userRolesViewModel.ApplicationUsers.Id).Count != 0 ? userManager.GetRoles(userRolesViewModel.ApplicationUsers.Id)[0] : "";
            userRolesViewModel.Roles = listRoles;

            return View(userRolesViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SuperAdmin)]
        public ActionResult EditPost(string id, UserRolesViewModel applicationUser)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (id != applicationUser.ApplicationUsers.Id)
            {
                return HttpNotFound();
            }

            var roles = roleManager.Roles.ToList();
            var user = userManager.FindById(id);

            if(user == null)
            {
                return HttpNotFound();
            }

            if(ModelState.IsValid)
            {
                ApplicationUser userFromDb = context.Users.Where(u => u.Id == id).FirstOrDefault();
                userFromDb.UserName = applicationUser.ApplicationUsers.UserName;
                userFromDb.Email = applicationUser.ApplicationUsers.Email;
                userFromDb.DrivingLicense = applicationUser.ApplicationUsers.DrivingLicense;
                userFromDb.PhoneNumber = applicationUser.ApplicationUsers.PhoneNumber;

                foreach (var item in roles)
                {
                    
                    if(userManager.IsInRole(user.Id, item.Name))
                    {
                        userManager.RemoveFromRole(user.Id, item.Name);
                    }
                }
               

                userManager.AddToRole(user.Id, applicationUser.RoleName);
                userManager.Update(user);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}