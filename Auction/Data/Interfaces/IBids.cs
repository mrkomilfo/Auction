using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Interfaces
{
    interface IBids
    {
        IEnumerable<Bid> Bids { get; }
        Bid getBid(int bidId);
    }
}
