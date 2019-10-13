using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class Bid
    {
        public int id { get; set; }

        public DateTime time { get; set; }

        public uint increase { get; set; }

        public int? lotid { get; set; }

        public Lot lot { get; set; }

        public int? userid { get; set; }

        public User user { get; set; }
    }
}
