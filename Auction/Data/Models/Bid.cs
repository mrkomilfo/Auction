using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public uint NewPrice { get; set; }

        public Lot Lot { get; set; }

        public User User { get; set; }
    }
}
