using Auction.Data.Interfaces;
using Auction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Controllers
{
    public class LotsController : Controller
    {
        private readonly ILots allLots;

        public LotsController(ILots iLots)
        {
            allLots = iLots;
        }

        public ViewResult LotsList()
        {
            LotsListViewModel obj = new LotsListViewModel();
            obj.allLots = allLots.Lots;
            return View(obj);
        }
    }
}
