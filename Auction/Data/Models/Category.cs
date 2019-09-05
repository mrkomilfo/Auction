using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<Lot> lots { get; set; }

        //public virtual User user {get; set;}
    }
}
