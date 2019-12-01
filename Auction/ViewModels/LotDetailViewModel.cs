using Auction.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Auction.ViewModels
{
    public class LotDetailViewModel
    {
        public Lot Lot { get; set; }

        public int BidId { get; set; }

        [Required(ErrorMessage = "BidRequired")]
        [Remote(action: "CheckBid", controller: "Lots", AdditionalFields = nameof(BidId), ErrorMessage = "WrongBid")]
        public uint BidPrice { get; set; }

        public User getLeader() => Lot.Bids.Last().User;  
    }
}
