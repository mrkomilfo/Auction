using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class Lot
    {
        public int id { get; set; }

        public string name { get; set; }

        public string desc { get; set; }

        public ushort price { get; set; }

        public string image { get; set; }

        public DateTime exposing { get; set; }

        public DateTime lastBid { get; set; }

        public DateTime ending { get; set; }

        public bool premium { get; set; }

        public virtual Category category { get; set; }


    }
}
