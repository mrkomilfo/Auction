using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Interfaces
{
    public interface ILots
    {
        //IEnumerable<Lot> Lots { get; }
        IEnumerable<Lot> ActualLots { get; }
        IEnumerable<Lot> EndedLots { get; }
        Lot getLot(int lotId);
    }
}
