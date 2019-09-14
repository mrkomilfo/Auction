using Auction.Data.Interfaces;
using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Mocks
{
    public class MockUsers : IUsers
    {
        public IEnumerable<User> Users
        {
            get
            {
                return new List<User>
                {
                    new User
                    {
                        name = "Валентин",
                        phoneNumber = "+375291234567",
                        city = "Брест",
                        image = "",
                        login = "komilfo",
                        password = "1312",
                        registration = new DateTime(2019, 9, 3, 19, 0, 0),
                        admin = true
                    },
                };
            }
        }

        public User getUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
