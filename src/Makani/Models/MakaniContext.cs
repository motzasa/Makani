using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Makani.Models
{
    public class MakaniContext : DbContext
    {
        public MakaniContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var MakaniconnectionString = Startup.Configuration["Data:MakaniConnection:ConnectionString"];

            optionsBuilder.UseSqlServer(MakaniconnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
