using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class Dict
    {
        public Dict(IStringLocalizer<Dict> localizer)
        {
            fuel = new List<string>() { localizer["petrol"], localizer["diesel"] , localizer["electro"]};
            transmission = new List<string>() { localizer["automatic"], localizer["manual"] };
            body = new List<string>() { localizer["SUV"], localizer["cabriolet"], localizer["coupe"], localizer["limousine"], localizer["liftback"], localizer["minibus"], localizer["minivan"], localizer["pickup"], localizer["roadstar"], localizer["sedan"], localizer["stationWagon"], localizer["hatchback"], localizer["other"] };
            drive = new List<string>() { localizer["rear"], localizer["frontWheel"], localizer["fourWheel"], };
        }

        //public static string[] fuel = { "бензин" , "дизель", "электро"};
        //public static string[] transmission = { "автомат", "механика" };
        //public static string[] body = { "внедорожник", "кабриолет", "купе", "лимузин", "лифтбек", "микроавтобус", "минивэн", "пикап", "родстер", "седан", "универсал", "хэтчбэк", "другой" };
        //public static string[] drive = { "задний", "передний", "полный" };

        public static List<string> fuel;
        public static List<string> transmission;
        public static List<string> body;
        public static List<string> drive;
    }
}