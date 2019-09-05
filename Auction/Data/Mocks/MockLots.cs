using Auction.Data.Interfaces;
using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Mocks
{
    public class MockLots : ILots
    {
        private readonly ICategories categoryLots = new MockCategories();

        public IEnumerable<Lot> Lots
        {
            get
            {
                return new List<Lot>
                {
                    new Lot
                    {
                        name = "Смартфон",
                        desc = "Xiaomi Redmi Note 7",
                        image = "",
                        price = 500,
                        premium = false,
                        exposing = new DateTime(2019, 9, 2, 23, 0, 0),
                        ending = new DateTime(2019, 10, 2, 23, 0, 0),
                        lastBid = new DateTime(2019, 9, 2, 23, 0, 0),
                        category = categoryLots.AllCategories.ElementAt(0)
                    },

                    new Lot
                    {
                        name = "Ноутбук",
                        desc = "ASUS ROG GL552V",
                        image = "",
                        price = 1000,
                        premium = true,
                        exposing = new DateTime(2019, 9, 3, 18, 0, 0),
                        ending = new DateTime(2019, 10, 3, 18, 0, 0),
                        lastBid = new DateTime(2019, 9, 3, 18, 0, 0),
                        category = categoryLots.AllCategories.ElementAt(0)
                    },

                    new Lot
                    {
                        name = "Volkswagen Passat B5",
                        desc = "2002 г.в./nПробег: 200000",
                        image = "",
                        price = 10000,
                        premium = false,
                        exposing = new DateTime(2019, 9, 3, 18, 10, 0),
                        ending = new DateTime(2019, 10, 3, 18, 10, 0),
                        lastBid = new DateTime(2019, 9, 3, 18, 10, 0),
                        category = categoryLots.AllCategories.ElementAt(1)
                    },

                    new Lot
                    {
                        name = "Opel Instignia",
                        desc = "2016 г.в./nПробег: 30000",
                        image = "",
                        price = 10000,
                        premium = true,
                        exposing = new DateTime(2019, 9, 3, 18, 20, 0),
                        ending = new DateTime(2019, 10, 3, 18, 20, 0),
                        lastBid = new DateTime(2019, 9, 3, 18, 20, 0),
                        category = categoryLots.AllCategories.ElementAt(1)
                    },
                };
            }
        }
        public IEnumerable<Lot> getPremLots { get; set; }
       

        public Lot getLot(int lotId)
        {
            throw new NotImplementedException();
        }
    }
}
