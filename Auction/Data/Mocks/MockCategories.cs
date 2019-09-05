using Auction.Data.Interfaces;
using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Mocks
{
    public class MockCategories : ICategories
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { name = "Электроника"},
                    new Category { name = "Транспортные средства" },
                    new Category { name = "Недвижимость" },
                    new Category { name = "Другое" }
                };
            }
        }
    }
}
