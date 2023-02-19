using Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<AirLine> Airlines { get; set; }    
        public DbSet<Flight> Flights { get; set; }
    }
}
