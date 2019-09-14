using Auction.Data.Interfaces;
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
            var lots = allLots.Lots;
            return View(lots);
        }
    }
}
