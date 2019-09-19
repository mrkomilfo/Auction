using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class LotController : Controller
    {
        public ViewResult LotDetail()
        {
            LotDetailViewModel obj = new LotDetailViewModel();
            //obj.allLots = allLots.Lots;
            return View(obj);
        }
    }
}