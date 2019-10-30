using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class Lot
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public ushort Year { get; set; }

        public ushort Transmission { get; set; }

        public double EngineVolume { get; set; }

        public ushort Fuel { get; set; }

        public ushort Body { get; set; }

        public ushort Drive { get; set; }

        public uint Milleage { get; set; }

        public uint Price { get; set; }

        public string Image { get; set; }

        public DateTime Exposing { get; set; }

        public DateTime Ending { get; set; }

        public User User { get; set; }

        public List<Bid> Bids { get; set; }

        public bool IsActual()
        {
            return DateTime.Now < Ending ? true : false;
        }
    }
}
