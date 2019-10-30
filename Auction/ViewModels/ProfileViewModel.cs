using Auction.Data.Models;
using System;

namespace Auction.ViewModels
{
    public class ProfileViewModel
    {
        public User User { get; set; }
        public bool IsMy { get; set; }
    }
}
