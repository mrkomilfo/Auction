using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Interfaces
{
    public interface ILots
    {
        IEnumerable<Lot> Lots { get; }
        IEnumerable<Lot> getPremLots { get; set; }
        Lot getLot(int lotId);
    }
}
