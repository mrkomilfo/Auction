using Auction.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {
            Database.EnsureCreated();
        }

        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}