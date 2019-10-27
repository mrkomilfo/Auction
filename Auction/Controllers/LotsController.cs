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

        [HttpGet]
        public ViewResult ActualLots()
        {
            LotsListViewModel obj = new LotsListViewModel();
            obj.allLots = allLots.ActualLots;
            return View("LotsList", obj);
        }

        [HttpGet]
        public ViewResult EndedLots()
        {
            LotsListViewModel obj = new LotsListViewModel();
            obj.allLots = allLots.EndedLots;
            return View("LotsList", obj);
        }

        [HttpGet]
        public ViewResult LotDetail(int id)
        {
            LotDetailViewModel obj = new LotDetailViewModel
            {
                lot = allLots.getLot(id)
            };
            return View(obj);
        }
    }
}
