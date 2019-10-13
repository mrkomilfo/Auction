using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class LotDetailViewModel
    {
        public Lot lot { get; set; }

        public string timeLeft(DateTime end)
        {
            TimeSpan left = end - DateTime.Now;
            if (left.TotalDays > 0)
                return ("До завершения " + (int)left.TotalDays).ToString() + " дн.";
            else if (left.TotalHours > 0)
                return ("До завершения " + (int)left.TotalHours).ToString() + " ч.";
            else if (left.TotalMinutes > 0)
                return ("До завершения " + (int)left.TotalHours).ToString() + " мин.";
            else if (left.TotalSeconds > 0)
                return "До завершения меньше минуты";
            else
                return "Торги завершены";
        }
    }
}
