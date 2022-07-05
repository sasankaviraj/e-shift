using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift.Data
{
    public class AppDBContext: DbContext
    {
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PickupLocation> PickupLocations { get; set; }
        public DbSet<DeliveryLocation> DeliveryLocations { get; set; }
    }
}
