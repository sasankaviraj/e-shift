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
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
