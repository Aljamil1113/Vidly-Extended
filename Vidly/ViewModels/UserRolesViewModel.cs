using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class UserRolesViewModel
    {
        public ApplicationUser ApplicationUsers { get; set; }
        public string RoleName { get; set; }
        public List<string> Roles { get; set; }
    }
}