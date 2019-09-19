using Auction.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> option) : base(option)
        {

        }

        public DbSet<Lot> Lot { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Bid> Bid { get; set; }
    }
}