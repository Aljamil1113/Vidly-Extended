using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Vidly.SqlViews
{
    public partial class VidlyViews : DbContext
    {
        public VidlyViews()
            : base("name=VidlyViews")
        {
        }

        public virtual DbSet<CustomerMembershipType> CustomerMembershipTypes { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<RentalCustomer> RentalCustomers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
