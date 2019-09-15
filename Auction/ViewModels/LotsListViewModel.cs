using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class LotsListViewModel
    {
        public IEnumerable<Lot> allLots { get; set; }
    }
}
