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

        public ushort year { get; set; }

        public ushort transmission { get; set; }

        public double engineVolume { get; set; }

        public ushort fuel { get; set; }

        public ushort body { get; set; }

        public ushort drive { get; set; }

        public uint mileage { get; set; }

        public uint price { get; set; }

        public string image { get; set; }

        public DateTime exposing { get; set; }

        public DateTime ending { get; set; }

        public bool premium { get; set; }

        public User user { get; set; }

        public List<Bid> bids { get; set; }

        public bool isActual()
        {
            if (DateTime.Now < ending)
            {
                return true;
            }
            else
                return false;
        }
    }
}
