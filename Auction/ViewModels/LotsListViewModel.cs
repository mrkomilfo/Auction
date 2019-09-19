using Auction.Data.Models;
using static Auction.Data.Dict;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class LotsListViewModel
    {
        public IEnumerable<Lot> allLots { get; set; }

        public string shortDesc(Lot lot)
        {
            return String.Format("{0}, {1}, {2} л., {3}, {4}, {5} км.", 
                lot.year, 
                transmission[lot.transmission], 
                lot.engineVolume.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), 
                fuel[lot.fuel], 
                body[lot.body], 
                lot.mileage);
        }

        public string timeLeft(DateTime end)
        {
            TimeSpan left = end - DateTime.Now;
            if (left.TotalDays > 0)
                return ((int)left.TotalDays).ToString() + " дней";
            else if (left.TotalHours > 0)
                return ((int)left.TotalHours).ToString() + " часов";
            else if (left.TotalMinutes > 0)
                return ((int)left.TotalHours).ToString() + " минут";
            else
                return "меньше минуты";
        }
    }
}
