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
        public static void Initial(ApplicationContext content)
        {
            /*if (!content.User.Any())
                content.User.AddRange(Users.Select(u=>u.Value));*/

            /*if (!content.Lots.Any())
            {
                User user = await userManager.FindByEmailAsync("admin@gmail.com");
                content.Lots.AddRange(
                    new Lot
                    {
                        name = "Jeep Grand Cherokee WK2 Laredo",
                        desc = "Авто в идеальном состоянии, пробег родной, крашенных элементов нет",
                        image = "/img/car_1.jpg",
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
                        image = "/img/car_2.jpg",
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
                        image = "/img/car_3.jpg",
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
                        image = "/img/car_4.jpg",
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

            content.SaveChanges();*/
        }

        /*private static Dictionary<string, User> user;
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
                            UserName = "Админ",
                            PhoneNumber = "+375291234567",
                            Email = "admin@auction.io",                           
                            //password = "1312",
                            Registration = new DateTime(2019, 9, 3, 19, 0, 0),
                            //admin = true
                        },
                    };

                    user = new Dictionary<string, User>();
                    foreach (User u in list)
                        user.Add(u.Email, u);
                }
                return user;
            }          
        }*/
    }
}
