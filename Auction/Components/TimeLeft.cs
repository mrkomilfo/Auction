using Auction.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System;

namespace Auction.Components
{
    public class TimeLeft : ViewComponent
    {
        public string Invoke(Lot lot, IViewLocalizer localizer)
        {
            TimeSpan left = lot.Ending - DateTime.Now;
            if (left.TotalDays > 1)
                return $"{localizer["Left"].Value }: {((int)left.TotalDays).ToString()} {localizer["day"].Value}";
            else if (left.TotalHours > 1)
                return $"{localizer["Left"].Value }: {((int)left.TotalHours).ToString()} {localizer["hour"].Value}";
            else if (left.TotalMinutes > 1)
                return $"{localizer["Left"].Value }: {((int)left.TotalHours).ToString()} {localizer["minute"].Value}";
            else if (left.TotalSeconds > 1)
                return localizer["LessThanMinute"].Value;
            else
                return localizer["BiddingCompleted"].Value;
        }
    }
}
