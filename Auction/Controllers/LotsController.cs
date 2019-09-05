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
        private readonly ICategories allCategories;

        public LotsController(ILots iLots, ICategories iCategories)
        {
            allLots = iLots;
            allCategories = iCategories;
        }

        public ViewResult LotsList()
        {
            var lots = allLots.Lots;
            return View(lots);
        }
    }
}
