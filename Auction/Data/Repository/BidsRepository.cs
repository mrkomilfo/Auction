using Auction.Data.Interfaces;
using Auction.Data.Models;
using Auction.Data.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class BidsRepository : IBids
    {
        private readonly ApplicationContext appDBContent;

        public BidsRepository(ApplicationContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Bid> Bids => appDBContent.Bids.Include(b=>b.User).Include(b=>b.Lot);

        //public IEnumerable<Bid> premBids => appDBContent.Bid.Where(l => l.premium);

        public Bid getBid(int lotId) => appDBContent.Bids.FirstOrDefault(l => l.Id == lotId);
    }
}
