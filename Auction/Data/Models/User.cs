using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class User : IdentityUser
    {
        public DateTime Registration { get; set; }

        public List<Lot> Lots { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
