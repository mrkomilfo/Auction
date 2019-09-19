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
        private readonly AppDBContent appDBContent;

        public LotsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Lot> Lots => appDBContent.Lot;

        //public IEnumerable<Lot> premLots => appDBContent.Lot.Where(l => l.premium);

        public Lot getLot(int lotId) => appDBContent.Lot.FirstOrDefault(l => l.id == lotId);
    }
}
