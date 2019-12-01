using Auction.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System;
using static Auction.Data.Dict;

namespace Auction.Components
{
    public class ShortDesc : ViewComponent
    {
        public string Invoke(Lot lot, IViewLocalizer localizer)
        {
            return String.Format("{0}, {1}, {2} {3}., {4}, {5}, {6} {7}.",
            lot.Year,
            transmission[lot.Transmission],
            lot.EngineVolume.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")),
            localizer["liter"].Value,
            fuel[lot.Fuel],
            body[lot.Body],
            lot.Milleage,
            localizer["km"].Value);
        }
    }
}
