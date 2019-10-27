using Auction.Data.Interfaces;
using Auction.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class LotsRepository : ILots
    {
        private readonly AppDBContext appDBContent;

        public LotsRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Lot> ActualLots => appDBContent.Lots.Include(l => l.user).Where(l=>l.isActual());

        public IEnumerable<Lot> EndedLots => appDBContent.Lots.Include(l => l.user).Where(l => !l.isActual());

        public Lot getLot(int lotId) => appDBContent.Lots.Include(l => l.user).Include(l => l.bids).FirstOrDefault(l => l.id == lotId);
    }
}
