using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SwiftPickup.Data
{
    public class SwiftPickupContext : DbContext
    {
        public SwiftPickupContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SwiftPickupContext, SwiftPickupMigrationsConfiguration>()
                );
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
        public DbSet<Driver> Drivers { get; set; }
    }
}