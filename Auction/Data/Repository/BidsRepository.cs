using Auction.Data.Interfaces;
using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class BidsRepository : IBids
    {
        private readonly AppDBContent appDBContent;

        public BidsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Bid> Bids => appDBContent.Bid;

        //public IEnumerable<Bid> premBids => appDBContent.Bid.Where(l => l.premium);

        public Bid getBid(int lotId) => appDBContent.Bid.FirstOrDefault(l => l.id == lotId);
    }
}
