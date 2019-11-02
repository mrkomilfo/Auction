using Auction.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.ViewModels
{
    public class LotDetailViewModel
    {
        public Lot Lot { get; set; }

        public int BidId { get; set; }

        [Required]
        [Remote(action: "CheckBid", controller: "Lots", AdditionalFields = nameof(BidId), ErrorMessage = "Ставка должна быть выше текущей")]
        public uint BidPrice { get; set; }
      
        public string TimeLeft(DateTime end)
        {
            TimeSpan left = end - DateTime.Now;
            if (left.TotalDays > 1)
                return ("До завершения " + (int)left.TotalDays).ToString() + " дн.";
            else if (left.TotalHours > 1)
                return ("До завершения " + (int)left.TotalHours).ToString() + " ч.";
            else if (left.TotalMinutes > 1)
                return ("До завершения " + (int)left.TotalHours).ToString() + " мин.";
            else if (left.TotalSeconds > 1)
                return "До завершения меньше минуты";
            else
                return "Торги завершены";
        }
    }
}
