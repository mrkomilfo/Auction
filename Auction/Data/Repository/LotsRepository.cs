using Auction.Data.Interfaces;
using Auction.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Auction.Data.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class LotsRepository : ILots
    {
        private readonly ApplicationContext appDBContent;

        public LotsRepository(ApplicationContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Lot> ActualLots => appDBContent.Lots.Include(l => l.User).Where(l=>l.IsActual());

        public IEnumerable<Lot> EndedLots => appDBContent.Lots.Include(l => l.User).Where(l => !l.IsActual());

        public Lot getLot(int lotId) => appDBContent.Lots.Include(l => l.User).Include(l => l.Bids).FirstOrDefault(l => l.Id == lotId);
    }
}
