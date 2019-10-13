using Auction.Data.Interfaces;
using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class UsersRepository : IUsers
    {
        private readonly AppDBContent appDBContent;

        public UsersRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<User> Users => appDBContent.User;

        public User getUser(int userId) => appDBContent.User.FirstOrDefault(u => u.id == userId);
    }
}
