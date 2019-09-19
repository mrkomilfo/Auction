using Auction.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.DB
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.User.Any())
                content.User.AddRange(Users.Select(u=>u.Value));

            if (!content.Lot.Any())
            {
                content.AddRange(
                    new Lot
                    {
                        name = "Jeep Grand Cherokee WK2 Laredo",
                        desc = "Авто в идеальном состоянии, пробег родной, крашенных элементов нет",
                        image = "/img/Jeep.jpg",
                        year = 2011,
                        transmission = 0,
                        engineVolume = 3.6,
                        fuel = 0,
                        body = 0,
                        drive = 2,
                        mileage = 69000,
                        price = 30000,
                        premium = true,
                        exposing = new DateTime(2019, 9, 2, 23, 0, 0),
                        ending = new DateTime(2019, 10, 2, 23, 0, 0),
                        user = Users["komilfo"]
                    },

                    new Lot
                    {
                        name = "Skoda Octavia II",
                        desc = "В отличном техническом состоянии",
                        image = "/img/Audi.jpg",
                        year = 2010,
                        transmission = 1,
                        engineVolume = 1.4,
                        fuel = 0,
                        body = 10,
                        drive = 1,
                        mileage = 163000,
                        price = 14000,
                        premium = false,
                        exposing = new DateTime(2019, 9, 2, 23, 0, 0),
                        ending = new DateTime(2019, 10, 2, 23, 0, 0),
                        user = Users["komilfo"]
                    },

                    new Lot
                    {
                        name = "SEAT Altea I",
                        desc = "В машине все работает, колеса 16, ТО до августа 2020г",
                        image = "/img/Seat.jpg",
                        year = 2013,
                        transmission = 1,
                        engineVolume = 1.4,
                        fuel = 0,
                        body = 6,
                        drive = 1,
                        mileage = 94000,
                        price = 22000,
                        premium = true,
                        exposing = new DateTime(2019, 9, 2, 23, 0, 0),
                        ending = new DateTime(2019, 10, 2, 23, 0, 0),
                        user = Users["komilfo"]
                    },

                    new Lot
                    {
                        name = "Opel Insignia I cosmo",
                        desc = "Автомобиль в отличном состоянии. Технически исправен.Масло от замены до замены. Экономичный.",
                        image = "/img/Opel.jpg",
                        year = 2011,
                        transmission = 0,
                        engineVolume = 2.0,
                        fuel = 1,
                        body = 9,
                        drive = 1,
                        mileage = 157000,
                        price = 22000,
                        premium = true,
                        exposing = new DateTime(2019, 9, 2, 23, 0, 0),
                        ending = new DateTime(2019, 10, 2, 23, 0, 0),
                        user = Users["komilfo"]
                    }
                );
            }          

            /* if(!content.Bids.Any())
            {
                content.AddRange(
                    new Bid
                    {
                        id = 1,
                        time = new DateTime(2019, 9, 17, 15, 33, 0),
                        increase = 10,
                        userId = 1,
                        lotId = 1,
                    }
                );
            }*/

            content.SaveChanges();
        }

        private static Dictionary<string, User> user;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (user == null)
                {
                    var list = new User[]
                    {
                        new User
                        {
                            name = "Валентин",
                            phoneNumber = "+375291234567",
                            login = "komilfo",
                            password = "1312",
                            registration = new DateTime(2019, 9, 3, 19, 0, 0),
                            admin = true
                        },
                    };

                    user = new Dictionary<string, User>();
                    foreach (User u in list)
                        user.Add(u.login, u);
                }
                return user;
            }

            
        }
    }
}
