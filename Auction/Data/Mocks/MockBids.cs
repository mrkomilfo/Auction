using Auction.Data.Interfaces;
using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Mocks
{
    public class MockBids : IBids
    {
        public IEnumerable<Bid> Bids
        {
            get
            {
                return new List<Bid>
                {
                    new Bid
                    {
                        id = 1,
                        time = new DateTime(2019, 9, 17, 15, 33, 0),
                        increase = 10,
                    },
                };
            }
        }

        public Bid getBid(int bidId)
        {
            throw new NotImplementedException();
        }
    }
}
