using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UserApp.Models;

namespace UserApp
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
