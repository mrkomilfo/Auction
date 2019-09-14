using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class User
    {
        public int id { get; set; }

        public string name { get; set; }

        public string phoneNumber { get; set; }

        public string city { get; set; }

        public string image { get; set; }

        public DateTime registration { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public bool admin { get; set; }

        public List<Lot> lots { get; set; }
    }
}
