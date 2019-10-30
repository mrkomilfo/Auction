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
        public IEnumerable<Lot> AllLots { get; set; }

        public string ShortDesc(Lot lot)
        {
            return String.Format("{0}, {1}, {2} л., {3}, {4}, {5} км.", 
                lot.Year, 
                transmission[lot.Transmission], 
                lot.EngineVolume.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), 
                fuel[lot.Fuel], 
                body[lot.Body], 
                lot.Milleage);
        }

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
